namespace TspLibNet.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Math extensions
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Nearest integral value function
        /// </summary>
        /// <param name="d">input value</param>
        /// <returns>nearest integral value</returns>
        public static double NearestInt(double d)
        {
            return Math.Round(d, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Max value of of three
        /// </summary>
        /// <param name="value1">first value</param>
        /// <param name="value2">second value</param>
        /// <param name="value3">third value</param>
        /// <returns>Max value of specified three</returns>
        public static double Max(double value1, double value2, double value3)
        {
            return Math.Max(value1, Math.Max(value2, value3));
        }
    }
}
