<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

 Uri uri = new Uri("https://www.httprecipes.com/1/5/https.php");

WebRequest http = HttpWebRequest.Create(@"https://www.kaspi.kz/");

//http.Headers

HttpWebResponse response = (HttpWebResponse)http.GetResponse();

var rdr = new StreamReader(response.GetResponseStream(),Encoding.GetEncoding(1251));

rdr.ReadToEnd().Dump();