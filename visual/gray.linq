<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Bitmap orig = new Bitmap("C:\\sp\\1.png");

byte[] gBuf = orig.getGrayBytes(),
	oBuf = orig.getBytes();

gBuf.Length.ToString("N0").Dump("Gray buffer length");

Bitmap gray = new Bitmap(orig.Width, orig.Height);

gray.fromGrayBytes(gBuf);

orig.Dump("Original");

gray.Dump("Gray");

for(int o = 0, g = 0; o < oBuf.Length; o += 4, g++)
{
	oBuf[o] = (byte)(oBuf[o] * 0.5 + gBuf[g] * 0.5);
	
	oBuf[o + 1] = (byte)(oBuf[o + 1] * 0.5 + gBuf[g] * 0.5);
	
	oBuf[o + 2] = (byte)(oBuf[o + 2] * 0.5 + gBuf[g] * 0.5);
}

Bitmap mix = new Bitmap(orig.Width, orig.Height);

mix.fromBytes(oBuf);

mix.Dump("Mix");