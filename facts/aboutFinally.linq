<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	tryit();
}

void tryit()
{
	try
	{
		if(true)
			throw new Exception("Hello");
	}
	catch(Exception ex)
	{
		ex.Message.Dump();
		return;
	}
	finally
	{
		"world".Dump();
	}
}