<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
    var ser = new XmlSerializer(typeof(ZloNs.A));
    var ser2 = new XmlSerializer(typeof(ZloNs.A[]));
    
    using(var ms = new MemoryStream())
    using(var sw = new StreamWriter(ms))
    using(var sr = new StreamReader(ms))
    {
        ser.Serialize(sw, new ZloNs.A());
        
        ms.Seek(0, 0);
        var el = XElement.Parse(sr.ReadToEnd()).Dump();
        
        el.Element("b").Dump();
        
        ser.Deserialize(new StringReader("<A><b>7</b></A>")).Dump();
    }
    
    using(var ms = new MemoryStream())
    using(var sw = new StreamWriter(ms))
    using(var sr = new StreamReader(ms))
    {
        ser2.Serialize(sw, new[]{new ZloNs.A()});
        
        ms.Seek(0, 0);
        var el = XElement.Parse(sr.ReadToEnd()).Dump();
        
        ser2.Deserialize(new StringReader("<ArrayOfA><A><b>7</b></A></ArrayOfA>")).Dump();
    }
}}

namespace ZloNs
{
    public class A
    {
        public int b = 1;
        public string c = null;
    }
}

class eof{