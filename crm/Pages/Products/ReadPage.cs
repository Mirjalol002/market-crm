using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Products
{
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {

            ConsoleTable consoleTable = new ConsoleTable("Id", "Maxsulot nomi", "Narxi", "Soni", "Tarif");
            Console.Clear();

            // Service da ishlamagani un repositorydan foydalanganman
            //IClientService clientService = new ClientService();

            IProductRepository productRepository = new ProductRepository();


            var productss = await productRepository.GetAllAsync();
            foreach (var product in productss)
            {
                consoleTable.AddRow(product.Id,
                    product.Name, product.Price, product.Count, product.Description);
            }
            consoleTable.Write();




            // Tableni ko'rib olish kerak
            Console.Write("Id: ");

            int id = int.Parse(Console.ReadLine()!);

            Console.Clear();

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Maxsulot nomi", "Narxi", "Soni", "Tarif");

            foreach (var product in productss)
            {
                if (product.Id == id)
                {
                    consoleTable1.AddRow(product.Id,
                        product.Name, product.Price, product.Count, product.Description);
                }
            }


        lebel:
            Console.Clear();
            consoleTable1.Write();

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ProductPage.ProductPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
