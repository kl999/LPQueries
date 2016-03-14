<Query Kind="Statements">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

HttpListener listener = new HttpListener();

listener.Prefixes.Add("http://127.0.0.1:80/");

listener.Start();

while (true)
	try
	{
		var context = await listener.GetContextAsync();
		
		context.Dump();
	}
	catch (HttpListenerException) { break; }
	catch (InvalidOperationException) { break; }