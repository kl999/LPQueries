<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Bitmap bmp = new Bitmap("C:\\sp\\1pxl.bmp");
	
	var str = new MemoryStream();
//	bmp.Save(str, ImageFormat.Png);
//	str.GetBuffer().Dump();
//	bmp = new Bitmap(str);
	
	bmp.Dump("1 pixel");
	
	var sw = new System.Diagnostics.Stopwatch();
	sw.Start();
	byte[] buf = packBmp(bmp);
	sw.Stop();
	sw.Dump("Memory stream");
	sw.Reset();
	
	buf.Dump();
	
	sw.Start();
	buf = ImageToByte(bmp);
	sw.Stop();
	sw.Dump("Image Converter");
	sw.Reset();
	
	buf.Dump();
	
	sw.Start();
	buf = lockBits(bmp);
	sw.Stop();
	sw.Dump("Lock bits");
	sw.Reset();
	
	buf.Dump();
	
	bmp.GetPixel(0,0).Dump();
	
	buf[2] = 0;
	buf[0] = 255;
	unlockBits(bmp, buf);
	bmp.Dump("1 pixel");
	bmp.GetPixel(0,0).Dump();
	
	//System.IO.File.ReadAllBytes( "C:\\sp\\1pxl.png" ).Dump();
}

byte[] packBmp(Bitmap bmp)
{
	MemoryStream str = new MemoryStream();
	
	bmp.Save(str, ImageFormat.Bmp);
	
	return str.GetBuffer();
}

byte[] ImageToByte(Image img)
{
    ImageConverter converter = new ImageConverter();
    return (byte[])converter.ConvertTo(img, typeof(byte[]));
}

byte[] lockBits(Bitmap bmp)
{
	Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
	System.Drawing.Imaging.BitmapData bmpData =
		bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
		PixelFormat.Format32bppArgb/*PixelFormat.Format24bppRgb bmp.PixelFormat*/);
		
	IntPtr ptr = bmpData.Scan0;
	
	int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
	byte[] rgbValues = new byte[bytes];
	
	System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
	
	bmp.UnlockBits(bmpData);
	
	return rgbValues;
}

void unlockBits(Bitmap bmp, byte[] buf)
{
	Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
	
	System.Drawing.Imaging.BitmapData bmpData =
		bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
		PixelFormat.Format32bppArgb);
		
	IntPtr ptr = bmpData.Scan0;
	
	int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
	
	System.Runtime.InteropServices.Marshal.Copy(buf, 0, ptr, bytes);
	
	bmp.UnlockBits(bmpData);
}