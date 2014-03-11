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
namespace TspLibNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Tours;

    /// <summary>
    /// Class represents instance of a TSP lib containing problem and it's optimal solution if available
    /// </summary>
    public class TspLib95Item
    {
        /// <summary>
        /// Member cacheing optimal tour distance
        /// </summary>
        private double optimalTourDistance = double.MaxValue;
        
        /// <summary>
        /// Creates new instance of TspLib95Item class
        /// </summary>
        /// <param name="problem">TSP problem to be encapsulated</param>
        /// <param name="optimalTour">Optimal tour of the problem</param>
        /// <param name="optimalTourDistance">Optimal tour distance</param>
        public TspLib95Item(IProblem problem, ITour optimalTour, double optimalTourDistance)
        {
            if (problem == null)
            {
                throw new ArgumentNullException("problem");
            }

            this.Problem = problem;
            this.OptimalTour = optimalTour;
            this.optimalTourDistance = optimalTourDistance;
        }

        /// <summary>
        /// Gets or sets problem
        /// </summary>
        public IProblem Problem { get; protected set; }

        /// <summary>
        /// Gets or sets optimal tour, null if not available
        /// </summary>
        public ITour OptimalTour { get; protected set; }
        
        /// <summary>
        /// Distance of optimal tour, if not availavle then returns int.MaxValue
        /// </summary>
        public double OptimalTourDistance
        {
            get
            {
                if (this.optimalTourDistance == double.MaxValue && this.OptimalTour != null)
                {
                    this.optimalTourDistance = this.Problem.TourDistance(this.OptimalTour);
                }

                return this.optimalTourDistance;
            }
        }

        /// <summary>
        /// Gets string representation of an instance
        /// </summary>
        /// <returns>string representation of an instance</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Problem.GetType().ToString());
            builder.Append(" - ");
            builder.Append(this.Problem.Name);
            builder.Append(" - ");
            builder.Append(this.Problem.Comment);
            builder.Append(" - ");
            builder.Append("OptimalTour: ");
            if(this.OptimalTour != null)
                builder.Append("Available");
            else builder.Append("Not Available");
            builder.Append(" - ");
            builder.Append("OptimalTourDistance: ");
            if(this.OptimalTourDistance != double.MaxValue)
                builder.Append(this.OptimalTourDistance);
            else builder.Append("Unknown");
            return builder.ToString();
        }
    }
}
