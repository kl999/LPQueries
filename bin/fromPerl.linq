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
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

for (k = 0; k < count(poly_y[j]); k++)
{
	if ((poly_x[j][k][1] - poly_x[j][k][0]) > 3) 
	{
		for (i = 0; i < count(poly_x[j][k]); i++)
		{
			poly_x[j][k][i] = poly_x[j][k][i]-3;
		}
	} elseif ((poly_x[j][k][0] - poly_x[j][k][1]) > 3) 
	{
		for (i = 0; i < count(poly_x[j][k]); i++)
			{
				poly_x[j][k][i] = poly_x[j][k][i] + 3;
			}
	} //else
	if ((poly_y[j][k][1] - poly_y[j][k][0]) > 3) 
	{
		for (i=0; i<count(poly_y[j][k]);i++)
		{
			poly_y[j][k][i] = poly_y[j][k][i] - 3;
		}
	} elseif ((poly_y[j][k][0] - poly_y[j][k][1]) > 3) 
	{
		for (i = 0; i < count(poly_y[j][k]); i++)
		{
			poly_y[j][k][i] = poly_y[j][k][i] + 3;
		}
	}
}