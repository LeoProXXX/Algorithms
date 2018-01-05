using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knappsnack
{
    class Program
    {
        /// <summary>
        /// Bottom-Up Dynamic Programming
        /// code adapted from
        /// http://www.programminglogic.com/knapsack-problem-dynamic-programming-algorithm/
        /// </summary>
        /// <param name="nItems">index of the item you need to decide to take or not(we start with the last element of the array and we work toward the first)  -   Ile jest przedmitów</param>
        /// <param name="knapsnackSize">size still available at the backpack    -   rozmiar cholernego plecaka</param>
        /// <param name="weights">array with the weights of all items   -   tablica z wagami przedmitow</param>
        /// <param name="values">array with the values of all items -   wartosci tychże przedmiotów</param>
        /// <returns>max wartosc która wejdzie do plecaka</returns>
        ///     Tablica matrix dla tego przypadku
        ///     X|  0   1   2   3   4   5   6   7   8   9   10  -   Wagi od 0 do pojemnosc lecaka
        ///     0|  0   0   0   0   0   0   0   0   0   0   0
        ///     1|  0   0   0   0   0   10  10  10  10  10  10
        ///     2|  0   0   0   0   40  40  40  40  40  50  50
        ///     3|  0   0   0   0   40  40  40  40  40  50  70
        ///     4|  0   0   0   50  50  50  50  90  90  90  90
        ///     ^
        ///     |
        ///     indeksyprzedmiotów
        static int knapsnackDynamicProg(int nItems, int knapsnackSize, int[] weights, int[] values)
        {
            int[,] matrix = new int[nItems + 1, knapsnackSize + 1]; //tablica do obliczania pierwszy wiersz kolumna same zera dla lepsiejszych obliczen

            for (int i = 1; i <= nItems; i++)//iterujem po wszystkich elementach przypomina pierwszy wiersz same  zera  -   przedmiotu
            {
                for (int j = 1; j <= knapsnackSize; j++)    // to smo dla wartosci - wartosci
                {
                    if (weights[i - 1] <= j)                //jezeli waga przedmiotu ktory sprawdzamy miesci sie to mamy przesrane i trzeba liczyc
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], values[i - 1] + matrix[i - 1, j - weights[i - 1]]);   //  biezemy maxa z (wczesniejszyego przedmiotu  ,   wartosci sprawdzanego przedmiotu i tego co sie jeszcze zmiesci jezeli wezmiem ten przedmiot)
                    }
                    else                                    //jezeli nie to biezemy wyniki z przedmiotu wczesniejszego
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
            return matrix[nItems, knapsnackSize];
        }

        static int knapsnackDynamicProgWithPicks(int nItems, int knapsnackSize, int[] weights, int[] values, int[,] picks)
        {
            int[,] matrix = new int[nItems + 1, knapsnackSize + 1]; //tablica do obliczania pierwszy wiersz kolumna same zera dla lepsiejszych obliczen

            for (int i = 1; i <= nItems; i++)//iterujem po wszystkich elementach przypomina pierwszy wiersz same  zera  -   przedmiotu
            {
                for (int j = 1; j <= knapsnackSize; j++)    // to smo dla wartosci - wartosci
                {
                    if (weights[i - 1] <= j)                //jezeli waga przedmiotu ktory sprawdzamy miesci sie to mamy przesrane i trzeba liczyc
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], values[i - 1] + matrix[i - 1, j - weights[i - 1]]);   //  biezemy maxa z (wczesniejszyego przedmiotu  ,   wartosci sprawdzanego przedmiotu i tego co sie jeszcze zmiesci jezeli wezmiem ten przedmiot)
                        if (values[i - 1] + matrix[i - 1, j - weights[i - 1]] > matrix[i - 1, j])
                        {
                            picks[i, j] = 1;
                        }
                        else
                        {
                            picks[i, j] = -1;
                        }
                    }
                    else                                    //jezeli nie to biezemy wyniki z przedmiotu wczesniejszego
                    {
                        picks[i, j] = -1;
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }
            return matrix[nItems, knapsnackSize];
        }

        static void printPicks(int nItems, int knapsnackSize, int[] weights, int[,] picks)
        {

            while (nItems > 0)
            {
                if (picks[nItems, knapsnackSize] == 1)
                {
                    Console.WriteLine(nItems - 1);
                    nItems--;
                    knapsnackSize -= weights[nItems];
                }
                else
                {
                    nItems--;
                }
            }

            return;
        }

        static void Main(string[] args)
        {
            int nItems = 4;
            int knapsnackSize = 10;
            int[] weights = { 5, 4, 6, 3 };
            int[] values = { 10, 40, 30, 50 };

            Console.WriteLine(knapsnackDynamicProg(nItems, knapsnackSize, weights, values));

            int[,] picks = new int[nItems + 1, knapsnackSize + 1];
            Console.WriteLine(knapsnackDynamicProgWithPicks(nItems, knapsnackSize, weights, values, picks));
            Console.WriteLine("Picks were:");
            printPicks(nItems, knapsnackSize, weights, picks);

            Console.ReadKey();
        }
    }
}
