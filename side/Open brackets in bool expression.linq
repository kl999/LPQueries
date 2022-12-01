<Query Kind="Statements" />

foreach(var a in new[]{ 1M, 2M, 2.5M, 3M, 7M })
{
	$"A is: {a}".Dump();

	if(!(a > 2 && a < 3) == (a <= 2 || a >= 3)) "a".Dump();

	if(!(a < 2 && a > 3) == (a >= 2 || a <= 3)) "b".Dump();


	var one = !(a == 3 ^ a > 2);
	var two = !((a == 3 || a > 2) && !(a == 3 && a > 2));
	var three = (a != 3 && a <= 2) || (a == 3 && a > 2);
	if(one == two && one == three) "c".Dump();
}