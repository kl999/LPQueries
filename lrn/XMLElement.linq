<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var doc = new XmlDocument();

doc.LoadXml("<root><sub1 id=''/><sub2><sub2-1 id='2nested'><a/></sub2-1></sub2></root>");

var root = doc.SelectSingleNode(@"root");

root.SelectNodes("node()").Dump("all");

doc.SelectSingleNode(@"root/sub1").Attributes["id"].InnerText = "15";

var nd = doc.SelectSingleNode(@"root/sub1");

doc.SelectSingleNode("root/sub2").SelectSingleNode("sub2-1/a").Dump("sub sub sub");

nd.AppendChild(doc.CreateElement("sub2"));

XElement.Parse(doc.OuterXml).Dump();

doc.Cast<XmlElement>().Select(i => i.Cast<XmlElement>().Select(i2 => i2.InnerText)).Dump();

doc
//.SelectSingleNode("//sub2-1/@id").Value
.SelectSingleNode("//sub2-1[@id='2nested']")
.Dump();