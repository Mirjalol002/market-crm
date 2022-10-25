using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Storages
{
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {

            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Maxsulot idsi", "Olingan narxi", "Soni");
           
            IStorageRepository storageRepository = new StorageRepository();
            var storages = await storageRepository.GetAllAsync();


            foreach (var storage in storages)
            {
                consoleTable.AddRow(storage.Id,
                        storage.ProductId, storage.SellPrice, storage.Count);
            }
            consoleTable.Write();



            // Tableni ko'rib olish kerak
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Clear();

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Maxsulot idsi", "Olingan narxi", "Soni");



            foreach (var storage in storages)
            {
                if (storage.Id == id)
                {
                    consoleTable1.AddRow(storage.Id,
                                storage.ProductId, storage.SellPrice, storage.Count);
                }
            }

        lebel:
            Console.Clear();
            consoleTable1.Write();




            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await StoragePage.StoragePageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;
        }
    }
}
