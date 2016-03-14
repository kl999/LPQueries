<Query Kind="Program">
  <Connection>
    <ID>937f840d-1199-41e6-931a-5d5dc0424131</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>NORTHWND</Database>
  </Connection>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	for(int i = 0; i < 100; i++)
	{
		"HI!".Dump();
		Thread.Sleep(100);
	}
}