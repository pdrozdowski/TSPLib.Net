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
namespace TspLibNet.Graph.Edges
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Exceptions;

    /// <summary>
    /// Provides graph edges by deriving them from a list of nodes (for complete graphs)
    /// </summary>
    public class NodeBasedEdgeProvider : IEdgeProvider
    {
        /// <summary>
        /// Creates a new instance of class NodeBasedEdgeProvider
        /// </summary>
        /// <param name="nodes">list of graph nodes</param>
        public NodeBasedEdgeProvider(IEnumerable<INode> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            this.Nodes = new NodesCollection(nodes);
        }

        /// <summary>
        /// Gets or sets collection of fixed edges
        /// </summary>
        public NodesCollection Nodes { get; protected set; }

        /// <summary>
        /// Get edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Edge between given nodes or null</returns>
        public IEdge GetEdge(INode first, INode second)
        {
            if (this.Nodes.Contains(first) && this.Nodes.Contains(second))
            {
                return new Edge(first, second);
            }

            throw new GraphException("Pair of nodes seems to not be a part of a complete graph!");
        }

        /// <summary>
        /// Checks if there is edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Indicates if there is an edge between given nodes</returns>
        public bool HasEdge(INode first, INode second)
        {
            return this.Nodes.Contains(first) && this.Nodes.Contains(second);
        }

        /// <summary>
        /// Get total number of edges
        /// </summary>
        /// <returns>Total number of edges</returns>
        public int CountEdges()
        {
            int count = 0;
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                count += (i + 1);
            }

            return count;
        }
    }
}
