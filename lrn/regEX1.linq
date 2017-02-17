<Query Kind="Statements">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string s = @"asd fgh asd";
Regex.Matches(s, @"^asd").Dump("1");

s = @"asd fgh zxc fgh asd Fghx zxc fgh";
Regex.Matches(s, @"(?<=asd\s)(?i)fgh(?-i)(?=x)").Dump("2");

string regex = @"^.*(?=,\r?$)";
s = @"hello, all,";
Regex.Matches(s, regex).Dump("3");
string s2 = @"hello, all";
Regex.Matches(s2, regex).Dump("3");

s = "http://127.0.0.1:16152/";
Regex.Match(s, @"http://(localhost|(\d{1,3}\.){3}\d{1,3}):*\d*/$").Success
.Dump("4");
s = "http://127.0.0.1:16152/";
Regex.Match(s, @"http://(localhost|(\d{1,3}\.){3}\d{1,3}):*\d*/$").Success
.Dump("4");

s = 
@"hello
all";
Regex.Match(s, @"(?m)^all").Success.Dump("5");

s = @"asd qwe dfr
awr xcw www
drefrwagest";
Regex.Matches(s, @"(?m)\b\w+w\w+\b").Dump("6");

Match m = Regex.Match ("206-465-1918", @"(\d{3})-(\d{3}-\d{4})");
m.Dump();
Console.WriteLine(m.Groups[1]);
Console.WriteLine(m.Groups[2]);

Regex.Replace("catapult the cat", "\\bcat\\B", "dog").Dump("replace");

string r = @"(?x)^(?=.* ( \d | \p{P} | \p{S} )).{6,}";
Console.WriteLine (Regex.IsMatch ("asda;sdsad8", r));

s = @"hello all all all";
Regex.Match(s, @"\b\w+\b(?=\sall)*\sall").Dump("7");

s = @"hello hello all all";
Regex.Matches(s, @"(\b\w+\b)(?=\s\1)").Dump("8");

s = @"hello hello all all";
Regex.Matches(s, @"(?'dupe'\b\w+\b)\W\k'dupe'").Dump("8");

s = @"hello all all to you and good bye";
Regex.Matches(s, @"(\b\w+\b)(?=\s\1)").Dump("9");

s = @"Thus I name you: ""The named group""";
Regex.Matches(s, @"(?<one>\w{3,})(?=.*\k<one>)").Dump("Name the group");

s = @"asdfmghjkl";
Regex.Matches(s, @"[^m]+").Dump("10");

Regex.Match("vasd bafd", @"\wa(?=s)").Dump("Positive lookahead");
Regex.Match("vasd bafd", @"\wa(?!s)").Dump("Negative lookahead");
Regex.Match("vasd bafd", @"(?<=s)d.*").Dump("Positive lookBehind");
Regex.Match("vasd bafd", @"(?<!s)d.*").Dump("Negative lookBehind");