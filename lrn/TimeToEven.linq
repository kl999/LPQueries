<Query Kind="Statements" />

DateTime cur = DateTime.Now;
int sec = cur.Second;
int millisecond = cur.Millisecond;
cur = cur.AddMinutes(1);
cur = cur.AddSeconds(-sec);
cur = cur.AddMilliseconds(-millisecond);
cur.Dump();