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

namespace TspLibNet
{
    using System;
    using TspLibNet.Graph.Edges;
    using TspLibNet.Graph.EdgeWeights;
    using TspLibNet.Graph.FixedEdges;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Tours;
    using TspLibNet.TSP;

    /// <summary>
    /// Sequential Ordering Problem
    /// </summary>
    public class SequentialOrderingProblem : ProblemBase
    {
        /// <summary>
        /// Creates new instance of SequentialOrderingProblem class
        /// </summary>
        /// <param name="name">problem name</param>
        /// <param name="comment">comment on problem from the author</param>
        /// <param name="nodeProvider">provider of nodes</param>
        /// <param name="edgeProvider">provider of edges</param>
        /// <param name="edgeWeightsProvider">provider of edge weights</param>
        /// <param name="fixedEdgesProvider">provider of fixed edges</param>
        public SequentialOrderingProblem(string name, string comment, INodeProvider nodeProvider, IEdgeProvider edgeProvider, IEdgeWeightsProvider edgeWeightsProvider, IFixedEdgesProvider fixedEdgesProvider)
            : base(name, comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider)
        {
        }

        /// <summary>
        /// Load problem from TSP file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>Loaded problem</returns>
        public static SequentialOrderingProblem FromFile(string fileName)
        {
            return FromTspFile(TspFile.Load(fileName));
        }

        /// <summary>
        /// Load problem from TSP file
        /// </summary>
        /// <param name="tspFile">TSP file instance</param>
        /// <returns>Loaded problem</returns>
        public static SequentialOrderingProblem FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != TSP.Defines.FileType.SOP)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            double weight = tspFile.EdgeWeights[0];
            tspFile.EdgeWeights.RemoveAt(0);

            TspFileDataExtractor extractor = new TspFileDataExtractor(tspFile);
            var nodeProvider = extractor.MakeNodeProvider();
            var nodes = nodeProvider.GetNodes();
            var edgeProvider = extractor.MakeEdgeProvider(nodes);
            var edgeWeightsProvider = extractor.MakeEdgeWeightsProvider();
            var fixedEdgesProvider = extractor.MakeFixedEdgesProvider(nodes);

            tspFile.EdgeWeights.Insert(0, weight);

            return new SequentialOrderingProblem(tspFile.Name, tspFile.Comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider);
        }

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Tour distance</returns>
        public override double TourDistance(ITour tour)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="errors">utputs list of errors found in tour</param>
        protected void ValidateTour(ITour tour)
        {
            throw new NotImplementedException();
        }
    }
}