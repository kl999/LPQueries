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

#line 2

void Main()
{
    try
    {
        try
        {
            die();
        }
        catch(OutOfMemoryException ex)
        {
            ex.Dump("First");
            throw;
        }
        catch(Exception ex)
        {
            ex.Dump();
        }
        
        "End 1!".Dump();
    }
    catch(Exception ex)
    {
        ex.Dump();
    }
    
    try
    {
        die();
    }
    catch(Exception ex) when (log(ex))
    {
    }
    catch(OutOfMemoryException ex)
    {
        ex.Dump("First");
        throw ex;
    }
    catch(Exception ex)
    {
        ex.Dump();
    }
    
    "End 2!".Dump();
}

void die()
{
    throw new OutOfMemoryException("Hi!");
}

bool log(Exception ex) //Hakcs
{
    $"Zi exception is {ex.GetType().Name}".Dump();
    return false;
}