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
namespace TspLibNet.Graph.FixedEdges
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.Graph.Edges;

    /// <summary>
    /// Provides fixed edges basing on a given list of edges
    /// </summary>
    public class EdgeListBasedFixedEdgesProvider : IFixedEdgesProvider
    {
        /// <summary>
        /// Creates new instance of a EdgeListBasedFixedEdgesProvider class.
        /// </summary>
        public EdgeListBasedFixedEdgesProvider()
        {
            this.FixedEdges = new EdgesCollection();
        }

        /// <summary>
        /// Creates new instance of a EdgeListBasedFixedEdgesProvider class.
        /// </summary>
        /// <param name="fixedEdges">list of fixed edges</param>
        public EdgeListBasedFixedEdgesProvider(IEnumerable<IEdge> fixedEdges)
        {
            if (fixedEdges == null)
            {
                throw new ArgumentNullException("fixedEdges");
            }

            this.FixedEdges = new EdgesCollection(fixedEdges);
        }

        /// <summary>
        /// Gets or sets collection of fixed edges
        /// </summary>
        public EdgesCollection FixedEdges { get; protected set; }

        /// <summary>
        /// Get fixed edges in given graph
        /// </summary>
        /// <returns>List of fixed edges</returns>
        public List<IEdge> GetFixedEdges()
        {
            return new List<IEdge>(this.FixedEdges.ToList());
        }

        /// <summary>
        /// Get number of fixed edges in given graph
        /// </summary>
        /// <returns>Number of fixed edges</returns>
        public int CountFixedEdges()
        {
            return this.FixedEdges.Count;
        }
    }
}
