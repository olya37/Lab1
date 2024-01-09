/*Вариант 6
Часть 2
Для заданной матрицы размером 8 x 8 найти такие k, при которых k-я строка матрицы совпадает с k-м столбцом.
Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class SecondPart
    {
        private readonly double[,] matrix = new double[10, 10];
        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + "or" + nameof(cols));
            }
            else
            {
                matrix = new double[rows, cols];
                var random = new Random();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = random.Next(-10, 10);
                    }
                }
            }
        }

        public double[,] Matrix
        {
            get
            {
                return matrix;
            }
        }


        public int? GetRepeatingNumbers()
        {
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                bool isMatching = true;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        isMatching = false;
                        break;
                    }
                }

                if (isMatching)
                {
                    return i;
                }
            }

            return -1;
        }

        public double SumRowsWithNegativeElements()
        {
            double sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool hasNegative = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (hasNegative)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum;
        }

    }
}
