namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.DistanceFunctions;

    /// <summary>
    /// Weight provider based on distance function
    /// </summary>
    /// <typeparam name="NodeType">Type of node</typeparam>
    public class FunctionBasedWeightProvider : IEdgeWeightsProvider
    {
        /// <summary>
        /// Creates new instance of a function based weight provider
        /// </summary>
        /// <param name="distanceFunction">distance function to be used</param>
        public FunctionBasedWeightProvider(IDistanceFunction distanceFunction)
        {
            if (distanceFunction == null)
            {
                throw new ArgumentNullException("distanceFunction");
            }

            this.DistanceFunction = distanceFunction;
        }

        /// <summary>
        /// Gets or sets distance function in use
        /// </summary>
        protected IDistanceFunction DistanceFunction { get; set; }

        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="first">first node of edge</param>
        /// <param name="second">second node of edge</param>
        /// <returns>Weight of a given edge</returns>
        public double GetWeight(INode first, INode second)
        {
            return this.DistanceFunction.Distance(first, second);
        }
    }
}
