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
            Console.WriteLine("Please enter a number greater than zero.");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[number];
                Populate(array);
                int sum = GetSum(array);
                int product = GetProduct(array, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine($"Your array is size: {number}");
                Console.WriteLine($"The numbers in the array are {string.Join(",", array)}");
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {array[number - 1]} = {product}");
                Console.WriteLine($"{product} / {product/quotient} = {quotient}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
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
                    Console.WriteLine($"Please enter a number: {i+1} of {arr.Length}");
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

        /// <summary>
        /// The method asks the user to randomly select a number between 1 and the first number the user entered,
        /// which is the length of the array.
        /// Then multiply the sum of the array (a returned value from method GetSum) to the random number the user selects.
        /// The result value is stored into variable product and thus can be accessed by StartSequence method.
        /// If the user selects a number that is outside of the range between 1 to the length of the array,
        /// an exception message is print to the console and the exception is thrown to the lower level of the callstack.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sum"></param>
        /// <returns>The output is an integer called product that is the result of the sum times the number input.</returns>
        static int GetProduct(int[] arr, int sum)
        {
            try
            {
                Console.WriteLine($"Please select a random number between 1 and {arr.Length}");
                string num = Console.ReadLine();
                int convertNum = Convert.ToInt32(num);
                int product = sum * (arr[convertNum] - 1);
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Asks the user to enter a number and the number is used to be the dividend of the product value.
        /// The result value is stored into variable quotient and is being returned so it is accessible by StartSequence method.
        /// If the number the user input is zero, an exception will be thrown to the lower level callstack.
        /// And an exception message is printed to the console.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide your product {product} by");
                string num = Console.ReadLine();
                decimal convertNum = Convert.ToInt32(num);
                decimal quotient = decimal.Divide(product, convertNum);
                return quotient;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

    }
}
