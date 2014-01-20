namespace TspLibNet.TSP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.TSP.Defines;

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
    }
}
