<Query Kind="Statements">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
  </Connection>
</Query>

{
IEnumerable<string> query = from f in System.Drawing.FontFamily.Families
select f.Name;
foreach (string name in query) Console.WriteLine (name);

IEnumerable<System.Drawing.FontFamily> query2 =
from f in System.Drawing.FontFamily.Families
where f.IsStyleAvailable (System.Drawing.FontStyle.Strikeout)
select f;
query2.Dump();
}

DirectoryInfo[] dirs = new DirectoryInfo (@"d:\Program Files (x86)").GetDirectories();
var query3 =
from d in dirs
where (d.Attributes & FileAttributes.System) == 0
select new
{
	DirectoryName = d.FullName,
	Created = d.CreationTime,
	Files = from f in d.GetFiles()
	where (f.Attributes & FileAttributes.Hidden) == 0
	select new { FileName = f.Name, f.Length, }
};
foreach (var dirFiles in query3)
{
	Console.WriteLine ("Directory: " + dirFiles.DirectoryName);
	foreach (var file in dirFiles.Files)
		Console.WriteLine (" " + file.FileName + " Len: " + file.Length);
}