/* The MIT License (MIT)
*
* Original Work Copyright (c) 2014 Pawel Drozdowski
* Modified Work Copyright (c) 2015 William Hallatt
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

namespace TspLibNet
{
    using Graph.Edges;
    using Graph.EdgeWeights;
    using Graph.FixedEdges;
    using Graph.Nodes;
    using System;
    using Tours;

    /// <summary>
    /// Problem base class
    /// </summary>
    public abstract class ProblemBase : IProblem
    {
        /// <summary>
        /// Creates new instance of ProblemBase class
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <param name="comment">Comment on problem</param>
        /// <param name="type">The problem type (TSP, ATSP, etc)</param>
        /// <param name="nodeProvider">Provider of graph nodes</param>
        /// <param name="edgeProvider">Provider of graph edges</param>
        /// <param name="edgeWeightsProvider">Provider of edge weights</param>
        /// <param name="fixedEdgesProvider">Provider of solution fixed edges</param>
        protected ProblemBase(string name,
                              string comment,
                              ProblemType type,
                              INodeProvider nodeProvider,
                              IEdgeProvider edgeProvider,
                              IEdgeWeightsProvider edgeWeightsProvider,
                              IFixedEdgesProvider fixedEdgesProvider)
        {
            if (nodeProvider == null)
            {
                throw new ArgumentNullException("nodeProvider");
            }

            if (edgeProvider == null)
            {
                throw new ArgumentNullException("edgeProvider");
            }

            if (edgeWeightsProvider == null)
            {
                throw new ArgumentNullException("edgeWeightsProvider");
            }

            if (fixedEdgesProvider == null)
            {
                throw new ArgumentNullException("fixedEdgesProvider");
            }

            Name = name;
            Comment = comment;
            Type = type;
            NodeProvider = nodeProvider;
            EdgeProvider = edgeProvider;
            EdgeWeightsProvider = edgeWeightsProvider;
            FixedEdgesProvider = fixedEdgesProvider;
        }

        /// <summary>
        /// Represents the problem type (TSP, ATSP, etc).
        /// </summary>
        public ProblemType Type { get; }

        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// Gets nodes provider
        /// </summary>
        public INodeProvider NodeProvider { get; }

        /// <summary>
        /// Gets Edges provider
        /// </summary>
        public IEdgeProvider EdgeProvider { get; }

        /// <summary>
        /// Gets Edge Weights Provider
        /// </summary>
        public IEdgeWeightsProvider EdgeWeightsProvider { get; }

        /// <summary>
        /// Gets Fixed Edges Provider
        /// </summary>
        public IFixedEdgesProvider FixedEdgesProvider { get; }

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="validate">Validate the tour</param>
        /// <returns>Tour distance</returns>
        public abstract double TourDistance(ITour tour, bool validate = true);
    }
}