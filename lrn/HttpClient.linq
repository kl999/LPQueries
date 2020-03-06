<Query Kind="Statements">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var client = new HttpClient (new HttpClientHandler
{
    UseProxy = true, 
    //UseDefaultCredentials = true,
    Proxy = new WebProxy
    (
        "http://proxy-all.hq.bc:8080",
        false,
        new string[]{},
        new NetworkCredential(@"HQ\samartsev_26224", "Nuzoznp14")
    ),
});


var request = new HttpRequestMessage(
    HttpMethod.Get,
    "https://en.wikipedia.org/wiki/Main_Page"
);

HttpResponseMessage response = await client.SendAsync(request);

response.EnsureSuccessStatusCode();

new[]{ await response.Content.ReadAsStringAsync() }.Dump("GET");

request = new HttpRequestMessage(
    HttpMethod.Post,
    "https://en.wikipedia.org/wiki/Main_Page"
);

request.Headers.Add("Content", "Stuff");

request.Content = new StringContent("<a>Hello!</a>", Encoding.UTF8, "application/xml");

response = await client.SendAsync(request);

response.EnsureSuccessStatusCode();

new[]{ await response.Content.ReadAsStringAsync() }.Dump("POST");