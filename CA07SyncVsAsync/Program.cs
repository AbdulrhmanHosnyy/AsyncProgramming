namespace CA07SyncVsAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, 7);
            CallSynchronous();

            ShowThreadInfo(Thread.CurrentThread, 10);
            CallAsynchronous();

            ShowThreadInfo(Thread.CurrentThread, 13);

            Console.ReadLine();
        }
        static void CallSynchronous()
        {
            Thread.Sleep(4000);
               ShowThreadInfo(Thread.CurrentThread, 20);
            Task.Run(() => Console.WriteLine("+++++++ Synchronous ++++++++")).Wait();
        }
        static void CallAsynchronous()
        {
            ShowThreadInfo(Thread.CurrentThread, 25);
            Task.Delay(4000).GetAwaiter().OnCompleted(() => Console.WriteLine("+++++++ Asynchronous ++++++++"));
        }
        static void ShowThreadInfo(Thread th, int line)
        {
            Console.WriteLine($"Line#: {line}, TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}