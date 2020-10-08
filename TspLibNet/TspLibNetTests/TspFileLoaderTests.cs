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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using TspLibNet;
using TspLibNet.Tours;
using TspLibNet.TSP;
using TspLibNet.TSP.Defines;

namespace TspLibNetTests
{
    [TestClass]
    public class TspFileLoaderTests
    {
        private const string RootDir = @"..\..\..\..\..\TSPLIB95";

        [TestMethod]
        public void LoadBerlin52Problem()
        {
            TspFile tspFile;
            var loader = new TspFileLoader();
            using (var reader = new StreamReader(Samples.Berlin52_Problem))
            {
                tspFile = loader.Load(reader);
                reader.Close();
            }

            Assert.IsNotNull(tspFile);

            Assert.AreEqual("berlin52", tspFile.Name);
            Assert.AreEqual(FileType.TSP, tspFile.Type);
            Assert.AreEqual("52 locations in Berlin (Groetschel)", tspFile.Comment);
            Assert.AreEqual(52, tspFile.Dimension);
            Assert.AreEqual(EdgeWeightType.Euclidean2D, tspFile.EdgeWeightType);
            Assert.AreEqual(52, tspFile.Nodes.Count);

            Assert.AreEqual(1, tspFile.Nodes[0][0]);
            Assert.AreEqual(565.0, tspFile.Nodes[0][1]);
            Assert.AreEqual(575.0, tspFile.Nodes[0][2]);

            Assert.AreEqual(2, tspFile.Nodes[1][0]);
            Assert.AreEqual(25.0, tspFile.Nodes[1][1]);
            Assert.AreEqual(185.0, tspFile.Nodes[1][2]);

            Assert.AreEqual(52, tspFile.Nodes[51][0]);
            Assert.AreEqual(1740.0, tspFile.Nodes[51][1]);
            Assert.AreEqual(245.0, tspFile.Nodes[51][2]);
        }

        [TestMethod]
        public void LoadBerlin52Tour()
        {
            TspFile tspFile;
            var loader = new TspFileLoader();
            using (var reader = new StreamReader(Samples.Berlin52_Tour))
            {
                tspFile = loader.Load(reader);
                reader.Close();
            }

            Assert.IsNotNull(tspFile);

            Assert.AreEqual("berlin52.opt.tour", tspFile.Name);
            Assert.AreEqual(FileType.TOUR, tspFile.Type);
            Assert.AreEqual(52, tspFile.Dimension);
            Assert.AreEqual(52, tspFile.Tour.Count);

            Assert.AreEqual(1, tspFile.Tour[0]);
            Assert.AreEqual(49, tspFile.Tour[1]);
            Assert.AreEqual(22, tspFile.Tour[51]);
        }

