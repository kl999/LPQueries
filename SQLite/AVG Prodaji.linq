<Query Kind="Statements">
  <Connection>
    <ID>5db1c020-1b2d-44b2-ac14-a925dc85ad67</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>System.Data.SQLite</Provider>
    <CustomCxString>Data Source=C:\Users\Psamarce\Desktop\trafMySQLXML\db</CustomCxString>
    <AttachFileName>C:\Users\Psamarce\Desktop\trafMySQLXML\db</AttachFileName>
    <DisplayName>SQLite</DisplayName>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <UseOciMode>false</UseOciMode>
      <CreateDbIfMissing>true</CreateDbIfMissing>
    </DriverData>
  </Connection>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

List<Tovari> tTov = Tovaris.ToList();

List<Prodaji> tProd = Prodajis.ToList();

tProd
.Select(i => new
	{
	Name = tTov.First(o => o.TovarID == i.Tovar).Name,
	Ct = i.Kol_vo 
	})
.GroupBy(o => o.Name)
.Select(o => new
	{
	Name = o.Key,
	AVG = Math.Floor(o.Average(i => i.Ct))
	})
.Dump();