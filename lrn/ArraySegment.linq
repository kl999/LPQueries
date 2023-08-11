<Query Kind="Statements" />

var a = new []{ 1, 2, 3, 4, 5, 6, 7, };

var seg = new ArraySegment<int>(a, 1, 2);

for(int i = 0; i < seg.Count; i++)
{
	seg[i].Dump();
}

seg.Offset.Dump();

seg.Slice(1).Dump();
