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
    using System.Collections.Generic;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Strongly typed edges collection
    /// </summary>
    public class EdgesCollection : List<IEdge>
    {
        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        public EdgesCollection()
        {
        }

        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        /// <param name="edges">range of edges to add initially</param>
        public EdgesCollection(IEnumerable<IEdge> edges)
            : base(edges)
        {
        }

        /// <summary>
        /// Find edge by given pair of nodes
        /// </summary>
        /// <param name="first">edge first node</param>
        /// <param name="second">edge second node</param>
        /// <returns>edge on given pair of nodes or null</returns>
        public IEdge FindEdge(INode first, INode second)
        {
            EdgesCollection edges = this.FilterByNode(first).FilterByNode(second);
            if (edges.Count > 0)
            {
                return edges[0];
            }

            return null;
        }

        /// <summary>
        /// Find edge with given node
        /// </summary>
        /// <param name="node">The node to filter edges by</param>
        /// <returns>Node with given id or null</returns>
        public EdgesCollection FilterByNode(INode node)
        {
            EdgesCollection result = new EdgesCollection();
            foreach (IEdge edge in this)
            {
                if (edge.First.Id == node.Id || edge.Second.Id == node.Id)
                {
                    result.Add(edge);
                }
            }

            return result;
        }
    }
}