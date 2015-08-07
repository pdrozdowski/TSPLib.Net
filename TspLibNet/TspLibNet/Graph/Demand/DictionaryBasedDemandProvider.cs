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
namespace TspLibNet.Graph.Demand
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Provides demand values basing on a provided lokup dictionary
    /// </summary>
    public class DictionaryBasedDemandProvider : IDemandProvider
    {
        /// <summary>
        /// Creates a new instance of DictionaryBasedDemandProvider class.
        /// </summary>
        /// <param name="demandDictionary">Lookup dictionary with a demands</param>
        public DictionaryBasedDemandProvider(Dictionary<INode, int> demandDictionary)
        {
            if (demandDictionary == null)
            {
                throw new ArgumentNullException("demandDictionary");
            }

            this.DemandDictionary = new Dictionary<INode, int>(demandDictionary);
        }

        /// <summary>
        /// Gets or sets demand lookup dictionary
        /// </summary>
        public Dictionary<INode, int> DemandDictionary { get; protected set; }

        /// <summary>
        /// Get demand for given node
        /// </summary>
        /// <returns>Value of demand on a given node</returns>
        public int GetDemand(INode node)
        {
            if (!this.DemandDictionary.ContainsKey(node))
            {
                throw new ArgumentOutOfRangeException("node");
            }

            return this.DemandDictionary[node];
        }
    }
}
