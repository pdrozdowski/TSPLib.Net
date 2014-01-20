using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TspLibNet.TSP;
using TspLibNet.TSP.Defines;
using TspLibNet.Problems;

namespace TspLibNetTests
{
    [TestClass]
    public class TspFileLoaderTests
    {
        const string rootDir = @"..\..\..\..\TSPLIB95";

        [TestMethod]
        public void LoadBerlin52Problem()
        {
            TspFile tspFile;
            TspFileLoader loader = new TspFileLoader();
            using(StreamReader reader = new StreamReader(Samples.Berlin52_Problem))
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
            TspFileLoader loader = new TspFileLoader();
            using (StreamReader reader = new StreamReader(Samples.Berlin52_Tour))
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
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir, "*.tsp", SearchOption.AllDirectories));
            foreach (string fileName in files)
            {
                TspFile tspFile;
                TspFileLoader loader = new TspFileLoader();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    tspFile = loader.Load(reader);
                    reader.Close();
                }

                Assert.IsNotNull(tspFile);
                TravelingSalesmanProblem problem = TravelingSalesmanProblem.FromTspFile(tspFile);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructAsynchronousTravelingSalesmanProblems()
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir, "*.atsp", SearchOption.AllDirectories));
            foreach (string fileName in files)
            {
                TspFile tspFile;
                TspFileLoader loader = new TspFileLoader();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    tspFile = loader.Load(reader);
                    reader.Close();
                }

                Assert.IsNotNull(tspFile);
                TravelingSalesmanProblem problem = TravelingSalesmanProblem.FromTspFile(tspFile);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructHamiltonianCycleProblems()
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir, "*.hcp", SearchOption.AllDirectories));
            foreach (string fileName in files)
            {
                TspFile tspFile;
                TspFileLoader loader = new TspFileLoader();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    tspFile = loader.Load(reader);
                    reader.Close();
                }

                Assert.IsNotNull(tspFile);
                HamiltonianCycleProblem problem = HamiltonianCycleProblem.FromTspFile(tspFile);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructSequentialOrderingProblems()
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir, "*.sop", SearchOption.AllDirectories));
            foreach (string fileName in files)
            {
                TspFile tspFile;
                TspFileLoader loader = new TspFileLoader();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    tspFile = loader.Load(reader);
                    reader.Close();
                }

                Assert.IsNotNull(tspFile);
                SequentialOrderingProblem problem = SequentialOrderingProblem.FromTspFile(tspFile);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructCapacitatedVehicleRoutingProblems()
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir, "*.vrp", SearchOption.AllDirectories));
            foreach (string fileName in files)
            {
                TspFile tspFile;
                TspFileLoader loader = new TspFileLoader();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    tspFile = loader.Load(reader);
                    reader.Close();
                }

                Assert.IsNotNull(tspFile);
                CapacitatedVehicleRoutingProblem problem = CapacitatedVehicleRoutingProblem.FromTspFile(tspFile);
                Assert.IsNotNull(problem);
            }
        }

        [TestMethod]
        public void ConstructTours()
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir, "*.tour", SearchOption.AllDirectories));
            foreach (string fileName in files)
            {
                TspFile tspFile;
                TspFileLoader loader = new TspFileLoader();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    tspFile = loader.Load(reader);
                    reader.Close();
                }

                Assert.IsNotNull(tspFile);
                // load tour
                // assert tour
            }
        }
    }
}
