using ConsoleTables;
using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Clients
{
#pragma warning disable
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Ism Familiyasi", "Telefon raqami", "Manzil", "Jinsi");

            IClientRepository clientRepository1 = new ClientRepository();
            var clientss = await clientRepository1.GetAllAsync();
            foreach (var clientt in clientss)
            {
                string gender;
                if (clientt.Gender == Enum.Gender.Erkak)
                {
                    gender = "Mele";
                }
                else
                {
                    gender = "Female";
                }
                consoleTable1.AddRow(clientt.Id, clientt.FullName, clientt.PhoneNumber, clientt.Address, gender);
            }

            consoleTable1.Write();


            //Console.Clear();
            Client client = new Client();
            IClientRepository clientRepository = new ClientRepository();
            int Id = int.Parse(Console.ReadLine());
            var clients = await clientRepository.GetAsync(Id);

            Console.Write("Foydalanuvchi Id: ");
            client.Id = int.Parse(Console.ReadLine());
            if (clients.Id != 0)
            {
                Console.WriteLine("<=========>  Foydalanuvchi malumotlarini yangilash  <=========>");
                Console.Write("Foydalanuvchi ismi: ");
                client.FullName = Console.ReadLine();

                Console.Write("Telefon raqami: ");
                client.PhoneNumber = Console.ReadLine();

                Console.Write("Manzil: ");
                client.Address = Console.ReadLine();

                Console.WriteLine("0. Erkak  <=====>  1. Ayol");
                int gender = int.Parse(Console.ReadLine());
                if (gender == 0)
                {
                    client.Gender = Enum.Gender.Erkak;
                }
                else
                {
                    client.Gender = Enum.Gender.Ayol;
                }

                await clientRepository.UpdateAsync(Id, client);

                Helper.HelperMessage.Successfuly("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                Thread.Sleep(1000);
                await UpdatePage.UpdatePageRunAsync();
            }

        }
    }
}
