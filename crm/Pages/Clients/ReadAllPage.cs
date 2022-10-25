using ConsoleTables;
using Market.Interface.Services;
using Market.Service;

namespace Market.Pages.Clients
{
    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "F.I", "Telefon raqami", "Manzili", "Jinsi");

            IClientService clientService = new ClientService();


            var clientViewModels = await clientService.GetAllAsync();
            foreach (var client in clientViewModels)
            {
                consoleTable.AddRow(client.Id,
                    client.FullName, client.PhoneNumber, client.Address, client.Gender);
            }
            consoleTable.Write();

            lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(2000); goto lebel; ;

        }
    }
}
