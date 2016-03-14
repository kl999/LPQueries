<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
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
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
    var main = new FlowLayoutPanel().Dump();
    main.FlowDirection = FlowDirection.TopDown;//LeftToRight;
    
    var tbarr = new TextBox[10];
    
    for(int i = 0; i < 10; i++)
    {
        tbarr[i] = new TextBox();
        
        tbarr[i].Parent = main;
        
        tbarr[i].Width = 200;
        
        //tbarr[i].AutoSize = true;
    }
    
    var btn = new Button();
    btn.Text = "Hello";
    btn.Click += (a, i) => 
    {
        foreach(var tb in tbarr)
        {
            tb.Text += "World ! ! !";
        }
    };
    btn.Parent = main;
    
    //new mf().ShowDialog();
    
    "qwe".Dump();
    
    var pb = new PictureBox();
    pb.Image = new Bitmap(@"c:\sp\1.png");
    pb.Parent = main;
    pb.Size = new Size(192, 108);
    pb.SizeMode = PictureBoxSizeMode.Zoom;
    
//    btn.Parent = null;
//    btn.Parent = main;
    
    var btn2 = new Button();
    btn2.Text = "Hide me";
    btn2.Click += (a, i) => 
    {
        btn2.Parent = null;
    };
    btn2.Parent = main;
    
    var btn3 = new Button();
    btn3.Text = "Loads of TBs<!>";
    btn3.AutoSize = true;
    btn3.Click += (a, o) => 
    {
        var tbarr2 = new TextBox[1000];
    
        for(int i = 0; i < 1000; i++)
        {
            tbarr2[i] = new TextBox();
            
            tbarr2[i].Parent = main;
            
            tbarr2[i].Width = 200;
            
            Thread.Sleep(500);
        }
    };
    btn3.Parent = main;
}

class mf : Form
{
    public mf()
    {
        
    }
}