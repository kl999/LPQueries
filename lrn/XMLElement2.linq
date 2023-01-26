<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var doc = new XmlDocument();

/*doc.LoadXml(File.ReadAllText(@"c:\sp\1.txt", Encoding.GetEncoding(1251)));

XElement.Parse(doc.OuterXml).Dump();

doc.Cast<XmlElement>().Select(i => i.Cast<XmlElement>().Select(i2 => i2.InnerText)).Dump();

doc
.SelectSingleNode("//parameter[@serviceId='38']")
.Dump();*/

doc = new XmlDocument();

doc.LoadXml(@"<a xmlns=""a.sd""><b>1</b></a>");

XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
nsmgr.AddNamespace("asd", "a.sd");
XmlNode xmlNode = doc.DocumentElement.SelectSingleNode(@"//asd:b", nsmgr);

xmlNode.Dump();