using ConsoleTables;
using Market.Interface.Repositories;
using Market.Interface.Services;
using Market.Models;
using Market.Repositories;
using Market.Service;

namespace Market.Pages.Clients
{
#pragma warning disable
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "F.I", "Telefon raqami", "Manzili", "Jinsi");
            IClientRepository clientRepository = new ClientRepository();


            var clientViewModels = await clientRepository.GetAllAsync();
            foreach (var client in clientViewModels)
            {
                consoleTable.AddRow(client.Id,
                    client.FullName, client.PhoneNumber, client.Address, client.Gender);
            }
            consoleTable.Write();




            
            Console.Write("Id: ");

            int id = int.Parse(Console.ReadLine());


            Console.Clear();

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "F.I", "Telefon raqami", "Manzili", "Jinsi");


            foreach (var client in clientViewModels)
            {
                if (client.Id == id) 
                {
                    consoleTable1.AddRow(client.Id,
                        client.FullName, client.PhoneNumber, client.Address, client.Gender);
                }
            }
        lebel:
            Console.Clear();
            consoleTable1.Write();


            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine();
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(2000); goto lebel;

        }
    }
}
