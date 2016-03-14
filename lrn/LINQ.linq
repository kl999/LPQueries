<Query Kind="Statements" />

List<string> str = (
  "Some say the world will end in fire "
+ "Some say in ice "
+ "From what I’ve tasted of desire "
+ "I stand with those who favor fire "
+ "But if it was to perish twice "
+ "I think I know enough of hate "
+ "To say that for destruction ice is also great "
+ "And will suffice"
).Split().ToList().Dump();
				
"-----------------------------".Dump();

str.Last().Dump("Last");

"-----------------------------".Dump();

str.Where(i => i.ToUpper()[0] == 'F').Dump("Words that starts with 'f'");

"-----------------------------".Dump();

str.Where(i => i.Length == str.Max(j => j.Length)).Dump("Longest words");

"-----------------------------".Dump();

(from obj in str.Select((i,j)=>new{name = i,i = j})
select obj).OrderBy(i => i.name).Dump("i - position of word, words are sorted alphabeticaly");

"-----------------------------".Dump();
str//.Select(i => i.Length).Dump()
.Sum(i => i.Length).Dump("Agregate");

str.Where(i => i[0].ToString() == i[0].ToString().ToUpper() ).Dump("CaPiTaL WoRdS");

new string(("Some say the world will end in fire "
+ "Some say in ice "
+ "From what I`ve tasted of desire "
+ "I stand with those who favor fire "
+ "But if it was to parish twice "
+ "I think I know enough of hate "
+ "To say that for distraction ice is also great "
+ "And will suffice").ToUpper().Replace(" ", "")
.Distinct()
.OrderBy(i => i)
.ToArray()).Dump();