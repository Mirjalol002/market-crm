using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Storages
{
    public class CreatePage
    {
        public static async Task CreatePageRunAsync()
        {

            
            Product product = new Product();
            IProductRepository productRepository = new ProductRepository();
            //IStorageRepository storageRepository = new StorageRepository();

            Console.Clear();
            Storage storages = new Storage();
            Console.Clear();
            Console.WriteLine("<=========>  Omborga maxsulot qo'shish  <=========>");

            Console.Write("Omborni Id: ");
            storages.Id = int.Parse(Console.ReadLine()!);

            Console.Write("Maxsulot id: ");
            //var nimadir = (product.Id == storages.ProductId);
            //var productNAME = (await productRepository.GetAllAsync()).FirstOrDefault(x => x.Name.Equals(product.Id == storages.ProductId))!.Id;
            //storages.ProductId = int.Parse(Console.ReadLine());
            storages.ProductId = int.Parse(Console.ReadLine()!);
            
            Console.Write("Sotib olingan narxi: ");
            storages.SellPrice = int.Parse(Console.ReadLine()!);

            Console.Write("Soni: ");
            storages.Count = int.Parse(Console.ReadLine()!);



            IStorageRepository storageRepository = new StorageRepository();
            await storageRepository.CreateAsync(storages);
            Helper.HelperMessage.Successfuly("Successfully");


        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await StoragePage.StoragePageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
