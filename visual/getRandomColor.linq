<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Bitmap bmp = new Bitmap(500, 500);

Random rand = new Random();

Color clr = Color.FromKnownColor((KnownColor)(rand.Next(100) + 1));

Graphics.FromImage(bmp).Clear(clr);

bmp.Dump();