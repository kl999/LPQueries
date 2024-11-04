<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var a = 3;
var b = 1;

convertToBin(a).Dump();
convertToBin(b).Dump();

b = b ^ a;
"b = b ^ a;".Dump();
convertToBin(a).Dump();
convertToBin(b).Dump();

a = b ^ a;
"a = b ^ a;".Dump();
convertToBin(a).Dump();
convertToBin(b).Dump();

b = b ^ a;
"b = b ^ a;".Dump();
convertToBin(a).Dump();
convertToBin(b).Dump();

(a, b).Dump();

string convertToBin(int value)
{
	return Convert.ToString(value, 2).PadLeft(32, '0');
}
