using ConsoleTables;
using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Products
{
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {
            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Maxsulot nomi", "Narxi", "Soni", "Tarif");

            IProductRepository productRepository = new ProductRepository();
            var products = await productRepository.GetAllAsync();
            foreach (var product in products)
            {
                
                consoleTable1.AddRow(product.Id, product.Name, product.Price, product.Count, product.Description);
            }

            consoleTable1.Write();


            //Console.Clear();
            Product product1 = new Product();
            IProductRepository productRepository1 = new ProductRepository();
            int Id = int.Parse(Console.ReadLine()!);
            var product2 = await productRepository1.GetAsync(Id);
            Console.WriteLine("<=========>  Maxsulot malumotlarini yangilash  <=========>");

            Console.Write("Maxsulot Id: ");
            product1.Id = int.Parse(Console.ReadLine()!);
            if (product2.Id != 0)
            {
                Console.Write("Maxsulot ismi: ");
                product1.Name = Console.ReadLine()!;

                Console.Write("Maxsulot narxi: ");
                product1.Price = int.Parse(Console.ReadLine()!);

                Console.Write("Maxsulot soni: ");
                product1.Count = int.Parse(Console.ReadLine()!);

                Console.Write("Qisqacha tarif: ");
                product1.Description = Console.ReadLine()!;

                await productRepository.UpdateAsync(Id, product1);

                Helper.HelperMessage.Successfuly("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                await UpdatePage.UpdatePageRunAsync();
            }

        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ProductPage.ProductPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
