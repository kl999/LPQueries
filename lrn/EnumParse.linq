<Query Kind="Statements" />

Enum.Parse(typeof(MyEnum), "Hello").Dump();

Enum.TryParse("Asd", true, out MyEnum rez).Dump();
rez.Dump();

enum MyEnum
{
	Hello = 1,
	Hi = 2,
	World = 4,
}