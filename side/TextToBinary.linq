<Query Kind="Statements">
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

var str = "Привет мир!";
string rezn = "", rezb = "";

foreach(byte ch in Encoding.GetEncoding(1251).GetBytes(str))
{
    rezn += Convert.ToString(ch, 16) + " ";
    
    rezb += Convert.ToString(ch, 2).PadLeft(8, '0') + " ";
}

rezn.Dump();
rezb.Dump();

var binin = "11001111 11110000 11101000 11100010 11100101 11110010 00100000 11101100 11101000 11110000 00100001";

Encoding.GetEncoding(1251).GetString(binin.Split(' ').Select(i => Convert.ToByte(i, 2)).ToArray()).Dump();