using System;

namespace ConsoleApp1
{
    public class Answer
    {
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int Z1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }
        public int Z2 { get; private set; }

        public Answer(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            X1 = x1;
            Y1 = y1;
            Z1 = z1;
            X2 = x2;
            Y2 = y2;
            Z2 = z2;
        }

        public bool IsWithinBounds(int maxX, int maxY, int maxZ)
        {
            return X1 >= 0 && X1 < maxX && Y1 >= 0 && Y1 < maxY && Z1 >= 0 && Z1 < maxZ &&
                   X2 >= 0 && X2 < maxX && Y2 >= 0 && Y2 < maxY && Z2 >= 0 && Z2 < maxZ;
        }


        public bool IsDifferentTiles()
        {
            return !(X1 == X2 && Y1 == Y2 && Z1 == Z2);
        }

        public void DisplaySelectedTiles()
        {
            Console.WriteLine($"Selected tiles at ({X1}, {Y1}, {Z1}) and ({X2}, {Y2}, {Z2})");
        }
    }
}