<Query Kind="Expression">
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

TrafficVideos
.Where(i => i.CrossroadId == 300 
	&& i.Time > new DateTime(2013, 11, 1, 17, 00, 00))
.ToArray()
.GroupBy(i => i.Time.Day)
.Select(lst => lst
	.GroupBy(i => i.Time.Hour)
	.Select(o =>
		new{
			count = o.Sum(i => i.TransportCount),
			speed = (int)o.Average(i => i.Speed),
			time = o.First().Time.Hour 
			}
	)
)
.SelectMany(i => i)