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

Tovari row = new Tovari{ TovarID = 1, Name = "Утюг", Price = 100};
Tovaris.InsertOnSubmit(row);

row = new Tovari{ TovarID = 2, Name = "Тостер", Price = 500};
Tovaris.InsertOnSubmit(row);

row = new Tovari{ TovarID = 3, Name = "Сковорода", Price = 30};
Tovaris.InsertOnSubmit(row);

row = new Tovari{ TovarID = 4, Name = "Вилка", Price = 8};
Tovaris.InsertOnSubmit(row);

SubmitChanges();

Tovaris.Dump();