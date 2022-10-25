using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Orders
{
    public class DeletePage
    {
        public static async Task DeletePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Mijoz ismi", "Maxsulot nomi", "Sotuvchi ismi", "Sanasi");

            IOrderRepository orderRepository = new OrderRepository();
            var orders = await orderRepository.GetAllAsync();
            foreach (var order in orders)
            {
               
                consoleTable.AddRow(order.Id, order.ClientId, order.ProductId, order.EmployeeId, order.DateTime);
            }

            consoleTable.Write();

            Console.Write("O'chiriladigan Idni kiriting: ");
            int Id = int.Parse(Console.ReadLine()!);

            bool take = (orders.FirstOrDefault(x => x.Id == Id) != null);

            if (take)
            {
                await orderRepository.DeleteAsync(Id);
                Helper.HelperMessage.Successfuly("Successfully!");
            }

            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                await DeletePage.DeletePageRunAsync();
            }



        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await OrderPage.OrderPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
