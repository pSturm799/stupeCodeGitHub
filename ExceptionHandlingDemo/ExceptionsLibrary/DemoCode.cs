using System;

namespace ExceptionsLibrary
{
    public class DemoCode
    {
        public int GrandparentMethod(int position)
        {
            int output = 0;
            Console.WriteLine("Open Database Connection");
            try
            {
                output = ParentMethod(position);
            }
            finally
            {
                Console.WriteLine("Close Database Connection");
            }

            return output;
        }

        public int ParentMethod(int position)
        {
            //if (position > 3)
            //{
            //    throw new InvalidOperationException("Darf nicht größer als 3 sein.");
            //}

            return GetNumber(position);
        }

        public int GetNumber(int position)
        {
            //try
            //{
            int[] numbers = { 1, 4, 7, 2 };
            return numbers[position];
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}