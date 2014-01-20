namespace TspLibNet.TSP.Defines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Format of eplicitly specified edge weights 
    /// </summary>
    public enum EdgeWeightFormat
    {
        /// <summary>
        /// Format is not defined
        /// </summary>
        Undefined,

        /// <summary>
        /// Weights are given by function
        /// </summary>
        Function,

        /// <summary>
        /// Weights are given by a full matrix
        /// </summary>
        FullMatrix,

        /// <summary>
        /// Upper triangular matrix, row-wise without diagonal entries
        /// </summary>
        UpperRow,

        /// <summary>
        /// Lower triangular matrix, row-wise without diagonal entries
        /// </summary>
        LowerRow,

        /// <summary>
        /// Upper triangular matrix, row-wise including diagonal entries
        /// </summary>
        UpperDiagonalRow,

        /// <summary>
        /// Lower triangular matrix, row-wise including diagonal entries
        /// </summary>
        LowerDiagonalRow,

        /// <summary>
        /// Upper triangular matrix, column-wise without diagonal entries
        /// </summary>
        UpperColumn,

        /// <summary>
        /// Lower triangular matrix, column-wise without diagonal entries
        /// </summary>
        LowerColumn,

        /// <summary>
        /// Upper triangular matrix, column-wise including diagonal entries
        /// </summary>
        UpperDiagonalColumn,

        /// <summary>
        /// Lower triangular matrix, column-wise including diagonal entries
        /// </summary>
        LowerDiagonalColumn
    }
}
