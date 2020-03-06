<Query Kind="Statements">
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Guid g;
for(int i = 0; i < 1; i++)
{
    g = Guid.NewGuid();
    g.Dump();
    g.ToString().Length.Dump();
}
