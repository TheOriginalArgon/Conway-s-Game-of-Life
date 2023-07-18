public static class Engine
{
    private static int[,] world;
    private static int[] visibleWorldSize = { 30, 100 };
    private static int[] worldCameraLocation = { 115, 115 };
    private static List<int[]> cellsToEnable = new List<int[]>(); // List of cells to enable (Like a buffer).
    private static List<int[]> cellsToDisable = new List<int[]>(); // List of cells to disable (Like a buffer).
    public static void Initialize(List<int[]>? activeCells = null)
    {
        world = new int[500, 500];
        if (activeCells != null && activeCells.Any())
        {
            foreach (int[] pair in activeCells)
            {
                world[pair[0], pair[1]] = 1;
            }
        }
        DrawWorld();
        UpdateWorld();
    }
    public static void DrawWorld()
    {
        for (int i = 0; i < visibleWorldSize[0]; i++)
        {
            for (int j = 0; j < visibleWorldSize[1]; j++)
            {
                if (world[worldCameraLocation[0] + i, worldCameraLocation[1] + j] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("_");
                }
            }
            Console.WriteLine("|");
        }
    }

    public static void UpdateWorld()
    {
        Console.Clear();
        cellsToEnable.Clear();
        cellsToDisable.Clear();

        // Iterate to the whole world. Save the cells we need to modify.
        for (int i = 0; i < world.GetLength(0); i++)
        {
            for (int j = 0; j < world.GetLength(1); j++)
            {
                int cellSum = AdjacentCellsSum(i, j);
                if (world[i, j] == 1)
                {
                    if (cellSum < 2 || cellSum > 3)
                    {
                        cellsToDisable.Add(new int[] { i, j });
                    }
                }
                else if (world[i, j] == 0)
                {
                    if (cellSum == 3)
                    {
                        cellsToEnable.Add(new int[] { i, j });
                    }
                }
            }
        }

        UpdateCells();
        DrawWorld();
        Thread.Sleep(420);
        UpdateWorld();
    }

    private static void UpdateCells()
    {
        foreach (int[] cell in cellsToDisable)
        {
            if (world != null)
            {
                world[cell[0], cell[1]] = 0;
            }
        }
        foreach (int[] cell in cellsToEnable)
        {
            if (world != null)
            {
                world[cell[0], cell[1]] = 1;
            }
        }
    }

    // Get the eight adjacent cells.
    public static int AdjacentCellsSum(int x, int y)
    {
        int totalSum = 0;
        int? worldWidth = world.GetLength(0) - 1;
        int? worldHeight = world.GetLength(1) - 1;

        List<int[]> possibleCells = new List<int[]>
        {
            new int[] { x - 1, y },
            new int[] { x + 1, y },
            new int[] { x, y - 1 },
            new int[] { x, y + 1 },
            new int[] { x + 1, y + 1 },
            new int[] { x - 1, y + 1 },
            new int[] { x + 1, y - 1 },
            new int[] { x - 1, y - 1 },
        };

        foreach (int[] pair in possibleCells)
        {
            if ((pair[0] < 0 || pair[0] > worldWidth) || (pair[1] < 0 || pair[1] > worldHeight))
            {
                continue;
            }
            else
            {
                if (world != null)
                {
                    totalSum += world[pair[0], pair[1]];
                }
            }
        }

        return totalSum;
    }
}