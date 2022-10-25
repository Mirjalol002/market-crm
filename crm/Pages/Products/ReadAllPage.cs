using ConsoleTables;
using Market.Interface.Services;
using Market.Models;
using Market.Service;

namespace Market.Pages.Products
{
    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Maxsulot nomi", "Narxi", "Soni", "Tarif");

            Product products = new Product();
            IProductService productService = new ProductService();
            var productViewModels = await productService.GetAllAsync();
            foreach (var order in productViewModels)
            {
                consoleTable.AddRow(order.Id,
                    order.Name, order.Price, order.Count,
                    order.Description);
            }
        lebel:
            Console.Clear();
            consoleTable.Write();

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ProductPage.ProductPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;
        }
    }
}
