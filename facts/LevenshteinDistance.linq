<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string w1 = "алсеко";
string w2 = "насекомые";

/*string[] inp = Console.ReadLine().Split(' ');

w1 = inp[0];
w2 = inp[1];*/

w1 = " " + w1;
w2 = " " + w2;

int w1l = w1.Length;
int w2l = w2.Length;

var sw = new Stopwatch();
sw.Start();

int del = 1, ins = 1, rep = 1;
int[][] a = new int[w1l][];

a[0] = new int[w2l];
a[0][0] = 0;

for(int i = 1; i < w2l; i++)
{
	a[0][i] = a[0][i - 1] + ins;
}

Func<int, int, int, int> min3 = (n1, n2, n3) =>
{
	int rez = n1;
	
	if(n2 < rez) rez = n2;
	
	if(n3 < rez) rez = n3;
	
	return rez;
};

for(int i = 1; i < w1l; i++)
{
	a[i] = new int[w2l];
	a[i][0] = a[i - 1][0] + del;
	
	for(int j = 1; j < w2l; j++)
	{
		int td = a[i - 1][j] + del;
		int ti = a[i][j - 1] + ins;
		int tr = 0;
		
		if(w1[i] == w2[j])
			{tr = a[i - 1][j - 1];}
		else
			{tr = a[i - 1][j - 1] + rep;}
			
		a[i][j] = min3(td, ti, tr);
	}
}

sw.Stop();

a[w1l - 1][w2l - 1].Dump();

("\n" + sw.Elapsed.TotalMilliseconds + " ms\n").Dump();

("*" + w2).Dump();

for(int i = 0; i < w1l; i++)
{
	string tstr = w1[i].ToString();
	
	foreach(int num in a[i])
	{
		tstr += num;
	}
	tstr.Dump();
}

//a.Dump();

"".Dump();

List<string> dir = new List<string>();

for(int i = w1l - 1, j = w2l - 1; !(i == 0 && j == 0);)
{
	int dc = -1,
		ic = -1,
		rc = -1;
	
	("i = " + i + " j = " + j).Dump();
	
	if(i > 0)
	dc = a[i - 1][j] + del;
	
	if(j > 0)
	ic = a[i][j - 1] + ins;
	
	if(i > 0 && j > 0)
	rc = a[i - 1][j - 1] + rep;
	
	("dc = " + dc + " ic = " + ic + " rc = " + rc).Dump();
	
	int min = Math.Max(dc, ic);
	
	if(dc >= 0 && dc < min)
		min = dc;
	if(ic >= 0 && ic < min)
		min = ic;
	if(rc >= 0 && rc < min)
		min = rc;
	
	if(rc == min)
	{
		if(w1[i] != w2[j])		
			dir.Add("r");
		else
			dir.Add("_");
			
		"<r>".Dump();
		
		i--;
		j--;
	}
	else if(dc == min)
	{
		dir.Add("d");
		
		"<d>".Dump();
		
		i--;
	}
	else if(ic  == min)
	{
		dir.Add("i");
		
		"<i>".Dump();
		
		j--;
	}
	
	//i=0;j=0;
}


string tst = w1;

dir.Reverse();

("\ndir---------\n" + tst + "\n===\n").Dump();

var w1charr = w1.ToArray();
var w2charr = w2.ToArray();

string ts = "\n";
for(int i = 1; i < w1.Length; i++)
	ts += " " + w1[i];
ts.Dump();

ts = "\n";
for(int i = 0; i < dir.Count; i++)
	ts += " " + dir[i];
ts.Dump();

ts = "\n";
for(int i = 1; i < w2.Length; i++)
	ts += " " + w2[i];
ts.Dump();

"\n".Dump();
int ind = 0;
foreach(string str in dir)
{
	ind++;
	
	("<" + str + ">").Dump();

	if(str == "d")
	{
		tst = tst.Remove(ind, 1);
		
		ind--;
	}
	
	if(str == "i")
	{
		var tmp = tst.ToList();
		
		tmp.Insert(ind, w2[ind]);
		
		tst = new string(tmp.ToArray());
	}
	
	if(str == "r")
	{
		var tmp = tst.ToList();
		
		tmp[ind] = w2[ind];
		
		tst = new string(tmp.ToArray());
	}
	
	("|" + tst.Substring(1) + "|").Dump();
}