using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Storages
{
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {

            Console.Write("Ombor Id: ");

            int id = int.Parse(Console.ReadLine()!);

            IStorageRepository storageRepository = new StorageRepository();

            var storages = await storageRepository.GetAsync(id);

            var storage = new Storage();

            Console.WriteLine("<=========>  Ombor malumotlarini yangilash  <=========>");
            Console.Write("Maxsulot id: ");
            storage.ProductId = int.Parse(Console.ReadLine()!);

            Console.Write("Sotib olingan narxi: ");
            storage.SellPrice = int.Parse(Console.ReadLine()!);

            Console.Write("Soni: ");
            storage.Count = int.Parse(Console.ReadLine()!);

            await storageRepository.UpdateAsync(id, storage);

        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await StoragePage.StoragePageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;
        }
    }
}
