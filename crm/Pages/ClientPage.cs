using Market.Pages.Clients;

namespace Market.Pages
{
    public class ClientPage
    {
        public static async Task ClientPageRunAsync()
        {
            Console.Clear();
            Console.Write("1. Mijozlar ro'yxati \n" +
                          "2. Mijoz ro'yxati \n" +
                          "3. Mijoz qo'shish \n" +
                          "4. Mijozni yangilash \n" +
                          "5. Mijozni o'chirish \n" +
                          "0. Bosh minu \n");

            var choose = Console.ReadLine();
            if (choose == "1")
            {
                await ReadAllPage.ReadAllPageRunAsync();
            }
            else if (choose == "2")
            {
                await ReadPage.ReadPageRunAsync();
            }
            else if (choose == "3")
            {
                await CreatePage.CreatePageRunAsync();
            }
            else if (choose == "4")
            {
                await UpdatePage.UpdatePageRunAsync();
            }
            else if (choose == "5")
            {
                await DeletePage.DeletePageRunAsync();
            }
            else if (choose == "0")
            {
                await MainPage.MainPageRunAsync();
            }
            else
            {
                Helper.HelperMessage.Error("Xata belgi kiritdingiz");
                Thread.Sleep(3000);
                Console.Clear();
                await MainPage.MainPageRunAsync();
            }
        }
    }
}
