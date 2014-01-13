namespace TspLibNet.Defines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Enumerates types of edge weights
    /// </summary>
    public enum EdgeWeightType
    {
        /// <summary>
        /// Undefined edge weight type
        /// </summary>
        Undefined,

        /// <summary>
        /// Weights are listed explicitly
        /// </summary>
        Explicit,

        /// <summary>
        /// Weights are Euclidean distances in 2D space
        /// </summary>
        Euclidean2D,

        /// <summary>
        /// Weights are Euclidean distances in 2D space rounded up
        /// </summary>
        EuclideanCeiled2D,

        /// <summary>
        /// Weights are Euclidean distances in 3D space
        /// </summary>
        Euclidean3D,

        /// <summary>
        /// Weights are maximum distances in 2D space
        /// </summary>
        Maximum2D,

        /// <summary>
        /// Weights are maximum distances in 3D space
        /// </summary>
        Maximum3D,

        /// <summary>
        /// Weights are Manhattan distances in 2D space
        /// </summary>
        Manhattan2D,

        /// <summary>
        /// Weights are Manhattan distances in 3D space
        /// </summary>
        Manhattan3D,

        /// <summary>
        /// Weights are geographical distances
        /// </summary>
        Geographical,

        /// <summary>
        /// Special distance function for problems att48 and att532
        /// </summary>
        Att,

        /// <summary>
        /// Special distance function for crystallography problems ver 1
        /// </summary>
        XRay1,

        /// <summary>
        /// Special distance function for crystallography problems ver 2
        /// </summary>
        XRay2,

        /// <summary>
        /// There is a pecial distance function documented elsewhere
        /// </summary>
        Special
    }
}
