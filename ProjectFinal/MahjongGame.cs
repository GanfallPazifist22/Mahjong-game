using System;
using System.Collections;

public class MahjongGame
{
    private Tile[,,] board;
    private ArrayList tiles;

    public MahjongGame()
    {
        board = new Tile[5, 4, 5];  // Keep the board size 5x4x5
        tiles = new ArrayList(100);  // 50 pairs of tiles, 100 total
        InitializeTiles();
        ShuffleTiles();
        InitializeBoard();
    }

    private void InitializeTiles()
    {
        // Create 50 pairs of tiles (100 tiles total)
        for (int i = 0; i < 50; i++)
        {
            tiles.Add(new Tile(i));
            tiles.Add(new Tile(i)); // Create a pair of each type
        }
    }

    private void ShuffleTiles()
    {
        Random random = new Random();
        int size = tiles.Size();

        for (int i = size - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            // Swap elements at indices i and j
            Tile temp = tiles.GetTile(i);
            tiles.Set(i, tiles.GetTile(j));
            tiles.Set(j, temp);
        }
    }

    private void InitializeBoard()
    {
        if (tiles.Size() != 100)
            throw new InvalidOperationException("Tile list must contain exactly 100 tiles.");

        int index = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (index < tiles.Size())
                        board[x, y, z] = tiles.GetTile(index++);
                }
            }
        }
    }

    public bool MatchTiles(int x1, int y1, int z1, int x2, int y2, int z2)
    {
        Tile tile1 = board[x1, y1, z1];
        Tile tile2 = board[x2, y2, z2];

        if (tile1 == null || tile2 == null || tile1.IsMatched || tile2.IsMatched)
            return false;

        // Ensure they are not the same tile in memory (not the same object reference)
        if (tile1 != tile2 && tile1.IsSame(tile2))
        {
            tile1.IsMatched = true;
            tile2.IsMatched = true;
            board[x1, y1, z1] = null;
            board[x2, y2, z2] = null;
            return true;
        }
        return false;
    }

    public void PrintBoard()
    {
        for (int x = 0; x < 5; x++)
        {
            Console.WriteLine($"Layer {x + 1}:");
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    Tile tile = board[x, y, z];
                    if (tile != null && !tile.IsMatched)
                        Console.Write($"[{tile}] "); // Show the tile symbol
                    else
                        Console.Write("[   ] "); // Empty space for unmatched or null tiles
                }
                Console.WriteLine();
            }
            Console.WriteLine(); // Separate each layer visually
        }
    }

    public bool AllTilesMatched()
    {
        foreach (var tile in board)
        {
            if (tile is Tile t && !t.IsMatched)
                return false;
        }
        return true;
    }

    public void AutoPlay()
    {
        Random random = new Random();

        while (!AllTilesMatched())
        {
            // Randomly pick two tiles
            int x1 = random.Next(5), y1 = random.Next(4), z1 = random.Next(5);
            int x2 = random.Next(5), y2 = random.Next(4), z2 = random.Next(5);

            Tile tile1 = board[x1, y1, z1];
            Tile tile2 = board[x2, y2, z2];

            if (tile1 != null && tile2 != null && !tile1.IsMatched && !tile2.IsMatched && tile1.IsSame(tile2))
            {
                Console.WriteLine($"Matched tiles: {tile1} at ({x1},{y1},{z1}) and {tile2} at ({x2},{y2},{z2})");
                MatchTiles(x1, y1, z1, x2, y2, z2);
                PrintBoard(); // Update the board after each match
            }
        }
        Console.WriteLine("Auto play finished!");
    }
}
