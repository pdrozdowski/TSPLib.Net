namespace TspLibNet.Distance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Extensions;
    using TspLibNet.Nodes;

    /// <summary>
    /// Base distance function
    /// </summary>
    public abstract class DistanceFunctionBase : IDistanceFunction
    {
        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public double Distance(INode a, INode b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            if (b == null)
            {
                throw new ArgumentNullException("b");
            }

            if (a is Node2D && b is Node2D)
            {
                return this.Distance((Node2D)a, (Node2D)b);
            }

            if (a is Node3D && b is Node3D)
            {
                return this.Distance((Node3D)a, (Node3D)b);
            }

            throw new NotSupportedException("Pair of nodes of type A:(" + a.GetType().ToString() + ") and B:(" + b.GetType().ToString() + ") not supported by this distance function");
        }

        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public virtual double Distance(Node2D a, Node2D b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public virtual double Distance(Node3D a, Node3D b)
        {
            throw new NotImplementedException();
        }
    }
}
