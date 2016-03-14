<Query Kind="Statements">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
  </Connection>
</Query>

Console.WriteLine("Enter number 0 - 255");
string str = Console.ReadLine();
//Console.Read().Dump();
str = Convert.ToString(Convert.ToInt16(str), 2);
str.Dump();
"".Dump();
//bool[] outBuf = str.Select(n => Convert.ToBoolean(Convert.ToInt16(n.ToString()))).ToArray();
bool[] outBuf = str.Select(n => n == '0' ? false : true ).ToArray();
outBuf.Dump();