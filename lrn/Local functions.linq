<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

"So the local functions are this kind of beast:".Dump();

int Sum(int a, int b)
{
	return a + b;
}

$"You declare them like normal functions and simply use them (Sum(2, 3) = {Sum(2, 3)}) inside method body".Dump();
