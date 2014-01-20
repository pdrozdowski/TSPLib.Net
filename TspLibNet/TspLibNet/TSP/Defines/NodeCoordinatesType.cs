namespace TspLibNet.TSP.Defines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Type of node coordinates
    /// </summary>
    public enum NodeCoordinatesType
    {
        /// <summary>
        /// Node cooridantes type is undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// No coordinates are specified
        /// </summary>
        NoCoordinates,

        /// <summary>
        /// Coordinates are in 2D
        /// </summary>
        Coordinates2D,

        /// <summary>
        /// Coordinates are in 3D
        /// </summary>
        Coordinates3D
    }
}
