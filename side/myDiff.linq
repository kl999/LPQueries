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
    var dirL = @"C:\Users\samartsev\Desktop\left";
    var dirR = @"C:\Users\samartsev\Desktop\right";
    
    var left = new DirectoryInfo(dirL).GetFiles();
    var right = new DirectoryInfo(dirR).GetFiles();
    
    var enc = Encoding.GetEncoding(1251);
    
    foreach(var lf in left)
    {
        foreach(var rf in right)
            if(lf.Name == rf.Name)
            {
                var difs = getDifs(File.ReadAllLines(lf.FullName, enc), File.ReadAllLines(rf.FullName, enc));
                
                if(!(difs[0].Length == 0 && difs[1].Length == 0))
                {
                    Console.WriteLine($"\n\n-----{lf.Name}-----\n");
                    Console.WriteLine($"left:");
                    Console.WriteLine(string.Join("\n", difs[0]));
                    Console.WriteLine($"\nright:");
                    Console.WriteLine(string.Join("\n", difs[1]));
                }
                
                break;
            }
    }
}

string[][] getDifs(string[] one, string[] two)
{
    bool[] oneFlags = new bool[one.Length].Select(i => false).ToArray();
    bool[] twoFlags = new bool[two.Length].Select(i => false).ToArray();
    
    for(int i = 0; i < one.Length; i++)
    {
        for(int j = 0; j < one.Length; j++)
        {
            if(!twoFlags[j] && one[i] == two[j])
            {
                oneFlags[i] = twoFlags[j] = true;
                
                break;
            }
        }
    }
    
    return new[]{ one.Where((i, ind) => !oneFlags[ind]).ToArray(), two.Where((i, ind) => !twoFlags[ind]).ToArray() };
}