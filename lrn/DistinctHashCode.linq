<Query Kind="Program">
  <Connection>
    <ID>b2aac786-6e24-43fc-aff9-4fa7b0f86818</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAB0aBac5XR15KW7AtZYYwGgAAAAAASAAACgAAAAEAAAAKutYqlP5CwXtVP0zaEla6JIAAAA0J+yYZ1aGj/rwGX2/HtUh4GOUFcLsH565L6NJ/0EDhoCVoGdUSAyLAgDZEutxqdAnj6Tq77ffFmOsdgtWxA7tlIk8XJ/6LOxFAAAABs0ugKbcjM3dDHhA1L9qCERMUUb</CustomCxString>
    <Server>192.168.0.200</Server>
    <Database>pir</Database>
    <UserName>pirro</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAAAZo7tSVA6XHKSsWEOow6FAAAAAASAAACgAAAAEAAAAIj/YEY+5XhgXBjLXIFL8uQIAAAAzbd7I1B/A2AUAAAAShnQq8Gg1v9jqiQFtenEAHalhKM=</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DisplayName>To PIR (read only)</DisplayName>
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

void Main()
{
	var lst = new List<string>(new[]{
		"Hi",
		"all",
		"Hello",
		"all"
	});
	
	lst
	.Select((i, j) => new testCls{str = i, num = j + i.Length})
	.Dump("from")
	.Distinct()
	.Dump("to");
	
	(new testCls{str = "aa", num = 3})
	.Equals(new testCls{str = "l", num = 5})
	.Dump();
}

class testCls : System.Object
{
	public int num = 0;
	public string str = "";
	
	public override bool Equals(System.Object b)
    {
		if(b is testCls)
			return GetHashCode() == b.GetHashCode();
		
		return false;
	}
	
	public override int GetHashCode()
	{
		return str.GetHashCode();
	}
}