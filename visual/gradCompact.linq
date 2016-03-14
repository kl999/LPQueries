<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

#define showGradMap
//#define round
#define white
#define showAreas

void Main()
{
	Bitmap orig = new Bitmap(
		//@"C:\Users\Psamarce\Desktop\2.png"
		//@"C:\sp\grads\car2.jpg"
		@"C:\sp\grads\6.png"
		//@"C:\sp\1.jpg"
		);
	
	var tmp = orig.getGrayBytes();
	
	orig.fromGrayBytes(tmp);
	
	orig.Dump();
	
	int w = orig.Width,
		h = orig.Height;
	
	#if showGradMap
	Bitmap rez = new Bitmap(w * 3, h * 3);
	#endif
	
	Bitmap grChng = new Bitmap(w, h);
	
	Graphics.FromImage(grChng).Clear(
		//Color.White
		#if !white
		Color.DarkOliveGreen
		#else
		Color.PaleGoldenrod
		#endif
	);
	
	#if showGradMap
	Graphics g = Graphics.FromImage(rez);
	
	g.Clear(Color.PaleGoldenrod);
	#endif
	
	PointF[,] pts = new PointF[w - 2, h - 2];
	
	for(int x = 1; x < w - 1; x++)
		for(int y = 1; y < h - 1; y++)
		{
			var grad = getGrad(tmp, w, x, y);
				//sfgetGrad(orig, x, y);
			
			pts[x - 1, y - 1] = new PointF((float)grad[0], (float)grad[1]);
			
			int angle = (int)grad[0];
			
			double grLen =
				#if round
				(int)
				#endif
				(255.0 * ((double)grad[1] / 1200.0));//grad[1] > 0 ? 15 : 0;
			
			#if showGradMap
			if(grLen > 0)
			{
				Color tcl = Color.FromArgb((int)grLen, 0, 0);
				
				g.FillRectangle(new SolidBrush(tcl), (x * 3), (y * 3), 3, 3);
			}
			
			drawLine(angle, (x * 3) + 1, (y * 3) + 1, Color.Green, g);
			
			g.FillRectangle(Brushes.Black, (x * 3) + 1, (y * 3) + 1, 1, 1);
			#endif
			
			if(grLen > 0)
			{
				int proc = (int)(255.0 * ((double)grad[1] / 1200.0));
				
				#if !white
				grChng
				.SetPixel(
					x,
					y,
					Color.FromArgb(
						proc
						,0
						,0)
				);
				#else				
				grChng
				.SetPixel(
					x,
					y,
					Color.FromArgb(
						255 - proc
						,255 - proc
						,255 - proc)
				);
				#endif
			}
		}
		
	"\nRez\n".Dump();
	
	grChng.Dump("Gr ch");
	
	#if showGradMap
	rez.Dump();
	#endif
	
	#if showAreas
	int[,] areasMap = new int[w - 2, h - 2];
	int areaCt = 0;
	Bitmap areaBmp = new Bitmap(w, h);
	Graphics.FromImage(areaBmp).Clear(Color.SkyBlue);
	
	List<Point> areasSizes = new List<Point>();
	
	for(int x = 0; x < w - 2; x++)
		for(int y = 0; y < h - 2; y++)
		{
			if(areasMap[x, y] == 0)
			{
				areaCt++;
				int size =
					getNewArea(x, y, w - 2, h - 2, pts, areaCt, areasMap);
				
				areasSizes.Add(new Point(areaCt, size));
			}
		}
		
	var bigAreas = areasSizes.Where(i => i.Y > 50).Select(i => i.X).ToList();
	
	for(int x = 0; x < w - 2; x++)
		for(int y = 0; y < h - 2; y++)
		{
			//36 - reserve
			KnownColor clr = (KnownColor)((areasMap[x, y] % 49) + 35);
			
			areaBmp.SetPixel(x + 1, y + 1, Color.FromKnownColor(clr));
		}
		
	areaBmp.Dump("Areas");
	
	var bigAreaBmp = new Bitmap(areaBmp);
	for(int x = 0; x < w - 2; x++)
		for(int y = 0; y < h - 2; y++)
		{
			//36 - reserve
			KnownColor clr;
		
			if(bigAreas.Contains(areasMap[x, y]))
			{
				clr = (KnownColor)((areasMap[x, y] % 48) + 36);
			}
			else
				clr = (KnownColor)35;
			
			bigAreaBmp.SetPixel(x + 1, y + 1, Color.FromKnownColor(clr));
		}
		
	bigAreaBmp.Dump("Big areas");
	#endif
}

