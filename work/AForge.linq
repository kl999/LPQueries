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

System.Windows.Forms.PictureBox pb;

void Main()
{
	AForge.Video.MJPEGStream stream;

    AForge.Controls.VideoSourcePlayer player;

	stream = new AForge.Video.MJPEGStream("http://81.17.162.21/mjpg/video.mjpg?streamprofile=count");
	
	player = new AForge.Controls.VideoSourcePlayer();
	
	player.VideoSource = stream;
	
	player.NewFrame += player_NewFrame;
	
	pb = new System.Windows.Forms.PictureBox();
	
	pb.Location = new System.Drawing.Point(12, 12);
	pb.Name = "pb";
	pb.Size = new System.Drawing.Size(500, 500);
	pb.TabIndex = 0;
	pb.TabStop = false;
	
	pb.Dump();
	
	player.Start();
	
	Task.Run(() =>
	{
		Console.ReadLine();
		
		//Task.Delay(5000).Wait();
		
		//player.Dump("pl");
		
		player.Stop();
		
		player.Dispose();
	});
}

void player_NewFrame(object sender, ref Bitmap image)
{
	//image.Dump();
	
	pb.Image = new Bitmap(image);
}