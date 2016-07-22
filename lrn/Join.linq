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

var arr1 = new[] { "ab1", "zx3" };

var arr2 = new[] { "a", "zxc" };

var rez = arr1.Join(
	arr2,
	one => Int32.Parse(one[2].ToString()),
	two => two.Length,
	(one, two) => one + " " + two
);

arr1.Dump();
arr2.Dump();
rez.Dump();

(from
    a1 in arr1
join
    a2 in arr2 on Int32.Parse(a1[2].ToString()) equals a2.Length
select
    a1 + " " + a2).Dump("SQLLike");