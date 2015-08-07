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
namespace TspLibNet.Tours
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.TSP;

    /// <summary>
    /// Tour class represents problem solution as a sequence of nodes to visit
    /// </summary>
    public class Tour : ITour
    {
        /// <summary>
        /// Create new instance of Tour class.
        /// </summary>
        /// <param name="name">file name which identifies the data file</param>
        /// <param name="comment">additional comments from problem author</param>
        /// <param name="dimension">problem dimension</param>
        /// <param name="nodes">tour nodes</param>
        public Tour(string name, string comment, int dimension, IEnumerable<int> nodes)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (dimension < 0)
            {
                throw new ArgumentOutOfRangeException("dimension");
            }

            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            this.Name = name;
            this.Comment = comment; 
            this.Dimension = dimension;
            this.Nodes = new List<int>(nodes);
            if (dimension == 0)
            {
                this.Dimension = this.Nodes.Count;
            }
        }

        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        public string Comment { get; protected set; }

        /// <summary>
        /// Gets problem dimension
        /// </summary>
        public int Dimension { get; protected set; }

        /// <summary>
        /// Gets list of node id's to visit
        /// </summary>
        public List<int> Nodes { get; protected set; }

        /// <summary>
        /// Create tour from TSP file
        /// </summary>
        /// <param name="tspFile">tsp file to load from</param>
        /// <returns>Tour read from tsp file</returns>
        public static Tour FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != TSP.Defines.FileType.TOUR)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            return new Tour(tspFile.Name, tspFile.Comment, tspFile.Dimension, tspFile.Tour);
        }

        /// <summary>
        /// Load tour from TSP file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>Loaded tour</returns>
        public static Tour FromFile(string fileName)
        {
            return FromTspFile(TspFile.Load(fileName));
        }
    }
}
