/* The MIT License (MIT)
*
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TspLibNet;
using TspLibNet.Tours;

namespace TspLibNetTests
{
    [TestClass]
    public class TspDistanceCalculationTests
    {
        private const string RootDir = @"..\..\..\..\..\TSPLIB95";

        [TestMethod]
        public void VerifyPcb442CanonicalTsp()
        {
            var tourDistance = TspCanonicalDistance("pcb442", 442);
            Assert.AreEqual(tourDistance, 221440);
        }

        [TestMethod]
        public void VerifyGr666CanonicalTsp()
        {
            var tourDistance = TspCanonicalDistance("gr666", 666);
            Assert.AreEqual(tourDistance, 423710);
        }

        [TestMethod]
        public void VerifyAtt532CanonicalTsp()
        {
            var tourDistance = TspCanonicalDistance("att532", 532);
            Assert.AreEqual(tourDistance, 309636);
        }

        private static double TspCanonicalDistance(string problemName, int nrNodes)
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadTSP(problemName);
            var problem = tspLib.GetItemByName(problemName, ProblemType.TSP).Problem;
            var nodes = Enumerable.Range(1, nrNodes);
            var tour = new Tour(problemName, "", nodes.Count(), nodes);
            return problem.TourDistance(tour);
        }
    }
}