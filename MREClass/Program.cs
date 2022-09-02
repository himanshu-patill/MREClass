public class ManualResetEventClass
{
    private static ManualResetEvent ManualEvent = new ManualResetEvent(false);
    //private static EventWaitHandle ManualEvent = new EventWaitHandle(true, EventResetMode.ManualReset);


    public static void Main(String[] args)
    {

        for (int i = 0; i <= 2; i++)
        {
            Thread t = new Thread(ThreadProcedure);
            t.Name = "Thread_" + i;
            t.Start();
        }

        Thread.Sleep(500);
        Console.WriteLine("Press Enter to signal the waiting threads");
        Console.ReadLine();

        ManualEvent.Set();

        Thread.Sleep(500);
        ManualEvent.Reset();
    }


    private static void ThreadProcedure()
    {
        string name = Thread.CurrentThread.Name;

        Console.WriteLine(name + " starts and calls WaitOne()");

        ManualEvent.WaitOne();

        Console.WriteLine(name + " Released.");
        Thread.Sleep(500);
    }
}