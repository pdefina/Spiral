using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Spiral
{

    public static class Spiral
    {
        /// <summary>
        /// Takes a Two Dimensional Array and does a Clockwise spiral on it
        /// </summary>
        /// <param name="TDArray">Must be a Two Dimensional Array</param>
        /// <returns> List<int> </returns>
        public static List<int> SpiralIt(int[,] TDArray)
        {
            int rsi = 0; // Row Start Index 
            int csi = 1; // Column Start Index
            int rei = TDArray.GetLength(0); // Row End Index
            int cei = TDArray.GetLength(1); // Column End Index
            int i = rsi;
            List<int> outList = new List<int>();

            if(rei != cei)
            {
                Assert.AreEqual(rei, cei, "The number of rows and columns in the Array must be equal!");
            }

            while (rsi < rei && csi < cei)
            {
                // left to right
                for (i = rsi; i < rei; i++)
                {
                    outList.Add(TDArray[rsi, i]);
                }
                rsi++;

                // Down
                for (i = csi; i < cei; i++)
                {
                    outList.Add(TDArray[i, cei - 1]);
                }
                cei--;

                // Right to left
                for (i = rei - 2; i >= rsi - 1; i--)
                {
                    outList.Add(TDArray[rei - 1, i]);
                }
                rei--;

                // Up
                for (i = cei - 1; i >= csi; i--)
                {
                    outList.Add(TDArray[i, csi - 1]);
                }
                csi++;
            }
            return outList;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Made the data a little more interesting
            int[,] array = new int[,]   { { 1, 2, 3, 4  },
                                          { 5, 6, 7, 8  },
                                          { 9, 10,11,12 },
                                          {13, 14,15,16 }};

            string expectedData = "1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10";

            List<int> spiralList = Spiral.SpiralIt(array);

            // Convert to a string for easy printing and testing
            string actualData = string.Join(" ", spiralList.ToArray());

            Console.WriteLine(actualData);

            // Verify
            Assert.AreEqual(expectedData, actualData);

        }
    }
}
