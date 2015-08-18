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

namespace TspLibNet
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Tours;

    /// <summary>
    /// Main class providing access to all TSP library resources.
    ///
    /// TspLib95 provides the entry point to TSPLIB95 instances and should be considered
    /// the default starting point for any application making use of TSPLib.Net.
    ///
    /// This class allows you to load instances by type, in total (entire library) or individually
    /// by name.  It furthermore provides access to lists of instances by type, all instances
    /// in total, or individual instances by name (where name is the name of the file containing
    /// the specific problem instance excluding the file extension).
    ///
    /// Each TSPLIB95 instance is wrapped within a <see>TspLib95Item</see> which ultimately provides
    /// all the available information for the specific TSP problem it wraps. In other words, not
    /// only is the TSP graph accessible (through <see>IProblem</see> and <see>ProblemBase</see>),
    /// but also the best known solutions (if they exist) in the form of optimal tours and optimal tour
    /// distances.
    /// </summary>
    public class TspLib95
    {
        // The path to the TSPLIB95 data library.
        private readonly string _tspLib95Path;

        /// <returns>ALL loaded TSPLIB95 items or an empty list if no items have been loaded.</returns>
        public List<TspLib95Item> Items { get; private set; }

        /// <returns>All symmetric TSP problem items or an empty list if no STSP items have been loaded.</returns>
        public IEnumerable<TspLib95Item> TSPItems()
        {
            return Items.Where(i => i.Problem.Type == ProblemType.TSP);
        }

        /// <returns>All asymmetric TSP problem items or an empty list if no ATSP items have been loaded.</returns>
        public IEnumerable<TspLib95Item> ATSPItems()
        {
            return Items.Where(i => i.Problem.Type == ProblemType.ATSP);
        }

        /// <returns>All HCP problem items or an empty list if no HCP items have been loaded.</returns>
        public IEnumerable<TspLib95Item> HCPItems()
        {
            return Items.Where(i => i.Problem.Type == ProblemType.HCP);
        }

        /// <returns>All SOP problem items or an empty list if no SOP items have been loaded.</returns>
        public IEnumerable<TspLib95Item> SOPItems()
        {
            return Items.Where(i => i.Problem.Type == ProblemType.SOP);
        }

        /// <returns>All CVRP problem items or an empty list if no CVRP items have been loaded.</returns>
        public IEnumerable<TspLib95Item> CVRPItems()
        {
            return Items.Where(i => i.Problem.Type == ProblemType.CVRP);
        }

        /// <summary>
        /// </summary>
        /// <param name="name">The name of the file containing the specific problem instance, excluding the file extension</param>
        /// <param name="type">The specific problem type (TSP, ATSP, etc)</param>
        /// <returns>The relevant TspLib95Item associated with "name" or a default item if not found</returns>
        public TspLib95Item GetItemByName(string name, ProblemType type)
        {
            return Items.Select(i => i).FirstOrDefault(i => i.Problem.Name == name && i.Problem.Type == type);
        }

        /// <summary>
        /// Creates a new instance of the TspLib95 class.
        /// </summary>
        /// <param name="tspLib95Path">TSPLIB95 data library root directory path</param>
        /// <exception cref="ArgumentNullException">Thrown if directory path name is null or empty</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if directory does not exist</exception>
        public TspLib95(string tspLib95Path)
        {
            if (string.IsNullOrWhiteSpace(tspLib95Path))
            {
                throw new ArgumentNullException("tspLib95Path");
            }

            if (!Directory.Exists(tspLib95Path))
            {
                throw new DirectoryNotFoundException();
            }

            _tspLib95Path = tspLib95Path;
            Items = new List<TspLib95Item>();
        }

        /// <summary>
        /// Clear ALL loaded library items.
        /// </summary>
        public void ClearAll()
        {
            Items.Clear();
        }

        /// <summary>
        /// Load ALL TSPLIB95 problem instances.
        /// </summary>
        /// <returns>A list of all TSPLIB95 problem items.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public IEnumerable<TspLib95Item> LoadAll()
        {
            LoadAllTSP();
            LoadAllATSP();
            LoadAllHCP();
            LoadAllSOP();
            LoadAllCVRP();
            return Items;
        }

        /// <summary>
        /// Load only TSP problems
        /// </summary>
        /// <returns>A list of all TSP lib problem items.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public IEnumerable<TspLib95Item> LoadAllTSP()
        {
            LoadTSP("*");
            return TSPItems();
        }

        /// <summary>
        /// Load only ATSP problems
        /// </summary>
        /// <returns>A list of all ATSP lib problem items.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public IEnumerable<TspLib95Item> LoadAllATSP()
        {
            LoadATSP("*");
            return ATSPItems();
        }

        /// <summary>
        /// Load only HCP problems
        /// </summary>
        /// <returns>A list of all HPC lib problem items.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public IEnumerable<TspLib95Item> LoadAllHCP()
        {
            LoadHCP("*");
            return HCPItems();
        }

        /// <summary>
        /// Load only SOP problems
        /// </summary>
        /// <returns>A list of all SOP lib problem items.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public IEnumerable<TspLib95Item> LoadAllSOP()
        {
            LoadSOP("*");
            return SOPItems();
        }

        /// <summary>
        /// Load only VRP problems
        /// </summary>
        /// <returns>A list of all CVRP lib problem items.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public IEnumerable<TspLib95Item> LoadAllCVRP()
        {
            LoadCVRP("*");
            return CVRPItems();
        }

        /// <summary>
        /// Loads the TSP problem with the given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <seealso cref="GetItemByName"/>
        /// <exception cref="ArgumentNullException">Thrown if "name" argument is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public void LoadTSP(string name)
        {
            ProblemLoader(name, "TravelingSalesmanProblem", ".tsp", "TSP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Loads the ATSP problem with the given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <seealso cref="GetItemByName"/>
        /// <exception cref="ArgumentNullException">Thrown if "name" argument is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public void LoadATSP(string name)
        {
            ProblemLoader(name, "TravelingSalesmanProblem", ".atsp", "ATSP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Loads the HCP problem with the given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <seealso cref="GetItemByName"/>
        /// <exception cref="ArgumentNullException">Thrown if "name" argument is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public void LoadHCP(string name)
        {
            ProblemLoader(name, "HamiltonianCycleProblem", ".hcp", "HCP", "bestSolutions.txt", ".opt.tour");
        }

        /// <summary>
        /// Loads the SOP problem with the given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <seealso cref="GetItemByName"/>
        /// <exception cref="ArgumentNullException">Thrown if "name" argument is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public void LoadSOP(string name)
        {
            // do not load best solution, lack of support at the moment
            ProblemLoader(name, "SequentialOrderingProblem", ".sop", "SOP", "????.txt", ".opt.tour");
        }

        /// <summary>
        /// Loads the VRP problem with the given name
        /// </summary>
        /// <param name="name">Problem name</param>
        /// <seealso cref="GetItemByName"/>
        /// <exception cref="ArgumentNullException">Thrown if "name" argument is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        public void LoadCVRP(string name)
        {
            ProblemLoader(name, "CapacitatedVehicleRoutingProblem", ".vrp", "VRP", "bestSolutions.txt", ".opt.tour");
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
        /// <returns>A list of the TspLib95Items loaded</returns>
        /// <exception cref="ArgumentNullException">Thrown if "name" argument is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if TSP lib path (<seealso cref="TspLib95"/>) does not point to TSPLIB95.</exception>
        private void ProblemLoader(string name,
                                   string type,
                                   string extension,
                                   string dir,
                                   string solutionsFile,
                                   string optTourExtension)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            name = name.Replace(extension, "");
            var instancesDir = Path.Combine(_tspLib95Path, dir);

            if (!Directory.Exists(instancesDir))
            {
                throw new DirectoryNotFoundException();
            }

            var instancePattern = name + extension;
            var solutions = LoadBestSolutionsFile(Path.Combine(instancesDir, solutionsFile));

            foreach (var file in Directory.GetFiles(instancesDir, instancePattern))
            {
                var problem = FactorizeProblem(file, type);
                ITour tour = null;
                var tourName = file.Replace(extension, optTourExtension);
                if (File.Exists(tourName))
                {
                    tour = Tour.FromFile(tourName);
                }

                var distance = double.MaxValue;
                if (solutions.ContainsKey(problem.Name))
                    distance = solutions[problem.Name];
                Items.Add(new TspLib95Item(problem, tour, distance));
            }
        }

        /// <summary>
        /// Creates instance of a specific TSP problem
        /// </summary>
        /// <param name="filename">name of file with problem</param>
        /// <param name="type">type of problem class</param>
        /// <returns>Problem loaded from the file</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when "type" is unknown.</exception>
        private static IProblem FactorizeProblem(string filename, string type)
        {
            switch (type)
            {
                case "TravelingSalesmanProblem":
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
        private static Dictionary<string, double> LoadBestSolutionsFile(string filename)
        {
            var results = new Dictionary<string, double>();
            if (File.Exists(filename))
            {
                foreach (var line in File.ReadAllLines(filename))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var parts = line.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        results.Add(parts[0], double.Parse(parts[1]));
                    }
                }
            }

            return results;
        }
    }
}