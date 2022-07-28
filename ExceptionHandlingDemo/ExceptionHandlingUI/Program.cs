using System;
using ExceptionsLibrary;

namespace ExceptionHandlingUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemoCode demo = new DemoCode();

            try
            {
                int result = demo.GrandparentMethod(5);
                Console.WriteLine($"The value at the given position is {result}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("You gave us bad information.");
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                var inner = e.InnerException;
                while (inner != null)
                {
                    Console.WriteLine(inner.StackTrace);
                    inner = inner.InnerException;
                }
            }


            Console.ReadLine();
        }
    }
}