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
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Graph edge class, first node have always lower id than the second node
    /// </summary>
    public class Edge : IEdge
    {
        /// <summary>
        /// Creates new instance of graph edge
        /// </summary>
        /// <param name="first">Edge first node</param>
        /// <param name="second">Edge second node</param>
        public Edge(INode first, INode second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (first.Id <= second.Id)
            {
                this.First = first;
                this.Second = second;
            }
            else
            {
                this.First = second;
                this.Second = first;
            }
        }

        /// <summary>
        /// Gets first edge node
        /// </summary>
        public INode First { get; protected set; }

        /// <summary>
        /// Gets second edge node
        /// </summary>
        public INode Second { get; protected set; }
    }
}
