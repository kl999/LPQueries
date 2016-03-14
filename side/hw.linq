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

var str = "Hello world";

String.Join(
	" ",
	Regex.Matches(str, @"[\w]{2}(\w)\k<1>?(?=(?:\w|\W))")
		.Cast<Match>()
		.Select(i => i.Value))
.Dump();