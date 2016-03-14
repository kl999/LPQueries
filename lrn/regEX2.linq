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

var str = @"HelloWorld!";
var regex = @"(?i)(?<=hello)\B";

Regex.Matches(str, regex).Dump();

Regex.Replace(str, regex, " ").Dump();

Regex.Split(str, @"(?=o)|(?<=o)(?=.o)").Dump();