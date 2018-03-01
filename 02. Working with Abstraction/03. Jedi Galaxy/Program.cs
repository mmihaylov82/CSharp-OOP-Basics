using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = FillMatrix(dimensions);

            long totalSum = 0;
            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                ParseEvilMove(matrix, evilCoordinates);
                totalSum += ParseIvoMove(matrix, ivoCoordinates);

                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private static int[,] FillMatrix(int[] dimensions)
        {
            int rows = dimensions[0];
            int columns = dimensions[1];

            int[,] matrix = new int[rows, columns];

            int value = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }

        private static long ParseIvoMove(int[,] matrix, int[] ivoCoordinates)
        {
            long sum = 0;
            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsPointInMatrix(matrix, ivoRow, ivoCol))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
            return sum;
        }

        private static void ParseEvilMove(int[,] matrix, int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsPointInMatrix(matrix, evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static bool IsPointInMatrix(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
