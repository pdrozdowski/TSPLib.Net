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
    using System.IO;
    using TspLibNet.Tours;

    /// <summary>
    /// Main class providing access to all TSP library resources.
    /// </summary>
    public class TspLib95
    {
        /// <summary>
        /// Creates new instance of TspLib95 class.
        /// </summary>
        /// <param name="rootPath">library root path</param>
        public TspLib95(string rootPath)
        {
            if (string.IsNullOrEmpty(rootPath))
            {
                throw new ArgumentNullException("rootPath");
            }

            this.RootPath = rootPath;
            this.Items = new List<TspLib95Item>();
        }

        /// <summary>
        /// Gets or sets library root path
        /// </summary>
        public string RootPath { get; protected set; }

        /// <summary>
        /// Clear loaded library items
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
        }

        /// <summary>
        /// Load all TSP LIB problem instances
        /// </summary>
        /// <returns></returns>
        public int LoadAll()
        {
            int counter = 0;
            counter += this.LoadTSP();
            counter += this.LoadATSP();
            counter += this.LoadHCP();
            counter += this.LoadSOP();
            counter += this.LoadVRP();
            return counter;
        }

        /// <summary>
        /// Load only TSP problems
        /// </summary>
        /// <returns>Number of problems loaded</returns>
        public int LoadTSP()
        {
            return this.LoadTSP("*");
        }

        /// <summary>
        /// Load only ATSP problems
        /// </summary>
        /// <returns>Number of problems loaded</returns>
        public int LoadATSP()
        {
            return this.LoadATSP("*");
        }

        /// <summary>
        /// Load only HCP problems
        /// </summary>
        /// <returns>Number of problems loaded</returns>
        public int LoadHCP()
        {
            return this.LoadHCP("*");
        }

        /// <summary>
        /// Load only SOP problems
        /// </summary>
        /// <returns>Number of problems loaded</returns>
        public int LoadSOP()
        {            
            return this.LoadSOP("*");
        }

        /// <summary>
        /// Load only VRP problems
        /// </summary>
        /// <returns>Number of problems loaded</returns>
        public int LoadVRP()
        {
            return this.LoadVRP("*");
        }

        /// <summary>
        /// Load TSP problem with a given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <returns>Number of problems loaded</returns>
        public int LoadTSP(string name)
        {
            return this.ProblemLoader(name, "TravelingSalesmanProblem", ".tsp", "TSP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Load ATSP problem with a given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <returns>Number of problems loaded</returns>
        public int LoadATSP(string name)
        {
            return this.ProblemLoader(name, "TravelingSalesmanProblem",  ".atsp", "ATSP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Load HCP problem with a given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <returns>Number of problems loaded</returns>
        public int LoadHCP(string name)
        {
            return this.ProblemLoader(name, "HamiltonianCycleProblem", ".hcp", "HCP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Load SOP problem with a given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <returns>Number of problems loaded</returns>
        public int LoadSOP(string name)
        {
            // do not load best solution, lack of support at the moment
            return this.ProblemLoader(name, "SequentialOrderingProblem", ".sop", "SOP", "????.txt", ".opt.tour");
        }

        /// <summary>
        /// Load VRP problem with a given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <returns>Number of problems loaded</returns>
        public int LoadVRP(string name)
        {
            return this.ProblemLoader(name, "CapacitatedVehicleRoutingProblem", ".vrp", "VRP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Generic problem loading routine
        /// </summary>
        /// <param name="name">problem name</param>
        /// <param name="type">problem class type</param>
        /// <param name="extension">problem file extension</param>
        /// <param name="dir">directory with problems of such type</param>
        /// <param name="solutionsFile">name of file with opt distances</param>
        /// <param name="optTourExtension">extension for files with opt tours</param>
        /// <returns>Number of problems loaded</returns>
        protected int ProblemLoader(string name, string type, string extension, string dir, string solutionsFile, string optTourExtension)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            int counter = 0;
            name = name.Replace(extension, "");
            string instancesDir = Path.Combine(this.RootPath, dir);
            string instancePattern = name + extension;
            Dictionary<string, double> solutions = this.LoadBestSolutionsFile(Path.Combine(instancesDir, solutionsFile));
            foreach (string file in Directory.GetFiles(instancesDir, instancePattern))
            {
                IProblem problem = this.FactorizeProblem(file, type);
                ITour tour = null;
                string tourName = file.Replace(extension, optTourExtension);
                if (File.Exists(tourName))
                {
                    tour = Tour.FromFile(tourName);
                }

                double distance = double.MaxValue;
                if (solutions.ContainsKey(problem.Name))
                    distance = solutions[problem.Name];
                this.Items.Add(new TspLib95Item(problem, tour, distance));
                counter++;
            }

            return counter;
        }

        /// <summary>
        /// Creates instance of a specific TSP problem
        /// </summary>
        /// <param name="filename">name of file with problem</param>
        /// <param name="type">type of problem class</param>
        /// <returns>Problem loaded from the file</returns>
        protected IProblem FactorizeProblem(string filename, string type)
        {
            switch (type)
            {
                case "TravelingSalesmanProblem" :
                    return TravelingSalesmanProblem.FromFile(filename);
                case "SequentialOrderingProblem":
                    return SequentialOrderingProblem.FromFile(filename);
                case "CapacitatedVehicleRoutingProblem":
                    return CapacitatedVehicleRoutingProblem.FromFile(filename);
                case "HamiltonianCycleProblem":
                    return HamiltonianCycleProblem.FromFile(filename);
            }

            throw new ArgumentOutOfRangeException("type");
        }

        /// <summary>
        /// Loads optimal tour file
        /// </summary>
        /// <param name="filename">Name of file with optimal tour</param>
        /// <returns>Loaded optimal tour</returns>
        protected Dictionary<string, double> LoadBestSolutionsFile(string filename)
        {
            Dictionary<string, double> results = new Dictionary<string,double>();
            if (File.Exists(filename))
            {
                foreach (string line in File.ReadAllLines(filename))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] parts = line.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        results.Add(parts[0], double.Parse(parts[1]));
                    }
                }
            }

            return results;
        }

        public List<TspLib95Item> Items { get; protected set; }
    }
}
