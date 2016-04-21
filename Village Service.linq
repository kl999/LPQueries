<Query Kind="Statements">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var el = XElement.Load(@"C:\Users\samartsev\Desktop\KSK.xml");

XNamespace mns = "http://v8.1c.ru/8.1/data/core";

var rez = "";

foreach(var col in el.Elements(mns + "column"))
{
    rez += col.Element(mns + "Title").Value + ";";
}

rez += Environment.NewLine;

foreach(var row in el.Elements(mns + "row"))
{
    foreach(var val in row.Elements(mns + "Value"))
        rez += val.Value + ";";
    
    rez += Environment.NewLine;
}

var dta = rez.Split('\n')
.Skip(1)
.Select(i => i.Split(';'))
.Where(i => i.Length >= 19)
.Select(i => new
{
    acc = i[1],
    org = i[2],
    obj = i[4],
    svc = i[11],
    amt = i[19]
});

dta
.GroupBy(i => i.acc)
.OrderByDescending(i => i.Count())
.Dump();

if(Console.ReadLine().ToLower() == "yes")
{
    rez.Dump();
    File.WriteAllText(@"C:\Users\samartsev\Desktop\KSK.csv", rez, Encoding.GetEncoding(1251));
}