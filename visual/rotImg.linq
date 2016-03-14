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
	rotateImage(new Bitmap(@"c:\sp\1.png"), 40).Dump();
	
	var bmp = new Bitmap(@"c:\sp\1.png");
	
	for(int i = 0; i < 360; i++)
	{
		bmp = rotateImage(bmp, -1);
	}
	
	bmp.Dump();
}

private Bitmap rotateImage(Bitmap b, float angle)
{
	//create a new empty bitmap to hold rotated image
	Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
	//make a graphics object from the empty bitmap
	Graphics g = Graphics.FromImage(returnBitmap);
	//move rotation point to center of image
	g.TranslateTransform((float)b.Width/2, (float)b.Height / 2);
	//rotate
	g.RotateTransform(angle);
	//move image back
	g.TranslateTransform(-(float)b.Width/2,-(float)b.Height / 2);
	//draw passed in image onto graphics object
	g.DrawImage(b, new Point(0, 0)); 
	return returnBitmap;
}