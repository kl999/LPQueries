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

doc.LoadXml("<root><sub1 id=''/><sub2><sub2-1 id='2nested'/></sub2></root>");

doc.SelectSingleNode(@"root/sub1").Attributes["id"].InnerText = "15";

var nd = doc.SelectSingleNode(@"root/sub1");

nd.AppendChild(doc.CreateElement("sub2"));

XElement.Parse(doc.OuterXml).Dump();

doc.Cast<XmlElement>().Select(i => i.Cast<XmlElement>().Select(i2 => i2.InnerText)).Dump();

doc
//.SelectSingleNode("//sub2-1/@id").Value
.SelectSingleNode("//sub2-1[@id='2nested']")
.Dump();