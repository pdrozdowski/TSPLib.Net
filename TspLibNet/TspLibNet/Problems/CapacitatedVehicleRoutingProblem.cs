namespace TspLibNet.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graphs;
    using TspLibNet.Tours;

    /// <summary>
    /// Capacitated Vehicle Routing Problem
    /// </summary>
    public class CapacitatedVehicleRoutingProblem : IProblem
    {
        /// <summary>
        /// Gets number of depots in problem
        /// </summary>
        public int DepotsCount { get; protected set; }

        /// <summary>
        /// Gets truck capacity in a CVRP
        /// </summary>
        public int Capacity { get; protected set; }

        /// <summary>
        /// Gets list of alternate depots
        /// </summary>
        public int[] Depots { get; protected set; }

        /// <summary>
        /// The demands of all nodes of CVRP, first is node, second is it's demand. Depot nodes have demands = 0.
        /// </summary>
        public List<KeyValuePair<int, int>> Demands { get; protected set; }

        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        public string Comment { get; protected set; }

        /// <summary>
        /// Gets number of nodes in problem
        /// </summary>
        public int NodesCount { get; protected set; }

        /// <summary>
        /// Gets number of edges in problem
        /// </summary>
        public int EdgesCount { get; protected set; }

        /// <summary>
        /// List of edges required to appear in each solution to the problem
        /// </summary>
        public List<IEdge> FixedEdges { get; protected set; }

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Whether tour is valid</returns>
        public bool ValidateSolution(ITour tour)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="errors">utputs list of errors found in tour</param>
        /// <returns>Whether tour is valid</returns>
        public bool ValidateSolution(ITour tour, out string[] errors)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Tour distance</returns>
        public double SolutionDistance(ITour tour)
        {
            throw new NotImplementedException();
        }
    }
}
