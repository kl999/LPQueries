<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//35 - 84
((int)KnownColor.Red).Dump("To int");

for(int i = 1; i < 175; i++)
{
	(i + ": " + (KnownColor)i).Dump();
	
	var bmp = new Bitmap(10, 10);
	Graphics.FromImage(bmp).Clear(Color.FromKnownColor((KnownColor)i));
	bmp.Dump();
}

var clr = (KnownColor)1;

for(int i = 1; i < 174; i++)
{	
	var bmp = new Bitmap(50, 10);
	Graphics.FromImage(bmp).Clear(Color.FromKnownColor(clr++));
	bmp.Dump();
}

"^              ^\n----------------\nv              V".Dump();


for(int i = 1; i < 60; i++)
{	

	KnownColor clr2 = (KnownColor)((i % 48) + 36);
	var bmp = new Bitmap(50, 10);
	Graphics.FromImage(bmp).Clear(Color.FromKnownColor(clr2));
	bmp.Dump(i.ToString());
}