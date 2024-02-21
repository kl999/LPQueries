<Query Kind="Statements" />

var a = new[] { 1, 2, 3 };

var b = new[] { 1, 2, 3 };

a.SequenceEqual(b).Dump();

a = new[] { 1, 2, 3 };

b = new[] { 1, 3, 2 };

a.SequenceEqual(b).Dump();

a = new[] { 1, 2, 3 };

b = new[] { 1, 2, 3, 4 };

a.SequenceEqual(b).Dump();
