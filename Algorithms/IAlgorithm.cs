namespace PathfindingVisualizer.Algorithms;

using Grid;

public interface IAlgorithm
{
    public Grid Grid { get; set; }
    public Path CalculatePath();
}

public class Path
{
    public Node[] NodePath;

    public Path(Node[] path)
    {
        NodePath = path;
    }
}