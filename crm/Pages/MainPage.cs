namespace Market.Pages
{
    public class MainPage
    {
        public static async Task MainPageRunAsync()
        {
            Console.Clear();
            Console.Write("1. Mijozlar \n" +
                          "2. Xodimlar \n" +
                          "3. Buyurtmalar \n" +
                          "4. Maxsulotlar \n" +
                          "5. Ombor \n" 
                          );


            var choose = Console.ReadLine();

            if (choose == "1")
            {
                await ClientPage.ClientPageRunAsync();
            }
            else if (choose == "2")
            {
                await EmployeePage.EmployeePageRunAsync();
            }
            else if (choose == "3")
            {
                await OrderPage.OrderPageRunAsync();
            }
            else if (choose == "4")
            {
                await ProductPage.ProductPageRunAsync();
            }
            else if (choose == "5")
            {
                await StoragePage.StoragePageRunAsync();
            }
       
            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz");
                Thread.Sleep(3000);
                await MainPage.MainPageRunAsync();
            }
        }
    }
}
