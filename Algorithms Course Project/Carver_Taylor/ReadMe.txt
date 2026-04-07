================================================================================
  Inversion Count by Divide-and-Conquer
  Author  : Taylor Carver
  Course  : Algorithms
================================================================================

SOFTWARE ENVIRONMENT
--------------------
- Language  : C# (.NET 8)
- SDK       : .NET 8 SDK  (https://dotnet.microsoft.com/download)
- IDE       : Any text editor or Visual Studio / VS Code
- OS        : Windows / macOS / Linux (cross-platform)

FOLDER STRUCTURE
----------------
Carver_Taylor/
├── ReadMe.txt                      <- this file
├── src/
│   └── InversionCounter/
│       ├── InversionCounter.csproj <- project configuration
│       └── Program.cs              <- algorithm source code
└── Result/
    └── SortedArray.txt             <- generated output (sorted array)

The IntegerArray.txt input file should remain in the parent
"Algorithms Course Project" folder (one level above Carver_Taylor/).

HOW TO COMPILE AND RUN
-----------------------
1. Open a terminal (Command Prompt, PowerShell, or bash).

2. Navigate to the project source folder:
     cd path\to\Carver_Taylor\src\InversionCounter

3. Restore and run (dotnet handles the build automatically):
     dotnet run

   Alternatively, build first and then run the executable:
     dotnet build -c Release
     dotnet run -c Release

4. The program will:
   a. Read IntegerArray.txt (100,000 integers, one per line).
   b. Count all inversions using a Divide-and-Conquer algorithm.
   c. Print the inversion count and running time to the console.
   d. Write the sorted array to:  Carver_Taylor/Result/SortedArray.txt

RUNNING RESULTS
---------------
  Total inversions : 2,407,905,288
  Running time     : ~0.034 seconds  (on a modern desktop CPU)

ALGORITHM SUMMARY
-----------------
The algorithm is a modified Merge Sort. It recursively splits the array
in half, sorts each half, and merges them back together. During the merge
step, whenever an element from the RIGHT half is placed before remaining
elements in the LEFT half, those remaining left elements each form a split
inversion with the right element. Because the left half is already sorted,
this count equals (number of remaining left elements) and is computed in
O(1) per merge decision, giving the algorithm an overall complexity of
O(n log n).
================================================================================
