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
    using System.Text;
    using TspLibNet.Graph;
    using TspLibNet.Tours;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Graph.Edges;
    using TspLibNet.Graph.EdgeWeights;
    using TspLibNet.Graph.FixedEdges;
    using TspLibNet.Graph.Depots;
    using TspLibNet.Graph.Demand;
    using TspLibNet.TSP;

    /// <summary>
    /// Capacitated Vehicle Routing Problem
    /// </summary>
    public class CapacitatedVehicleRoutingProblem : ProblemBase
    {
        public CapacitatedVehicleRoutingProblem(string name, string comment, INodeProvider nodeProvider, IEdgeProvider edgeProvider, IEdgeWeightsProvider edgeWeightsProvider, IFixedEdgesProvider fixedEdgesProvider, IDepotsProvider depotsProvider, IDemandProvider demandProvider)
            : base(name, comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider)
        {
            if (depotsProvider == null)
            {
                throw new ArgumentNullException("depotsProvider");
            }

            if (demandProvider == null)
            {
                throw new ArgumentNullException("demandProvider");
            }

            this.DepotsProvider = depotsProvider;
            this.DemandProvider = demandProvider;
        }

        public static CapacitatedVehicleRoutingProblem FromFile(string fileName)
        {
            return FromTspFile(TspFile.Load(fileName));
        }

        public static CapacitatedVehicleRoutingProblem FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != TSP.Defines.FileType.CVRP)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            TspFileDataExtractor extractor = new TspFileDataExtractor(tspFile);
            var nodeProvider = extractor.MakeNodeProvider();
            var nodes = nodeProvider.GetNodes();
            var edgeProvider = extractor.MakeEdgeProvider(nodes);
            var edgeWeightsProvider = extractor.MakeEdgeWeightsProvider();
            var fixedEdgesProvider = extractor.MakeFixedEdgesProvider(nodes);
            var depots = extractor.MakeDepotsProvider(nodes);
            var demand = extractor.MakeDemandProvider(nodes);
            return new CapacitatedVehicleRoutingProblem(tspFile.Name, tspFile.Comment, nodeProvider, edgeProvider, edgeWeightsProvider, fixedEdgesProvider, depots, demand);
        }

        /// <summary>
        /// Gets depots provider
        /// </summary>
        public IDepotsProvider DepotsProvider { get; protected set; }

        /// <summary>
        /// Gets demand provider
        /// </summary>
        public IDemandProvider DemandProvider { get; protected set; }
        
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
