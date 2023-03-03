namespace CA012ConcurrencyAndParallelism
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var things = new List<DailyDuty>
            {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Going out")
            };

            //Console.WriteLine("Using Parallel Processing");
            //await ProcessThingsInParallel(things);

            Console.WriteLine("Using Concurrent Processing");
            await ProcessThingsInConcurrent(things);

            Console.ReadLine(); 
        }

        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things, things => things.Process());
            return Task.CompletedTask;
        }

        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }
            return Task.CompletedTask;
        }
    }
    class DailyDuty
    {
        public string title { get; set; }

        public bool Processed { get; private set; } 
        public DailyDuty(string title)
        {
            this.title = title;
        }

        public void Process()
        {
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}, ProccessorId: {Thread.GetCurrentProcessorId()}");
            Task.Delay(1000).Wait();
            this.Processed = true;  
        }
    }
}