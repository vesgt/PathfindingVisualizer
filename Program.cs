using PathfindingVisualizer.Grid;
using Raylib_cs;

const int screenSize = 800;
const int gridSize = 20;
const int cellSize = screenSize / gridSize;

var grid = new Grid(gridSize, cellSize);

Raylib.InitWindow(screenSize, screenSize, "Pathfinding Visualizer");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    grid.Draw();

    Raylib.EndDrawing();
}

Raylib.CloseWindow();