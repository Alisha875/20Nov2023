using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_17
{
    internal class Program
    {
        static void Main()
        {
            PerformPerformanceAnalysis(20);
            PerformPerformanceAnalysis(30);
            PerformPerformanceAnalysis(50);

            Console.ReadKey();
        }

        static void PerformPerformanceAnalysis(int arraySize)
        {
            int[] array = GenerateRandomArray(arraySize);

            Stopwatch quicksortStopwatch = Stopwatch.StartNew();
            Quicksort(array, 0, array.Length - 1);
            quicksortStopwatch.Stop();

            CheckSortedArray(array);

            Console.WriteLine($"Quicksort time for {arraySize} elements: {quicksortStopwatch.ElapsedMilliseconds} ms");
        }

        static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1000); // Adjust the range as needed
            }

            return array;
        }

        static void Quicksort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);
                Quicksort(array, low, partitionIndex - 1);
                Quicksort(array, partitionIndex + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static void CheckSortedArray(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    Console.WriteLine("Error: Array is not sorted correctly!");
                    return;
                }
            }
            Console.WriteLine("Array is sorted correctly.");
        }
    }
}


