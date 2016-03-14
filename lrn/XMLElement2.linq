<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml</Namespace>
</Query>

var doc = new XmlDocument();

doc.LoadXml(File.ReadAllText(@"c:\sp\1.txt", Encoding.GetEncoding(1251)));

XElement.Parse(doc.OuterXml).Dump();

doc.Cast<XmlElement>().Select(i => i.Cast<XmlElement>().Select(i2 => i2.InnerText)).Dump();

doc
.SelectSingleNode("//parameter[@serviceId='38']")
.Dump();