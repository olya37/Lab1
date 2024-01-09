/*Вариант 6
Часть 1
В одномерном массиве, состоящем из N целочисленных элементов, вычислить:
---номер максимального элемента массива
---произведение элементов массива, расположенных между первым и вторым нулевыми элементами.
Преобразовать массив таким образом, чтобы в первой его половине располагались элементы, стоявшие в нечетных позициях, а во второй половине — элементы, стоявшие на четных позициях.
Часть 2
Для заданной матрицы размером 8 x 8 найти такие k, при которых k-я строка матрицы совпадает с k-м столбцом.
Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
*/
using System.ComponentModel.DataAnnotations;
using Task01;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Номер максимального элемента массива: " + firstPart.GetNumOfMaxElement());

            var multiBetween = firstPart.GetMultiBetweenFirstSecondZeroElem();
            if (multiBetween == 0)
            {
                Console.WriteLine("В массиве нет двух нулевых элементов");
            }
            else
            {
                Console.WriteLine("Произведение элементов массива, расположенных между первым и вторым нулевыми элементами: " + firstPart.GetMultiBetweenFirstSecondZeroElem());
            }

            firstPart.SortingArray();
            Console.WriteLine("Преобразованный массив(сначала все нечетные элементы, затем все четные): ");
            PrintVector(firstPart.Vector);


            Console.WriteLine("Часть 2:");

            Console.Write("Введите количество строк матрицы: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы: ");
            int cols = int.Parse(Console.ReadLine());
            SecondPart secondPart = new SecondPart(rows, cols); 
            PrintMatrix(secondPart.Matrix); 

            var newRepeating = secondPart.GetRepeatingNumbers();
            if (newRepeating == -1)
            {
                Console.WriteLine("В матрице нет одинаковых строк со столбцом");
            }
            else
            {
                Console.WriteLine("Номер повторяющихся столбцов и строк: " + firstPart.GetMultiBetweenFirstSecondZeroElem());
            }

            Console.WriteLine("Сумма элементов строк, которые содержат хотя бы один отрицательный элемент: " + secondPart.SumRowsWithNegativeElements());
        }

        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        public static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0); 
            int cols = matrix.GetLength(1); 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) 
                {
                    Console.Write("{0,5:F2} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(); 
        }
    }
}
