<Query Kind="Statements" />

Array a = Array.CreateInstance(typeof(int), new[] { 10, 7, 30, 1 });
a.Rank.Dump("Rank");
a.SetValue(3, new[] { 1, 1, 0, 0 });
(a.GetValue(new[] { 1, 1, 0, 0 }).ToString()).Dump("Access");