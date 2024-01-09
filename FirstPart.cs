/*Вариант 6
Часть 1
В одномерном массиве, состоящем из N целочисленных элементов, вычислить:
---номер максимального элемента массива
---произведение элементов массива, расположенных между первым и вторым нулевыми элементами.
Преобразовать массив таким образом, чтобы в первой его половине располагались элементы, стоявшие в нечетных позициях, а во второй половине — элементы, стоявшие на четных позициях.
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class FirstPart
    {
        private readonly int[] array;

        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }

        public int GetNumOfMaxElement()
        {
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public int GetMultiBetweenFirstSecondZeroElem()
        {
            int firstZeroIndex = -1;
            int secondZeroIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if ((firstZeroIndex == -1 || secondZeroIndex == -1) && array[i] == 0)
                {
                    if (firstZeroIndex == -1)
                    {
                        firstZeroIndex = i;
                    }
                    else
                    {
                        secondZeroIndex = i;
                        break;
                    }
                }
            }
            if (firstZeroIndex != -1 && secondZeroIndex != -1)
            {
                int mul = 1;
                for (int j = firstZeroIndex + 1; j < secondZeroIndex; j++)
                {
                    mul *= array[j];
                }
                return mul;
            }
            else
            {
                return 0;
            }
        }

        public void SortingArray()
        {
            int[] result = new int[array.Length];

            int oddIndex = 0;
            int evenIndex = array.Length / 2;

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[evenIndex] = array[i];
                    evenIndex++;
                }
                else
                {
                    result[oddIndex] = array[i];
                    oddIndex++;
                }
            }

            // копируем полученный результат обратно в исходный массив
            Array.Copy(result, array, array.Length);
        }
    }
}
