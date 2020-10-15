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
namespace TspLibNet.Graph.Depots
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Provides depot nodes by extracting them directly from a list of depot nodes
    /// </summary>
    public class NodeListBasedDepotProvider : IDepotsProvider
    {
        /// <summary>
        /// Creates new instance of NodeListBasedDepotProvider
        /// </summary>
        /// <param name="nodes">list of depot nodes initializing provider</param>
        public NodeListBasedDepotProvider(IEnumerable<INode> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            this.Nodes = new NodesCollection(nodes);
        }

        /// <summary>
        /// Gets or sets providers nodes
        /// </summary>
        public NodesCollection Nodes { get; protected set; }

        /// <summary>
        /// Get all depot nodes in graph
        /// </summary>
        /// <returns>List of nodes</returns>
        public List<INode> GetDepots()
        {
            return new List<INode>(this.Nodes.ToList());
        }

        /// <summary>
        /// Get total number of depots
        /// </summary>
        /// <returns>Total number of depots</returns>
        public int CountDepots()
        {
            return this.Nodes.Count;
        }
    }
}
