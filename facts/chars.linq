<Query Kind="Statements">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

for(int i = 33; i < 170; i++)
{
	(i + ": '" + (char)i + "'").Dump();
}
((char)65).Dump();
((char)122).Dump();