using System;

namespace CA06TaskDelay
{

    class program
    {
        static void Main(string[] args)
        {
            DelayUsingTask(5000);

            Console.ReadLine();
        }

        static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Completed after Task.Dealy({ms})");
            }
            );
        }
        static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed after Thread.Sleep({ms})");

        }
    }
}