<Query Kind="Statements" />

var from = File.ReadAllLines(@"c:\sp\from.csv").Where(i => !String.IsNullOrWhiteSpace(i));
var to = File.ReadAllLines(@"c:\sp\to.csv").Where(i => !String.IsNullOrWhiteSpace(i)).Select(i => (str: i, found: false)).ToArray();

var fromDiff = new List<string>();

foreach(var fr in from)
{
	var found = false;
	
	for(int tr = 0; tr < to.Length; tr++)
	{
		if(to[tr].found) continue;
		
		if(fr == to[tr].str)
		{
			to[tr] = (str: to[tr].str, found: true);
			found = true;
		}
	}
	
	if(!found) fromDiff.Add(fr);
}

fromDiff.Dump("From difference");

to.Where(i => !i.found).Select(i => i.str).Dump("To difference");
