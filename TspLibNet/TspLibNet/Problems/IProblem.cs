namespace TspLibNet.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Tours;
    using TspLibNet.Graphs;

    /// <summary>
    /// Interface for a graph based problem
    /// </summary>
    public interface IProblem
    {
        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// Gets number of nodes in problem
        /// </summary>
        int NodesCount { get; }

        /// <summary>
        /// Gets number of edges in problem
        /// </summary>
        int EdgesCount { get; }

        /// <summary>
        /// List of edges required to appear in each solution to the problem
        /// </summary>
        List<IEdge> FixedEdges { get; }

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Whether tour is valid</returns>
        bool ValidateSolution(ITour tour);

        /// <summary>
        /// Validate given solution
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="errors">utputs list of errors found in tour</param>
        /// <returns>Whether tour is valid</returns>
        bool ValidateSolution(ITour tour, out string[] errors);

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Tour distance</returns>
        double SolutionDistance(ITour tour);
    }
}
