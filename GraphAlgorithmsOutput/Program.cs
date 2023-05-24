using GraphAlgorithms;

UndirectedGraph<char> graph1 = new UndirectedGraph<char>();
UndirectedGraph<int> graph2 = new UndirectedGraph<int>();

graph2.AddEdges(new int[,] {
    { 0, 8 },
    { 0, 1 },
    { 0, 5 },
    { 5, 8},
    { 2, 3},
    { 2, 4},
    { 3, 4},
    { 3, 5},
});
graph1.AddEdges(new char[,] { { 'w', 'x' }, { 'x', 'y' }, { 'z', 'y' }, { 'z', 'v' }, { 'a', 'b' } });


Console.WriteLine(DFS.ConnectedComponentsCount<UndirectedGraph<int>, int>(graph2));
Console.WriteLine(DFS.ConnectedComponentsCount<DirectedGraph<char>, char>(graph1));
Console.WriteLine("Largest Component Count");
Console.WriteLine(DFS.LargestComponentCount<UndirectedGraph<int>, int>(graph2));
Console.WriteLine("Largest Component Count");
Console.WriteLine(BFS.ShortestPathBFS(graph2, 0, 8));
Console.WriteLine("HERE!!!!");
Console.WriteLine(BFS.ShortestPathBFS(graph1, 'w', 'y'));

Node<char>[,] grid = new Node<char>[,]
{
    {
        new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
    },
    {
        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
    },
    {
        new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'),
    },
    {
        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('L'), new Node<char>('L'), new Node<char>('L'),
    },
    {
        new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
    },
    {
        new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
    },
    {
        new Node<char>('L'), new Node<char>('L'), new Node<char>('L'), new Node<char>('W'), new Node<char>('W'), new Node<char>('W'),
    }
};


GridGraph<char> graph3 = new GridGraph<char>();

graph3.AddGrid(grid);
graph3.Print();
Console.WriteLine("Island Count Grid Graph");
Console.WriteLine(Grid.IslandCountGridGraph(graph3));
Console.WriteLine("Min Island Size Grid Graph");
Console.WriteLine(Grid.MinIslandSizeGridGraph(graph3));

char[,] gridChar = new char[,]
{
    {
        'W', 'W', 'W', 'W', 'W', 'W'
    },
    {
        'W', 'W', 'W', 'W', 'W', 'W'
    },
    {
        'W', 'L', 'L', 'L', 'L', 'W'
    },
    {
        'W', 'L', 'W', 'W', 'L', 'W'
    },
    {
        'W', 'L', 'W', 'W', 'L', 'W'
    },
    {
        'W', 'L', 'W', 'W', 'L', 'W'
    },
};

Console.WriteLine("Island Count Grid");
Console.WriteLine(Grid.IslandCountGrid(gridChar));
Console.WriteLine("Island Count Grid");
Console.WriteLine(Grid.MinIslandSizeGrid(gridChar));

GridGraph<char> gridGraph = new GridGraph<char>();
char[,] grid77 = new char[,]
{
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
                {'W', 'W', 'W', 'W', 'W' },
};
gridGraph.AddGrid(Node<char>.MakeNodeGrid(grid77));
int result = Grid.IslandCountGridGraph(gridGraph);
Console.WriteLine(result);
