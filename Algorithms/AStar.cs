namespace PathfindingVisualizer.Algorithms;

using Grid;

public class AStar : IAlgorithm
{
    public Grid Grid { get; set;  }
    private Node _currentNode;
    private Dictionary<Node, int> _nodeCost = new ();
    private Dictionary<Node, Node> _parents = new();
    
    public Path CalculatePath()
    {
        _currentNode = Grid.StartNode;
        var openList = new List<Node>();
        var closedList = new List<Node>();
        
        _nodeCost[_currentNode] = 0;
        openList.Add(_currentNode);
        
        Console.WriteLine("Entering while loop till hitting goal");
        while (_currentNode != Grid.GoalNode)
        {
            Console.WriteLine("Searching...");
            closedList.Add(_currentNode);
            openList.Remove(_currentNode);
            
            var neighbors = Grid.GetNeighbors(_currentNode)
                .Where(n => !closedList.Contains(n))
                .ToList();
            
            neighbors.ForEach(n => { 
                _nodeCost[n] = _nodeCost[_currentNode] + 1;
                _parents[n] = _currentNode;
            });
            openList.AddRange(neighbors.OrderBy(n => _nodeCost[n] + CalculateHeuristic(n)));

            var min = openList.Select(n => _nodeCost[n] + CalculateHeuristic(n)).Min();
            _currentNode = openList.Where(n => _nodeCost[n] + CalculateHeuristic(n) == min).FirstOrDefault();

            if (_currentNode == Grid.GoalNode)
                break;
        }
        Console.WriteLine("Finished");

        return ReconstructPath();
    }

    private Path ReconstructPath()
    {
        Console.WriteLine("Attempting to reconstruct path...");
        var path = new List<Node>();
        var current = Grid.GoalNode;

        while (current != Grid.StartNode)
        {
            path.Add(current);
            current = _parents[current];
        }
        
        path.Add(Grid.StartNode);
        path.Reverse();
        
        Console.WriteLine("Path reconstructed");
        return new Path(path.ToArray());
    }

    private int CalculateHeuristic(Node node)
    {
        return Math.Abs(Grid.GoalNode.PositionX - node.PositionX) + Math.Abs(Grid.GoalNode.PositionY - node.PositionY);
    }
}