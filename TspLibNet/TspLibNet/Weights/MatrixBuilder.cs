namespace TspLibNet.Weights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graphs;

    /// <summary>
    /// Weight matrix builder
    /// </summary>
    public class MatrixBuilder
    {
        /// <summary>
        /// Weights are given by a full matrix
        /// </summary>
        public MatrixBasedProvider BuildFromFullMatrix(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Upper triangular matrix, row-wise without diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromUpperRow(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Lower triangular matrix, row-wise without diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromLowerRow(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Upper triangular matrix, row-wise including diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromUpperDiagonalRow(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Lower triangular matrix, row-wise including diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromLowerDiagonalRow(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Upper triangular matrix, column-wise without diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromUpperColumn(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Lower triangular matrix, column-wise without diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromLowerColumn(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Upper triangular matrix, column-wise including diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromUpperDiagonalColumn(double[,] data)
        {
            return null;
        }

        /// <summary>
        /// Lower triangular matrix, column-wise including diagonal entries
        /// </summary>
        public MatrixBasedProvider BuildFromLowerDiagonalColumn(double[,] data)
        {
            return null;
        }
    }
}
