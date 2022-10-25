using Market.Enum;
using Market.Interface.Repositories;
using Market.Models;
using Market.Repositories;

namespace Market.Pages.Employees
{
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {
            //Console.Clear();

            Console.Write("Xodim Id: ");

            int id = int.Parse(Console.ReadLine()!);

            IEmployeeRepository employeeRepository = new EmployeeRepository();

            var employees = await employeeRepository.GetAsync(id);

            var employee = new Employee();

            Console.WriteLine("<=========>  Xodim malumotlarini yangilash  <=========>");
            Console.Write("Xodim ismi: ");
            employee.FullName = Console.ReadLine()!;

            Console.Write("Xodim yoshi: ");
            employee.Age = int.Parse(Console.ReadLine()!);

            Console.Write("Xodim addressi: ");
            employee.Address = Console.ReadLine()!;

            Console.Write("Xodim Telefon raqami: ");
            employee.PhoneNumber = Console.ReadLine()!;

            Console.Write("Xodimni oyligi: ");
            employee.Salary = int.Parse(Console.ReadLine()!);

            Console.WriteLine("0. Erkak  <=====>  1. Ayol");
            employee.Gender = (Gender)int.Parse(Console.ReadLine()!);

            await employeeRepository.UpdateAsync(id, employee);


            lebel:
            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;
        }
    }
}
