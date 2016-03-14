<Query Kind="Program">
  <Connection>
    <ID>017f3d8e-8ed9-4150-8249-1fabe793edbb</ID>
    <Persist>true</Persist>
    <Server>tb-impex-db</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>ImExDB</Database>
    <NoPluralization>true</NoPluralization>
    <UserName>ImExDBUser</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA9QqopYu6QUSrcyly5v9QgQAAAAACAAAAAAADZgAAwAAAABAAAAD5WIs4mgqCtfMTKwgxN5ROAAAAAASAAACgAAAAEAAAADce6p38+wVTbpEMAhy9e/QIAAAAY6XnGQx0MOUUAAAAI8qi4BtECYD8fusyRg6gkjS/ggI=</Password>
    <IsProduction>true</IsProduction>
  </Connection>
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

string nameToSearch = "Энергопоток";//"Энергопоток";//"Energopotok";//"Шыгысэнерготрейд";
string schemaName = "Energopotok";
List<KeyValuePair<string, XElement>> rezs = new List<KeyValuePair<string, XElement>>();

void Main()
{
    Tbl_Groups
    .AsEnumerable()
    .Where(i =>
    {
        if(Regex.IsMatch(i.VchGroupName, nameToSearch))
            return true;
            
        if(Regex.IsMatch(i.VchGroupAlias, nameToSearch))
            return true;
        
        return false;
    })
    .Select(i => new
    {
        i.IntGroupId,
        i.VchGroupName,
        i.VchGroupAlias,
        Choice = new Hyperlinq(new Action(() =>
        {
            chngScripts(i.IntGroupId);
        }), "select"),
    })
    .Dump();
}

void chngScripts(int groupId)
{
    var arr = Tbl_Services
    .Where(i => i.IntGroupId == groupId)
    .Select(i => new KeyValuePair<string, string>(i.VchServiceName + " - " + i.IntServiceId, i.TxtConfig))
    .ToArray()
    ;
    
    arr
    .Select(i => new{ name = i.Key, cfg = XElement.Parse(i.Value) })
    .Dump();
    
    foreach(var o in arr)
    {
        XElement xml = null;
        
        try
        {
            xml = XElement.Parse(o.Value);
        }
        catch(Exception ex)
        {
            $"Can not parse task {o.Key} problem is:\n{ex.ToString()}".Dump();
            continue;
        }
        
        var preChng = xml.ToString();
        
        //xml.Dump();
        
        if(xml.Name != "configuration") continue;
        
        foreach(var im in xml.Elements("import"))
        {
            var tgt = im.Element("dataaccess").Element("target");
            
            //tgt.Attributes().Dump();
            
            if(tgt.Attribute("providertype")?.Value.ToUpper() != "SQL") continue;
            
            var connectionStr = tgt.Attribute("connstr").Value;
            if(connectionStr.ToLower().Contains("data source=tb-impex-db;"))
            {
                tgt.SetAttributeValue("connstr", "DBConnStrOfflineRegistry");
            }
            else
            {
                var tmp = Tbl_SettingEntries.FirstOrDefault(i => i.Name == connectionStr);
                
                if(tmp != null)
                {
                    if(tmp.Value.ToLower().Contains("data source=tb-impex-db;"))
                    {
                        tgt.SetAttributeValue("connstr", "DBConnStrOfflineRegistry");
                    }
                }
            }
            
            if(tgt.Attribute("connstr")?.Value.ToUpper() == "DBCONNSTROFFLINEREGISTRY"
                || tgt.Attribute("connstr")?.Value.ToUpper().Contains("IMEXOFFLINEREGISTRY") == true
                ){}
                else continue;
            
            foreach(var table in tgt.Element("tables").Elements("table"))
            {
                //table.Dump();
                
                var name = table.Attribute("name").Value.Split('.');
                var trueName = "";
                
                if(name.Length == 1)
                    trueName = $"{schemaName}.{name[0]}";
                else if(name.Length == 2)
                    trueName = $"{schemaName}.{name[1]}";
                else
                    throw new Exception("name.Length > 2!!!");
                
                table.SetAttributeValue("trueName", trueName);
            }
        }
        
        foreach(var im in xml.Elements("export"))
        {
            var tgt = im.Element("dataaccess").Element("source");
            
            //tgt.Attributes().Dump();
            
            if(tgt.Attribute("providertype")?.Value.ToUpper() != "SQL") continue;
            
            var connectionStr = tgt.Attribute("connstr").Value;
            if(connectionStr.ToLower().Contains("data source=tb-impex-db;"))
            {
                tgt.SetAttributeValue("connstr", "DBConnStrOfflineRegistry");
            }
            else
            {
                var tmp = Tbl_SettingEntries.FirstOrDefault(i => i.Name == connectionStr);
                
                if(tmp != null)
                {
                    if(tmp.Value.ToLower().Contains("data source=tb-impex-db;"))
                    {
                        tgt.SetAttributeValue("connstr", "DBConnStrOfflineRegistry");
                    }
                }
            }
            
            if(tgt.Attribute("connstr")?.Value.ToUpper() == "DBCONNSTROFFLINEREGISTRY"
                || tgt.Attribute("connstr")?.Value.ToUpper().Contains("IMEXOFFLINEREGISTRY") == true
                ){}
                else continue;
            
            foreach(var table in tgt.Element("tables").Elements("table"))
            {
                //table.Dump();
                
                var name = table.Attribute("name").Value.Split('.');
                var trueName = "";
                
                if(name.Length == 1)
                    trueName = $"{schemaName}.{name[0]}";
                else if(name.Length == 2)
                    trueName = $"{schemaName}.{name[1]}";
                else
                    throw new Exception("name.Length > 2!!!");
                
                table.SetAttributeValue("trueName", trueName);
            }
        }
        
        //xml.Dump("asd");
        
        if(preChng != xml.ToString()) rezs.Add(new KeyValuePair<string, XElement>(o.Key, xml));
    }
    
    new Hyperlinq(new Action(submitChanges), "Change this scripts:").Dump();
    
    rezs.Dump();
}

void submitChanges()
{
    foreach(var o in rezs)
    {
        var tmp = o.Key.Split('-');
        var tmp2 = Int32.Parse(tmp[tmp.Length - 1].Trim());
        
        Tbl_Services.First(i => i.IntServiceId == tmp2).TxtConfig = o.Value.ToString();
    }
    
    SubmitChanges();
}