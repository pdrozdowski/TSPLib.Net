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
    /// Hamiltonian Cycle Problem
    /// This problem purpose is to find out if there is a Hamiltonian path in a graph.
    /// To do so we have edges with weight of one on all adjacent graph nodes and rest of edges have weight greater than one.
    /// Hamiltonian path on existing edges will exist if the minimal tour distance will be made only from edges with weight of one...
    /// so the total distance of the tour will be number of nodes.
    /// </summary>
    public class HamiltonianCycleProblem : ProblemBase
    {
        /// <summary>
        /// Creates new instance of HamiltonianCycleProblem class
        /// </summary>
        /// <param name="name">problem name</param>
        /// <param name="comment">comment on problem from the author</param>
        /// <param name="nodeProvider">provider of nodes</param>
        /// <param name="edgeProvider">provider of edges</param>
        /// <param name="edgeWeightsProvider">provider of edge weights</param>
        /// <param name="fixedEdgesProvider">provider of fixed edges</param>
        public HamiltonianCycleProblem(string name,
            string comment,
            INodeProvider nodeProvider,
            IEdgeProvider edgeProvider,
            IEdgeWeightsProvider edgeWeightsProvider,
            IFixedEdgesProvider fixedEdgesProvider)
            : base(name, comment, ProblemType.HCP, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider)
        {
        }

        /// <summary>
        /// Load problem from TSP file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>Loaded problem</returns>
        public static HamiltonianCycleProblem FromFile(string fileName)
        {
            return FromTspFile(TspFile.Load(fileName));
        }

        /// <summary>
        /// Gets distance of optimal tour for HCP
        /// </summary>
        public double OptimalTourDistance
        {
            get
            {
                return NodeProvider.CountNodes();
            }
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
        private static HamiltonianCycleProblem FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != FileType.HCP)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            TspFileDataExtractor extractor = new TspFileDataExtractor(tspFile);
            var nodeProvider = extractor.MakeNodeProvider();
            var nodes = nodeProvider.GetNodes();
            var edgeProvider = extractor.MakeEdgeProvider(nodes);
            var edgeWeightsProvider = new NodeAdjacencyBasedWeightProvider(edgeProvider, 1, 2);
            var fixedEdgesProvider = extractor.MakeFixedEdgesProvider(nodes);
            return new HamiltonianCycleProblem(tspFile.Name, tspFile.Comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider);
        }
    }
}