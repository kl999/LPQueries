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

var el = XElement.Load(@"c:\sp\ids.xml");
el.XPathSelectElement("item[@value=\"hello\"]").Dump();

var maxCt = el.Elements("item").Max(i => Int32.Parse(i.Attribute("id").Value));

maxCt.Dump("maxStart");

var dc = new DumpContainer();
dc.Dump();

for(;;)
{
    var str = Console.ReadLine();
    
    if(str == "\\exit") break;
    
    var ms = Regex.Matches(str, @"\b\w+\b");
    
    foreach(Match m in ms)
    {
        var t = el.XPathSelectElement($"item[@value=\"{m.Value}\"]");
        if(t == null)
        {
            maxCt++;
            var te = new XElement("item");
            te.SetAttributeValue("id", maxCt);
            te.SetAttributeValue("value", m.Value);
            el.Add(te);
        }
    }
    
    dc.Content = null;
    dc.Content = el;
}

maxCt.Dump("maxEnd");

el.Save(@"c:\sp\ids.xml");