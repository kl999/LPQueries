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
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Rand rand = new Rand();
	
	List<int> arr = new List<int>();
	
	for(int i = 0; i < 1000; i++)
	{
		for(;;)
		{
			int num = rand.next(1000);
			
			bool found = false;
			
			foreach(int tn in arr)
			{
				if(num == tn)
				{
					//if(tn > 100 && rand.next(100) < 80)
					{
						found = true;
					}
					break;
				}
			}
			
			if(!found)
			{
				arr.Add(num);
				break;
			}
		}
	}
	
	//arr.OrderBy(i => i).Dump();
	
	string handbook = arr[0].ToString();
	
	for(int i = 1; i < arr.Count; i++)
	{
		handbook += "|" + arr[i];
	}
	
	handbook.Dump();
}

class Rand
{
	System.Security.Cryptography.RandomNumberGenerator rand = System.Security.Cryptography.RandomNumberGenerator.Create();
	
	public double ret()
	{
		byte[] b = new byte[4];
		
		rand.GetBytes(b);
		
		return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
	}
	
	public int next(int max)
	{
		return (int)(ret() * max);
	}
}