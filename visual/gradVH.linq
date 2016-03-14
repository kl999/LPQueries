<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Bitmap orig = new Bitmap(
		@"C:\sp\1.png"
		//@"C:\sp\grads\targ.png"
		//@"C:\sp\grads\car1.jpg"
		//@"c:\sp\grads\car2.jpg"
	);
	
	var origArr = orig.getGrayBytes();
	
	orig.fromGrayBytes(origArr);
	
	orig.Dump();
	
	int w = orig.Width,
		h = orig.Height;
	
	var gradx = new Bitmap(orig);
	
	Graphics.FromImage(gradx).Clear(Color.FromArgb(127, 127, 127));
	
	var gxarr = gradx.getGrayBytes();
	
	for(int x = 1; x < w - 1; x++)
	for(int y = 1; y < h - 1; y++)
	{
		double grad = getsGradX(origArr, w, x, y);
		
//		if(grad >= 0.1 || grad <= -0.1)
//		grad.Dump();
		
		if(grad > 0)
		{
			gxarr[x + w * y] = (byte)(127 + 127.0 * grad);
		}
		else
		{
			gxarr[x + w * y] = (byte)(127 + 127.0 * grad);
		}
	}
	
	gradx.fromGrayBytes(gxarr);
	
	gradx.Dump("Width");
	
	var grady = new Bitmap(orig);
	
	Graphics.FromImage(grady).Clear(Color.FromArgb(127, 127, 127));
	
	var gyarr = grady.getGrayBytes();
	
	for(int x = 1; x < w - 1; x++)
	for(int y = 1; y < h - 1; y++)
	{
		double grad = getsGradY(origArr, w, x, y);
		
//		if(grad >= 0.1 || grad <= -0.1)
//		grad.Dump();
		
		if(grad > 0)
		{
			gyarr[x + w * y] = (byte)(127 + 127.0 * grad);
		}
		else
		{
			gyarr[x + w * y] = (byte)(127 + 127.0 * grad);
		}
	}
	
	grady.fromGrayBytes(gyarr);
	
	grady.Dump("Heigth");
	
	var gradP = new Bitmap(orig);
	
	var gParr = grady.getGrayBytes();
	
	for(int x = 1; x < w - 1; x++)
	for(int y = 1; y < h - 1; y++)
	{
		int ax = Math.Abs(gxarr[x + w * y] - 127);
		int ay = Math.Abs(gyarr[x + w * y] - 127);
		
		if(ax > ay)
		{
			gParr[x + w * y] = gxarr[x + w * y];
		}
		else
		{
			gParr[x + w * y] = gyarr[x + w * y];
		}
	}
	
	gradP.fromGrayBytes(gParr);
	
	gradP.Dump("Plus");
	
	var rdarr = gradP.getBytes();
	
	double rcomp = 1, gcomp = 1, bcomp = 1;
	
	Color rezClr = Color.Gold;//Goldenrod;//Tan;//Beige;//DarkRed;
	
	rcomp = (double)rezClr.R / 255.0;
	gcomp = (double)rezClr.G / 255.0;
	bcomp = (double)rezClr.B / 255.0;
	
	for(int i = 0; i < rdarr.Length; i += 4)
	{
//		int ind = i / 4;
//		int y = ind / width;
//		int x = ind % width;
		
		rdarr[i + 0] = (byte)(rdarr[i + 0] * bcomp);
		rdarr[i + 1] = (byte)(rdarr[i + 1] * gcomp);
		rdarr[i + 2] = (byte)(rdarr[i + 2] * rcomp);
	}
	
	var rd = new Bitmap(orig);
	
	rd.fromBytes(rdarr);
	
	rd.Dump("Colored");
}

double getsGradX(byte[] bmp, int w, int x, int y)
{
	int one = -1 * bmp[x - 1 +  w * (y)];
	int two = 1 * bmp[x + 1 +  w * (y)];
	return (double)(one + two) / 255;
}

double getsGradY(byte[] bmp, int w, int x, int y)
{
	int one = -1 * bmp[x +  w * (y - 1)];
	int two = 1 * bmp[x +  w * (y + 1)];
	return (double)(one + two) / 255;
}

double getGradX(byte[] bmp, int w, int x, int y)
{
	double[,] Gxm = new double[3,3];
	Gxm[0, 0] = -1 * bmp[x - 1 +  w * (y - 1)];
	Gxm[1, 0] = -2 * bmp[x - 1 +  w * (y)];
	Gxm[2, 0] = -1 * bmp[x - 1 +  w * (y + 1)];
	Gxm[0, 2] = 1 * bmp[x + 1 +  w * (y - 1)];
	Gxm[1, 2] = 2 * bmp[x + 1 +  w * (y)];
	Gxm[2, 2] = 1 * bmp[x + 1 +  w * (y + 1)];
	return matrix(Gxm);
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
	
	double Gx = getGradX(bmp, w, x, y);
	
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