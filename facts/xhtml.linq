<Query Kind="Statements">
  <Connection>
    <ID>07654b0a-d360-457f-a499-fa821ae7c7f7</ID>
    <Server>tb-impex-db</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>ImExDBUser</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAD3LmAGy+IkOR/3qrx+HoeQAAAAACAAAAAAADZgAAwAAAABAAAADbFSqvpZll4kv+Baep9cJWAAAAAASAAACgAAAAEAAAAEvFUvGJtSlVzZYId4WLco4IAAAAHo5eMJNUA18UAAAAdijbqnXmEu+ODWjRrbAPO4X/E5k=</Password>
    <Database>KazTransGazAimak</Database>
    <ShowServer>true</ShowServer>
  </Connection>
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

var styleInstruction = new XProcessingInstruction (
"xml-stylesheet", "href='styles.css' type='text/css'");
var docType = new XDocumentType ("html",
"-//W3C//DTD XHTML 1.0 Strict//EN",
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd", null);
XNamespace ns = "http://www.w3.org/1999/xhtml";
var root =
new XElement (ns + "html",
new XElement (ns + "head",
new XElement (ns + "title", "An XHTML page")),
new XElement (ns + "body",
new XElement (ns + "p", "This is the content"))
);
var doc =
new XDocument (
new XDeclaration ("1.0", "utf-8", "no"),
new XComment ("Reference a stylesheet"),
styleInstruction,
docType,
root);
doc.Save (@"c:\sp\test.html");