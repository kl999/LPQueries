<Query Kind="Statements" />

Func<string, int> a = s => s.Length;

Func<string, int, int> b = (s, i) => { int t = s.Length; t += i; return t; };

a("Hello").Dump();

b("Hello", 1).Dump();