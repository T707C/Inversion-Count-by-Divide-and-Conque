/*
==============================================================
Author: Taylor Carver
Course: Algorithms
Date: 4/6/2026
Project: Inversion Count via Divede-and-Conquer: This project implements an inversion counting algorithm
using the divide and conquer paradigm. Given an array of 100,000 distinct integers ranging from 1 to
100,000. The goal is to computer the total number of inversions — pairs of indices (i, j) where i < j but array[i] > array[j]. 
*/

using System;
using System.Diagnostics;
using System.IO;

class InversionCounter
{
    static void Main(string[] args)
    {
        //Locate the input file
        string exeDir = AppContext.BaseDirectory;
        string inputFile = Path.GetFullPath(
            Path.Combine(exeDir, "..", "..", "..", "..", "..", "..",
                         "IntegerArray.txt"));
        if (!File.Exists(inputFile))
        {
             // Fallback: let the user supply a path
            Console.Write("IntegerArray.txt not found automatically.\n" +
                          "Enter full path to IntegerArray.txt: ");
            inputFile = Console.ReadLine()?.Trim() ?? "";

        }

        // Read every integer per line
        Console.WriteLine($"Reading from: {inputFile}");
        string[] lines = File.ReadAllLines(inputFile);
        long[] array = new long[lines.Length];
        for (int i = 0; i < lines.Length; i++)
            array[i] = long.Parse(lines[i].Trim());


        Console.WriteLine($"Loaded {array.Length:N0} integers.");

        // Runs the algorithm and times it
            Stopwatch sw = Stopwatch.StartNew();
        long inversions = SortAndCount(array);
        sw.Stop();

        // Report the results
        Console.WriteLine($"\nTotal inversions : {inversions:N0}");
        Console.WriteLine($"Running time     : {sw.Elapsed.TotalSeconds:F4} seconds");

        // Saves the sorted array to the Result Folder
        string resultDir = Path.GetFullPath(
            Path.Combine(exeDir, "..", "..", "..", "..", "..",
                         "Result"));
        Directory.CreateDirectory(resultDir);   // creates it if missing


        string outputFile = Path.Combine(resultDir, "SortedArray.txt");
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (long num in array)
                writer.WriteLine(num);
        }
        Console.WriteLine($"\nSorted array written to:\n  {outputFile}");
    }

    /*
     ======================================================
                   SortAndCount
        * Recursively sorts 'array' in place and returns 
        the number of inversions found in it.

        *Base Case: An array of 0 or 1 elements have 0 inverions
        and is alreayd sorted.

        *Recursive Case: 
            1. Split the array into left and right halves.
            2. Recursively sort and count each half.
            3. Merge the two sorted halves, counting split
                inversions along the way.
            4. Return the sum of all three inversion counts.

     ===========================================================

    */

    static long SortAndCount(long[] array)
    {
        // Base case - already sorted
        if (array.Length <= 1)
            return 0;

        // Step 1: Split //
        int mid = array.Length / 2;

        long[] left  = new long[mid];
        long[] right = new long[array.Length - mid];

        Array.Copy(array, 0,   left,  0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);


        // Step 2: Recurse //
         long leftInversions  = SortAndCount(left);
        long rightInversions = SortAndCount(right);

        // ── Step 3 & 4: Merge + count split inversions ─────────
        long splitInversions = MergeAndCount(left, right, array);

        return leftInversions + rightInversions + splitInversions;


    }
}