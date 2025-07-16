<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

DateTime.Parse("01.01.1970").AddSeconds(1_735_463_001L).Dump("From");

(DateTime.Now - DateTime.Parse("01.01.1970")).TotalSeconds.ToString("#,0").Dump("To");
