class Program
{
    static void Main()
    {
        // Input
        Console.WriteLine("Enter five space-separated integers:");
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Call the function
        MiniMaxSum(arr);

        Console.WriteLine("Bonus: ");
        // Count total of array
        Console.WriteLine($"Total of array: {arr.Length}");

        // Find min in array with 2 solutions: use c# linq and define funtion
        int min = 0;
        min = arr.Min();
        // min = FindMin(arr);
        Console.WriteLine($"Min in array: {min}");

        // Find max in array with 2 solutions: use c# linq and define funtion
        int max = 0;
        max = arr.Max();
        // max = FindMax(arr);
        Console.WriteLine($"Max in array: {max}");

        // Find even elements in array
        FindEvenElements(arr);

        Console.WriteLine();

        // Find odd elements in array
        FindOddElements(arr);
    }
    static void MiniMaxSum(int[] arr)
    {
        // Sort the array 
        Array.Sort(arr);

        // Sum of first 4 elements is minimum sum
        long minSum = arr.Take(4).Sum();

        // Sum of last 4 elements is maximum sum
        long maxSum = arr.Skip(1).Take(4).Sum();

        // Print the results min-max sum
        Console.WriteLine($"{minSum} {maxSum}");
    }

    static void FindEvenElements(int[] arr)
    {
        Console.Write("Even elements in the array: ");

        foreach (var element in arr)
        {
            if (element % 2 == 0)
            {
                Console.Write($"{element} ");
            }
        }
    }
    static void FindOddElements(int[] arr)
    {
        Console.Write("Odd elements in the array: ");

        foreach (var element in arr)
        {
            if (element % 2 != 0)
            {
                Console.Write($"{element} ");
            }
        }
    }
    static int FindMin(int[] arr)
    {
        int min = int.MaxValue;

        foreach (var element in arr)
        {
            if (element < min)
            {
                min = element;
            }
        }

        return min;
    }
    static int FindMax(int[] arr)
    {
        int max = int.MinValue;

        foreach (var element in arr)
        {
            if (element > max)
            {
                max = element;
            }
        }

        return max;
    }
}