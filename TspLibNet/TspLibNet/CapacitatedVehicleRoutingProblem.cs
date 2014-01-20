namespace TspLibNet.Problems
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
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="errors">utputs list of errors found in tour</param>
        /// <returns>Whether tour is valid</returns>
        public override bool ValidateTour(ITour tour, out string[] errors)
        {
            throw new NotImplementedException();
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
    }
}
