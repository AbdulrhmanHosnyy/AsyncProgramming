namespace CA02TaskReturnsValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(GetCurrentDatetime);
            //Console.WriteLine(task.Result); // block thread until result is ready

            Console.WriteLine(task.GetAwaiter().GetResult());
            Console.ReadLine();
        }
        
        static DateTime GetCurrentDatetime() => DateTime.Now;   
    }
}