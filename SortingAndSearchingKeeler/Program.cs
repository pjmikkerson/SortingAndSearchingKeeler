

using System.Diagnostics;

namespace SortingAndSearchingKeeler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Random rand = new Random();
            int arraySize = 200000;
            int[] randomArray = new int[arraySize];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = rand.Next(0, arraySize);
            }
            




            sw.Start();
            SelectionSort(randomArray);
            sw.Stop();
            Console.WriteLine("Selection sort time");

            Console.WriteLine(sw.Elapsed);
            sw.Reset();


            //for (int i = 0; i < randomArray.Length; i++)
            //{
            //    Console.Write(randomArray[i] + ",");
            //}
            //Console.WriteLine();
            sw.Start();
            BinarySearch(randomArray, 5);
            sw.Stop();
            Console.WriteLine("Binary search time");
            Console.WriteLine(sw.Elapsed);
            sw.Reset();
            


        }

        private static void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        private static void SelectionSort(int[] array)
        {
            int n = array.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (array[j] < array[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = array[min_idx];
                array[min_idx] = array[i];
                array[i] = temp;
            }
        }

        private static void BubbleSort(int[] array)
        {
            int n = array.Length;
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {

                        // Swap arr[j] and arr[j+1]
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were
                // swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
        }


        //Linear is best used  on smaller arrays, it is also capable of 
        //searching unsorted arrays
        static int LinearSearch(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }

            }
            return -1;
        }

        //Binary search is significantly faster than linear search
        //however, it is only capable of searching sorted arrays
        static int BinarySearch(int[] array, int value)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // Check if the value is at the middle index
                if (array[mid] == value)
                {
                    return mid;
                }
                // If the value is greater than the middle element, search the right half
                else if (array[mid] < value)
                {
                    left = mid + 1;
                }
                // If the value is less than the middle element, search the left half
                else
                {
                    right = mid - 1;
                }
            }

            // If the value is not found, return -1 instead of -99
            return -1;
        }
    }
}
