<Query Kind="Program">
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
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Dir_points.AsEnumerable()
	.OrderBy(i => i.Update)
	.Select(i => new{
		ID = i.Id,
		x = i.TileX - 93499,
		y = i.TileY - 48079,
		xIn = i.InTileX,
		yIn = i.InTileY,
		i.CRID,
		i.Direction,
		i.Speed,
		Time = UnixTimeStampToDateTime(i.Update)
		}).Dump();
}

public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
{
	// Unix timestamp is seconds past epoch
	System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
	dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
	return dtDateTime;
}