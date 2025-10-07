namespace PathfindingVisualizer.Grid;

public struct Node
{
    public int PositionX;
    public int PositionY;
    public NodeType NodeType;
    public bool IsVisited;
    public float Cost;
    public float Heuristic;

    public Node(int x, int y, NodeType nodeType = 0)
    {
        PositionX = x;
        PositionY = y;
    }
}

public enum NodeType
{
    Walkable,
    Obstacle,
    Goal,
    Start,
}