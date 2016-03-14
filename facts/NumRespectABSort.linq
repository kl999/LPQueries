<Query Kind="Statements">
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

var arr = new[]
{
	"1",
	"2",
	"3",
	"10",
	"11",
	"20"
};

arr
.OrderBy(i => i)
.Dump();

arr = new[]
{
	"01",
	"02",
	"03",
	"10",
	"11",
	"20"
};

arr
.OrderBy(i => i)
.Dump();