namespace CA09CancellationToken
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            //await DoCheck01(cts);
            //await DoCheck02(cts);
            await DoCheck03(cts);

            Console.ReadLine();
        }

        static async Task DoCheck01(CancellationTokenSource cts)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if(input.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });
            while(!cts.Token.IsCancellationRequested)
            {
                Console.Write("Checking...");
                await Task.Delay(4000);
                Console.WriteLine($"Completed on{DateTime.Now}");
                Console.WriteLine();
            }
            Console.WriteLine("Check was Terminated");
        }

        static async Task DoCheck02(CancellationTokenSource cts)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });
            while (true)
            {
                Console.Write("Checking...");
                await Task.Delay(4000, cts.Token);
                Console.WriteLine($"Completed on{DateTime.Now}");
                Console.WriteLine();
            }
            Console.WriteLine("Check was Terminated");
        }

        static async Task DoCheck03(CancellationTokenSource cts)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });
            try
            {


                while (true)
                {
                    cts.Token.ThrowIfCancellationRequested();
                    Console.Write("Checking...");
                    await Task.Delay(4000);
                    Console.WriteLine($"Completed on{DateTime.Now}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Check was Terminated"); 
        }


    }
}