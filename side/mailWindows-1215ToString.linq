<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string str = 
@"=8F=7B! 
=8F";

string rez = "";

for(int i = 0; i < str.Length; i++)
{
	if(str[i] == '=')
	{
		byte[] tmp = new byte[] {Convert.ToByte(str[++i].ToString() + str[++i], 16)};
		
		rez += Encoding.GetEncoding("windows-1251").GetString(tmp);
	}
	else
	{
		rez += str[i];
	}
}

rez.Dump("rez");