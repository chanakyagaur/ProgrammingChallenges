ProgrammingChallenges
=====================

Solutions for programming questions from Stanford's Algorithms: Design and Analysis online course

- Inversion counter problem: task is to compute the number of inversions in the file given, where the i-th row of the file indicates the i-th entry of an array. Solution based on an enhanced version of the merge sort.
- Quick sort problem:  Task is to compute the total number of comparisons used to sort the given input file by QuickSort. There are 3 pivoting strategies implemented: first, last and the median-of-three
- Min cut problem: task is to code up and run the randomized contraction algorithm for the min cut problem and use it on the above graph to compute the min cut
- Compute strongly connected components problem: task is to code up the Kosaraju's algorithm for computing strongly connected components (SCCs), and to run this algorithm on the given graph
- Min path problem: task is to run Dijkstra's shortest-path algorithm on this graph, using 1 (the first vertex) as the source vertex, and to compute the shortest-path distances between 1 and every other vertex of the graph. If there is no path between a vertex v and vertex 1, we'll define the shortest-path distance between 1 and v to be 1000000
- 2 Sum algorithm: Your task is to compute the number of target values t in the interval [2500,4000] (inclusive) such that there are distinct numbers x,y in the input file that satisfy x+y=t. 
- Median Maintenance algorithm:  Letting xi denote the ith number of the file, the kth median mk is defined as the median of the numbers x1,…,xk. (So, if k is odd, then mk is ((k+1)/2)th smallest number among x1,…,xk; if k is even, then mk is the (k/2)th smallest number among x1,…,xk.) Calculate the sum of 10000 medians, modulo 10000

Optional:
- Calculate number of cycles for all numbers within interval (n,m) using rules from famous 3n+1 problem (http://en.wikipedia.org/wiki/Collatz_conjecture#Program_to_calculate_Hailstone_sequences)
