<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

{
string overflow = "stackOverflow";
string[] stack = new string[20000000];
for(int i = 0; i < stack.Length; i++)
{
	stack[i] = overflow + i;
}

"In scope".Dump();
Console.ReadLine();
}

"Out of scope".Dump();
Console.ReadLine();