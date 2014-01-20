namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.DistanceFunctions;

    /// <summary>
    /// Weight provider based on distance function that is able to cache deistances get from distance function for reuse
    /// </summary>
    /// <typeparam name="NodeType">Type of node</typeparam>
    public class FunctionBasedWeightProviderWithCaching : IEdgeWeightsProvider
    {
        /// <summary>
        /// Creates new instance of a function based weight provider
        /// </summary>
        /// <param name="distanceFunction">distance function to be used</param>
        public FunctionBasedWeightProviderWithCaching(IDistanceFunction distanceFunction)
        {
            if (distanceFunction == null)
            {
                throw new ArgumentNullException("distanceFunction");
            }

            this.DistanceFunction = distanceFunction;
            this.DistancesCache = new Dictionary<string, double>();
        }

        /// <summary>
        /// Gets or sets distances cache
        /// </summary>
        public Dictionary<string, double> DistancesCache { get; protected set; }

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
            string key = first + ":" + second;
            if (!this.DistancesCache.ContainsKey(key))
            {
                this.DistancesCache.Add(key, this.DistanceFunction.Distance(first, second));
            }

            return this.DistancesCache[key];
        }
    }
}
