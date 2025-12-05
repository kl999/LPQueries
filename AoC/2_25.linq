<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var input = raw.Split(',').Select(i => i.Split('-').Select(Int64.Parse).ToArray())
	//.Dump()
	;
	
	long result = 0;
	long result2 = 0;
	
	foreach(var pairs in input)
	{
		for(long i = pairs[0]; i <= pairs[1]; i++)
		{
			var str = i.ToString();
			var len = str.Length;
			
			for(int j = 1; j <= len / 2; j++)
			{
				if(len % j != 0) continue;
				
				var pattern = str.Substring(0, j);
				
				var found = true;
				for(int k = j; k < len; k += j)
				{
					var chunk = str.Substring(k, j);
					
					//chunk.Dump();
					
					if(pattern != chunk) { found = false; break; }
				}
				
				if (found)
				{
					result2 += i;
					break;
				}
			}
			
			if (str.Length % 2 == 0)
			{
				//str.Dump();
				
				var left = str.Substring(0, str.Length / 2);
				var right = str.Substring(str.Length / 2);
				
				//$"{left} = {right}".Dump();
				
				if(left == right) result += i;
			}
		}
	}
	
	result.Dump("1");
	result2.Dump("2");
}

string my1 = "121212-121212";

string rawt = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

string raw = @"132454-182049,42382932-42449104,685933-804865,5330496-5488118,21-41,289741-376488,220191-245907,49-70,6438484-6636872,2-20,6666660113-6666682086,173-267,59559721-59667224,307-390,2672163-2807721,658272-674230,485679-647207,429-552,72678302-72815786,881990-991937,73-111,416063-479542,596-934,32825-52204,97951700-98000873,18335-27985,70203-100692,8470-11844,3687495840-3687599608,4861-8174,67476003-67593626,2492-4717,1442-2129,102962-121710,628612213-628649371,1064602-1138912";