int getNewArea(int x, int y, int w, int h, PointF[,] pts, int areaCt, int[,] areasMap)
{
	int ct = 0;

	double minDif = 20;

	List<Point> iterPoints = new List<Point>();
	iterPoints.Add(new Point(x, y));
	
	for(; iterPoints.Count() > 0;)
	{
		List<Point> tempPts = new List<Point>();
	
		foreach(Point pt in iterPoints)
		{
			areasMap[pt.X, pt.Y] = areaCt;
			ct++;
			
			if(pt.X - 1 > 0
				&& Math.Abs(pts[pt.X - 1, pt.Y].Y - pts[pt.X, pt.Y].Y) < minDif
				&& areasMap[pt.X - 1, pt.Y] == 0
				)
			{
				tempPts.Add(new Point(pt.X - 1, pt.Y));
				areasMap[pt.X - 1, pt.Y] = -1;
			}
				
			if(pt.X + 1 < w
				&& Math.Abs(pts[pt.X + 1, pt.Y].Y - pts[pt.X, pt.Y].Y) < minDif
				&& areasMap[pt.X + 1, pt.Y] == 0
				)
			{
				tempPts.Add(new Point(pt.X + 1, pt.Y));
				areasMap[pt.X + 1, pt.Y] = -1;
			}
				
			if(pt.Y - 1 > 0
				&& Math.Abs(pts[pt.X, pt.Y - 1].Y - pts[pt.X, pt.Y].Y) < minDif
				&& areasMap[pt.X, pt.Y - 1] == 0
				)
			{
				tempPts.Add(new Point(pt.X, pt.Y - 1));
				areasMap[pt.X, pt.Y - 1] = -1;
			}
				
			if(pt.Y + 1 < h
				&& Math.Abs(pts[pt.X, pt.Y + 1].Y - pts[pt.X, pt.Y].Y) < minDif
				&& areasMap[pt.X, pt.Y + 1] == 0
				)
			{
				tempPts.Add(new Point(pt.X, pt.Y + 1));
				areasMap[pt.X, pt.Y + 1] = -1;
			}
		}
		
		iterPoints.Clear();
		
		iterPoints = tempPts;
	}
	
	return ct;
}

double[] sfgetGrad(Bitmap bmp, int x, int y)
{
	double[,] Gym = new double[3,3];
	Gym[0, 0] = -1 * bmp.GetPixel(x - 1, y - 1).R;
	Gym[0, 1] = -2 * bmp.GetPixel(x, y - 1).R;
	Gym[0, 2] = -1 * bmp.GetPixel(x + 1, y - 1).R;
	Gym[2, 0] = 1 * bmp.GetPixel(x - 1, y + 1).R;
	Gym[2, 1] = 2 * bmp.GetPixel(x, y + 1).R;
	Gym[2, 2] = 1 * bmp.GetPixel(x + 1, y + 1).R;
	double Gy = matrix(Gym);
	
	double[,] Gxm = new double[3,3];
	Gxm[0, 0] = -1 * bmp.GetPixel(x - 1, y - 1).R;
	Gxm[1, 0] = -2 * bmp.GetPixel(x - 1, y).R;
	Gxm[2, 0] = -1 * bmp.GetPixel(x - 1, y + 1).R;
	Gxm[0, 2] = 1 * bmp.GetPixel(x + 1, y - 1).R;
	Gxm[1, 2] = 2 * bmp.GetPixel(x + 1, y).R;
	Gxm[2, 2] = 1 * bmp.GetPixel(x + 1, y + 1).R;
	double Gx = matrix(Gxm);
	
	double len = Math.Sqrt(Gy * Gy + Gx * Gx);
	
	/*Gy = Gy != 0 ? Gy : 0.0001;
	Gx = Gx != 0 ? Gx : 0.0001;*/
	
	double angle = Math.Atan(Gy / Gx);
	
	double O = angle * 180 / Math.PI; if(O < 0) O = 360 + O;
	
	return new[]{ O, len };
}

