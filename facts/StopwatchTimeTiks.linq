<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var sw = new Stopwatch();

sw.Start();

var sw2 = new Stopwatch();

sw2.Start();

sw2.Stop();
string a = sw2.Elapsed.ToString();

sw.Stop();
sw.ElapsedTicks.Dump();