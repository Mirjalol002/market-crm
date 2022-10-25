using Market.Pages.Storages;

namespace Market.Pages
{
    public class StoragePage
    {
        public static async Task StoragePageRunAsync()
        {
            Console.Clear();
            Console.Write("1. Ombordagi maxsulotlar ro'yxati \n" +
                          "2. Ombordagi maxsulot ro'yxati \n" +
                          "3. Omborga maxsulot qo'shish \n" +
                          "4. Ombordagi maxsulotni yangilash \n" +
                          "5. Ombordagi maxsulotni o'chirish \n" +
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
