<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	ListenAsync(); // Start server
	
	WebClient wc = new WebClient(); // Make a client request.
	
	/*Console.WriteLine (wc.DownloadString
		("http://localhost:51111/MyApp/1.txt"));*/
}
async static void ListenAsync()
{
	HttpListener listener = new HttpListener();
	
	listener.Prefixes.Add ("http://localhost:51111/MyApp/"); // Listen on
	
	listener.Start(); // port 51111.
	
	// Await a client request:
	HttpListenerContext context = await listener.GetContextAsync();
	
	// Respond to the request:
	string msg = "You asked for: " + context.Request.RawUrl;
	
	context.Response.ContentLength64 = Encoding.UTF8.GetByteCount (msg);
	
	context.Response.StatusCode = (int) HttpStatusCode.OK;
	
	using (Stream s = context.Response.OutputStream)
	using (StreamWriter writer = new StreamWriter (s))
		await writer.WriteAsync (msg);
	
	listener.Stop();
}