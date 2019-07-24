namespace TCPLib
{
    public class NewClientEventArgs
    {
        public MyTCPClient client;

        public NewClientEventArgs(MyTCPClient myClt)
        {
            this.client = myClt;
        }
    }
}