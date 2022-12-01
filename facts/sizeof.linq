<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

sizeof(Boolean).Dump("Size of bool");

sizeof(byte).Dump("Size of byte");

sizeof(Int16).Dump("Size of int16");

sizeof(int).Dump("Size of int");

sizeof(long).Dump("Size of long");

sizeof(float).Dump("Size of float");

sizeof(double).Dump("Size of double");

sizeof(decimal).Dump("Size of decimal");

"Ints max values:".Dump();

byte.MaxValue.Dump(sizeof(byte).ToString());
short.MaxValue.Dump(sizeof(short).ToString());
int.MaxValue.Dump(sizeof(int).ToString());
long.MaxValue.Dump(sizeof(long).ToString());