using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Clients
{
# pragma warning disable
    public class DeletePage
    {
        public static async Task DeletePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Ism Familiyasi", "Telefon raqami", "Manzil", "Jinsi");

            IClientRepository clientRepository = new ClientRepository();
            var clients = await clientRepository.GetAllAsync();
            foreach (var client in clients)
            {
                string gender;
                if (client.Gender == Enum.Gender.Erkak)
                {
                    gender = "Erkak";
                }
                else
                {
                    gender = "Ayol";
                }
                consoleTable.AddRow(client.Id, client.FullName, client.PhoneNumber, client.Address, gender);
            }

            consoleTable.Write();

            Console.Write("Id kiriting: ");
            int Id = int.Parse(Console.ReadLine());

            bool take = (clients.FirstOrDefault(x => x.Id == Id) != null);

            if (take)
            {
                await clientRepository.DeleteAsync(Id);
                Helper.HelperMessage.Successfuly("Successfully!");
            }

            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                await DeletePage.DeletePageRunAsync();
            }

            lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine();
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xattoo belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
