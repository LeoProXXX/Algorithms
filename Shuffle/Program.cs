using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    public class Program
    {
        static List<int> FisherYates(List<int> arr)
        {
            var result = new List<int> { };
            var r = new Random();

            while (arr.Count > 0)
            {
                var i = r.Next(arr.Count);
                result.Add(arr[i]);
                arr.RemoveAt(i);
            }

            return result;
        }

        public static void Durstenfeld(int[] arr)
        {
            var r = new Random();

            foreach (var i in Enumerable.Range(1, arr.Length - 1).Reverse())
            {
                var j = r.Next(i + 1);
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }

        public static void KnuthShuffle<T>(T[] arr)
        {
            var random = new Random();
            for (var i = 1; i < arr.Length; ++i)
            {
                var j = random.Next(i + 1);
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }

        static void Main(string[] args)
        {
            foreach (var item in FisherYates(new List<int> { 1, 2, 3 }))
            {
                Console.Write("{0}\t", item);
            }

            var tab1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Durstenfeld(tab1);

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", tab1));

            var tab2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            KnuthShuffle(tab2);

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", tab2));


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
