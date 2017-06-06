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

var rand = new Random();

string[,][][] forthD = new string[5, 3][][];

int[,] tst = new int[5, 3];

for(int z1 = 0; z1 < 5; z1++)
for(int z2 = 0; z2 < 3; z2++)
{
    tst[z1, z2] = 5;//new{ dt = DateTime.Now.AddSeconds(rand.Next(3000)) };
    
    forthD[z1, z2] = new int[6].Select
    ((i3, z3) =>
        new int[2].Select
        ((i4, z4) =>
            $"{z1}:{z2}:{z3}:{z4} = {1 + rand.Next(10)}"
        ).ToArray()
    ).ToArray();
}

tst.Dump();

forthD.Dump();