<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	TstFrm_Load();
}

private void TstFrm_Load()
{
  Console.WriteLine("mn id = " + Thread.CurrentThread.ManagedThreadId);

  var factory = new TaskFactory(new MyTskSchduler());

  //new Task().Start(new MyTskSchduler());

  Console.WriteLine(WebRequest.GetSystemWebProxy().GetProxy(new Uri("http://google.com")));

  var clt = new HttpClient(new HttpClientHandler() { Proxy = new WebProxy(WebRequest.GetSystemWebProxy().GetProxy(new Uri("http://google.com"))) { UseDefaultCredentials = true }, });

  factory.StartNew(() =>
      {
          Thread.Sleep(2000);

          Console.WriteLine("out id = " + Thread.CurrentThread.ManagedThreadId);
          Task.Factory.StartNew(() =>
              {
                  Console.WriteLine("in id = " + Thread.CurrentThread.ManagedThreadId);
              });

          Console.WriteLine("send");

          var rez = clt.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://google.com")).Result;

          Console.WriteLine("read");

          var strm = new StreamReader(rez.Content.ReadAsStreamAsync().Result, Encoding.UTF8);

          ("rez is:--------------" + Environment.NewLine + strm.ReadToEnd()  + Environment.NewLine + "----------------").Dump();
      });
}

private void button1_Click(object sender, EventArgs e)
{
  Console.WriteLine();
}

class MyTskSchduler : TaskScheduler
{
   Random rand = new Random();

   protected override IEnumerable<Task> GetScheduledTasks()
   {
       Console.WriteLine("asked for tasks");

       yield break;
   }

   protected override void QueueTask(Task task)
   {
       int id = rand.Next(256);

       Console.WriteLine("My sched " + id.ToString("X").PadLeft(2, '0') + " start ");

       new Thread(() =>
           base.TryExecuteTask(task)
           ).Start()
       ;

       Console.Write("My sched " + id.ToString("X") + " " + task.Status);

       Console.WriteLine(" | trd id = " + Thread.CurrentThread.ManagedThreadId);
   }

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
       Console.WriteLine("is inline");

       return false;
   }
}