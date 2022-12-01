<Query Kind="Statements">
  <Namespace>System.Dynamic</Namespace>
</Query>

dynamic o = new ExpandoObject();

((IDictionary<String, Object>)o).TryAdd("Hi", "Hello");

(o as object).Dump();

((IDictionary<String, Object>)o).Remove("Hi");

o.Bye = "Goodbye";

(o as object).Dump();

((IDictionary<String, Object>)o).First().Dump();