<Query Kind="SQL">
  <Connection>
    <ID>b35e2479-3b0e-4dd6-bd5f-36670a7fe583</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAACREX2+tLaFEppNNnO8ecpBAAAAAASAAACgAAAAEAAAAEHgtGt1TILs2eYyk9+Zx8M4AAAAOqFxxJYGkshKtROr2d/Y/tfVotVIlTygb+UiTZygbipu7XPLEyz9SQC6vx1ofCb+iSPzikzntkoUAAAAvSeOWuPI5AjsddgD8SRI31SXGAY=</CustomCxString>
    <Server>192.168.0.13</Server>
    <Database>avideo</Database>
    <UserName>video</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAAAxoqwgcoRFGaWg4mq52TjmAAAAAASAAACgAAAAEAAAAOehqnKZvhaeJJ6wpD6EWU8IAAAAMI20flaJLuQUAAAAILu84iqrc3EC74EN3i8gqU8k2LI=</Password>
    <DisplayName>aVideo</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
    </DriverData>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

SELECT 
    table_schema 'Schema',
    table_name 'Table name',
    FORMAT((data_length + index_length) / 1024 / 1024,
        0) 'Size in MB',
    FORMAT((data_length + index_length) / 1024 / 1024 / 1024,
        1) 'In GB',
	CONCAT('~', table_rows) 'Rows'
FROM
    information_schema.TABLES
WHERE
    table_schema != 'information_schema'
ORDER BY table_schema , (data_length + index_length) DESC
;