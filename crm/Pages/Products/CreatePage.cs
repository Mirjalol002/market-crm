using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Products
{
    public class CreatePage
    {
        public static async Task CreatePageRunAsync()
        {
            Product products = new Product();

            Console.Clear();
            Console.WriteLine("<=========>  Maxsulot qo'shish  <=========>");

            Console.Write("Maxsulotni Id: ");
            products.Id = int.Parse(Console.ReadLine()!);

            Console.Write("Maxsulotni nomi: ");
            products.Name = Console.ReadLine()!;

            Console.Write("Maxsulot narxi: ");
            products.Price = int.Parse(Console.ReadLine()!);

            Console.Write("Maxsulot sonni: ");
            products.Count = int.Parse(Console.ReadLine()!);

            Console.Write("Maxsulotga qisqa tarif: ");
            products.Description = Console.ReadLine()!;



            IProductRepository productRepository = new ProductRepository();
            await productRepository.CreateAsync(products);

        lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ProductPage.ProductPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;


        }
    }
}
