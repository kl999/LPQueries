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

var str =
@"293;200;0
261;200;0
174;200;150
349;200;100
349;200;150
293;200;0
261;200;0
174;200;150
349;200;100
349;200;100
293;200;0
261;200;0
174;200;150
349;200;150
220;200;150
349;200;100
349;200;200
293;200;0
261;200;0
130;150;200
349;150;200
349;150;200
293;200;0
261;200;0
130;200;200
349;150;200
349;150;200
293;200;0
261;200;150
146;200;150
349;200;200
164;200;150
349;200;200
174;200;150
349;200;200
349;200;200";

foreach(var o in
str.Split('\n')
.Select(i => i.Split(';').Select(o => Int32.Parse(o)).ToArray())
)
{
	//o.Dump();
	
	Console.Beep(
		o[0] * 4,
		o[1]);
	Task.Delay(o[2]).Wait();
}











//http://yvision.kz/post/350215