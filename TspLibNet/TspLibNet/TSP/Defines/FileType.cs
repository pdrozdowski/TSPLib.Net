namespace TspLibNet.TSP.Defines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Enumerates type of data in TSP files
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// File type is undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// Data for symmetric traveling salesman problem
        /// </summary>
        TSP,

        /// <summary>
        /// Data for asymmetric traveling salesman problem
        /// </summary>
        ATSP,

        /// <summary>
        /// Data for sequential ordering problem
        /// </summary>
        SOP,

        /// <summary>
        /// Data for hamiltonian cycle problem
        /// </summary>
        HCP,

        /// <summary>
        /// Data for capacitated vehicle routing problem
        /// </summary>
        CVRP,

        /// <summary>
        /// File with a tour
        /// </summary>
        TOUR
    }
}
