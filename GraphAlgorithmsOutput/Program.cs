using GraphAlgorithms;

UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
UndirectedGraph<int> graph2 = new UndirectedGraph<int>();

graph2.AddEdges(new int[,] { { 1, 2 }, { 4, 5 }, { 6, 7 }, { 7, 8} });
graph1.AddEdges(new char[,] { { 'a', 'b' }, { 'a', 'c'}, { 'a', 'd' } , { 'd', 'c' } , { 'f', 'c' } });


Console.WriteLine(DFS.ConnectedComponentsCount<UndirectedGraph<int>, int>(graph2));
Console.WriteLine(DFS.ConnectedComponentsCount<DirectedGraph<char>, char>(graph1));
