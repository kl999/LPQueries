<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    DecodeEncodedNonAsciiCharacters(File.ReadAllText(@"C:\Users\samartsev\Desktop\new  1.xml")).Dump();
}

static string DecodeEncodedNonAsciiCharacters(string value)
{
    return Regex.Replace(
        value,
        @"\\u(?<Value>[a-zA-Z0-9]{4})",
        m => {
            return ((char) int.Parse( m.Groups["Value"].Value, NumberStyles.HexNumber )).ToString();
        } );
}