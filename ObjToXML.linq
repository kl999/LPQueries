<Query Kind="Program">
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

void Main()
{
    var o = new MyZ.A { a = 9 };

    var xml = SimpleXMLConverter.toXlm(o);

    Console.WriteLine(xml);

    var o2 = SimpleXMLConverter.fromXml(xml, new[] { typeof(MyZ.A), typeof(MyZ.B) });

    Console.WriteLine((o2 as MyZ.A).a);
}

public static class SimpleXMLConverter
{
    public static List<Type> simpleTypesLs = new List<Type>(new[]
    {
            typeof(int),
            typeof(long),
            typeof(string),
            typeof(bool),
            typeof(DateTime),
            typeof(TimeSpan)
    });

    public static XElement toXlm<T>(T obj, string propName = null)
    {
        XElement rez = null;

        if (obj == null)
        {
            rez = new XElement(typeof(T).FullName);

            rez.SetAttributeValue("null", "true");

            if (propName != null) rez.SetAttributeValue("propName", propName);

            return rez;
        }

        Type type = obj.GetType();

        if (simpleTypesLs.Contains(type))
        {
            rez = new XElement(type.FullName, obj.ToString());
        }
        else if (type.IsArray)
        {
            rez = new XElement("Array");
            rez.SetAttributeValue("type", type.GetElementType().FullName);

            foreach (var item in (obj as dynamic))
            {
                rez.Add(toXlm(item));
            }
        }
        else
        {
            if (type.GetConstructor(new Type[0]) == null) throw new Exception($"No parameterless constructor in type {type.FullName}!");

            rez = new XElement(type.FullName);

            if (propName != null) rez.SetAttributeValue("propName", propName);

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (simpleTypesLs.Contains(field.FieldType))
                    rez.Add(new XElement(field.Name, field.GetValue(obj).ToString()));
                else
                    rez.Add(toXlm(field.GetValue(obj), field.Name));
            }
        }

        return rez;
    }

    internal static object fromXml(XElement xml, Type[] knownTypes)
    {
        object rez = null;

        if (xml.Attribute("null")?.Value == "true") return null;

        Type type = null;

        foreach (var item in simpleTypesLs)
        {
            if (item.FullName == xml.Name.ToString())
                return getSimpleValue(xml.Value, item.FullName);
        }

        if (xml.Name.ToString() == "Array")
        {
            var typeName = xml.Attribute("type").Value;
            var arrMbrs = xml.Elements().ToArray();

            foreach (var item in simpleTypesLs.Concat(knownTypes ?? new Type[0]))
            {
                if (item.FullName == typeName)
                    type = item;
            }

            if (type == null) throw new Exception("Array type is unknown!");

            var ctor = type.MakeArrayType().GetConstructor(new Type[0]);

            rez = Activator.CreateInstance(type.MakeArrayType(), new object[] { arrMbrs.Length });

            for (int i = 0; i < arrMbrs.Length; i++)
            {
                  (rez as Array).SetValue(fromXml(arrMbrs[i], knownTypes), i);
            }

            return rez;
        }
        else
        {
            foreach (var item in knownTypes)
            {
                if (item.FullName == xml.Name.ToString())
                    type = item;
            }

            if (type == null) throw new Exception("Type is unknown!");

            var ctor = type.GetConstructor(new Type[0]);

            rez = ctor.Invoke(new object[0]);

            foreach (var el in xml.Elements())
            {
                object val = null;

                string propName = el.Attribute("propName")?.Value;

                var fld = type.GetField(propName ?? el.Name.ToString(), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                if (propName != null)
                    val = fromXml(el, knownTypes);
                else
                    val = getSimpleValue(el.Value, fld.FieldType.FullName);

                fld.SetValue(rez, val);
            }

            return rez;
        }
    }

    private static object getSimpleValue(string value, string typeName)
    {
        switch (typeName)
        {
            case "System.String":
                return value;

            case "System.Int32":
                return Int32.Parse(value);

            case "System.Int64":
                return Int64.Parse(value);

            case "System.Boolean":
                return Boolean.Parse(value);

            case "System.TimeSpan":
                return TimeSpan.Parse(value);

            case "System.DateTime":
                return DateTime.Parse(value);

            default:
                throw new Exception($"Unknown type name ({typeName})!");
        }
    }
}}

namespace MyZ
{
    class A
    {
        public int a = 5;
    
    #pragma warning disable CS0414
        private int b = 7;
    #pragma warning restore CS0414
    
        public string str = "Hi!";
    
        public bool flag = true;
    
        public DateTime dt = DateTime.Now;
    
        public TimeSpan ts = new TimeSpan(0, 5, 30);
    
        public B inner = new B();
        public B isnull = null;
    }
    
    class B
    {
        public int fst = 3;
        public long scnd = 18;
    }
}

class EoF{