using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        #region Bubble
        // A function to implement bubble sort
        static void bubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }

        // An optimized version of Bubble Sort
        static void bubbleSortO(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;

                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
        #endregion

        #region Selection
        static void selectionSort(int[] arr)
        {
            int tmp, min;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;
                    }
                }

                tmp = arr[i];
                arr[i] = arr[min];
                arr[min] = tmp;
            }
        }
        #endregion

        #region Inserion
        static void insertionSort(int[] arr)
        {
            int key, j;
            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        #region Sehll
        static void shellSort(int[] arr)
        {
            for (int gap = arr.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    int tmp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > tmp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = tmp;
                }
            }
        }
        #endregion

        #region Merge
        static int[] Merge(int[] arr1, int[] arr2)
        {
            int p1 = 0;
            int p2 = 0;
            int k = 0;

            int[] result = new int[arr1.Length + arr2.Length];

            while (p1 < arr1.Length && p2 < arr2.Length)
            {
                //result[k++] = arr1[p1] < arr2[p2] ? arr1[p1++] : arr2[p2++];
                if (arr1[p1] < arr2[p2])
                {
                    result[k++] = arr1[p1++];
                }
                else
                {
                    result[k++] = arr2[p2++];
                }
            }

            while (p1 < arr1.Length)
            {
                result[k++] = arr1[p1++];
            }

            while (p2 < arr2.Length)
            {
                result[k++] = arr2[p2++];
            }

            return result;
        }

        static int[] MergeSort(int[] arr)
        {
            if (arr.Length > 1)
            {
                var k = arr.Length / 2;
                int[] tmp1 = new int[k];
                int[] tmp2 = new int[arr.Length - k];
                Array.Copy(arr, tmp1, k);
                Array.Copy(arr, k, tmp2, 0, arr.Length - k);
                return Merge(MergeSort(tmp1), MergeSort(tmp2));
            }
            else
            {
                return arr;
            }

        }
        #endregion

        #region Quick
        static void QuickSort(int[] arr, int left, int right)//tablica, pierwszy indeks, ostatni indeks
        {
            var i = left;
            var j = right;
            var pivot = arr[(left + right) / 2];    //pivot na srodek
            while (i < j)
            {
                while (arr[i] < pivot)    //szukamy pierwszego elementu od lewej wiekszego od pivota
                {
                    i++;
                }

                while (arr[j] > pivot)  //szukamy pierwszego elementu od prawej mniejszego od pivota
                {
                    j--;
                }
                if (i <= j)             //Jezlie nie przekroczylismy srodka to je zamieniamy
                {
                    //swap
                    var tmp = arr[i];
                    arr[i++] = arr[j];
                    arr[j--] = tmp;
                }
            }
            if (left < j)           //warunki koncowe
            {
                QuickSort(arr, left, j);
            }
            if (i < right)
            {
                QuickSort(arr, i, right);
            }
        }
        #endregion

        #region Bucket
        static void bucketSort(int[] arr)
        {
            int min = arr.Min();
            int max = arr.Max();

            List<int>[] bucket = new List<int>[max - min + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - min].Add(arr[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                for (int j = 0; j < bucket[i].Count; j++)
                {
                    arr[k++] = bucket[i][j];
                }
            }
        }
        #endregion

        #region Counting
        static void CountingSort(int[] arr)
        {
            int max = arr.Max();
            int min = arr.Min();

            int[] count = new int[max - min + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }

            int z = 0;

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    arr[z] = i;
                    z++;
                }
            }
        }
        #endregion

        #region Radix
        static void radixSort(int[] arr, int podstawa = 10)
        {
            int[] B = new int[arr.Length];
            int max = arr.Max();
            int exp = 1;
            while (max / exp > 0)
            {
                int[] count = new int[podstawa];
                //zliczanie wartosci na pozycja
                for (int i = 0; i < arr.Length; i++)
                {
                    count[(arr[i] / exp) % podstawa]++;
                }
                for (int i = 1; i < count.Length; i++)
                {
                    count[i] += count[i - 1];
                }
                for (int i = arr.Length - 1; i >= 0; i--)   //trzeba od tyłu poniewaz z tyłu sa najwieksze liczby na pozycji wczesniej
                {
                    B[--count[(arr[i] / exp) % podstawa]] = arr[i];
                }
                Array.Copy(B, arr, arr.Length);
                exp *= podstawa;
            }
        }
        
        /*Niedziala
        static void radixSortmsd(int[] arr, int podstawa = 10)//LSD
        {
            int[] B = new int[arr.Length];
            int max = arr.Max();

            int rzad = 1;
            while ((rzad *= 10) < max) ;
            rzad /= 10;

            while (rzad > 0)
            {
                int[] count = new int[podstawa];
                //zliczanie wartosci na pozycja
                for (int i = 0; i < arr.Length; i++)
                {
                    count[(arr[i] / rzad) % podstawa]++;
                }
                for (int i = 1; i < count.Length; i++)
                {
                    count[i] += count[i - 1];
                }
                for (int i = 0; i < arr.Length; i++)
                //for (int i = 0; i < arr.Length; i++)    //trzeba od tyłu poniewaz z tyłu sa najwieksze liczby na pozycji wczesniej
                {
                    B[--count[(arr[i] / rzad) % podstawa]] = arr[i];
                }
                Array.Copy(B, arr, arr.Length);
                rzad /= podstawa;
            }
        }
        */

        static void radixSort2(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            int[] arr = { 64, 25, 12, 22, 11 };
            int[] arrTmp;

            Console.WriteLine("bubbleSort");
            arrTmp = (int[])arr.Clone();
            bubbleSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("bubbleSort");
            arrTmp = (int[])arr.Clone();
            bubbleSortO(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("selectionSort");
            arrTmp = (int[])arr.Clone();
            selectionSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("insertionSort");
            arrTmp = (int[])arr.Clone();
            insertionSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("shellSort");
            arrTmp = (int[])arr.Clone();
            shellSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("MergeSort");
            arrTmp = (int[])arr.Clone();
            arrTmp = MergeSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("QuickSort");
            arrTmp = (int[])arr.Clone();
            QuickSort(arrTmp, 0, arrTmp.Length - 1);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("bucketSort");
            arrTmp = (int[])arr.Clone();
            bucketSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("CountingSort");
            arrTmp = (int[])arr.Clone();
            CountingSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.WriteLine("radixSortLsd");
            arrTmp = (int[])arr.Clone();
            radixSort(arrTmp);
            Console.WriteLine(string.Join(" ", arrTmp));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
