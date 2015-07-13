/* The MIT License (MIT)
*
* Copyright (c) 2014 Pawel Drozdowski
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace TspLibNet.TSP.Defines
{
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
