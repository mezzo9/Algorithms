using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Warmup");
            var stopwatch = Stopwatch.StartNew();
            long seed = Environment.TickCount;  // Prevents the JIT Compiler 
                                                // from optimizing Fkt calls away

            long result = 0;
            int count = 100000000;
            while (stopwatch.ElapsedMilliseconds < 1200)  // A Warmup of 1000-1500 mS 
                                                          // stabilizes the CPU cache and pipeline.
            {
                result = TestFunction(seed, count); // Warmup
            }
            stopwatch.Stop();

            int arraySize = 1000000;
            var runCount = 2;
            stopwatch.Reset();
            stopwatch.Start();
            var stringArray = GetStringArray(arraySize);
            stopwatch.Stop();
            Console.WriteLine($"Initializing a {arraySize} elements string array: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            var intArray = GetIntArray(arraySize);
            stopwatch.Stop();
            Console.WriteLine($"Initializing a {arraySize} elements Integer array: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            var stringList = GetStringArrayList(arraySize);
            stopwatch.Stop();
            Console.WriteLine($"Initializing a {arraySize} elements string List: {stopwatch.ElapsedMilliseconds} ms");

            var currentCount = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("--------------    Integer Bubble Sort   ---------------------");
            Console.WriteLine("-------------------------------------------------------------");
            while (currentCount < runCount)
            {
                stopwatch.Reset();
                stopwatch.Start();
                BubbleSort.Sort(intArray = GetIntArray(arraySize));
                stopwatch.Stop();
                Console.WriteLine($"Bubble Sorting an Integer array of {arraySize} elements {stopwatch.ElapsedMilliseconds} ms");
                //PrintTop10(intArray);
                currentCount++;
            }

            currentCount = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("------------  Integer Bubble Sort (Parallel) ----------------");
            Console.WriteLine("-------------------------------------------------------------");
            while (currentCount < runCount)
            {
                stopwatch.Reset();
                stopwatch.Start();
                BubbleSort.sortParallel(GetIntArray(arraySize));
                stopwatch.Stop();
                Console.WriteLine($"Bubble Sorting an Integer array of {arraySize} elements {stopwatch.ElapsedMilliseconds} ms");
                //PrintTop10(intArray);
                currentCount++;
            }

            currentCount = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("--------------    Integer Merge Sort   ---------------------");
            Console.WriteLine("-------------------------------------------------------------");

            while (currentCount < runCount)
            {
                stopwatch.Reset();
                stopwatch.Start();
                MergeSort.Sort(GetIntArray(arraySize));
                stopwatch.Stop();
                Console.WriteLine($"Merge Sorting an Integer array of {arraySize} elements {stopwatch.ElapsedMilliseconds} ms");
                //PrintTop10(intArray);
                currentCount++;
            }

            //currentCount = 0;
            //Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine("--------------    String Bubble Sort    ---------------------");
            //Console.WriteLine("-------------------------------------------------------------");

            //while (currentCount < runCount)
            //{
            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    BubbleSort.Sort(GetStringArray(arraySize));
            //    stopwatch.Stop();
            //    Console.WriteLine($"Bubble Sorting a string array of {arraySize} elements {stopwatch.ElapsedMilliseconds} ms");
            //    //PrintTop10(stringArray);
            //    currentCount++;
            //}

            currentCount = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("--------------    String Merge Sort     ---------------------");
            Console.WriteLine("-------------------------------------------------------------");
            while (currentCount < runCount)
            {
                stopwatch.Reset();
                stopwatch.Start();
                MergeSort.Sort(GetStringArray(arraySize));
                stopwatch.Stop();
                Console.WriteLine($"Bubble Sorting a string array of {arraySize} elements {stopwatch.ElapsedMilliseconds} ms");
                //PrintTop10(stringArray);
                currentCount++;
            }

            currentCount = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("--------------  String List Merge Sort  ---------------------");
            Console.WriteLine("-------------------------------------------------------------");
            while (currentCount < runCount)
            {
                stopwatch.Reset();
                stopwatch.Start();
                MergeSort.Sort(GetStringArrayList(arraySize));
                stopwatch.Stop();
                Console.WriteLine($"Bubble Sorting a string array of {arraySize} elements {stopwatch.ElapsedMilliseconds} ms");
                //PrintTop10(stringArray);
                currentCount++;
            }

            Console.Read();
        }

        static string[] GetStringArray(int size)
        {
            var array = new string[size];
            for (var i = 0; i < size; i++)
            {
                array[i] = GetRandomString();
            }
            return array;
        }

        static string[] GetStringArrayList(int size)
        {
            var array = new List<string>();
            for (var i = 0; i < size; i++)
            {
                array.Add("1234"); // GetRandomString());
            }
            var a = new string[2];
            a[0] = "123";
            a[1] = "123";
            return a; // array.ToArray();
        }

        static int[] GetIntArray(int size)
        {
            var array = new int[size];
            Random rnd = new Random();
            for (var i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 5000);
            }
            return array;
        }








        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
        public static void PrintTop10(string[] array)
        {
            for(var i=0;i<10;i++)
            {
                Console.WriteLine($"Element {i}: {array[i]}");
            }
        }
        public static void PrintTop10(int[] array)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Element {i}: {array[i]}");
            }
        }
        static ulong Factor(ulong f)
        {
            if (f == 0 || f == 1) return 1;
            return f * Factor(f - 1);
        }


        public static long TestFunction(long seed, int count)
        {
            long result = seed;
            for (int i = 0; i < count; ++i)
            {
                result ^= i ^ seed; // Some useless bit operations
            }
            return result;
        }
    }
}
