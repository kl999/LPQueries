<Query Kind="Statements">
  <Connection>
    <ID>937f840d-1199-41e6-931a-5d5dc0424131</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>NORTHWND</Database>
  </Connection>
</Query>

Tst tstrow = new Tst{Num = 20, Field = "the 20`th"};
Tsts.InsertOnSubmit(tstrow);
//SubmitChanges();
Tsts.Dump();