        [TestMethod]
        public void ConstructTravelingSalesmanProblems()
        {
            var files = new List<string>(Directory.EnumerateFiles(RootDir, "*.tsp", SearchOption.AllDirectories));
            foreach (var fileName in files)
            {
                var problem = TravelingSalesmanProblem.FromFile(fileName);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructAsymmetricTravelingSalesmanProblems()
        {
            var files = new List<string>(Directory.EnumerateFiles(RootDir, "*.atsp", SearchOption.AllDirectories));
            foreach (var fileName in files)
            {
                var problem = TravelingSalesmanProblem.FromFile(fileName);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructHamiltonianCycleProblems()
        {
            var files = new List<string>(Directory.EnumerateFiles(RootDir, "*.hcp", SearchOption.AllDirectories));
            foreach (var fileName in files)
            {
                var problem = HamiltonianCycleProblem.FromFile(fileName);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructSequentialOrderingProblems()
        {
            var files = new List<string>(Directory.EnumerateFiles(RootDir, "*.sop", SearchOption.AllDirectories));
            foreach (var fileName in files)
            {
                var problem = SequentialOrderingProblem.FromFile(fileName);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructCapacitatedVehicleRoutingProblems()
        {
            var files = new List<string>(Directory.EnumerateFiles(RootDir, "*.vrp", SearchOption.AllDirectories));
            foreach (var fileName in files)
            {
                var problem = CapacitatedVehicleRoutingProblem.FromFile(fileName);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructTours()
        {
            var files = new List<string>(Directory.EnumerateFiles(RootDir, "*.tour", SearchOption.AllDirectories));
            foreach (var fileName in files)
            {
                ITour tour = Tour.FromFile(fileName);
                Assert.IsNotNull(tour);
                Assert.AreEqual(tour.Dimension, tour.Nodes.Count);
            }
        }

        [TestMethod]
        public void CheckOptTourDistancesOnTSP()
        {
            AssertTourDistance(FileType.TSP, "tsp/a280.tsp", "tsp/a280.opt.tour", 2579);
            AssertTourDistance(FileType.TSP, "tsp/att48.tsp", "tsp/att48.opt.tour", 10628);
            AssertTourDistance(FileType.TSP, "tsp/bayg29.tsp", "tsp/bayg29.opt.tour", 1610);
            AssertTourDistance(FileType.TSP, "tsp/bays29.tsp", "tsp/bays29.opt.tour", 2020);
            AssertTourDistance(FileType.TSP, "tsp/berlin52.tsp", "tsp/berlin52.opt.tour", 7542);
            AssertTourDistance(FileType.TSP, "tsp/brg180.tsp", "tsp/brg180.opt.tour", 1950);
            AssertTourDistance(FileType.TSP, "tsp/ch130.tsp", "tsp/ch130.opt.tour", 6110);
            AssertTourDistance(FileType.TSP, "tsp/ch150.tsp", "tsp/ch150.opt.tour", 6528);
            AssertTourDistance(FileType.TSP, "tsp/eil51.tsp", "tsp/eil51.opt.tour", 426);
            AssertTourDistance(FileType.TSP, "tsp/eil76.tsp", "tsp/eil76.opt.tour", 538);
            AssertTourDistance(FileType.TSP, "tsp/eil101.tsp", "tsp/eil101.opt.tour", 629);
            AssertTourDistance(FileType.TSP, "tsp/fri26.tsp", "tsp/fri26.opt.tour", 937);
            AssertTourDistance(FileType.TSP, "tsp/gr24.tsp", "tsp/gr24.opt.tour", 1272);
            AssertTourDistance(FileType.TSP, "tsp/gr48.tsp", "tsp/gr48.opt.tour", 5046);
            AssertTourDistance(FileType.TSP, "tsp/gr120.tsp", "tsp/gr120.opt.tour", 6942);
            AssertTourDistance(FileType.TSP, "tsp/kroA100.tsp", "tsp/kroA100.opt.tour", 21282);
            AssertTourDistance(FileType.TSP, "tsp/kroC100.tsp", "tsp/kroC100.opt.tour", 20749);
            AssertTourDistance(FileType.TSP, "tsp/kroD100.tsp", "tsp/kroD100.opt.tour", 21294);
            AssertTourDistance(FileType.TSP, "tsp/lin105.tsp", "tsp/lin105.opt.tour", 14379);
            AssertTourDistance(FileType.TSP, "tsp/pa561.tsp", "tsp/pa561.opt.tour", 2763);
            AssertTourDistance(FileType.TSP, "tsp/pcb442.tsp", "tsp/pcb442.opt.tour", 50778);
            AssertTourDistance(FileType.TSP, "tsp/pr76.tsp", "tsp/pr76.opt.tour", 108159);
            AssertTourDistance(FileType.TSP, "tsp/pr1002.tsp", "tsp/pr1002.opt.tour", 259045);
            AssertTourDistance(FileType.TSP, "tsp/pr2392.tsp", "tsp/pr2392.opt.tour", 378032);
            AssertTourDistance(FileType.TSP, "tsp/rd100.tsp", "tsp/rd100.opt.tour", 7910);
            AssertTourDistance(FileType.TSP, "tsp/st70.tsp", "tsp/st70.opt.tour", 675);
            AssertTourDistance(FileType.TSP, "tsp/tsp225.tsp", "tsp/tsp225.opt.tour", 3916);
            AssertTourDistance(FileType.TSP, "tsp/ulysses22.tsp", "tsp/ulysses22.opt.tour", 7013);
            AssertTourDistance(FileType.TSP, "tsp/ulysses16.tsp", "tsp/ulysses16.opt.tour", 6859);
            AssertTourDistance(FileType.TSP, "tsp/gr96.tsp", "tsp/gr96.opt.tour", 55209);
            AssertTourDistance(FileType.TSP, "tsp/gr202.tsp", "tsp/gr202.opt.tour", 40160);
            AssertTourDistance(FileType.TSP, "tsp/gr666.tsp", "tsp/gr666.opt.tour", 294358);
            AssertTourDistance(FileType.TSP, "tsp/pla33810.tsp", "tsp/pla33810.opt.tour", 66048945);
        }

        [TestMethod]
        public void CheckOptTourDistancesOnHCP()
        {
            AssertHCPTourDistance("hcp/alb1000.hcp", "hcp/alb1000.opt.tour");
            AssertHCPTourDistance("hcp/alb2000.hcp", "hcp/alb2000.opt.tour");
            AssertHCPTourDistance("hcp/alb3000a.hcp", "hcp/alb3000a.opt.tour");
            AssertHCPTourDistance("hcp/alb3000b.hcp", "hcp/alb3000b.opt.tour");
            AssertHCPTourDistance("hcp/alb3000c.hcp", "hcp/alb3000c.opt.tour");
            AssertHCPTourDistance("hcp/alb3000d.hcp", "hcp/alb3000d.opt.tour");
            AssertHCPTourDistance("hcp/alb3000e.hcp", "hcp/alb3000e.opt.tour");
            AssertHCPTourDistance("hcp/alb4000.hcp", "hcp/alb4000.opt.tour");
            AssertHCPTourDistance("hcp/alb5000.hcp", "hcp/alb5000.opt.tour");
        }

        // TODO: no opt tours for SOP, VRP, ATSP with known distance for validation

        private static void AssertTourDistance(FileType problemType, string problemFileName, string tourFileName, int expectedDistance)
        {
            var problemTspFile = Path.Combine(RootDir, problemFileName);
            var tourTspFile = TspFile.Load(Path.Combine(RootDir, tourFileName));

            Assert.IsNotNull(problemTspFile);
            Assert.IsNotNull(tourTspFile);

            IProblem problem = null;
            switch (problemType)
            {
                case FileType.TSP:
                case FileType.ATSP:
                    problem = TravelingSalesmanProblem.FromFile(problemTspFile);
                    break;

                case FileType.CVRP:
                    problem = CapacitatedVehicleRoutingProblem.FromFile(problemTspFile);
                    break;

                case FileType.SOP:
                    problem = SequentialOrderingProblem.FromFile(problemTspFile);
                    break;
            }

            Assert.IsNotNull(problem);

            ITour tour = Tour.FromTspFile(tourTspFile);

            Assert.IsNotNull(tour);
            Assert.AreEqual(expectedDistance, problem.TourDistance(tour));
        }

        private static void AssertHCPTourDistance(string problemFileName, string tourFileName)
        {
            var problemTspFile = Path.Combine(RootDir, problemFileName);
            var tourTspFile = TspFile.Load(Path.Combine(RootDir, tourFileName));

            Assert.IsNotNull(problemTspFile);
            Assert.IsNotNull(tourTspFile);

            var problem = HamiltonianCycleProblem.FromFile(problemTspFile);

            Assert.IsNotNull(problem);

            ITour tour = Tour.FromTspFile(tourTspFile);

            Assert.IsNotNull(tour);
            Assert.AreEqual(problem.OptimalTourDistance, problem.TourDistance(tour));
        }
    }
}