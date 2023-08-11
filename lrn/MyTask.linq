<Query Kind="Program">
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    Console.WriteLine(await AwaitThis());

    Console.WriteLine("End.");
    Console.ReadLine();
}

static B AwaitThis()
{
    return new B();
}

public class B
{
    public MyAwaiter GetAwaiter()
    {
        var awaiter = new MyAwaiter();

        Task.Delay(2000).ContinueWith((tsk) => awaiter.Complet());

        return awaiter;
    }
}

public class MyAwaiter : ICriticalNotifyCompletion
{
    public bool IsCompleted
    {
        get
        {
            return _isCompleted;
        }
    }
    private bool _isCompleted = false;

    private Action? continuation;

    public void Complet()
    {
        _isCompleted = true;

        Console.WriteLine(">c<");

        if (continuation is not null) continuation();
    }

    public string GetResult()
    {
        return "asd";
    }

    public void OnCompleted(Action continuation)
    {
        this.continuation = continuation;
    }

    public void UnsafeOnCompleted(Action continuation)
    {
        OnCompleted(continuation);
    }
}
