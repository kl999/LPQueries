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

var xml = XElement.Parse(@"<config id=""5"">
  <type>Sftp</type>
  <host>10.1.11.170</host>
  <user>imex_sftp</user>
  <password encrypt=""none"">Qwert1234</password>
  <imexTaskId>1</imexTaskId>
  <SshHostKeyFingerprint>ssh-rsa 2048 1d:66:9d:08:83:10:d2:43:68:42:14:a3:43:c7:65:5f</SshHostKeyFingerprint>
  <localStorage>\\kaspi-imex1\ImExData\FilesIn\FromSFTP\AlmatyGaz</localStorage>
  <localStorage>\\kaspi-imex2\ImExData\FilesIn\FromSFTP\AlmatyGaz</localStorage>
  <zip/>
  <location>
    <path>/AlmatyGazService_ext/</path>
    <files>
      <file>fiz_RT_\d{8}.xml</file>
    </files>
  </location>
</config>");

var els = new List<XElement>();
foreach(var el in xml.Elements())
    els.Add(el);

xml.RemoveNodes();

var rand = new Random();

foreach(var el in els.Select(i => new{ order = rand.Next(), el = i }).OrderBy(i => i.order).Select(i => i.el))
    xml.Add(el);

xml.Dump();