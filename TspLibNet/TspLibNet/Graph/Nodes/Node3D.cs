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
namespace TspLibNet.Graph.Nodes
{
    /// <summary>
    /// Represents graph 3D node
    /// </summary>
    public class Node3D : INode
    {
        /// <summary>
        /// Creates a new instance of graph node
        /// </summary>
        /// <param name="id">node id</param>
        /// <param name="x">node x coordinate</param>
        /// <param name="y">node y coordinate</param>
        /// <param name="z">node z coordinate</param>
        public Node3D(int id, double x, double y, double z)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        
        /// <summary>
        /// Gets node Id
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets node X coordinate
        /// </summary>
        public double X { get; protected set; }

        /// <summary>
        /// Gets node Y coordinate
        /// </summary>
        public double Y { get; protected set; }

        /// <summary>
        /// Gets node Z coordinate
        /// </summary>
        public double Z { get; protected set; }
    }
}
