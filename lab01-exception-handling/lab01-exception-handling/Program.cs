using System;

namespace lab01_exception_handling
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                 StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
                Console.ReadLine();
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Welcom to my game! Let's do some math!");
            Console.WriteLine("please enter a number greater than zero.");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[number];
                Populate(array);
                int sum = GetSum(array);
                int product = GetProduct(array, sum);
                int quotient = GetQuotient(product);
                Console.WriteLine($"Your array is size: {number}");
                Console.WriteLine($"The numbers in the array are {string.Join(",", array)}");
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {array[number - 1]} = {product}");
                Console.WriteLine($"{product} / {quotient} = {product / quotient}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int[] Populate(int[] arr)
        {
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"Please enter a number: 1 of {i}");
                    string num = Console.ReadLine();
                    int convertNum = Convert.ToInt32(num);
                    arr[i] = convertNum;
                }
                    return arr;
            }
            catch
            {
                throw;
            }
        }

        static int GetSum(int[] arr)
        {

        }

        static int GetProduct(int[] arr, int sum)
        {

        }

        static int GetQuotient(int product)
        {

        }

    }
}
