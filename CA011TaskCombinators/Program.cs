namespace CA011TaskCombinators
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var has1000subscriberTask = Task.Run(() => Has1000Subscriber());
            var has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());
            //Console.WriteLine("Using WhenAny()");
            //Console.WriteLine("-----------------");
            //var any = await Task.WhenAny(has1000subscriberTask, has4000ViewHoursTask);
            //Console.WriteLine(any.Result);

            Console.WriteLine("Using WhenAll()");
            Console.WriteLine("-----------------");
            var all = await Task.WhenAll(has1000subscriberTask, has4000ViewHoursTask);
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static Task<string> Has1000Subscriber()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("Congratulation !! you have 1000 subscribers");
        }

        static Task<string> Has4000ViewHours()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("Congratulation !! you have 4000 view hours");
        }
    }
}