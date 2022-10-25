using ConsoleTables;
using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;
using Market.ViewModels;

namespace Market.Pages.Orders
{
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {
            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Mijoz ismi", "Maxsulot nomi", "Sotuvchi ismi", "Soni", "Sanasi");

            IOrderRepository orderRepository1 = new OrderRepository();
            var orderss = await orderRepository1.GetAllAsync();
            OrderViewModel orderViewModel = new OrderViewModel();
            foreach (var orderr in orderss)
            {
                
                consoleTable1.AddRow(orderr.Id, orderViewModel.ClientName, orderViewModel.ProductName, orderViewModel.EmployeeName, orderr.Count, orderr.DateTime);
            }

            consoleTable1.Write();


            //Console.Clear();
            Order order = new Order();
            IOrderRepository orderRepository = new OrderRepository();
            int Id = int.Parse(Console.ReadLine()!);
            var orders = await orderRepository.GetAsync(Id);

            Console.Write("Buyurtma Id: ");
            order.Id = int.Parse(Console.ReadLine()!);
            if (orders.Id != 0)
            {
                Console.WriteLine("<=========>  Buyurtma malumotlarini yangilash  <=========>");
                Console.Write("Foydalanuvchi id: ");
                order.ClientId = int.Parse(Console.ReadLine()!);

                Console.Write("Maxsulot id: ");
                order.ProductId = int.Parse(Console.ReadLine()!);

                Console.Write("Xodim id: ");
                order.EmployeeId = int.Parse(Console.ReadLine()!);

                Console.Write("Soni:");
                order.Count = int.Parse(Console.ReadLine()!);

                orderViewModel.DateTime = DateTime.Now;

                await orderRepository.UpdateAsync(Id, order);

                Helper.HelperMessage.Successfuly("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                await UpdatePage.UpdatePageRunAsync();
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
