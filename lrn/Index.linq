<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <RuntimeVersion>9.0</RuntimeVersion>
</Query>

int[] a = [7, 8, 9];

foreach(var (ind, val) in a.Index())
	(ind * val).Dump();
