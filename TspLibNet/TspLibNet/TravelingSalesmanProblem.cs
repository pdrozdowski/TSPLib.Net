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
    using DistanceFunctions;
    using Exceptions;
    using Graph.Edges;
    using Graph.EdgeWeights;
    using Graph.FixedEdges;
    using Graph.Nodes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tours;
    using TSP;
    using TSP.Defines;

    /// <summary>
    /// Traveling Salesman Problem
    ///
    /// This class represents both symmetric and asymmetric Traveling Salesman Problems:
    ///
    /// "Given a set of n nodes and distances for each pair of nodes, find a roundtrip of minimal total length
    /// visiting each node exactly once."
    ///
    /// For the symmetric TSP, the distance from node i to node j is the same as from node j to node i.
    /// For asymmetric TSP, the distance from node i to node j and the distance from node j to node i may be different.
    /// </summary>
    public class TravelingSalesmanProblem : ProblemBase
    {
        /// <summary>
        /// Creates new instance of TravelingSalesmanProblem class
        /// </summary>
        /// <param name="name">problem name</param>
        /// <param name="comment">comment on problem from the author</param>
        /// <param name="type">TSP or ATSP</param>
        /// <param name="nodeProvider">provider of nodes</param>
        /// <param name="edgeProvider">provider of edges</param>
        /// <param name="edgeWeightsProvider">provider of edge weights</param>
        /// <param name="fixedEdgesProvider">provider of fixed edges</param>
        public TravelingSalesmanProblem(string name,
                                        string comment,
                                        ProblemType type,
                                        INodeProvider nodeProvider,
                                        IEdgeProvider edgeProvider,
                                        IEdgeWeightsProvider edgeWeightsProvider,
                                        IFixedEdgesProvider fixedEdgesProvider)
            : base(name, comment, type, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider)
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

        public static TravelingSalesmanProblem FromString(string content)
        {
            return FromTspFile(TspFile.LoadFromString(content));
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
            var edgeWeightsProvider = new FunctionBasedWeightProviderWithCaching(new Euclidean());
            var fixedEdgesProvider = new EdgeListBasedFixedEdgesProvider(new EdgesCollection());
            return new TravelingSalesmanProblem(nodes.Count + " city TSP problem", "Generated", ProblemType.ATSP, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider);
        }

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Tour distance</returns>
        public override double TourDistance(ITour tour)
        {
            ValidateTour(tour);
            double distance = 0;
            for (int i = -1; i + 1 < tour.Nodes.Count; i++)
            {
                INode first = i == -1 ? NodeProvider.GetNode(tour.Nodes.Last()) : NodeProvider.GetNode(tour.Nodes[i]);
                INode second = NodeProvider.GetNode(tour.Nodes[i + 1]);
                double weight = EdgeWeightsProvider.GetWeight(first, second);
                distance += weight;
            }

            return distance;
        }

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        private void ValidateTour(ITour tour)
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

                if (null == NodeProvider.GetNode(nodeId))
                {
                    throw new TourInvalidException("Tour is invalid, has a node " + nodeId + " which is not present in a problem");
                }

                identifiers.Add(nodeId);
            }
        }

        /// <summary>
        /// Load problem from TSP file
        /// </summary>
        /// <param name="tspFile">TSP file instance</param>
        /// <returns>Loaded problem</returns>
        private static TravelingSalesmanProblem FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != FileType.TSP && tspFile.Type != FileType.ATSP)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            TspFileDataExtractor extractor = new TspFileDataExtractor(tspFile);
            var nodeProvider = extractor.MakeNodeProvider();
            var nodes = nodeProvider.GetNodes();
            var edgeProvider = extractor.MakeEdgeProvider(nodes);
            var edgeWeightsProvider = extractor.MakeEdgeWeightsProvider();
            var fixedEdgesProvider = extractor.MakeFixedEdgesProvider(nodes);
            var type = (tspFile.Type == FileType.TSP) ? ProblemType.TSP : ProblemType.ATSP;
            return new TravelingSalesmanProblem(tspFile.Name, tspFile.Comment, type, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider);
        }
    }
}