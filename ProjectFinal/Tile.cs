using System;

public class Tile
{
    public int Type { get; set; }
    public bool IsMatched { get; set; }

    private static readonly string[] Symbols = {
        "Dragon 1", "Dragon 2", "Dragon 3", "Dragon 4", "Dragon 5", "Dragon 6", "Dragon 7", "Dragon 8", "Dragon 9", "Dragon 10",
        "God 1", "God 2", "God 3", "God 4", "God 5", "God 6", "God 7", "God 8", "God 9", "God 10",
        "Human 1", "Human 2", "Human 3", "Human 4", "Human 5", "Human 6", "Human 7", "Human 8", "Human 9", "Human 10",
        "Demon 1", "Demon 2", "Demon 3", "Demon 4", "Demon 5", "Demon 6", "Demon 7", "Demon 8", "Demon 9", "Demon 10",
        "Lizard 1", "Lizard 2", "Lizard 3", "Lizard 4", "Lizard 5", "Lizard 6", "Lizard 7", "Lizard 8", "Lizard 9", "Lizard 10"
    };

    public Tile(int type)
    {
        Type = type;
        IsMatched = false;
    }

    public bool IsSame(Tile other)
    {
        return other != null && Type == other.Type;
    }

    public override string ToString()
    {
        return Symbols[Type];
    }
}
