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
    (ArmLogEventsType.login == ArmLogEventsType.none).Dump();
    
    ((int)ArmLogEventsType.login == (int)ArmLogEventsType.none).Dump();
    
    ((ArmLogEventsType)(int)ArmLogEventsType.login).Dump();
}

enum ArmLogEventsType
{
    none = 0,
    other = -1,
    login,
}