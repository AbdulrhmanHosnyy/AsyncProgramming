namespace CA03LongRunningTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() => RunLongTask(), TaskCreationOptions.LongRunning);
            ShowThreadInfo(Thread.CurrentThread);
            Console.ReadLine();
        }

        static void RunLongTask()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Completed");
        }
        static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}