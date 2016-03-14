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
    var z = new a();
    
    z.block();
    
    z.packet.a = 4;
    
    z.packet.a.Dump();
}

class a
{
    object locker = new object();
    
    public ShowPacket packet
    {
        get
        {
            lock(locker)
                return _packet;
        }
        set
        {
            lock(locker)
                _packet = value;
        }
    }

    ShowPacket _packet = new ShowPacket();
    
    public void block()
    {
        Task.Run(() =>
        {
            lock(locker)
            {
                for(;;)
                {
                    int i = 4;
                }
            }
        });
    }
}

class ShowPacket
{
    public int a = 3;
}