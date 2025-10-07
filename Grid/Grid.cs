using Raylib_cs;

namespace PathfindingVisualizer.Grid;

public class Grid
{
    public Node[,] Nodes { get; set; }
    public int GridSize { get; }     // number of nodes per axis
    public int CellSize { get; }     // pixel width/height of each node

    public Grid(int gridSize, int cellSize)
    {
        GridSize = gridSize;
        CellSize = cellSize;

        Nodes = new Node[GridSize, GridSize];
        for (var x = 0; x < GridSize; x++)
        for (var y = 0; y < GridSize; y++)
            Nodes[x, y] = new Node(x, y);
    }
    
    public Node? GetNode(int x, int y)
    {
        if (x < 0 || y < 0 || x >= GridSize || y >= GridSize)
            return null;
        return Nodes[x, y];
    }
    
    public List<Node> GetNeighbors(Node node)
    {
        var neighbors = new List<Node>();

        var x = node.PositionX;
        var y = node.PositionY;

        // 4-directional
        int[,] directions = {
            { 1, 0 }, { -1, 0 },
            { 0, 1 }, { 0, -1 }
        };

        for (var i = 0; i < directions.GetLength(0); i++)
        {
            var nx = x + directions[i, 0];
            var ny = y + directions[i, 1];
            var neighbor = GetNode(nx, ny);
            
            if (neighbor != null && neighbor.Value.NodeType != NodeType.Obstacle)
                neighbors.Add(neighbor.Value);
        }

        return neighbors;
    }
    
    public void Draw()
    {
        for (var x = 0; x < GridSize; x++)
        {
            for (var y = 0; y < GridSize; y++)
            {
                var node = Nodes[x, y];
                var color = node.NodeType switch
                {
                    NodeType.Goal => Color.Gold,
                    NodeType.Obstacle => Color.Black,
                    NodeType.Walkable => Color.White,
                    NodeType.Start => Color.Green,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Raylib.DrawRectangle(
                    x * CellSize,
                    y * CellSize,
                    CellSize - 1,
                    CellSize - 1,
                    color
                );
            }
        }
    }

    public Node GetRandomNode()
    {
        var random = new Random();
        var x = random.Next(0, GridSize);
        var y = random.Next(0, GridSize);
        
        return Nodes[x, y];
    }
}