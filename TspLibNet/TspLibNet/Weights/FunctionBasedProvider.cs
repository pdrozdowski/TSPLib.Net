namespace TspLibNet.Weights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graphs;
    using TspLibNet.Distance;

    /// <summary>
    /// Weight provider based on distance function
    /// </summary>
    /// <typeparam name="NodeType">Type of node</typeparam>
    public class FunctionBasedProvider : IWeightProvider
    {
        /// <summary>
        /// Creates new instance of a function based weight provider
        /// </summary>
        /// <param name="distanceFunction">distance function to be used</param>
        public FunctionBasedProvider(IDistanceFunction distanceFunction)
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
        /// <param name="edge">edge to check</param>
        /// <returns>Weight of a given edge</returns>
        public double Weight(IEdge edge)
        {
            return this.DistanceFunction.Distance(edge.First, edge.Second);
        }
    }
}
