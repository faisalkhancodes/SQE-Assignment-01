using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchLibrary.Models;
using SearchLibrary;

namespace SearchLibrary.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        // --- MC/DC Tests for Order Logic ---
        [DataTestMethod]
        [DataRow(true, 1500.0, "Processed High Value")] // (T, T) -> Processed High Value
        [DataRow(true, 500.0, "Processed")]            // (T, F) -> Processed
        [DataRow(false, -10.0, "Invalid Amount")]       // (F, T) -> Invalid Amount
        [DataRow(false, 50.0, "Pending")]              // (F, F) -> Pending
        public void Order_Status_MCDC_Test(bool isProcessed, double amount, string expected)
        {
            var order = new Order { OrderId = 1, IsProcessed = isProcessed, TotalAmount = amount };
            string result = order.GetOrderStatus();
            Assert.AreEqual(expected, result);
        }

        // --- All-Paths Coverage for Search Algorithms ---
        
        [TestMethod]
        public void BinarySearch_AllPaths()
        {
            int[] sortedArr = { 10, 20, 30, 40, 50 };
            
            // Path 1: Found
            Assert.AreEqual(2, SearchAlgorithms.BinarySearch(sortedArr, 30));
            
            // Path 2: Not Found (Target smaller than min)
            Assert.AreEqual(-1, SearchAlgorithms.BinarySearch(sortedArr, 5));
            
            // Path 3: Not Found (Target larger than max)
            Assert.AreEqual(-1, SearchAlgorithms.BinarySearch(sortedArr, 60));

            // Path 4: Empty Array
            Assert.AreEqual(-1, SearchAlgorithms.BinarySearch(new int[] { }, 5));
        }

        [TestMethod]
        public void LinearSearch_AllPaths()
        {
            int[] arr = { 5, 3, 8, 1 };
            
            // Path 1: Found
            Assert.AreEqual(2, SearchAlgorithms.LinearSearch(arr, 8));
            
            // Path 2: Not Found
            Assert.AreEqual(-1, SearchAlgorithms.LinearSearch(arr, 10));

            // Path 3: Empty Array
            Assert.AreEqual(-1, SearchAlgorithms.LinearSearch(new int[] { }, 5));
        }

        [TestMethod]
        public void JumpSearch_AllPaths()
        {
            int[] sortedArr = { 1, 3, 5, 7, 9, 11, 13, 15 };
            
            // Path 1: Found
            Assert.AreEqual(4, SearchAlgorithms.JumpSearch(sortedArr, 9));
            
            // Path 2: Not Found
            Assert.AreEqual(-1, SearchAlgorithms.JumpSearch(sortedArr, 2));

            // Path 3: Not Found (Exceeds array bounds)
            Assert.AreEqual(-1, SearchAlgorithms.JumpSearch(sortedArr, 20));

            // Path 4: Empty array
            Assert.AreEqual(-1, SearchAlgorithms.JumpSearch(new int[] { }, 5));
        }
    }
}
