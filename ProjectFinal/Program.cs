using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Mahjong Game!");
        Console.WriteLine("Choose game mode:");
        Console.WriteLine("1. Manual Play");
        Console.WriteLine("2. Auto Play");
        string choice = Console.ReadLine();

        MahjongGame game = new MahjongGame();
        game.PrintBoard();

        if (choice == "1")
        {
            // Manual Play
            while (true)
            {
                Console.WriteLine("Enter coordinates for two tiles to match (e.g., 0 0 0 and 1 1 1):");
                Console.Write("Tile 1 (z y x): ");
                string[] input1 = Console.ReadLine().Split();
                Console.Write("Tile 2 (z y x): ");
                string[] input2 = Console.ReadLine().Split();

                int x1 = int.Parse(input1[0]);
                int y1 = int.Parse(input1[1]);
                int z1 = int.Parse(input1[2]);
                int x2 = int.Parse(input2[0]);
                int y2 = int.Parse(input2[1]);
                int z2 = int.Parse(input2[2]);

                if (game.MatchTiles(x1, y1, z1, x2, y2, z2))
                {
                    Console.WriteLine("Match successful!");
                    game.PrintBoard();  // Update the board after the match
                }
                else
                {
                    Console.WriteLine("Match failed.");
                }

                // Ask if the player wants to continue, give up or auto play
                Console.WriteLine("Do you want to continue? (y/n) or give up? (give up)");
                string decision = Console.ReadLine().ToLower();

                if (decision == "give up")
                {
                    Console.WriteLine("You gave up. Switching to Auto Play...");
                    game.AutoPlay();
                    break;
                }
                else if (game.AllTilesMatched())
                {
                    Console.WriteLine("You won the game!");
                    break;
                }
            }
        }
        else if (choice == "2")
        {
            // Auto Play
            game.AutoPlay();
        }
    }
}
