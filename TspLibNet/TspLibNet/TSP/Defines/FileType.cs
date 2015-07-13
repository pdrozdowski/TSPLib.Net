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
