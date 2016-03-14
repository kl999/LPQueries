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

new int[10]
.Select((i, ind) => ind)
.Where((i, ind) => { ("1 " + ind).Dump(); return ind % 5 != 0; })
.Select((i, ind) => { ("2 " + ind).Dump(); return i; })
.Dump();