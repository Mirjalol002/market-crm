using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Employees
{
    public class DeletePage
    {
        public static async Task DeletePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "F.I", "Xodim yoshi", "Xodim addressi", "Telefon raqami", "Xodim oyligi", "jinsi");

            IEmployeeRepository employeeRepository = new EmployeeRepository();
            var employees = await employeeRepository.GetAllAsync();
            foreach (var employee in employees)
            {
                string gender;
                if (employee.Gender == Enum.Gender.Erkak)
                {
                    gender = "Mele";
                }
                else
                {
                    gender = "Female";
                }
                consoleTable.AddRow(employee.Id, employee.FullName, employee.Age, employee.Address, employee.PhoneNumber, employee.Salary, gender);
            }

            consoleTable.Write();

            Console.Write("O'chiriladigan Idni kiriting: ");
            int Id = int.Parse(Console.ReadLine()!);

            bool take = (employees.FirstOrDefault(x => x.Id == Id) != null);

            if (take)
            {
                await employeeRepository.DeleteAsync(Id);
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
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;
        }
    }
}
