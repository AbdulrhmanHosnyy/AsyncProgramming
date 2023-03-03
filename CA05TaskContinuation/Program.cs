namespace CA05TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine( CountPrimeNumberInARange(2, 2_000_000));

            Task<int> task = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));
            // -- 1 --
            //Console.WriteLine(task.Result); // BAD!! it blocks the thread

            // -- 2 --
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>{
            //    Console.WriteLine(awaiter.GetResult()); // block the thread but task is completed
            //});

            // -- 3 --
            task.ContinueWith((x) => Console.WriteLine(x.Result));
            Console.WriteLine("Hosny");

            Console.ReadLine();
        }

        static int CountPrimeNumberInARange(int lowerBound, int upperBound)
        {
            var count = 0;
            for (int i = lowerBound; i < upperBound; i++)
            {
                var j = 2;
                var isPrime = true;
                while(j <= (int)Math.Sqrt(i))
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if(isPrime) count++;
            }
            return count;
        }
    }
}