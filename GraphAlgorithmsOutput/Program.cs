using GraphAlgorithms;

DirectedGraph<char> graph1 = new DirectedGraph<char>();

//graph1.AddEdge('a', 'c');
//graph1.AddEdge('a', 'b');
//graph1.AddEdge('b', 'd');
//graph1.AddEdge('c', 'e');
//graph1.AddEdge('d', 'f');

graph1.AddEdge('a', 'c');
graph1.AddEdge('a', 'b');
graph1.AddEdge('b', 'c');
graph1.AddEdge('c', 'a');
graph1.AddEdge('d', 'f');

Console.WriteLine("*****DFS Iterative*****");
graph1.DFSTraverseIterative('a');
Console.WriteLine("*****DFS Iterative*****");
Console.WriteLine("*****DFS Recursive*****");
graph1.DFSTraverseRecursive('a');
Console.WriteLine("*****DFS Recursive*****");
Console.WriteLine("*****BFS Iterative*****");
graph1.BFSTraverseIterative('a');
Console.WriteLine("*****BFS Iterative*****");

DirectedGraph<char> graph2 = new DirectedGraph<char>();

graph2.AddEdge('f', 'g');
graph2.AddEdge('f', 'i');
graph2.AddEdge('g', 'h');
graph2.AddEdge('i', 'g');
graph2.AddEdge('i', 'k');
graph2.AddEdge('j', 'i');

graph2.Print();

Console.WriteLine("\n*****Has Path DFS*****");
Console.WriteLine(DFS.HasPathDFS(graph2, 'f', 'k'));
Console.WriteLine("*****Has Path DFS*****");
Console.WriteLine("*****Has Path DFS*****");
Console.WriteLine(DFS.HasPathDFS(graph2, 'f', 'j'));
Console.WriteLine("*****Has Path DFS*****");
Console.WriteLine("*****Has Path BFS*****");
Console.WriteLine(BFS.HasPathBFS(graph2, 'f', 'k'));
Console.WriteLine("*****Has Path BFS*****");
Console.WriteLine("*****Has Path BFS*****");
Console.WriteLine(BFS.HasPathBFS(graph2, 'f', 'j'));
Console.WriteLine("*****Has Path BFS*****");

char[,] edges = new char[6, 2] { 
    { 'i', 'j' },
    { 'k', 'i' },
    { 'm', 'k' },
    { 'k', 'l' }, 
    { 'k', 'j' },
    { 'o', 'n' } 
};

UndirectedGraph<char> graph3 = new UndirectedGraph<char>();
graph3.AddEdges(edges);
graph3.Print();

Console.WriteLine("\n*****Has Path DFS*****");
Console.WriteLine(DFS.HasPathDFS(graph3, 'k', 'i'));
Console.WriteLine("*****Has Path DFS*****");
Console.WriteLine("*****Has Path BFS*****");
Console.WriteLine(BFS.HasPathBFS(graph3, 'k', 'i'));
Console.WriteLine("*****Has Path BFS*****");
Console.WriteLine("*****DFS Iterative*****");
graph3.DFSTraverseIterative('i');
Console.WriteLine("*****DFS Iterative*****");
Console.WriteLine("*****DFS Recursive*****");
graph3.DFSTraverseRecursive('i');
Console.WriteLine("*****DFS Recursive*****");
