<Query Kind="Statements">
  <Connection>
    <ID>b2aac786-6e24-43fc-aff9-4fa7b0f86818</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAACDmBk7daE0wTZokTPQk4snAAAAAASAAACgAAAAEAAAADtn+b4st6GHWwxj/9clfgFIAAAAxMzik28IbypWcSEt24wAAt9bWzvr6qPnseZnIE0SxXfSP5NjS3vxOMVLhYSvyunJ+CpJtjaULL0QDKQqYhkQdVwjKpB8G3DFFAAAACgnMO+BRJ3K3g6RKVwllDGVebGF</CustomCxString>
    <Server>192.168.0.200</Server>
    <Database>pir</Database>
    <UserName>pirro</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAAAZo7tSVA6XHKSsWEOow6FAAAAAASAAACgAAAAEAAAAIj/YEY+5XhgXBjLXIFL8uQIAAAAzbd7I1B/A2AUAAAAShnQq8Gg1v9jqiQFtenEAHalhKM=</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <ExtraCxOptions>CharSet=utf8;</ExtraCxOptions>
    </DriverData>
  </Connection>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

DateTime dt = DateTime.Now;

int updInDay = 24 * 4 * 16;

TrafficBlocks.Where(o => o.Time > dt.AddDays(-1) && o.Time < dt)
.GroupBy(o => o.CrossroadId).ToList()
.Select(o => 
	new {
		o.Key,
		tr = o.Sum(i => i.TransportCount),
		ct = o.Count(),
		fromNorm = (o.Count() * 100 / updInDay) + "%"
		}
).Dump();