double[] getGrad(byte[] bmp, int w, int x, int y)
{
	double[,] Gym = new double[3,3];
	Gym[0, 0] = -1 * bmp[x - 1 +  w * (y - 1)];
	Gym[0, 1] = -2 * bmp[x +  w * (y - 1)];
	Gym[0, 2] = -1 * bmp[x + 1 +  w * (y - 1)];
	Gym[2, 0] = 1 * bmp[x - 1 +  w * (y + 1)];
	Gym[2, 1] = 2 * bmp[x + w * (y + 1)];
	Gym[2, 2] = 1 * bmp[x + 1 +  w * (y + 1)];
	double Gy = matrix(Gym);
	
	double[,] Gxm = new double[3,3];
	Gxm[0, 0] = -1 * bmp[x - 1 +  w * (y - 1)];
	Gxm[1, 0] = -2 * bmp[x - 1 +  w * (y)];
	Gxm[2, 0] = -1 * bmp[x - 1 +  w * (y + 1)];
	Gxm[0, 2] = 1 * bmp[x + 1 +  w * (y - 1)];
	Gxm[1, 2] = 2 * bmp[x + 1 +  w * (y)];
	Gxm[2, 2] = 1 * bmp[x + 1 +  w * (y + 1)];
	double Gx = matrix(Gxm);
	
	double len = Math.Sqrt(Gy * Gy + Gx * Gx);
	
	/*Gy = Gy != 0 ? Gy : 0.0001;
	Gx = Gx != 0 ? Gx : 0.0001;*/
	
	double angle = Math.Atan(Gy / Gx);
	
	double O = angle * 180 / Math.PI; if(O < 0) O = 360 + O;
	
	return new[]{ O, len };
}

/*double matrix(double[,] mat)
{	
	return mat[0,0] * mat[1,1] * mat[2,2]
		+ mat[0,2] * mat[1,0] * mat[2,1]
		+ mat[2,0] * mat[0,1] * mat[1,2]
		- mat[0,2] * mat[1,1] * mat[2,0]
		- mat[2,2] * mat[1,0] * mat[0,1]
		- mat[0,0] * mat[2,1] * mat[1,2];
}*/

double matrix(double[,] mat)
{	
	return mat[0,0] + mat[1,1] + mat[2,2]
		+ mat[0,2] + mat[1,0] + mat[2,1]
		+ mat[2,0] + mat[0,1] + mat[1,2];
}

private void drawLine(int angle, int x, int y, Color clr, Graphics g)
{
	int lineY = y;
	int lineX = x;
	
	if(angle < 45)
	{
		//lineY++;
		lineX++;
	}
	else if(angle < 90)
	{
		lineY++;
		lineX++;
	}
	else if(angle < 135)
	{
		lineY++;
		//lineX++;
	}
	else if(angle < 180)
	{
		lineY++;
		lineX--;
	}
	else if(angle < 225)
	{
		//lineY++;
		lineX--;
	}
	else if(angle < 270)
	{
		lineY--;
		lineX--;
	}
	else if(angle < 315)
	{
		lineY--;
		//lineX--;
	}
	else if(angle < 360)
	{
		lineY--;
		lineX++;
	}
	
	Pen pen = new Pen(clr, 1);
	
	g.DrawLine(pen, x, y, lineX, lineY);
}