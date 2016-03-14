<Query Kind="Statements" />

int i = 1;

startLoop:

if (i <= 5)
{
	i++.Dump();
	goto startLoop;
}