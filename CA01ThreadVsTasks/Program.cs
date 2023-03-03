using System;

namespace CA01ThreadVsTasks
{

    class program
    {
        static void Main(string[] args)
        {
            ///
            /// Diff between thread and task:
            /// thread                      task
            /// ---------------------------------------
            /// low level                   high level
            /// no thred pool               thread pool
            /// no return value             return value
            /// no chaining                 chaining
            /// no exception propgation     exception propgation
            /// fore and back ground        background
            /// no support cancellation     support cancellation
            ///
            var th = new Thread(() => Display("Hosny using thread !!!"));
            th.Start();
            th.Join();
           
            Task.Run(() => Display("Hosny using thread !!!")).Wait();
            Console.ReadLine();
        }
        
        static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}