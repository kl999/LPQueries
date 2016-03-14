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

XmlDocument config = null;
config = new XmlDocument();
config.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration xmlns='http://kaspi.kz/OfflineStd.xsd'>
  <ServiceConfigs>
    <svc id=""669"" name=""SaranCommunService"">
      <dbname>ImexOfflineRegistry.SaranCommunService</dbname>
      <type>VarChar</type>
      <accLength>12</accLength>
      <checkName>sp_Check</checkName>
      <paymentName>sp_Payment</paymentName>
      <cancelName>sp_Cancel</cancelName>
    </svc>
    <zxc xmlns="""">Know no namespace</zxc>
  </ServiceConfigs>
</configuration>");

config.Dump();

System.Xml.XmlNamespaceManager nsm = new System.Xml.XmlNamespaceManager(config.NameTable);

nsm.AddNamespace("dft", "http://kaspi.kz/OfflineStd.xsd");
nsm.AddNamespace("nons", "");

nsm.DefaultNamespace.Dump();

config.SelectSingleNode("/dft:configuration/dft:ServiceConfigs/dft:svc[@id=" + 669.ToString() + "]", nsm)
.Dump();

config.SelectSingleNode("/dft:configuration/dft:ServiceConfigs/nons:zxc", nsm)
.Dump("noNs");

config.SelectSingleNode("/dft:configuration/dft:ServiceConfigs/zxc", nsm)
.Dump("not Ns");