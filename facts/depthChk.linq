<Query Kind="Statements">
  <Connection>
    <ID>db74b755-21a0-4139-adcc-4a20f1c4df87</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAUWL3VCZXzkGgpTgupjeYcAAAAAACAAAAAAADZgAAwAAAABAAAACwDm7i5njir180sebnRqjuAAAAAASAAACgAAAAEAAAAIpj4/+8dKfH6ReqH4maP15IAAAAHCBdVZOmhn475ZAfQHdvUkCdfxjVAkH6Fc6Qy4dt6WIAsRv0oF9Lb5M5UKGB/RAnaWz3zv3WpQDVQwLE4G4/+Vfbhzt61QKGFAAAAHypu/3NaYNFnr9hf20pDAD1RJdf</CustomCxString>
    <Server>192.168.0.200</Server>
    <Database>Graph</Database>
    <UserName>Graph</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAUWL3VCZXzkGgpTgupjeYcAAAAAACAAAAAAADZgAAwAAAABAAAADKu4heJ6pHohiptqY73KkzAAAAAASAAACgAAAAEAAAAA3HCrEQPcVRN8btscYpSjEIAAAAeS0V1M8xaOYUAAAALSkiv+wfCppAaT3BXGPWS8RL/Ns=</Password>
    <DisplayName>Graph</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <ExtraCxOptions>CharSet=utf8;</ExtraCxOptions>
    </DriverData>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

int[,] arr = new int[30, 30];

//arr.Dump().Dump().Dump();

int dist = 3;

int x = 28, y = 10;

arr[x, y] = 3;

int xp = dist + x, yp = dist + y;
int xm = x - dist, ym = y - dist;

("xp " + xp + ", yp " + yp + "\nxm " + xm + ", ym " + ym).Dump("input");

int stpCt = dist * 2 + 1;

var dc = new DumpContainer();

dc.Dump();

for(int stp = 0; stp < stpCt; stp++)
{
	int spx = xp - stp, spy = yp - stp,
		smx = xm + stp, smy = ym + stp;
	
	if(spx < 30 && spx >= 0 && yp < 30)
	{
		arr[xp - stp, yp] = 1;
	}
	
	if(spy < 30 && spy >= 0 && xp < 30)
	{
		arr[xp, yp - stp] = 1;
	}
	
	if(smx < 30 && smx >= 0 && ym >= 0)
	{
		arr[xm + stp, ym] = 1;
	}
	
	if(smy < 30 && smy >= 0 && xm >= 0)
	{
		arr[xm, ym + stp] = 1;
	}

	dc.Content = arr;
	
	Task.Delay(1000).Wait();
}