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

var arr = new[]{ 2, 4, 6, };
var wrongArr = new[]{ 2, 4, 6, 7 };

arr.All(i => i % 2 == 0).Dump();
wrongArr.All(i => i % 2 == 0).Dump();