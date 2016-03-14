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

var bmp = new Bitmap(100, 100);

var g = Graphics.FromImage(bmp);

g.Clear(Color.Green);

for(int i = 0; i < 10; i++)
for(int j = 0; j < 10; j++)
{
	Brush b = Brushes.Black;
	
	if(i % 2 == 0)
	{
		if(j % 2 == 0)
			b = Brushes.White;
	}
	else
	if(j % 2 != 0)
		b = Brushes.White;
	
	g.FillRectangle(b, i * 10, j * 10, 10, 10);
}

bmp.Dump();