<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

XmlDocument document = new XmlDocument();

document.LoadXml("<rq v='2'><rt>3</rt><id su='' p=''></id><acc prv='' sum=''></acc></rq>");

document
.OuterXml
.Dump("Outer");

document
.InnerXml
.Dump("Inner");