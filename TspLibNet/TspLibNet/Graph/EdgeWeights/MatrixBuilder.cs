namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            List<double> input = new List<double>(data);                       
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
            List<double> weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = x; y < dimension; y++)
                {
                    if (x == y)
                    {
                        result[x, y] = 0;
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
        /// Lower triangular matrix, row-wise without diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromLowerRow(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            List<double> weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y <= x; y++)
                {                
                    if (x == y)
                    {
                        result[x, y] = 0;
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
        /// Upper triangular matrix, row-wise including diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromUpperDiagonalRow(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            List<double> weights = new List<double>(data);
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
            List<double> weights = new List<double>(data);
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
            List<double> weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {   
                for (int x = 0; x <= y; x++)
                {                
                    if (x == y)
                    {
                        result[x, y] = 0;
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
        /// Lower triangular matrix, column-wise without diagonal entries
        /// </summary>
        /// <param name="data">matrix data</param>
        /// <param name="dimension">matrix dimension</param>
        /// <returns>matrixed filed with data</returns>
        public double[,] BuildFromLowerColumn(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            List<double> weights = new List<double>(data);
            double[,] result = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                for (int x = y; x < dimension; x++)
                {
                    if (x == y)
                    {
                        result[x, y] = 0;
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
        /// Upper triangular matrix, column-wise including diagonal entries
        /// </summary>
        public double[,] BuildFromUpperDiagonalColumn(IEnumerable<double> data, int dimension)
        {
            int weightsIndex = 0;
            List<double> weights = new List<double>(data);
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
            List<double> weights = new List<double>(data);
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
