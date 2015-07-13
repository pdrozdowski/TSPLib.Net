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
    using System.Collections.Generic;
    using System.Linq;
    using TspLibNet.Exceptions;
    using TspLibNet.Graph.Edges;
    using TspLibNet.Graph.EdgeWeights;
    using TspLibNet.Graph.FixedEdges;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Tours;
    using TspLibNet.TSP;

    /// <summary>
    /// Traveling Salesman Problem
    /// This class servers for synchronous and asynchronous Traveling Salesman Problem.
    /// The problem is to visit all the nodes of the graph with a shortes posible tour.
    /// In synchronous variant edges weights are invariant of a move direction, in asynchronous they can have different
    /// weights whether going from A to B or from B to A... usualy then weights are provided in form of a weights matrix.
    /// For synchronous problem weights are commonly made by the one of distance functions.
    /// </summary>
    public class TravelingSalesmanProblem : ProblemBase
    {
        /// <summary>
        /// Creates new instance of TravelingSalesmanProblem class
        /// </summary>
        /// <param name="name">problem name</param>
        /// <param name="comment">comment on problem from the author</param>
        /// <param name="nodeProvider">provider of nodes</param>
        /// <param name="edgeProvider">provider of edges</param>
        /// <param name="edgeWeightsProvider">provider of edge weights</param>
        /// <param name="fixedEdgesProvider">provider of fixed edges</param>
        public TravelingSalesmanProblem(string name, string comment, INodeProvider nodeProvider, IEdgeProvider edgeProvider, IEdgeWeightsProvider edgeWeightsProvider, IFixedEdgesProvider fixedEdgesProvider)
            : base(name, comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider)
        {
        }

        /// <summary>
        /// Load problem from TSP file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>Loaded problem</returns>
        public static TravelingSalesmanProblem FromFile(string fileName)
        {
            return FromTspFile(TspFile.Load(fileName));
        }

        /// <summary>
        /// Load problem from TSP file
        /// </summary>
        /// <param name="tspFile">TSP file instance</param>
        /// <returns>Loaded problem</returns>
        public static TravelingSalesmanProblem FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != TSP.Defines.FileType.TSP && tspFile.Type != TSP.Defines.FileType.ATSP)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            TspFileDataExtractor extractor = new TspFileDataExtractor(tspFile);
            var nodeProvider = extractor.MakeNodeProvider();
            var nodes = nodeProvider.GetNodes();
            var edgeProvider = extractor.MakeEdgeProvider(nodes);
            var edgeWeightsProvider = extractor.MakeEdgeWeightsProvider();
            var fixedEdgesProvider = extractor.MakeFixedEdgesProvider(nodes);
            return new TravelingSalesmanProblem(tspFile.Name, tspFile.Comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider);
        }

        /// <summary>
        /// Create problem from list of nodes
        /// </summary>
        /// <param name="nodes">list of nodes defining TSP problem instance</param>
        /// <returns>Generated TSP problem</returns>
        public static TravelingSalesmanProblem FromNodes(List<INode> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            var nodeProvider = new NodeListBasedNodeProvider(nodes);
            var edgeProvider = new NodeBasedEdgeProvider(nodes);
            var edgeWeightsProvider = new FunctionBasedWeightProviderWithCaching(new DistanceFunctions.Euclidean());
            var fixedEdgesProvider = new EdgeListBasedFixedEdgesProvider(new EdgesCollection());
            return new TravelingSalesmanProblem(nodes.Count + " city TSP problem", "Generated", nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider);
        }

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Tour distance</returns>
        public override double TourDistance(ITour tour)
        {
            this.ValidateTour(tour);
            double distance = 0;
            for (int i = -1; i + 1 < tour.Nodes.Count; i++)
            {
                INode first = i == -1 ? this.NodeProvider.GetNode(tour.Nodes.Last()) : this.NodeProvider.GetNode(tour.Nodes[i]);
                INode second = this.NodeProvider.GetNode(tour.Nodes[i + 1]);
                double weight = this.EdgeWeightsProvider.GetWeight(first, second);
                distance += weight;
            }

            return distance;
        }

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="errors">outputs list of errors found in tour</param>
        protected void ValidateTour(ITour tour)
        {
            if (tour == null)
            {
                throw new ArgumentNullException("tour");
            }

            if (tour.Dimension != tour.Nodes.Count)
            {
                throw new TourInvalidException("Tour dimension does not match number of nodes on a list");
            }

            HashSet<int> identifiers = new HashSet<int>();
            foreach (int nodeId in tour.Nodes)
            {
                if (identifiers.Contains(nodeId))
                {
                    throw new TourInvalidException("Tour is invalid, has a node " + nodeId + " multiple times");
                }

                if (null == this.NodeProvider.GetNode(nodeId))
                {
                    throw new TourInvalidException("Tour is invalid, has a node " + nodeId + " which is not present in a problem");
                }

                identifiers.Add(nodeId);
            }
        }
    }
}