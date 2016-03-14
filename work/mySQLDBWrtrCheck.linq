<Query Kind="Statements">
  <Connection>
    <ID>a4c45978-5d31-40c9-a263-9421bd6a63cf</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAD8RKCmPiMJyOajuV09wbaEAAAAAASAAACgAAAAEAAAAHTAd5EFdWU6lmWHaUPzdeZIAAAACS+h56P9u4dUaZje84pmxS7rLJ+0sg5I/3/WItFgPJQSCNi6o4eC2rxgwu6ySAYXZcbE/RhLhFhW7fuvlM6tbxQUO7TJlaiDFAAAAC9IHUoPIn7NIrP5e3CnUji6xwqD</CustomCxString>
    <Server>192.168.0.35</Server>
    <UserName>frompir</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAADwxvNcWLoqT7wOSQTxCc61AAAAAASAAACgAAAAEAAAANutJ6NqGFPfIRDVtMBgDcwIAAAAlAIB1msaLxsUAAAAwLP/xLTgEgnzNdFexWeGiEtGYxU=</Password>
    <Database>frompir</Database>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <ExtraCxOptions>CharSet= utf8;</ExtraCxOptions>
    </DriverData>
  </Connection>
</Query>

Crinfos
.OrderBy(i => i.Time)
.Where(i => i.S != 0 || i.W != 0 || i.N != 0 || i.E !=0)
.Where(i => i.Time == DateTime.Parse("02.10.2013 11:00 AM").Dump("Time is"))
.Take (1000).ToList().Dump()
.Count.Dump("Working");