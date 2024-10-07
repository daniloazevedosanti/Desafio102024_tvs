using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeExtension
{
    class Program
    {
        async static Task Main(string[] args)
        {          
			Random randNum = new Random();
			Queue<int> Fila = new Queue<int>();
            for (int i = 1; i<=100; i++) {
                Fila.Enqueue(randNum.Next(0, 100)); 
            }

			foreach (var joy in Fila.Batch(2).Select((datum, Idx) => (datum, Idx)))
            {
                List<Task> tasks = new List<Task>();

                foreach (var hello in joy.datum.Select((Delay, Jdx) => (Delay, Jdx)))
                {
                    int index = (joy.Idx * 3) + hello.Jdx;

                    tasks.Add(Task.Run(async () =>
                    {
						Random taskDelay = new Random();
                        var delay = taskDelay.Next(0, 5);
						Console.WriteLine($"ID: {joy.Idx} {index}: Delaying: {delay}");
						
						await Task.Delay(delay*1000);//(hello.Delay);

                        Console.WriteLine($"{index}: Done");
                    }));
                }

                await Task.WhenAll(tasks);
            }

            Console.WriteLine("All Done");
        }
    }

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int maxItems)
        {
            return items.Select((item, idx) => new { item, idx })
                        .GroupBy(x => x.idx / maxItems)
                        .Select(g => g.Select(x => x.item));
        }
    }


}