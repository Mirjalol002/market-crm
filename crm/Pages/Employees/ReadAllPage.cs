using ConsoleTables;
using Market.Interface.Services;
using Market.Service;

namespace Market.Pages.Employees
{
    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
        {
            Console.Clear();
            ConsoleTable consoleTable = new ConsoleTable("Id", "F.I", "Xodim yoshi", "Xodim addressi", "Telefon raqami", "Xodim oyligi", "jinsi");



            IEmployeeService employeeService = new EmployeeService();

         
            var employeeViewModels = await employeeService.GetAllAsync();

            foreach (var employee in employeeViewModels)
            {
                consoleTable.AddRow(employee.Id, employee.FullName,employee.Age,employee.Address,
                    employee.PhoneNumber, employee.Salary, employee.Gender);
            }
            lebel:
            Console.Clear();
            consoleTable.Write();


            Console.WriteLine("0. Back  <=========>  1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;

        }
    }
}
