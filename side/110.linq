<Query Kind="Program">
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

int width = 1920;

bool[][] arr = null;

void Main()
{
    arr = new bool[width][];
    for(int y = 0; y < arr.Length; y++)
    {
        arr[y] = new bool[width];
    }
    
    var firstMovedToRight = new int[]
    { 1 }
    .Select(i => i == 1).ToArray();
    
    for(int x = arr.Length - firstMovedToRight.Length, x2 = 0; x < arr.Length; x++, x2++)
    {
        arr[0][x] = firstMovedToRight[x2];
    }
    
    var dc = new DumpContainer().Dump("Rule110");
    
    for(int y = 1; y < arr.Length; y++)
    {
        dc.Content = y;
        
        for(int x = 0; x < arr[y].Length; x++)
        {
            arr[y][x] = Rule110(x, y);
        }
    }
    
    if(width > 1920)
        savePicture(arr);
    else
        showPicture(arr);
}

bool getBit(int x, int y)
{
    if(x < 0 || x >= width) return false;
    if(y < 0 || y >= width) return false;
    
    return arr[y][x];
}

bool Rule110(int x, int y)
{
    var l = getBit(x - 1, y - 1);
    var c = getBit(x, y - 1);
    var r = getBit(x + 1, y - 1);
    
    if(l & c & r)    return false;
    if(l & c & !r)   return true;
    if(l & !c & r)   return true;
    if(l & !c & !r)  return false;
    if(!l & c & r)   return true;
    if(!l & c & !r)  return true;
    if(!l & !c & r)  return true;
    if(!l & !c & !r) return false;
    
    throw new NotImplementedException("Unreachable");
}

void showText(bool[][] arr)
{
    var rez = new StringBuilder();
    
    var dc = new DumpContainer().Dump("showText");
    
    rez.Append("|");
    
    for(int y = 0; y < arr.Length; y++)
    {
        dc.Content = y;
        
        for(int x = 0; x < arr[0].Length; x++)
        {
            
            rez.Append(arr[y][x] ? "X" : ".");
        }
        
        rez.AppendLine("|");
        rez.Append("|");
    }
    
    rez.ToString().Dump();
}

void showPicture(bool[][] arr)
{
    var bmp = new Bitmap(width, width);
    
    bmp.fromGrayBytes(
        arr.SelectMany(i => i.Select(ii => (byte)(ii ? 0 : 255)))
    );
    bmp.Dump();
}

void savePicture(bool[][] arr)
{
    var bmp = new Bitmap(width, width);
    
    bmp.fromGrayBytes(
        arr.SelectMany(i => i.Select(ii => (byte)(ii ? 0 : 255)))
    );
    bmp.Save(@"c:\sp\Rule110.png");
}




