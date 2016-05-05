<Query Kind="Statements">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Regex.Replace("asd{123}eqeqw", @"(\{|})", @"\$1").Dump("ByOrder");
Regex.Replace("asd{123}eqeqw", @"(?<curly>\{|})", @"\${curly}").Dump("ByName");
Regex.Replace("140{cur}", @"\{cur}", @"$$").Dump("Literal $");
Regex.Replace("asd{123}eqeqw", @"{|}", @"\$&").Dump("EntireMatch");
Regex.Replace("12z34", @"z", @"{$`$'}").Dump(@"StringBefore\AfterMatch");
string ptrn = @"(?<=Name\:\s)(\w+)\s?(\w+)?", repl = @"($+)";
Util.VerticalRun(
Regex.Replace("Name: Evil Nobz", ptrn, repl),
Regex.Replace("Name: Evil Gitz", ptrn, repl),
Regex.Replace("Name: Evil", ptrn, repl)).Dump(@"LastCapturedGroup");
Regex.Replace("recursive", @"r", @"$_").Dump(@"ReplaceWithWholeMatch");