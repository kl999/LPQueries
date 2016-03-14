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

var sw = new Stopwatch();

Bitmap ld = new Bitmap(@"c:\sp\1.png").Dump();

Bitmap bmp;

sw.Restart();

bmp = new Bitmap(ld, 100, 100);

sw.Stop();
sw.ElapsedTicks.Dump();