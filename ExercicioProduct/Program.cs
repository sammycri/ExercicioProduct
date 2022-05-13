using System;
using System.Collections.Generic;
using System.Globalization;
using ExercicioProduct.Entities;

namespace ExercicioProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            
            List<Product> list = new List<Product>();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, Used or Imported? (c/u/i)?");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (type == 'c')
                {                                               
                    list.Add(new Product(name, price));
                }

                else if (type == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, manufactureDate));
                }
                else
                {
                    Console.Write("Customs Fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
                               
            }

            Console.WriteLine("");
            Console.WriteLine("Price Tags: ");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
