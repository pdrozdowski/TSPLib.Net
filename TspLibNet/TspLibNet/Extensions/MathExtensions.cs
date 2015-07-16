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
namespace TspLibNet.Extensions
{
    using System;

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
