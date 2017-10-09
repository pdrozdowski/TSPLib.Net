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

using System.Text;

namespace TspLibNet.TSP
{
    using System.Collections.Generic;
    using TspLibNet.TSP.Defines;
    using System.IO;

    /// <summary>
    /// Represents TSP file
    /// </summary>
    public class TspFile
    {
        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        public string Name;

        /// <summary>
        /// Gets type of file - specifies the type of the data
        /// </summary>
        public FileType Type;

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        public string Comment;

        /// <summary>
        /// Gets problem dimension, for TSP and ATSP is a number of nodes. For CVRP total number of nodes and depots. For tour it is a dimension of coresponding problem.
        /// </summary>
        public int Dimension;

        /// <summary>
        /// Gets truck capacity in a CVRP
        /// </summary>
        public int Capacity;

        /// <summary>
        /// Gets how edge weights (or distances) are given
        /// </summary>
        public EdgeWeightType EdgeWeightType = EdgeWeightType.Undefined;

        /// <summary>
        /// Describes format of the edge weights if are given explicitly
        /// </summary>
        public EdgeWeightFormat EdgeWeightFormat = EdgeWeightFormat.Function;

        /// <summary>
        /// Describes the format in which the edges of a grap are given, if the graph is not complete
        /// </summary>
        public EdgeDataFormat EdgeDataFormat = EdgeDataFormat.Undefined;

        /// <summary>
        /// Specifies whether coordinates are associated with each node
        /// </summary>
        public NodeCoordinatesType NodeCoordinatesType = NodeCoordinatesType.NoCoordinates;

        /// <summary>
        /// How graphical display of nodes can be obtained
        /// </summary>
        public DisplayDataType DisplayDataType = DisplayDataType.NoDisplay;

        /// <summary>
        /// Gets nodes coordinates
        /// </summary>
        public List<object[]> Nodes;

        /// <summary>
        /// Gets list of alternate depots
        /// </summary>
        public List<int> Depots;

        /// <summary>
        /// The demands of all nodes of CVRP, first is node, second is it's demand. Depot nodes have demands = 0.
        /// </summary>
        public List<int[]> Demands;

        /// <summary>
        /// List of edges or list of adjacency lists for nodes
        /// </summary>
        public List<int[]> Edges;

        /// <summary>
        /// List of edges required to appear in each solution to the problem
        /// </summary>
        public List<int[]> FixedEdges;

        /// <summary>
        /// Display nodes data
        /// </summary>
        public List<object[]> DisplayNodes;

        /// <summary>
        /// Gets optimal tour
        /// </summary>
        public List<int> Tour;

        /// <summary>
        /// Matrix of edge weights
        /// </summary>
        public List<double> EdgeWeights;

        /// <summary>
        /// Loads TSP file
        /// </summary>
        /// <param name="fileName">file to load</param>
        /// <returns>Loaed tsp file</returns>
        public static TspFile Load(string fileName)
        {
            TspFile result = null;
            TspFileLoader loader = new TspFileLoader();
            using (StreamReader reader = new StreamReader(fileName))
            {
                result = loader.Load(reader);
                reader.Close();
            }

            return result;
        }

        /// <summary>
        /// Loads TSP from string
        /// </summary>
        /// <param name="content">tsp task</param>
        /// <returns>Load tsp file</returns>
        public static TspFile LoadFromString(string content)
        {
            TspFile result = null;
            TspFileLoader loader = new TspFileLoader();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    result = loader.Load(reader);
                    reader.Close();
                }
            }
            return result;
        }
    }
}
