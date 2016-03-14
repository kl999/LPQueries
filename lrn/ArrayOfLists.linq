<Query Kind="Statements" />

List<int>[] arLst = new List<int>[10];
arLst[0] = new List<int>();
for(int i = 0; i < 10000; i++)
{
arLst[0].Add(i);
arLst[0].Last().Dump();
}
arLst.Dump();
arLst[0][1100].Dump();