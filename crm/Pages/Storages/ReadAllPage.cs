using ConsoleTables;
using Market.Interface.Services;
using Market.Models;
using Market.Service;

namespace Market.Pages.Storages
{
    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Maxsulot idsi", "Olingan narxi", "Soni");

            Storage products = new Storage();
            IStorageService productService = new StorageService();
            var productViewModels = await productService.GetAllAsync();
            foreach (var order in productViewModels)
            {
                consoleTable.AddRow(order.Id,
                    order.ProductId, order.SellPrice,
                    order.Count);
            }
        lebel:
            Console.Clear();
            consoleTable.Write();


            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await StoragePage.StoragePageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
