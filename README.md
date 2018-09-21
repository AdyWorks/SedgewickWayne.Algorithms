# SedgewickWayne.Algorithms

Porting algorithms by _Robert Sedgewick_ and _Kevin Wayne_ in .NET.

Initial approach was to **convert java archives with IKVM**, then **use ILSpy on the generated bytecode** to produce cs files.
Those files would then have to be stripped off the unnecessary metadata. 
Source: [`algs4.jar`](https://algs4.cs.princeton.edu/code/algs4.jar).

They reside in the `./SedgewickWayne.Algorithms/AnteRoom` folder and are not included in the project.
This approach was dropped because most of the code looked bad, especially inner classes for linked lists, list nodes and enumerators, and even after trimming metadata, severe refactoring was needed.

Replaced tokens: `using IKVM.Attributes;`, `using java.lang;`, `In.__<clinit>();`, `[HideFromJava]`, `using java.util;`, `using ikvm.lang;`, ` Throwable.__<suppressFillInStackTrace>();`, `using java.io;`, ` using ikvm.@internal;`, `: java.lang.Object`, `using IKVM.Runtime;`, `using System.Runtime.CompilerServices;`, `using System;`, `[MethodImpl(MethodImplOptions.NoInlining)]`

Replaced regex: `\[LineNumberTable\([^\)]+\)\]`, `^.*(\[[^\]\(\)]+\([^\]\(\)]+\)[^\]\(\)]*\])$` with ` \/\/\1`, `(\[Implements\(new string\[\]\r\n[^{]+{[^\]]+\])`, `\[LineNumberTable\(new byte\[\]\r\n[^{]+{[^}]+\}\)`, `[LineNumberTable(\d\d), Modifiers(Modifiers.Static | Modifiers.Synthetic)]`

**Instead, it seems easier to port java files from the [Princeton repo](http://algs4.cs.princeton.edu) or the [duplicated Brazilian one](https://www.ime.usp.br/~pf/sedgewick-wayne/algs4/)**.

## Pages

Below is the work for which porting was _finished_ and _unit tests passing_.

+ [Fundamentals](./doc/fndmntl.md)
+ [Collections](./doc/col.md)
+ [Dynamic Connectivity](./doc/uf.md)
+ [Sorting](./doc/sort.md)
+ [Priority Queues](./doc/pq.md)
+ [Symbol tables](./doc/st.md)

## Algorithms to do list

Files which have been generated by means of IKVM and ILSpy but not yet included in the project, or haven't been ported yet.

- AcyclicLP                     
- AcyclicSP                     
- AdjMatrixEdgeWeightedDigraph  
- Alphabet                      
- Arbitrage                     
- AssignmentProblem             
- Average                       
- Bipartite                     
- BipartiteMatching             
- BellmanFordSP                 
- BinaryDump                    
- BoruvkaMST                    
- BoyerMoore                    
- BreadthFirstDirectedPaths     
- BreadthFirstPaths             
- BTree                         
- Cat                           
- CC                            
- ClosestPair                   
- CollisionSystem               
- Complex                       
- Copy                          
- Count                         
- Counter                       
- CPM                           
- Cycle                         
- Date                          
- DepthFirstDirectedPaths       
- DepthFirstOrder               
- DepthFirstPaths               
- DepthFirstSearch              
- Digraph                       
- DigraphGenerator              
- DijkstraAllPairsSP            
- DijkstraSP                    
- DirectedCycle                 
- DirectedDFS                   
- DirectedEdge                  
- DoublingRatio                 
- DoublingTest                  
- Edge                          
- EdgeWeightedDigraph           
- EdgeWeightedDirectedCycle     
- EdgeWeightedGraph             
- FarthestPair                  
- FFT                           
- FlowEdge                      
- FlowNetwork                   
- FloydWarshall                 
- GabowSCC                      
- GaussianElimination           
- Genome                        
- GrahamScan                    
- Graph                         
- GraphGenerator                
- GREP                          
- Huffman                       
- Interval1D                    
- Interval2D                    
- KMP                           
- Knuth                         
- KosarajuSharirSCC             
- KruskalMST                    
- KWIK                          
- LazyPrimMST                   
- LinearRegression              
- LongestCommonSubstring        
- LRS                           
- LSD                           
- LZW                           
- MSD                           
- NFA                           
- PolynomialRegression          
- PrimMST                       
- Quick3String                  
- RabinKarp                     
- RandomSeq                     
- RunLength                     
- Simplex
- SuffixArray                   
- SuffixArrayX                  
- SymbolDigraph                 
- SymbolGraph                   
- TarjanSCC                     
- Topological                   
- Transaction                   
- TransitiveClosure             
- TrieSET                       
- TrieST                        
- TST                           
- Vector                        
- WhiteList                     