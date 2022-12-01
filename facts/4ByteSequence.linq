<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Convert.ToString(0xA5, 16).Dump();
Convert.ToByte("A5", 16).Dump();
new String(new[] { (char)0xFE, (char)0xA5, (char)0xC8, (char)0xF6 }).Dump();
//new String(new[] { (char)0x56, (char)0x41, (char)0x4B, (char)0x68 })