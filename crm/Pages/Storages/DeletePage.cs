using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Storages
{
    public class DeletePage
    {
        public static async Task DeletePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Maxsulot idsi", "Olingan narxi", "Soni");

            IStorageRepository storageRepository = new StorageRepository();
            var storages = await storageRepository.GetAllAsync();
            foreach (var storage in storages)
            {

                consoleTable.AddRow(storage.Id, storage.ProductId, storage.SellPrice, storage.Count);
            }

            consoleTable.Write();

            Console.Write("Id kiriting: ");
            int Id = int.Parse(Console.ReadLine()!);

            bool take = (storages.FirstOrDefault(x => x.Id == Id) != null);

            if (take)
            {
                await storageRepository.DeleteAsync(Id);
                Helper.HelperMessage.Successfuly("Successfully!");
            }

            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                await DeletePage.DeletePageRunAsync();
            }



        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await StoragePage.StoragePageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
