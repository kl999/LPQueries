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

void Main()
{
	Bitmap orig = new Bitmap(@"C:\sp\g1.png");
	
	var tmp = orig.getGrayBytes();
	
	orig.fromGrayBytes(tmp);
	
	orig.Dump();
	
	int w = orig.Width,
		h = orig.Height;
	
	#if showGradMap
	Bitmap rez = new Bitmap(w * 30, h * 30);
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
	
	g.Clear(Color.White);
	#endif
	
	for(int x = 1; x < w - 1; x++)
		for(int y = 1; y < h - 1; y++)
		{
			var grad = getGrad(orig, x, y);
			
			int angle = (int)grad[0];
			
			double grLen =
				#if round
				(int)
				#endif
				(15.0 * ((double)grad[1] / 1200.0));//grad[1] > 0 ? 15 : 0;
			
			#if showGradMap
			g.FillEllipse(grLen > 0 ? Brushes.Crimson : Brushes.Black, (x * 30) + 12, (y * 30) + 12, 6, 6);
			
			drawLine(angle, (int)grLen, (x * 30) + 15, (y * 30) + 15, Color.Black, g);
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
}

double[] getGrad(Bitmap bmp, int x, int y)
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
	
	double O = angle * 180 / Math.PI; if(O < 0) O = 360 + O;;
	
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

private void drawLine(int angle, int lineLength, int x, int y, Color clr, Graphics g)
{
	int lineY;
	int lineX;
	
	double lineRad = angle * (Math.PI / 180);
	
	double lineSin = Math.Sin(lineRad);
	
	lineY = (int)(lineSin * lineLength);
	
	lineX = Convert.ToInt32(Math.Sqrt(lineLength * lineLength - lineY * lineY));
	
	if (angle > 90 && angle < 270)
		lineX *= -1;
	
	Pen pen = new Pen(clr, 2);
	
	g.DrawLine(pen, x, y, lineX + x, lineY + y);
}