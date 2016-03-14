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

object[] objarr = new object[3];

objarr[0] = new Stopwatch();

objarr[1] = "Hello!";

objarr[2] = new{ id = 3, str = "all!!!", ch = 'Z', ElapsedMilliseconds = "ASD" };

objarr.Dump();