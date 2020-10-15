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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Strongly typed nodes collection
    /// </summary>
    public class NodesCollection
    {
        private readonly Dictionary<int, INode> _idToNodes;
        private List<INode> _valueCache;

        /// <summary>
        /// Creates new instance of NodesCollection
        /// </summary>
        public NodesCollection()
        {
            _idToNodes = new Dictionary<int, INode>();
        }

        /// <summary>
        /// Creates new instance of NodesCollection
        /// </summary>
        /// <param name="nodes">range of nodes to add initially</param>
        public NodesCollection(IEnumerable<INode> nodes)
        {
            _idToNodes = nodes.ToDictionary(n => n.Id);
        }

        public int Count => _idToNodes.Count;

        public void Add(INode node)
        {
            _idToNodes.Add(node.Id, node);
            _valueCache = null;
        }

        /// <summary>
        /// Find node by id
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>node with given id or null</returns>
        public INode FindById(int id)
        {
            var found = _idToNodes.TryGetValue(id, out var node);

            return found ? node : null;
        }

        public bool Contains(INode first)
        {
            return _idToNodes.ContainsKey(first.Id);
        }

        public List<INode> ToList()
        {
            return _valueCache ?? (_valueCache = _idToNodes.Values.ToList());
        }
    }
}
