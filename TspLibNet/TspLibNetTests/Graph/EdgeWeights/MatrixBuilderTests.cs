using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TspLibNet.Graph.EdgeWeights;

namespace TspLibNetTests.Graph.EdgeWeights
{
    [TestClass]
    public class MatrixBuilderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildFromFullMatrix_DimensionsDoesNotFitInputData_ThrowsException()
        {
            MatrixBuilder builder = new MatrixBuilder();
            builder.BuildFromFullMatrix(new double [] { 1, 2, 3, 4 }, 10);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildFromUpperRow_DimensionsDoesNotFitInputData_ThrowsException()
        {
            MatrixBuilder builder = new MatrixBuilder();
            builder.BuildFromUpperRow(new double[] { 1, 2, 3, 4, 5, 6 }, 10);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildFromLowerRow_DimensionsDoesNotFitInputData_ThrowsException()
        {
            MatrixBuilder builder = new MatrixBuilder();
            builder.BuildFromLowerRow(new double[] { 1, 2, 3, 4, 5, 6 }, 10);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildFromUpperDiagonalRow_DimensionsDoesNotFitInputData_ThrowsException()
        {
            MatrixBuilder builder = new MatrixBuilder();
            builder.BuildFromUpperDiagonalRow(new double[] { 1, 2, 3, 4, 5, 0, 0, 0, 0 }, 10);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuildFromLowerDiagonalRow_DimensionsDoesNotFitInputData_ThrowsException()
        {
            MatrixBuilder builder = new MatrixBuilder();
            builder.BuildFromLowerDiagonalRow(new double[] { 1, 2, 3, 4, 5, 6, 0, 0, 0, 0 }, 10);
            Assert.Fail();
        }

        [TestMethod]
        public void ValidateBuildFromFullMatrix()
        {
            MatrixBuilder builder = new MatrixBuilder();
            int dimension = 4;
            double[] input =
            {
                 1,  2,  3, 4,
                 5,  6,  7, 8,
                 9, 10, 11, 12,
                13, 14, 15, 16
            };
            double[,] expectedOutput =
            {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };

            var output = builder.BuildFromFullMatrix(input, dimension);
            AssertArraysAreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void ValidateBuildFromUpperRow()
        {
            MatrixBuilder builder = new MatrixBuilder();
            int dimension = 4;
            double[] input =
            {
                 1,  2,  3,  // only top right triangle w/o diagonal, read by rows
                     4,  5, 
                         6,                 
            };
            double[,] expectedOutput =
            {
                { 0, 1, 2, 3 },
                { 1, 0, 4, 5 },
                { 2, 4, 0, 6 },
                { 3, 5, 6, 0 }
            };

            var output = builder.BuildFromUpperRow(input, dimension);
            AssertArraysAreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void ValidateBuildFromLowerRow()
        {
            MatrixBuilder builder = new MatrixBuilder();
            int dimension = 4;
            double[] input =
            {
                 1,
                 2, 4,  // only bottom left triangle w/o diagonal, read by rows
                 3, 5, 6
            };
            double[,] expectedOutput =
            {
                { 0, 1, 2, 3 },
                { 1, 0, 4, 5 },
                { 2, 4, 0, 6 },
                { 3, 5, 6, 0 }
            };

            var output = builder.BuildFromLowerRow(input, dimension);
            AssertArraysAreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void ValidateBuildFromUpperDiagonalRow()
        {
            MatrixBuilder builder = new MatrixBuilder();
            int dimension = 4;
            double[] input =
            {
                 0, 1,  2,  3,  // only top right triangle with diagonal, read by rows
                     0, 4,  5,
                         0, 6,
                            0
            };
            double[,] expectedOutput =
            {
                { 0, 1, 2, 3 },
                { 1, 0, 4, 5 },
                { 2, 4, 0, 6 },
                { 3, 5, 6, 0 }
            };

            var output = builder.BuildFromUpperDiagonalRow(input, dimension);
            AssertArraysAreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void ValidateBuildFromLowerDiagonalRow()
        {
            MatrixBuilder builder = new MatrixBuilder();
            int dimension = 4;
            double[] input =
            {
                 0,
                 1, 0,
                 2, 4, 0,  // only bottom left triangle with diagonal, read by rows
                 3, 5, 6, 0
            };
            double[,] expectedOutput =
            {
                { 0, 1, 2, 3 },
                { 1, 0, 4, 5 },
                { 2, 4, 0, 6 },
                { 3, 5, 6, 0 }
            };

            var output = builder.BuildFromLowerDiagonalRow(input, dimension);
            AssertArraysAreEqual(expectedOutput, output);
        }

        public void AssertArraysAreEqual(double[,] expected, double[,] actual) 
        {
            if (expected == null && actual == null)
                return;
            
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.GetLength(0), actual.GetLength(0), "Arrays dimmensions are different");
            Assert.AreEqual(expected.GetLength(1), actual.GetLength(1), "Arrays dimmensions are different");
            StringBuilder expectedArray = new StringBuilder();
            StringBuilder actualArray = new StringBuilder();
            for (int x = 0; x < expected.GetLength(0); x++)
            {
                for (int y = 0; y < expected.GetLength(1); y++)
                {
                    expectedArray.Append(expected[x, y]);
                    expectedArray.Append(",");
                    actualArray.Append(actual[x, y]);
                    actualArray.Append(",");
                    Assert.AreEqual(expected[x, y], actual[x, y], "Arrays are different. \r\n\r\nExpected:\r\n" + expectedArray + "\r\n\r\nActual\r\n" + actualArray);
                }

                expectedArray.AppendLine();
                actualArray.AppendLine();
            }
        }
    }
}
