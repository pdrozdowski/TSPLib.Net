namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Graph.Edges;

    /// <summary>
    /// Hamiltonian Cycle Weight Provider
    /// </summary>
    public class NodeAdjacencyBasedWeightProvider : IEdgeWeightsProvider
    {
        /// <summary>
        /// Creates new instance of a node adjacency based weight provider
        /// </summary>
        /// <param name="edgeProvider">distance function to be used</param>
        public NodeAdjacencyBasedWeightProvider(IEdgeProvider edgeProvider, double adjacentWeight, double notAdjacentWeight)
        {
            if (edgeProvider == null)
            {
                throw new ArgumentNullException("edgeProvider");
            }

            this.EdgeProvider = edgeProvider;
            this.AdjacentWeight = adjacentWeight;
            this.NotAdjacentWeight = notAdjacentWeight;
        }

        /// <summary>
        /// Gets or sets distance function in use
        /// </summary>
        protected IEdgeProvider EdgeProvider { get; set; }

        /// <summary>
        /// Gets or sets weight when nodes are adjacent
        /// </summary>
        protected double AdjacentWeight { get; set; }

        /// <summary>
        /// Gets or sets weight when nodes are not adjacent
        /// </summary>
        protected double NotAdjacentWeight { get; set; }

        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="first">first node of edge</param>
        /// <param name="second">second node of edge</param>
        /// <returns>Weight of a given edge</returns>
        public double GetWeight(INode first, INode second)
        {
            // adjacent cities has a distance of 1, all other have distance of 2
            return this.EdgeProvider.HasEdge(first, second) ? this.AdjacentWeight : this.NotAdjacentWeight;
        }
    }
}
