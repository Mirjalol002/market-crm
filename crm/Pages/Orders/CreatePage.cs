using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;
using Market.ViewModels;

namespace Market.Pages.Orders
{
    public class CreatePage
    {

        public static async Task CreatePageRunAsync()
        {
            IProductRepository productRepository = new ProductRepository();

            Order orders = new Order();
            //
            OrderViewModel orderViewModel = new OrderViewModel();
            //
            Console.Clear();
            Console.WriteLine("<=========>  Buyurtma qo'shish  <=========>\n");

            Console.Write("Buyirtma Id: ");
            orderViewModel.Id = int.Parse(Console.ReadLine()!);

            Console.Write("Mijoz ismi: ");
            orderViewModel.ClientName = Console.ReadLine()!;

            Console.Write("Maxsulot nomi: ");
            orderViewModel.ProductName = Console.ReadLine()!;

            int productId = (await productRepository.GetAllAsync()).FirstOrDefault(x => x.Name.Equals(orderViewModel.ProductName))!.Id;

            Console.Write("Maxsulot soni: ");
            orderViewModel.ProductCount = int.Parse(Console.ReadLine()!);

            Console.Write("Xodim ismi: ");
            orderViewModel.EmployeeName = Console.ReadLine()!;

         

            orderViewModel.TotalSumm = ((await productRepository.GetAsync(productId)).Price * orderViewModel.ProductCount);

            Console.WriteLine("Vaqt: ",DateTime.Now);
            orderViewModel.DateTime = DateTime.Now;


            IOrderRepository orderRepository = new OrderRepository();
            await orderRepository.CreateAsync(orderViewModel);



        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await OrderPage.OrderPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;



        }
    }
}
