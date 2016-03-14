<Query Kind="Statements" />

System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

sw.Start();

byte pow = 1 << 7;

sw.Stop();
Console.WriteLine(sw.Elapsed.TotalMilliseconds); // output: 0.0012 (may differ)

sw.Reset();

sw.Start();

byte mathPow = (byte)Math.Pow(2, 7);

sw.Stop();
Console.WriteLine(sw.Elapsed.TotalMilliseconds); // output: 0.0057 (may differ)