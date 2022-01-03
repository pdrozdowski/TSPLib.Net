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
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Strongly typed edges collection
    /// </summary>
    public class EdgesCollection
    {
        private readonly List<IEdge> _allEdges;
        private readonly Dictionary<int, List<IEdge>> _firstIdToEdges;
        private readonly Dictionary<int, List<IEdge>> _secondIdToEdges;
        private readonly Dictionary<int, Dictionary<int, IEdge>> _idsToEdge;

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count => _allEdges.Count;

        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        public EdgesCollection()
        {
            _allEdges = new List<IEdge>();
            _firstIdToEdges = new Dictionary<int, List<IEdge>>();
            _secondIdToEdges = new Dictionary<int, List<IEdge>>();
            _idsToEdge = new Dictionary<int, Dictionary<int, IEdge>>();
        }

        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        /// <param name="edges">range of edges to add initially</param>
        public EdgesCollection(IEnumerable<IEdge> edges)
        {
            _allEdges = edges.ToList();

            _firstIdToEdges = new Dictionary<int, List<IEdge>>(_allEdges.Count);
            AddToDictionary(_firstIdToEdges, _allEdges, n => n.First.Id);

            _secondIdToEdges = new Dictionary<int, List<IEdge>>(_allEdges.Count);
            AddToDictionary(_secondIdToEdges, _allEdges, n => n.Second.Id);

            _idsToEdge = new Dictionary<int, Dictionary<int, IEdge>>();

            foreach (var edge in _allEdges)
            {
                AddEdge(edge, edge.First, edge.Second);
                AddEdge(edge, edge.Second, edge.First);
            }
        }

        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        /// <param name="edges1">range of edges to add initially</param>
        /// <param name="edges2">range of edges to add initially</param>
        private EdgesCollection(IEnumerable<IEdge> edges1, IEnumerable<IEdge> edges2)
        {
            _allEdges = edges1.ToList();
            _allEdges.AddRange(edges2);

            _firstIdToEdges = new Dictionary<int, List<IEdge>>(_allEdges.Count);
            AddToDictionary(_firstIdToEdges, _allEdges, n => n.First.Id);

            _secondIdToEdges = new Dictionary<int, List<IEdge>>(_allEdges.Count);
            AddToDictionary(_secondIdToEdges, _allEdges, n => n.Second.Id);

            _idsToEdge = new Dictionary<int, Dictionary<int, IEdge>>();

            foreach (var edge in _allEdges)
            {
                AddEdge(edge, edge.First, edge.Second);
                AddEdge(edge, edge.Second, edge.First);
            }
        }

        private static void AddToDictionary(IDictionary<int, List<IEdge>> dictionary, IEnumerable<IEdge> source, Func<IEdge, int> keySelector)
        {
            foreach (var element in source)
            {
                var key = keySelector(element);
                var found = dictionary.TryGetValue(key, out var edges);

                if (found)
                {
                    edges.Add(element);
                }
                else
                {
                    dictionary.Add(key, new List<IEdge> { element });
                }
            }
        }

        private void AddEdge(IEdge edge, INode left, INode right)
        {
            var found = _idsToEdge.TryGetValue(left.Id, out var existingDictionary);

            if (found)
            {
                existingDictionary.Add(right.Id, edge);
            }
            else
            {
                var newDictionary = new Dictionary<int, IEdge> { { right.Id, edge } };
                _idsToEdge.Add(left.Id, newDictionary);
            }
        }

        /// <summary>
        /// Find edge by given pair of nodes
        /// </summary>
        /// <param name="first">edge first node</param>
        /// <param name="second">edge second node</param>
        /// <returns>edge on given pair of nodes or null</returns>
        public IEdge FindEdge(INode first, INode second)
        {
            var firstFound = _idsToEdge.TryGetValue(first.Id, out var secondDictionary);
            
            if (!firstFound)
                return null;

            var secondFound = secondDictionary.TryGetValue(second.Id, out var edge);

            return secondFound ? edge : null;
        }

        /// <summary>
        /// Find edge with given node
        /// </summary>
        /// <param name="node">The node to filter edges by</param>
        /// <returns>Node with given id or null</returns>
        public EdgesCollection FilterByNode(INode node)
        {
            var nodeId = node.Id;
            var firstEdges = _firstIdToEdges[nodeId];
            var secondEdges = _secondIdToEdges[nodeId];
            var result = new EdgesCollection(firstEdges, secondEdges);

            return result;
        }
        
        /// <summary>
        /// Gets a list of all edges.
        /// </summary>
        /// <returns>The list of edges</returns>
        public List<IEdge> ToList()
        {
            return _allEdges;
        }
    }
}