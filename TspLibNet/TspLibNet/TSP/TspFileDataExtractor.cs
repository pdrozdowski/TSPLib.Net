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

namespace TspLibNet.TSP
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.DistanceFunctions;
    using TspLibNet.Graph.Demand;
    using TspLibNet.Graph.Depots;
    using TspLibNet.Graph.Edges;
    using TspLibNet.Graph.EdgeWeights;
    using TspLibNet.Graph.FixedEdges;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Builds graph from TSP data file
    /// </summary>
    public class TspFileDataExtractor
    {
        private TspFile tspFile;

        /// <summary>
        /// Creates a new instance of TSP file data extractor
        /// </summary>
        /// <param name="tspFile">tsp file to use</param>
        public TspFileDataExtractor(TspFile tspFile)
        {
            if (tspFile == null)
            {
                throw new ArgumentNullException("tspFile");
            }

            this.tspFile = tspFile;
        }

        /// <summary>
        /// Makes a node provider
        /// </summary>
        /// <returns>node provider</returns>
        public INodeProvider MakeNodeProvider()
        {
            if (tspFile.NodeCoordinatesType == Defines.NodeCoordinatesType.NoCoordinates)
            {
                return new DimensionBasedNodeProvider(tspFile.Dimension);
            }
            else if (tspFile.NodeCoordinatesType == Defines.NodeCoordinatesType.Coordinates2D)
            {
                List<INode> nodes = new List<INode>();
                foreach (object[] data in tspFile.Nodes)
                {
                    nodes.Add(new Node2D((int)data[0], (double)data[1], (double)data[2]));
                }

                return new NodeListBasedNodeProvider(nodes);
            }
            else if (tspFile.NodeCoordinatesType == Defines.NodeCoordinatesType.Coordinates3D)
            {
                List<INode> nodes = new List<INode>();
                foreach (object[] data in tspFile.Nodes)
                {
                    nodes.Add(new Node3D((int)data[0], (double)data[1], (double)data[2], (double)data[3]));
                }

                return new NodeListBasedNodeProvider(nodes);
            }
            else throw new NotSupportedException();
        }

        /// <summary>
        /// Makes an edge provider
        /// </summary>
        /// <param name="nodes">current set of nodes</param>
        /// <returns>edge provider</returns>
        public IEdgeProvider MakeEdgeProvider(IEnumerable<INode> nodes)
        {
            if (tspFile.NodeCoordinatesType == Defines.NodeCoordinatesType.Coordinates2D || tspFile.NodeCoordinatesType == Defines.NodeCoordinatesType.Coordinates3D)
            {
                return new NodeBasedEdgeProvider(nodes);
            }

            if (tspFile.EdgeDataFormat == Defines.EdgeDataFormat.EdgeList)
            {
                return new EdgeListBasedEdgeProvider(this.LoadEdges(nodes));
            }
            else if (tspFile.EdgeDataFormat == Defines.EdgeDataFormat.AdjacencyList)
            {
                throw new NotImplementedException("AdjacencyList is not supported, not used in original set of problems of TSPLIB and so not implemented");
            }
            else if (tspFile.EdgeDataFormat == Defines.EdgeDataFormat.Undefined)
            {
                return new WeightMatrixBasedEdgeProviderWithExclusions(this.LoadWeightMatrix(), new double[] { });
            }
            else throw new NotSupportedException();
        }

        /// <summary>
        /// Makes an edge weights provider
        /// </summary>
        /// <returns>edge weights provider</returns>
        public IEdgeWeightsProvider MakeEdgeWeightsProvider()
        {
            // edge weight type is not specified
            if (tspFile.EdgeWeightType == Defines.EdgeWeightType.Undefined)
            {
                throw new NotSupportedException();
            }

            // edge weight should be function based, get approperiate
            if (tspFile.EdgeWeightFormat == Defines.EdgeWeightFormat.Function)
            {
                return new FunctionBasedWeightProvider(this.LoadDistanceFunction());
            }
            // edge weight should be matrix based
            else if (tspFile.EdgeWeightType == Defines.EdgeWeightType.Explicit)
            {
                // matrix format not specified
                if (tspFile.EdgeWeightFormat == Defines.EdgeWeightFormat.Undefined)
                {
                    throw new NotSupportedException();
                }
                // have to be matrix but format set to function
                else if (tspFile.EdgeWeightFormat == Defines.EdgeWeightFormat.Function)
                {
                    throw new NotSupportedException();
                }
                else
                {
                    return new MatrixBasedWeightProvider(this.LoadWeightMatrix());
                }
            }
            else
            {
                // edge weight is not function nor matrix based
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Makes a fixed edges provider
        /// </summary>
        /// <param name="nodes">current set of nodes</param>
        /// <returns>fixed edges</returns>
        public IFixedEdgesProvider MakeFixedEdgesProvider(IEnumerable<INode> nodes)
        {
            return new EdgeListBasedFixedEdgesProvider(this.LoadFixedEdges(nodes));
        }

        /// <summary>
        /// Makes depots provider
        /// </summary>
        /// <param name="nodes">current set of nodes</param>
        /// <returns>depots provider</returns>
        public IDepotsProvider MakeDepotsProvider(IEnumerable<INode> nodes)
        {
            return new NodeListBasedDepotProvider(this.LoadDepots(nodes));
        }

        /// <summary>
        /// Makes demands porivee
        /// </summary>
        /// <param name="nodes">current set of nodes</param>
        /// <returns>demands porivee</returns>
        public IDemandProvider MakeDemandProvider(IEnumerable<INode> nodes)
        {
            return new DictionaryBasedDemandProvider(this.LoadDemands(nodes));
        }

        /// <summary>
        /// Loads nodes that are depots
        /// </summary>
        /// <param name="nodes">all nodes in graph</param>
        /// <returns>Nodes that are depots</returns>
        protected List<INode> LoadDepots(IEnumerable<INode> nodes)
        {
            NodesCollection graphNodes = new NodesCollection(nodes);
            NodesCollection result = new NodesCollection();
            foreach (int id in tspFile.Depots)
            {
                result.Add(graphNodes.FindById(id));
            }

            return result.ToList();
        }

        /// <summary>
        /// Loads demands for graph nodes
        /// </summary>
        /// <param name="nodes">all nodes in graph</param>
        /// <returns>demands for graph nodes</returns>
        protected Dictionary<INode, int> LoadDemands(IEnumerable<INode> nodes)
        {
            NodesCollection graphNodes = new NodesCollection(nodes);
            Dictionary<INode, int> result = new Dictionary<INode, int>();
            foreach (int[] entry in tspFile.Demands)
            {
                result.Add(graphNodes.FindById(entry[0]), entry[1]);
            }

            return result;
        }

        /// <summary>
        /// Build edges given in tsp file
        /// </summary>
        /// <param name="nodes">graph nodes</param>
        /// <returns>List of edges</returns>
        protected List<IEdge> LoadEdges(IEnumerable<INode> nodes)
        {
            NodesCollection graphNodes = new NodesCollection(nodes);
            List<IEdge> result = new List<IEdge>();
            if (tspFile.Edges != null)
            {
                foreach (int[] entry in tspFile.Edges)
                {
                    if (entry[0] == -1)
                    {
                        break;
                    }

                    result.Add(new Edge(graphNodes.FindById(entry[0]), graphNodes.FindById(entry[1])));
                }
            }

            return result;
        }

        /// <summary>
        /// Build fixed edges given in tsp file
        /// </summary>
        /// <param name="nodes">graph nodes</param>
        /// <returns>List of fixed edges</returns>
        protected List<IEdge> LoadFixedEdges(IEnumerable<INode> nodes)
        {
            NodesCollection graphNodes = new NodesCollection(nodes);
            List<IEdge> result = new List<IEdge>();
            if (tspFile.FixedEdges != null)
            {
                foreach (int[] entry in tspFile.FixedEdges)
                {
                    if (entry[0] == -1)
                    {
                        break;
                    }

                    result.Add(new Edge(graphNodes.FindById(entry[0]), graphNodes.FindById(entry[1])));
                }
            }

            return result;
        }

        /// <summary>
        /// Loads weight matrix from tsp data
        /// </summary>
        /// <returns>Edge weight matrix</returns>
        protected double[,] LoadWeightMatrix()
        {
            MatrixBuilder matrixBuilder = new MatrixBuilder();
            switch (tspFile.EdgeWeightFormat)
            {
                case Defines.EdgeWeightFormat.FullMatrix:
                    return matrixBuilder.BuildFromFullMatrix(tspFile.EdgeWeights, tspFile.Dimension);

                case Defines.EdgeWeightFormat.UpperRow:
                case Defines.EdgeWeightFormat.LowerColumn:
                    return matrixBuilder.BuildFromUpperRow(tspFile.EdgeWeights, tspFile.Dimension);

                case Defines.EdgeWeightFormat.LowerRow:
                case Defines.EdgeWeightFormat.UpperColumn:
                    return matrixBuilder.BuildFromLowerRow(tspFile.EdgeWeights, tspFile.Dimension);

                case Defines.EdgeWeightFormat.UpperDiagonalRow:
                case Defines.EdgeWeightFormat.LowerDiagonalColumn:
                    return matrixBuilder.BuildFromUpperDiagonalRow(tspFile.EdgeWeights, tspFile.Dimension);

                case Defines.EdgeWeightFormat.LowerDiagonalRow:
                case Defines.EdgeWeightFormat.UpperDiagonalColumn:
                    return matrixBuilder.BuildFromLowerDiagonalRow(tspFile.EdgeWeights, tspFile.Dimension);

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Loads distance function
        /// </summary>
        /// <returns>Loaded distance function</returns>
        protected IDistanceFunction LoadDistanceFunction()
        {
            switch (tspFile.EdgeWeightType)
            {
                case Defines.EdgeWeightType.Euclidean2D:
                case Defines.EdgeWeightType.Euclidean3D:
                    return new Euclidean();

                case Defines.EdgeWeightType.EuclideanCeiled2D:
                    return new EuclideanCeiled();

                case Defines.EdgeWeightType.Manhattan2D:
                case Defines.EdgeWeightType.Manhattan3D:
                    return new Manhattan();

                case Defines.EdgeWeightType.Maximum2D:
                case Defines.EdgeWeightType.Maximum3D:
                    return new Maximum();

                case Defines.EdgeWeightType.Geographical:
                    return new Geographical();

                case Defines.EdgeWeightType.PseudoEuclidean:
                    return new PseudoEuclidean();

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Lookups list of int arrays
        /// </summary>
        /// <param name="data">data to check</param>
        /// <param name="key">key to look up</param>
        /// <returns>found value or 0</returns>
        private int LookupIntArrayList(List<int[]> data, int key)
        {
            foreach (int[] entry in data)
            {
                if (entry[0] == key)
                {
                    return entry[1];
                }
            }

            return 0;
        }
    }
}