<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var bmp = new Bitmap(@"c:\sp\1.png");

var rez = new Bitmap(bmp);

bmp.Dump();

for(int x = 0; x < bmp.Width; x++)
for(int y = 0; y < bmp.Height; y++)
{
    var clr = bmp.GetPixel(x, y);
    
    int r = clr.R,
        g = clr.G,
        b = clr.B;
    
    double pr = 255.0 / (double)Math.Max(Math.Max(r, g), b);
    
    if(pr > 5) pr = 0;
    
    r = (int)(r * pr); r = r < 0 ? 0 : r;
    g = (int)(g * pr); g = g < 0 ? 0 : g;
    b = (int)(b * pr); b = b < 0 ? 0 : b;
    
//    clr.Dump();
//    
//    (r + " " + g + " " + b).Dump();
    
    var clr2 = Color.FromArgb(r, g, b);
    
    rez.SetPixel(x, y, clr2);
}

rez.Dump();

bmp.Dispose();