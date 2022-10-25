using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Clients
{
# pragma warning disable
    public class CreatePage
    {
        public static async Task CreatePageRunAsync()
        {
            Client clients = new Client();
            Console.Clear();
            Console.WriteLine("<=========>  Foydalanuvchi qo'shish  <=========>");

            Console.Write("Foydalanuvchi Id: ");
            clients.Id = int.Parse(Console.ReadLine());

            Console.Write("Foydalanuvchi Ismi: ");
            clients.FullName = Console.ReadLine();

            Console.Write("Foydalanuvchi telefon raqami: ");
            clients.PhoneNumber = Console.ReadLine();

            Console.Write("Foydalanuvchi addressi: ");
            clients.Address = Console.ReadLine();

            Console.WriteLine("0. Erkak  <=======> 1. Ayol");
            int gender = int.Parse(Console.ReadLine());

            if (gender == 0)
            {
                clients.Gender = Enum.Gender.Erkak;
                Helper.HelperMessage.Successfuly("Successfully");
            }
            else if (gender == 1)
            {
                clients.Gender = Enum.Gender.Ayol;
                Helper.HelperMessage.Successfuly("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xato belgi kiritdingiz");
                Thread.Sleep(3000);
                Console.Clear();
                await CreatePage.CreatePageRunAsync();
            }

            IClientRepository clientRepository = new ClientRepository();
            await clientRepository.CreateAsync(clients);

            lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine();
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;
 
        }
    }
}
