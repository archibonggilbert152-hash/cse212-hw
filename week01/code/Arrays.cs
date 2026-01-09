using System;
using System.Collections.Generic;

class Arrays
{
    static void Main(string[] args)
    {
        // ===== PART 1 TEST =====
        double[] multiples = MultiplesOf(3, 5);
        Console.WriteLine("MultiplesOf(3, 5):");
        Console.WriteLine(string.Join(", ", multiples));

        // ===== PART 2 TEST =====
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);

        Console.WriteLine("\nRotated List by 3:");
        Console.WriteLine(string.Join(", ", numbers));
    }

    // ==========================================================
    // PART 1: ARRAYS
    // ==========================================================
    static double[] MultiplesOf(double start, int count)
    {
        /*
         * PLAN:
         * 1. Create a new array with size equal to 'count'
         * 2. Use a loop that runs 'count' times
         * 3. For each index i:
         *      - Multiply the starting number by (i + 1)
         *      - Store the result in the array at index i
         * 4. Return the filled array
         */

        double[] result = new double[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        return result;
    }

    // ==========================================================
    // PART 2: LISTS
    // ==========================================================
    static void RotateListRight(List<int> data, int amount)
    {
        /*
         * PLAN:
         * 1. Create a new temporary list to store rotated values
         * 2. Find the starting index:
         *      - data.Count - amount
         * 3. Add elements from that index to the end of the list
         * 4. Add the remaining elements from the beginning
         * 5. Clear the original list
         * 6. Copy the rotated data back into the original list
         */

        List<int> rotated = new List<int>();
        int startIndex = data.Count - amount;

        // Add the last 'amount' elements
        for (int i = startIndex; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }

        // Add the remaining elements from the beginning
        for (int i = 0; i < startIndex; i++)
        {
            rotated.Add(data[i]);
        }

        // Replace original list contents
        data.Clear();
        data.AddRange(rotated);
    }
}
