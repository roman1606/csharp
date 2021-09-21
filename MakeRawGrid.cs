using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridQuestion
{
    /// <summary>
    /// Task is to take in an X by X grid of positive integers assuming X > 2.
    /// Output a new X by X grid that points to the highest value
    ///     neighbour with the characters '>', '<', 'v', '^' or 'o' if none
    ///     are higher. In the case where the program is on an edge (X = 0, Y = 0,
    ///     X = Length - 1, Y = Length - 1) no character or any character is valid.
    ///     In case of ties, any direction between the highest values are valid.
    /// Take the following process:
    ///     1) Describe a process that solves the challenge
    ///     2) Write psuedo code for the solution
    ///     3) Write code for the solution in Visual Studio (assuming memory, CPU, etc are infinite)
    ///     4) Revise code to be better than O(n*n) (note n already is length*length)
    ///     
    /// Example:
    ///     5 4 3 2
    ///     9 2 7 1
    ///     1 8 7 1
    ///     2 7 6 3
    ///     
    ///     5 4 3 2
    ///     9 < o 1
    ///     1 o < 1
    ///     2 7 6 3
    /// </summary>

    class Program
    {
        public static void Main(String [] args)
        {
            int[,] gridInt = MakeRawGrid(10);
            char[,] gridChar = new char[gridInt.GetLength(0), gridInt.GetLength(0)];

            for (int i = 0; i < gridInt.GetLength(0); i++)
            {
                for (int y = 0; y < gridInt.GetLength(0); y++)
                {
                    gridChar[i, y] = Convert.ToChar(Convert.ToString(gridInt[i, y]));
                }
            }

            for (int i = 1; i < gridInt.GetLength(0) - 1; i++)
            {
                for (int y = 1; y < gridInt.GetLength(0) - 1; y++)
                {
                    int[] temp = { gridInt[i - 1, y], gridInt[i + 1, y], 
                        gridInt[i, y - 1], gridInt[i , y + 1], gridInt[i, y] };

                    int maxValue = temp.Max();
                    if ( temp[0] == maxValue)
                    {
                        gridChar[i, y] = '^';
                    }
                    else if (temp[1] == maxValue)
                    {
                        gridChar[i, y] = 'v';
                    }
                    else if (temp[2] == maxValue)
                    {
                        gridChar[i, y] = '<';
                    }
                    else if (temp[3] == maxValue)
                    {
                        gridChar[i, y] = '>';
                    }
                    else 
                    {
                        gridChar[i, y] = 'o';
                    }
                }
            }

            DrawGrid(gridInt);
            Console.WriteLine();
            DrawGrid(gridChar);
            Console.ReadLine();
        }

        public static int[,] MakeRawGrid(int length)
        {
            if (length > 2)
            {
                Random random = new Random();
                int[,] rawGrid = new int[length, length];

                for (int x = 0; x < length; x++)
                {
                    for (int y = 0; y < length; y++)
                    {
                        rawGrid[x, y] = random.Next(1, 10);
                    }
                }

                return rawGrid;
            }
            else
            {
                return null;
            }
        }

        public static void DrawGrid(char[,] directionGrid)
        {
            int length = directionGrid.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    Console.Write(directionGrid[x, y] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void DrawGrid(int[,] rawGrid)
        {
            int length = rawGrid.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    Console.Write(rawGrid[x, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

