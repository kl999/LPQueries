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

int a = Convert.ToInt32("1001", 2).Dump("a");
Convert.ToString(a, 2).Dump("a in binary");

Convert.ToString(18 >> 1, 2).Dump("10010 >> 1");

Convert.ToString(5 << 1, 2).Dump($"101 << 1 = {5 << 1}");

Convert.ToString(a = 21 & 12, 2).Dump($"10101 & 1100 = {a}");

Convert.ToString(a = 9 | 4, 2).Dump($"1001 | 100 = {a}");

Convert.ToString(a = 9 ^ 5, 2).Dump($"1001 ^ 101 = {a}");