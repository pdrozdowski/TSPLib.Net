namespace TspLibNet.Defines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Specifies how a graphical display of the nodes can be obtained
    /// </summary>
    public enum DisplayDataType
    {
        /// <summary>
        /// Data display is not defined
        /// </summary>
        Undefined,

        /// <summary>
        /// Display is generated from the node coordinates (is default when coordinates are specified)
        /// </summary>
        Coordinates,

        /// <summary>
        /// Explicit coordinates in 2D are given
        /// </summary>
        Display2D,

        /// <summary>
        /// No graphical display is possible (is default when coordinates are not specified)
        /// </summary>
        NoDisplay
    }
}
