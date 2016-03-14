<Query Kind="SQL">
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

SELECT 
	SUM(kolvo) AS "Сумма",
	strftime('%m', time) AS "Месяц",
	strftime('%Y', time) AS "Год"
FROM prodaji
GROUP BY "Год", "Месяц"