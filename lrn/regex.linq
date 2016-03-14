<Query Kind="Statements">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string s1 = "Не время для драконов 00:00:00";

Regex reg = new Regex(@"[0-9]+:[0-9]+:[0-9]+", RegexOptions.IgnoreCase);

MatchCollection mc = reg.Matches(s1);

foreach (Match mat in mc)
{
	Console.WriteLine(mat.ToString());
}

Console.WriteLine(mc.Count);