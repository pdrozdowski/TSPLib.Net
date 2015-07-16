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
    using Graph.Nodes;
    using System;

    /// <summary>
    /// Factory making nodes
    /// </summary>
    public class NodesFactory
    {
        /// <summary>
        /// Create random problem with given number of nodes
        /// </summary>
        /// <param name="numberOfNodes">number of nodes in the proble</param>
        /// <param name="width">problem space width</param>
        /// <param name="height">problem space height</param>
        /// <returns>Generated problem</returns>
        public static NodesCollection MakeNodes(int numberOfNodes, int width, int height)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            NodesCollection nodes = new NodesCollection();
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes.Add(new Node2D(i + 1, random.NextDouble() * width, random.NextDouble() * height));
            }

            return nodes;
        }

        /// <summary>
        /// Create random problem with given number of nodes, problem space by default is square of size 1.0 x 1.0
        /// </summary>
        /// <param name="numberOfNodes">number of nodes in the problem</param>
        /// <returns>Generated problem</returns>
        public static NodesCollection MakeNodes(int numberOfNodes)
        {
            return MakeNodes(numberOfNodes, 1, 1);
        }
    }
}