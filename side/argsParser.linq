<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var args = new[]{
	"a",
	"b",
	"-c",
	"-d",
	"2",
	"e"
	};
	
	var schema = new Dictionary<string, string>{
	["c"] = "prm:c",
	["d"] = "prm:d:val",
	["prm1"] = "ord",
	["prm2"] = "ord",
	["prmLast"] = "-ord"
	};
	
	ArgsParser.Parse(args, schema).Dump();
	
	ArgsParser.Parse(args, new(){
	["a"] = "ord"
	}).Dump();
	
	ArgsParser.Parse(args, new(){
	["z"] = "-ord"
	}).Dump();
	
	ArgsParser.Parse(args, new(){
	["d"] = "prm:d"
	}).Dump();
	
	ArgsParser.Parse(args, new(){
	["z"] = "-ord",
	["a"] = "ord"
	}).Dump();
	
	ArgsParser.Parse(args, new(){
	["z"] = "asd",
	["a"] = "ord"
	}).Dump();
}

static class ArgsParser {
	public static Dictionary<string, string> Parse(string[] args, Dictionary<string, string> schema) {
		var result = new Dictionary<string, string>();
		var q = args.ToList();
		foreach(var prm in schema) {
			if(Regex.IsMatch(prm.Value, @"^ord$")) result[prm.Key]=RemoveAndReturnOrEmpty(q, 0);
			else if(Regex.IsMatch(prm.Value, @"^-ord$")) result[prm.Key]=RemoveAndReturnOrEmpty(q, q.Count-1);
			else if(Regex.IsMatch(prm.Value, @"^prm:\w+")) {
				var t=""; var splits = prm.Value.Split(':');
				var ind = q.Select((i, ind2) => Tuple.Create(i, ind2)).FirstOrDefault(i => i.Item1 == "-" + splits[1])?.Item2 ?? -1;
				if(ind < 0) continue;
				if(splits.Length == 3)t=RemoveAndReturnOrEmpty(q, ind + 1);
				result[prm.Key] = t;
				q.RemoveAt(ind); }
			else throw new FormatException($"'{prm}' is unknown or bad format!"); }
		return result; }
	private static string RemoveAndReturnOrEmpty(List<string> q, int ind){var t="";if(q.Count > ind) {t=q[ind];q.RemoveAt(ind);} return t; } }
