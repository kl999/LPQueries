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

Prodaji row = new Prodaji{ Tovar = 4, Kolvo = 9999, Pokupatel = 6, Time = DateTime.Now};

DateTime dt = DateTime.Now.AddYears(-4);

Random randID = new Random(DateTime.Now.Millisecond);

Random randCt = new Random(DateTime.Now.Minute / DateTime.Now.Second);

for(int i = 1; i < 1000; i++)
{	
	dt = dt.AddDays(1);
	
	if(randID.Next(3) == 1)
	{
		int ID = randID.Next(4) + 1;
		
		int Ct = randCt.Next(9999) + 1;
		
		row = new Prodaji{ Tovar = ID, Kolvo = Ct, Pokupatel = randID.Next(4) + 1, Time = dt };
		
		Prodajis.InsertOnSubmit(row);
	}
}

SubmitChanges();
Prodajis.Dump();