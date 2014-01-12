All data and descriptions come from Heidelberg University site: http://comopt.ifi.uni-heidelberg.de/software/TSPLIB95/
Each folder has sample instances for various type of problems.

Symmetric traveling salesman problem (TSP)
==========================================
Given a set of n nodes and distances for each pair of nodes, find a roundtrip of minimal total length visiting each node exactly once. The distance from node i to node j is the same as from node j to node i.

Asymmetric traveling salesman problem (ATSP)
============================================
Given a set of n nodes and distances for each pair of nodes, find a roundtrip of minimal total length visiting each node exactly once. In this case, the distance from node i to node j and the distance from node j to node i may be different.

Hamiltonian cycle problem (HCP)
===============================
Given a graph, test if the graph contains a Hamiltonian cycle or not.

Sequential ordering problem (SOP)
=================================
This problem is an asymmetric traveling salesman problem with additional constraints. Given a set of n nodes and distances for each pair of nodes, find a Hamiltonian path from node 1 to node n of minimal length which takes given precedence constraints into account. Each precedence constraint requires that some node i has to be visited before some other node j.

Capacitated vehicle routing problem (CVRP)
==========================================
We are given n-1 nodes, one depot and distances from the nodes to the depot, as well as between nodes. All nodes have demands which can be satisfied by the depot. For delivery to the nodes, trucks with identical capacities are available. The problem is to find tours for the trucks of minimal total length that satisfy the node demands without violating truck capacity constraint. The number of trucks is not specified. Each tour visits a subset of the nodes and starts and terminates at the depot. (Remark: In some data files a collection of alternate depots is given. A CVRP is then given by selecting one of these depots.)

All files version from 12th Jan 2014
Check DOC.PS or DOC.PDF for original description of problems, used functions and file formats.

