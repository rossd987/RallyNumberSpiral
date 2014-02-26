/******************
 * Ross Dougherty
 * 2014-02-25
 * ***************/
using System;

namespace RallyNumberSpiral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter an integer or \"q\" to quit: ");
            var i = Console.ReadLine();
            while (i.ToLower() != "q")
            {
                try
                {
                    NumberSpiral numberSpiral = NumberSpiral.CreateNumberSpiral(i);
                    Console.Write(numberSpiral.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }

                Console.Write("\nPlease enter an integer or \"q\" to quit: ");
                i = Console.ReadLine();
            }
        }
    }
}
