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
namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.Graph.Edges;

    /// <summary>
    /// Provides nodes by extracting them from given list of graph edges
    /// </summary>
    public class EdgeListBasedNodeProvider : INodeProvider
    {
        /// <summary>
        /// Creates new instance of EdgeListBasedNodeProvider
        /// </summary>
        /// <param name="edges">edge list initializing provider</param>
        public EdgeListBasedNodeProvider(IEnumerable<IEdge> edges)
        {
            if (edges == null)
            {
                throw new ArgumentNullException("matrix");
            }

            this.Nodes = new NodesCollection();
            HashSet<int> nodesToCreate = new HashSet<int>();
            foreach (IEdge edge in edges)
            {
                if (!nodesToCreate.Contains(edge.First.Id))
                {
                    nodesToCreate.Add(edge.First.Id);
                }

                if (!nodesToCreate.Contains(edge.Second.Id))
                {
                    nodesToCreate.Add(edge.Second.Id);
                }
            }

            foreach(int id in nodesToCreate)
            {
                this.Nodes.Add(new Node(id));
            }
        }

        /// <summary>
        /// Gets or sets providers nodes
        /// </summary>
        public NodesCollection Nodes { get; protected set; }

        /// <summary>
        /// Get all nodes in graph
        /// </summary>
        /// <returns>List of nodes</returns>
        public List<INode> GetNodes()
        {
            return new List<INode>(this.Nodes.ToList());
        }

        /// <summary>
        /// Get node with a given id
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>Node with a given id or null</returns>
        public INode GetNode(int id)
        {
            return this.Nodes.FindById(id);
        }
        
        /// <summary>
        /// Get total number of nodes
        /// </summary>
        /// <returns>Total number of nodes</returns>
        public int CountNodes()
        {
            return this.Nodes.Count;
        }
    }
}
