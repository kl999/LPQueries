<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var client = new HttpClient(new HttpClientHandler
{
	UseProxy = true,
	Proxy = new WebProxy("10.70.8.18:3128", true){ UseDefaultCredentials = true }
		//WebRequest.GetSystemWebProxy()
});

var request = new HttpRequestMessage(
	HttpMethod.Get,
	@"https://81.88.148.173:8443/kaspi/paymentserver/servletresponse"
//	+ "?command=check&txn_id=" + new Random().Next(1000000) + "&account="
//	+ "101152072"
//	+ "&sum=200.00"
	);

HttpResponseMessage response = client.SendAsync(request).Result;
response.EnsureSuccessStatusCode();

var rez = response.Content.ReadAsStringAsync().Result;

Console.WriteLine(rez);