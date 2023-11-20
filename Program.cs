using System;
using System.Diagnostics;

namespace Assignment16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 29, 35, 72, 28, 92, 77, 81, 56 };

            Console.WriteLine("Original Array: " + string.Join(", ", array));

            Quicksort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted Array: " + string.Join(", ", array));

            bool isSorted = IsArraySorted(array);
            Console.WriteLine("Is Array Sorted Correctly? " + isSorted);

            int[] array20 = GenerateRandomArray(20);
            int[] array30 = GenerateRandomArray(30);
            int[] array50 = GenerateRandomArray(50);

            MeasureTimeAndSort(array20, "Array of 20 elements");
            MeasureTimeAndSort(array30, "Array of 30 elements");
            MeasureTimeAndSort(array50, "Array of 50 elements");
            Console.ReadKey();
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
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static bool IsArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void MeasureTimeAndSort(int[] array, string arrayDescription)
        {
            int[] originalArray = (int[])array.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            Quicksort(array, 0, array.Length - 1);
            stopwatch.Stop();
            ValidateSorting(originalArray, array);
            Console.WriteLine($"{arrayDescription}:");
            Console.WriteLine($"Time taken to sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine();
        }

        static int[] GenerateRandomArray(int size)
        { 
            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 100); // Generate random integers between 1 and 100
            }

            return array;
        }

        static void ValidateSorting(int[] originalArray, int[] sortedArray)
        {
            Array.Sort(originalArray);
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (originalArray[i] != sortedArray[i])
                {
                    throw new InvalidOperationException("Array not sorted correctly.");
                }
            }
        }
    }
}