using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Employees
{
    public class CreatePage
    {
        public static async Task CreatePageRunAsync()
        {
            Employee employees = new Employee();

            Console.Clear();
            Console.WriteLine("<=========>  Xodim qo'shish  <=========>\n");

            Console.Write("Xodimni Id: ");
            employees.Id = int.Parse(Console.ReadLine()!);

            Console.Write("Xodim Ismi: ");
            employees.FullName = Console.ReadLine()!;

            Console.Write("Xodim yoshi: ");
            employees.Age = int.Parse(Console.ReadLine()!);

            Console.Write("Xodim addressi: ");
            employees.Address = Console.ReadLine()!;

            Console.Write("Xodim telefon raqami: ");
            employees.PhoneNumber = Console.ReadLine()!;

            Console.Write("Xodim oyligi: ");
            employees.Salary = int.Parse(Console.ReadLine()!);

            Console.Write("Xodimga qisqa tarif: ");
            employees.Description = Console.ReadLine()!;

            Console.Write("Xodim jinsi: ");
            Console.WriteLine("0. Erkak  <=======> 1. Ayol");
            int gender = int.Parse(Console.ReadLine()!);

            if (gender == 0)
            {
                employees.Gender = Enum.Gender.Erkak;
                Helper.HelperMessage.Successfuly("Successfully");
            }
            else if (gender == 1)
            {
                employees.Gender = Enum.Gender.Ayol;
                Helper.HelperMessage.Successfuly("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xato belgi kiritdingiz");
                Thread.Sleep(3000);
                Console.Clear();
            }

            IEmployeeRepository employeeRepository = new EmployeeRepository();
            await employeeRepository.CreateAsync(employees);



            lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
