<Query Kind="Statements">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var client = new HttpClient (new HttpClientHandler{});

var request = new HttpRequestMessage(
    HttpMethod.Get,
    "https://www.random.org/integers/?num=10000&min=0&max=99&col=5&base=10&format=plain&rnd=new"
);

HttpResponseMessage response = await client.SendAsync(request);

response.EnsureSuccessStatusCode();

var raw = await response.Content.ReadAsStringAsync();

var nums = raw.Replace("\r", "").Split('\n')
.SelectMany(i => Regex.Matches(i, @"\d+"))
.Select(i => i.Value)
.Select(Int32.Parse)
.ToArray();

nums.Dump();
