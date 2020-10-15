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
    using Tours;

    /// <summary>
    /// Represents possible TSPLIB problem types.
    /// </summary>
    public enum ProblemType
    {
        /// <summary> Symmetric TSP </summary>
        TSP,

        /// <summary> Aymmetric TSP </summary>
        ATSP,

        /// <summary> Hamiltonian Cycle Problem </summary>
        HCP,

        /// <summary> Sequential Ordering Problem </summary>
        SOP,

        /// <summary> Capacitated Vehicle Routing Problem </summary>
        CVRP
    }

    /// <summary>
    /// Interface for a graph based problems
    /// </summary>
    public interface IProblem
    {
        /// <summary>
        /// Represents the problem type (TSP, ATSP, etc).
        /// </summary>
        ProblemType Type { get; }

        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <param name="validate">Validate the tour</param>
        /// <returns>Tour distance</returns>
        double TourDistance(ITour tour, bool validate = true);

        /// <summary>
        /// Gets nodes provider
        /// </summary>
        INodeProvider NodeProvider { get; }

        /// <summary>
        /// Gets Edges provider
        /// </summary>
        IEdgeProvider EdgeProvider { get; }

        /// <summary>
        /// Gets Edge Weights Provider
        /// </summary>
        IEdgeWeightsProvider EdgeWeightsProvider { get; }

        /// <summary>
        /// Gets Fixed Edges Provider
        /// </summary>
        IFixedEdgesProvider FixedEdgesProvider { get; }
    }
}