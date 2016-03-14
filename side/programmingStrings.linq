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

//		  v<-----------------------------------<
//		event								    ^
//		  v									 new event
//		  examened by properties (edit event or ^)
//		  v
//		 bah

void Main()
{
	var wrk = new worker();
	
	wrk.props.Add(new hell());
	
	wrk.props.Add(new allAdd());
	
	for(int i = 0; i < 10; i++)
		wrk.doEvt(new lo());
}

class worker
{
	public List<prop> props = new List<prop>();
	
	private List<ev> evs = new List<ev>();
	
	public void doEvt(ev evt)
	{
		foreach(prop o in props)
		{
			o.fire(evt, evs);
		}
		
		evt.fire();
		
		if(evs.Count > 0)
		{
			ev nextEvt = evs[0];
			
			evs.Remove(nextEvt);
			
			doEvt(nextEvt);
		}
	}
}

interface prop
{
	string val{ get; set; }
	
	void fire(ev evt, List<ev> evs);
}

interface ev
{
	string val{ get; set; }
	
	void fire();
}

class hell : prop
{
	public string val{ get; set; }
	
	public hell()
	{
		val = "hell prop:1";
	}
	
	public void fire(ev evt, List<ev> evs)
	{
		string[] tmp = evt.val.Split(':');
		
		if(tmp[0] == "hel")
		{
			string[] temp = val.Split(':');
			
			int t2 = Int32.Parse(temp[1]);
			
			evt.val = tmp[0] + "lo:" + t2++;
			
			val = temp[0] + ":" + t2;
			
			evs.Add(new all());
		}
	}
}

class allAdd : prop
{
	public string val{ get; set; }
	
	public allAdd()
	{
		val = "allAdd prop:1";
	}
	
	public void fire(ev evt, List<ev> evs)
	{
		string[] tmp = evt.val.Split(':');
		
		if(tmp[0] == "all")
		{
			string[] temp = val.Split(':');
			
			int t2 = Int32.Parse(temp[1]);
			
			evt.val = tmp[0] + ":" + t2++;
			
			val = temp[0] + ":" + t2;
		}
	}
}

class lo : ev
{
	public string val{ get; set; }
	
	public lo()
	{
		val = "hel:";
	}
	
	public void fire()
	{
		val.Dump();
	}
}

class all : ev
{
	public string val{ get; set; }
	
	public all()
	{
		val = "all:";
	}
	
	public void fire()
	{
		val.Dump();
	}
}