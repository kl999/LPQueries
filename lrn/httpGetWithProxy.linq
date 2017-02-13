<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <system.net>
          <defaultProxy>
            <proxy bypassonlocal="False" usesystemdefault="True" proxyaddress="http://proxyall.hq.bc.:8080" />
          </defaultProxy>
        </system.net>
      </configuration>
    </Content>
  </AppConfig>
</Query>

//System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

var client = new HttpClient (new HttpClientHandler {
    UseProxy = true, 
    //UseDefaultCredentials = true,
    Proxy = new WebProxy("http://proxyall.hq.bc:8080", false, new string[]{}, new NetworkCredential("HQ\\samartsev_26224", "BssdpKpmoor6")),
});
var request = new HttpRequestMessage (
HttpMethod.Get, "https://87.76.32.6/kaspi.php?action=check&txn_id=362405260&number=106744");
//request.Content = new StringContent ("Hello!");
HttpResponseMessage response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine (await response.Content.ReadAsStringAsync());