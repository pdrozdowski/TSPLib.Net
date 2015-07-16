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
namespace TspLibNet.Graph.Edges
{
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Interface for providing graph edges
    /// </summary>
    public interface IEdgeProvider
    {
        /// <summary>
        /// Get edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Edge between given nodes or null</returns>
        IEdge GetEdge(INode first, INode second);

        /// <summary>
        /// Checks if there is edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Indicates if there is an edge between given nodes</returns>
        bool HasEdge(INode first, INode second);

        /// <summary>
        /// Get total number of edges
        /// </summary>
        /// <returns>Total number of edges</returns>
        int CountEdges();
    }
}
