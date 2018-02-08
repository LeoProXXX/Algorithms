using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void BinarySearchIteration_ArraysContainsValue_ReturnIndexOfValue()
        {
            int[] arrAscending = Enumerable.Range(1, 100).ToArray();
            int expectedValue = Array.IndexOf(arrAscending, 60);
            int actualValue = Search.Program.BinarySearchIteration(arrAscending, 60);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void BinarySearchIteration_ArraysDoNotContainsValue_ReturnMinusOne()
        {
            // Less than min value in array
            int[] arrAscending1 = Enumerable.Range(1, 100).ToArray();
            int expectedValue = Array.IndexOf(arrAscending1, -10);
            int actualValue = Search.Program.BinarySearchIteration(arrAscending1, -10);
            Console.WriteLine(actualValue);
            Assert.AreEqual(expectedValue, actualValue);

            // Greater than min value in array
            int[] arrAscending2 = Enumerable.Range(1, 100).ToArray();
            int expectedValue2 = Array.IndexOf(arrAscending2, 110);
            int actualValue2 = Search.Program.BinarySearchIteration(arrAscending2, 110);
            Console.WriteLine(actualValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void BinarySearchRecursion_ArraysContainsValue_ReturnIndexOfValue()
        {
            int[] arrAscending = Enumerable.Range(1, 100).ToArray();
            int expectedValue = Array.IndexOf(arrAscending, 60);
            int actualValue = Search.Program.BinarySearchRecursion(arrAscending, 60, 0, arrAscending.Length - 1);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void BinarySearchRecursion_ArraysDoNotContainsValue_ReturnMinusOne()
        {
            // Less than min value in array
            int[] arrAscending1 = Enumerable.Range(1, 100).ToArray();
            int expectedValue = Array.IndexOf(arrAscending1, -10);
            int actualValue = Search.Program.BinarySearchRecursion(arrAscending1, -10, 0, arrAscending1.Length - 1);
            Console.WriteLine(actualValue);
            Assert.AreEqual(expectedValue, actualValue);

            // Greater than min value in array
            int[] arrAscending2 = Enumerable.Range(1, 100).ToArray();
            int expectedValue2 = Array.IndexOf(arrAscending2, 110);
            int actualValue2 = Search.Program.BinarySearchRecursion(arrAscending2, 110, 0, arrAscending2.Length - 1);
            Console.WriteLine(actualValue);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
