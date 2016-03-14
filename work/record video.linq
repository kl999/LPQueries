<Query Kind="Program">
  <Reference>D:\Документы\TrafficVideoCount\TrafficVideoCount\dll\AForge.Controls.dll</Reference>
  <Reference>D:\Документы\TrafficVideoCount\TrafficVideoCount\dll\AForge.dll</Reference>
  <Reference>D:\Документы\TrafficVideoCount\TrafficVideoCount\dll\AForge.Video.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
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
	AForge.Video.MJPEGStream stream;

    AForge.Controls.VideoSourcePlayer player;

	stream = new AForge.Video.MJPEGStream(@"http://81.17.175.181/mjpg/video.mjpg");
	
	player = new AForge.Controls.VideoSourcePlayer();
	
	player.VideoSource = stream;
	
	player.NewFrame += player_NewFrame;
	
	player.Start();
	
	Console.ReadLine();
	
	player.Stop();
	
	player.Dispose();
}

int ct = 0;

void player_NewFrame(object sender, ref Bitmap image)
{
	image.Save(@"c:\sp\video\vid" + ct++ + ".png");
}