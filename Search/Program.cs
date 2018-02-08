using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Program
    {
        public static int BinarySearchRecursion(int[] arr, int x, int start, int end)
        {
            if (start == end)
            {
                if (arr[start] == x)
                {
                    return start;
                }
                return -1;
            }
            int middle = start + (end - start) / 2;
            if (x > arr[middle])
            {
                return BinarySearchRecursion(arr, x, middle + 1, end);
            }
            return BinarySearchRecursion(arr, x, start, middle);
        }

        public static int BinarySearchIteration(int[] arr, int x)
        {
            int i = 0;
            int j = arr.Length - 2;
            int jest = -1;

            while (i < j)
            {
                int k = (i + j) / 2;

                if (x > arr[k])
                    i = k + 1;
                else
                    j = k;
            }
            if (arr[j] == x)
            {
                jest = j;
            }

            return jest;
        }


        static void Main(string[] args)
        {
            int[] tab = Enumerable.Range(1, 100).ToArray();

            Console.WriteLine(BinarySearchIteration(tab, 60));
            Console.WriteLine(BinarySearchRecursion(tab, 60, 0, tab.Length - 1));

            Console.ReadKey();
        }
    }
}
