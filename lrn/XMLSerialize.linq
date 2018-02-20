<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
    var xml = "";
    XmlSerializer xsSubmit = new XmlSerializer(new a().GetType(), new[] { typeof(zxc), typeof(qwe) });
    using (StringWriter sw = new StringWriter())
    {
        xsSubmit.Serialize(sw, new a());
        xml = sw.ToString();
    }
    Console.WriteLine(xml);

    using (StringReader sr = new StringReader(xml))
        Console.WriteLine((xsSubmit.Deserialize(sr) as a));

    XmlSerializer xsSubmit2 = new XmlSerializer(typeof(e));
    using (StringWriter sw = new StringWriter())
    {
        xsSubmit2.Serialize(sw, new e());
        xml = sw.ToString();
    }
    Console.WriteLine(xml);

    using (StringReader sr = new StringReader(xml))
        Console.WriteLine((xsSubmit2.Deserialize(sr) as e));

    DataContractSerializer xsSubmit3 = new DataContractSerializer(typeof(Ie), new[] { typeof(e) });
    using (StringWriter sw = new StringWriter())
    using(XmlTextWriter xw = new XmlTextWriter(sw))
    {
        xsSubmit3.WriteObject(xw, new Ie());
        xml = sw.ToString();
    }
    Console.WriteLine("Ie:\n" + XElement.Parse(xml));
    using (Stream sr = new MemoryStream(xml.Select(i => (byte)i).ToArray()))
        Console.WriteLine((xsSubmit3.ReadObject(sr) as Ie));
    
    xml = @"<UserQuery.Ie xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/"">
  <a i:type=""UserQuery.e"">
    <b>5</b>
    <a>5</a>
  </a>
</UserQuery.Ie>";
    using (Stream sr = new MemoryStream(xml.Select(i => (byte)i).ToArray()))
        Console.WriteLine((xsSubmit3.ReadObject(sr) as Ie));
}

[Serializable]
public class a
{
    public asd o = new asd();
    public asd o1 = new zxc();
    public asd o2 = new qwe();
}

//[XmlInclude(typeof(zxc))]
//[XmlInclude(typeof(qwe))]
[Serializable]
public class asd
{
    public int a = 999;
}

//[XmlInclude(typeof(asd))]
[Serializable]
public class zxc : asd
{
    public string str = "I see U!";
}

[Serializable]
public class qwe : asd
{
    public string str = "I see U 2!";
}

//[Serializable]
public interface I1
{
    int b { get; set; }
}

public class e : I1
{
    public int a = 5;

    public int b { get; set; }

    /*public void WriteXml(System.Xml.XmlWriter writer)
    {
        writer.WriteElementString("a", 5.ToString());
        //writer.WriteString("Evil string!");
    }

    public void ReadXml(System.Xml.XmlReader reader)
    {
        reader.Read();

        var a = reader.ReadElementContentAsInt();

        //if (reader.ReadString() != "Evil string!") throw new Exception("Bad Xml (nothing evil)!");
    }

    public System.Xml.Schema.XmlSchema GetSchema()
    {
        return (null);
    }*/
}

public class Ie
{
    public I1 a = new e() { b = 5 };
}