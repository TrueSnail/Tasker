using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Runner();
        }

        static async Task Runner ()
        {
            var time = await Taker();

            Console.WriteLine(time.Minute);
            Task<DateTime> WaitForTaker = Taker();
            Console.WriteLine(time.Minute % 2 == 0 ? "Parzysta" : "NieParzysta");

            await Task.Delay(1000);
            Console.WriteLine("Waiting for Taker...");
            WaitForTaker.Wait();
            Console.WriteLine(WaitForTaker.GetAwaiter().GetResult());
            await Runner();
        }

        static async public Task<DateTime> Taker ()
        {
            DateTime CurrentDate = DateTime.Now;
            await Task.Delay(2000);
            return CurrentDate;
        }
    }
}
