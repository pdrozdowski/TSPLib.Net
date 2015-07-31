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
namespace TspLibNet.Graph.EdgeWeights
{
    using System.Collections.Generic;

    /// <summary>
    /// Weight matrix builder
    /// </summary>
    public class MatrixBuilder
    {
        /// <summary>
        /// Weights are given by a full matrix
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromFullMatrix(IEnumerable<double> data, int dimension)
        {
            int dataIndex = 0;
            double[,] result = new double[dimension, dimension];
            var input = new List<double>(data);                       
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    result[x, y] = input[dataIndex++];
                }
            }
            
            return result;
        }

        /// <summary>
        /// Upper triangular matrix, row-wise without diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromUpperRow(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = x; y < dimension; y++)
                {
                    result[x, y] = x == y ? 0 : weights[weightsIndex++];
                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Lower triangular matrix, row-wise without diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromLowerRow(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y <= x; y++)
                {
                    result[x, y] = x == y ? 0 : weights[weightsIndex++];
                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Upper triangular matrix, row-wise including diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromUpperDiagonalRow(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = x; y < dimension; y++)
                {
                    if (x == y)
                    {
                        result[x, y] = weights[weightsIndex++];
                    }
                    else
                    {
                        result[x, y] = weights[weightsIndex++];
                    }

                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Lower triangular matrix, row-wise including diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromLowerDiagonalRow(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y <= x; y++)
                {
                    if (x == y)
                    {
                        result[x, y] = weights[weightsIndex++];
                    }
                    else
                    {
                        result[x, y] = weights[weightsIndex++];
                    }

                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Upper triangular matrix, column-wise without diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromUpperColumn(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {   
                for (int x = 0; x <= y; x++)
                {
                    result[x, y] = x == y ? 0 : weights[weightsIndex++];
                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Lower triangular matrix, column-wise without diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromLowerColumn(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                for (int x = y; x < dimension; x++)
                {
                    result[x, y] = x == y ? 0 : weights[weightsIndex++];
                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Upper triangular matrix, column-wise including diagonal entries
        /// </summary>
        public double[,] BuildFromUpperDiagonalColumn(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x <= y; x++)
                {
                    if (x == y)
                    {
                        result[x, y] = weights[weightsIndex++];
                    }
                    else
                    {
                        result[x, y] = weights[weightsIndex++];
                    }

                    result[y, x] = result[x, y];
                }
            }

            return result;
        }

        /// <summary>
        /// Lower triangular matrix, column-wise including diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromLowerDiagonalColumn(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            var weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                for (int x = y; x < dimension; x++)
                {
                    if (x == y)
                    {
                        result[x, y] = weights[weightsIndex++];
                    }
                    else
                    {
                        result[x, y] = weights[weightsIndex++];
                    }

                    result[y, x] = result[x, y];
                }
            }

            return result;
        }
    }
}
