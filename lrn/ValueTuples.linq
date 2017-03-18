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

var a = (1, "Hi");
a.Dump();

var b = (bt: 15, name: "asd");
b.name.Dump();

(byte bt, string name) c = (bt: 15, name: "asd");
/*Error! (byte bt, string name) c = */(bt: 256, name: "asd").Dump();
$"c.bt = {c.bt}\n".Dump();

(byte bt, string) d = (18, "Unnamed");
$@"d.bt = {d.bt}
d.Item2 = {d.Item2}
".Dump();

(byte bt, string, int z) d2 = (18, "Unnamed", 8);
$@"d2.bt = {d2.bt}
d2.Item2 = {d2.Item2}
d2.z = {d2.z}
".Dump();

(int, byte) e = (a:15, b:6);
/*Error! e.b.Dump();*/
$"e.Item2 = {e.Item2}\n".Dump();

(int f, int g) = (8, 7);
$@"int f = {f}
int g = {g}
".Dump();