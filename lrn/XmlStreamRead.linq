<Query Kind="Statements">
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
</Query>

using(var rdr = XmlReader.Create("../tst.xml"))
{
    for(;rdr.Read();)
    {
        //rdr.Dump();
        
        if(rdr.NodeType.ToString() == "Whitespace") continue;
        
        $"{rdr.NodeType.ToString().PadRight(15)}|{rdr.Name}|{rdr.Value}|".Dump();
        
        if(rdr.HasAttributes)
        {
            for (int attInd = 0; attInd < rdr.AttributeCount; attInd++)
            {
              rdr.MoveToAttribute( attInd );
              $"                   {rdr.Name} = {rdr.Value}".Dump();
            }
        }
    }
}