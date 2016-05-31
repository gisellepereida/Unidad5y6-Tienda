using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Product
    {

        public string Code;
        public string Description;
        public decimal Price;

        public Product(string c, string d, decimal p)
        {

            Code = c;
            Description = d;
            Price = p;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}", Code, Description, Price);

        }

    }

    class ProductDB
    {
        const string dir = @"C:\Users\GabrielaGiselle\Desktop\";
        const string path = dir + @"Products.txt";

        public static List<Product> GetProducts()
        {
            StreamReader textIn = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
            List<Product> products = new List<Product>();
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                products.Add(new Product(columns[0], columns[1], Convert.ToDecimal(columns[2])));
            }
            return products;
        }
        public static void SaveProducts(List<Product> products)
        {
            StreamWriter textOut = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            foreach (Product p in products)
            {
                textOut.Write(p.Code + "|");
                textOut.Write(p.Description + "|");
                textOut.Write(p.Price);
            }

            textOut.Close();
        }

  
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productos = new List<Product>();
            //P.Add(new Product("AAA","XBOX ONE, 6000.23m));
            //P.Add(new Product("AAB","PS4",7000.23m));
            //P.Add(new Product("AAC", "WiiU", 3000.99m));
            // ProductDB.SaveProducts(P);
            productos = ProductDB.GetProducts();
            foreach (Product p in productos)
                Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}




