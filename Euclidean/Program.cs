using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidean
{
    class Program
    {
        //In the subtraction-based version
        static int gcd1(int m, int n)
        {
            while (n > 0)
            {
                if (m > n)
                {
                    int tmp = m;
                    m = n;
                    n = tmp;
                }
                n -= m;
            }
            return m;
        }

        //the division-based version
        static int gcd2(int m, int n)
        {
            while (n > 0)
            {
                int tmp = m;
                m = n;
                n = tmp % n;
            }
            return m;
        }

        //The recursive version[
        static int gcd3(int m, int n)
        {
            if (n == 0)
            {
                return m;
            }
            return gcd3(n, m % n);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(gcd1(5, 15));
            Console.WriteLine(gcd2(5, 15));
            Console.WriteLine(gcd3(5, 15));

            Console.WriteLine(gcd1(12, 16));
            Console.WriteLine(gcd2(12, 16));
            Console.WriteLine(gcd3(12, 16));

            Console.ReadKey();
        }
    }
}
