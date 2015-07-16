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
namespace TspLibNet.TSP.Defines
{
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
        PseudoEuclidean,

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
