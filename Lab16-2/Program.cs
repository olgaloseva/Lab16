using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Lab16_2
{
    class Program
    {
        //Программа для получения информации о товаре из json-файла, определяет название самого дорогого товара.
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxPrice = products[0];
            foreach (Product pr in products)
            {
                if (pr.PriceProd > maxPrice.PriceProd)
                {
                    maxPrice = pr;
                }
            }

            Console.WriteLine($"Название самого дорого товара: {maxPrice.NameProd}, \nего код: {maxPrice.CodeProd}, цена: {maxPrice.PriceProd:f2}");
            Console.ReadKey();
        }
    }
}
