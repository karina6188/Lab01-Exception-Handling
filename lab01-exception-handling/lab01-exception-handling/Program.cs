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

        /// <summary>
        /// Take user input and set up an array with the input.
        /// Various methods are being called through this method.
        /// Output values of array, sum, product, and quotient to the user.
        /// </summary>
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

        /// <summary>
        /// Based on the first input the user entered for StartSequence method,
        /// this method asks the user for more number inputs for fill the array.
        /// If for any chances there is an exception, it is thrown to the StartSequence method to take care of it.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>This method returns an array that is filled with user's number inputs.</returns>
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

        /// <summary>
        /// This method iterates through the array and get the sum of the numbers.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>The output is an integer which is the sum of the array.</returns>
        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            if (sum < 20)
            {
                throw (new Exception ($"Value of {sum} is too low."));
            }
            return sum;
        }

        static int GetProduct(int[] arr, int sum)
        {

        }

        static int GetQuotient(int product)
        {

        }

    }
}
