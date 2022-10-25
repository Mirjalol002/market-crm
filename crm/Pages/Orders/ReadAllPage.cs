using ConsoleTables;
using Market.Interface.Services;
using Market.Models;
using Market.Service;

namespace Market.Pages.Orders
{
    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Mijoz ismi", "Maxsulot nomi", "Sotuvchi ismi", "Soni", "Narxi", "Sanasi");

            Order orders = new Order();
            IOrderService orderService = new OrderService();

            var orderViewModels = await orderService.GetAllAsync();

            foreach (var orderViewModel in orderViewModels)
            {
                consoleTable.AddRow(orderViewModel.Id,
                    orderViewModel.ClientName, orderViewModel.ProductName, orderViewModel.EmployeeName,
                    orderViewModel.ProductCount, orderViewModel.TotalSumm, orderViewModel.DateTime);
            }
        lebel:
            Console.Clear();
            consoleTable.Write();


            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await OrderPage.OrderPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
