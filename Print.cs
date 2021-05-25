using System;
using Cells;

namespace Interface
{
    class Print
    {
        /// <summary>
        /// prtints the matrix to the console
        /// </summary>
        /// <param name="currentMatrix"></param>
        public static void PrintMatrix(Cell [,] currentMatrix)
        {
            for (int i = 0; i < Matrix.matrixSize; i++)
            {
                Console.Write('|');

                for (int j = 0; j < Matrix.matrixSize; j++)
                {
                    if (currentMatrix[i, j] == null)
                    {
                        Console.Write(' ');
                    }
                    else if (currentMatrix[i, j].ColorOfCell == Cell.Color.Blue)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('♦');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('♦');
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('|');
                }

                Console.Write("\n");
            }

            Console.Write('\n');
        }
    }
}
