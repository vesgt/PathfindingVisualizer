namespace PathfindingVisualizer.Grid;

public class Node
{
    public int PositionX;
    public int PositionY;
    public NodeType NodeType;
    public bool IsVisited;

    public Node(int x, int y, NodeType nodeType = 0)
    {
        PositionX = x;
        PositionY = y;
        NodeType = nodeType;
    }
}

public enum NodeType
{
    Walkable,
    Obstacle,
    Goal,
    Start,
}