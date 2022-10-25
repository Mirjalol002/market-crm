using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Orders
{
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Foydalanuvchi Id", "Maxsulot Id", "Xodim Id", "Soni", "Summa", "Vaqti");
            // Service da ishlamagani un repositorydan foydalanganman
            //IClientService clientService = new ClientService();

            IOrderRepository orderRepository = new OrderRepository();


            var orders = await orderRepository.GetAllAsync();
            foreach (var order in orders)
            {
                consoleTable.AddRow(order.Id,
                    order.ClientId, order.ProductId, order.EmployeeId, order.Count, order.TotalSum, order.DateTime);
            }
            consoleTable.Write();




            // Tableni ko'rib olish kerak
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Clear();


            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Foydalanuvchi Id", "Maxsulot Id", "Xodim Id", "Soni", "Summa", "Vaqti");

            foreach (var order in orders)
            {
                if (order.Id == id)
                {
                    consoleTable.AddRow(order.Id,
                   order.ClientId, order.ProductId, order.EmployeeId, order.Count, order.TotalSum, order.DateTime);
                }
            }
        lebel:
            Console.Clear();
            consoleTable1.Write();


            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await OrderPage.OrderPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;




        }
    }
}
