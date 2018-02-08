using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class SortingsTests
    {
        int length = 100;
        int minValue = 0;

        int[] arrAscending;
        int[] arrDescending;
        int[] arrRandom;
        int[] arrPredefined1 = { 64, 25, 12, 22, 11 };

        int[] arrAscendingExpected;
        int[] arrDescendingExpected;
        int[] arrRandomExpected;
        int[] arrPredefined1Expected = { 11, 12, 22, 25, 64 };

        [TestInitialize]
        public void Init()
        {
            // Ascending arrray
            arrAscending = Enumerable.Range(minValue, length).ToArray();
            arrAscendingExpected = (int[])arrAscending.Clone();
            Array.Sort(arrAscendingExpected);

            // Descending arrray
            arrDescending = Enumerable.Range(minValue, length).Reverse().ToArray();
            arrDescendingExpected = (int[])arrDescending.Clone();
            Array.Sort(arrDescendingExpected);

            // Random array
            arrRandom = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < arrRandom.Length; i++)
            {
                arrRandom[i] = rnd.Next(minValue, 200);
            }
            arrRandomExpected = (int[])arrRandom.Clone();
            Array.Sort(arrRandomExpected);

            Console.WriteLine("Random array:");
            Console.WriteLine(string.Join(" ", arrRandom));
        }

        [TestMethod]
        public void BubbleSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.BubbleSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.BubbleSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.BubbleSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.BubbleSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void SelectionSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.SelectionSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.SelectionSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.SelectionSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.SelectionSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void InsertionSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.InsertionSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.InsertionSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.InsertionSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.InsertionSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void ShellSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.ShellSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.InsertionSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.ShellSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.ShellSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void MergeSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            actualArrAscending = Sorting.Program.MergeSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            actualArrDescending = Sorting.Program.MergeSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            actualArrRandom = Sorting.Program.MergeSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            actualArrPredefined1Expected = Sorting.Program.MergeSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void QuickSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.QuickSort(actualArrAscending, 0, actualArrAscending.Length - 1);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.QuickSort(actualArrDescending, 0, actualArrDescending.Length - 1);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.QuickSort(actualArrRandom, 0, actualArrRandom.Length - 1);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.QuickSort(actualArrPredefined1Expected, 0, actualArrPredefined1Expected.Length - 1);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void BucketSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.BucketSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.BucketSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.BucketSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.BucketSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void CountingSort()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.CountingSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.CountingSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.CountingSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.CountingSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }

        [TestMethod]
        public void RadixSortLsd()
        {
            int[] actualArrAscending = (int[])arrAscending.Clone();
            Sorting.Program.RadixSort(actualArrAscending);
            Assert.IsTrue(actualArrAscending.SequenceEqual(arrAscendingExpected));

            int[] actualArrDescending = (int[])arrDescending.Clone();
            Sorting.Program.RadixSort(actualArrDescending);
            Assert.IsTrue(actualArrDescending.SequenceEqual(arrDescendingExpected));

            int[] actualArrRandom = (int[])arrRandom.Clone();
            Sorting.Program.RadixSort(actualArrRandom);
            Assert.IsTrue(actualArrRandom.SequenceEqual(arrRandomExpected));

            int[] actualArrPredefined1Expected = (int[])arrPredefined1.Clone();
            Sorting.Program.RadixSort(actualArrPredefined1Expected);
            Assert.IsTrue(actualArrPredefined1Expected.SequenceEqual(arrPredefined1Expected));
        }
    }
}
