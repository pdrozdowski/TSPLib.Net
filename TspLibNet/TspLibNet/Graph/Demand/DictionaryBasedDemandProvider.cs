namespace TspLibNet.Graph.Demand
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Exceptions;

    /// <summary>
    /// Provides demand values basing on a provided lokup dictionary
    /// </summary>
    public class DictionaryBasedDemandProvider : IDemandProvider
    {
        /// <summary>
        /// Creates a new instance of DictionaryBasedDemandProvider class.
        /// </summary>
        /// <param name="demandDictionary">Lookup dictionary with a demands</param>
        public DictionaryBasedDemandProvider(Dictionary<INode, int> demandDictionary)
        {
            if (demandDictionary == null)
            {
                throw new ArgumentNullException("demandDictionary");
            }

            this.DemandDictionary = new Dictionary<INode, int>(demandDictionary);
        }

        /// <summary>
        /// Gets or sets demand lookup dictionary
        /// </summary>
        public Dictionary<INode, int> DemandDictionary { get; protected set; }

        /// <summary>
        /// Get demand for given node
        /// </summary>
        /// <returns>Value of demand on a given node</returns>
        public int GetDemand(INode node)
        {
            if (!this.DemandDictionary.ContainsKey(node))
            {
                throw new ArgumentOutOfRangeException("node");
            }

            return this.DemandDictionary[node];
        }
    }
}
