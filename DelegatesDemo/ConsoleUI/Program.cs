using System;
using System.Collections.Generic;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static readonly ShoppingCartModel cart = new ShoppingCartModel();

        static void Main(string[] args)
        {
            PopulateCartWithDemoData();

            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser)}€");
            Console.WriteLine();

            // create anyoumus methods
            decimal total = cart.GenerateTotal(subTotal => Console.WriteLine($"The Subtotal for cart 2 is {subTotal}"),
                (products, subTotal) =>
                {
                    if (products.Count > 3)
                    {
                        return subTotal * 0.5M;
                    }

                    return subTotal;
                },
                message => Console.WriteLine($"Cart 2 Alert: {message}")
            );
            Console.WriteLine($"The total for cart 2 is {total}");

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please press any key to exit the application...");
            Console.ReadKey();
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal}€");
        }

        // Action<>
        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        // Func<>
        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }

            if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }

            if (subTotal > 10)
            {
                return subTotal * 0.95M;
            }

            return subTotal;
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
    }
}