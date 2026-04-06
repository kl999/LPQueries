<Query Kind="Statements">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

string tempPath = System.IO.Path.GetTempPath();
string tempfile = Path.Combine(tempPath, "test.txt");

File.WriteAllText(tempfile, "Asd!");

File.ReadAllText(tempfile).Dump();

File.Delete(tempfile);