<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var e1 = new XElement ("test", "Hello"); e1.Add ("World");
var e2 = new XElement ("test", "Hello", "World");

var e = new XElement ("test", new XText ("Hello"), new XText ("World"));
Console.WriteLine (e.Value); // HelloWorld
Console.WriteLine (e.Nodes().Count()); // 2

e.ToString().Dump("asd");

var obj = XElement.Parse(e.ToString());

Console.WriteLine (obj.Nodes().Count()); // 1?

obj.ToString().Dump("asd");