using ConsoleTables;
using Market.Interface.Repositories;
using Market.Repositories;

namespace Market.Pages.Employees
{
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "F.I", "Xodim yoshi", "Xodim addressi", "Telefon raqami", "Xodim oyligi", "jinsi");
            // Service da ishlamagani un repositorydan foydalanganman
            //IClientService clientService = new ClientService();

            IEmployeeRepository employeeRepository = new EmployeeRepository();
            var employees = await employeeRepository.GetAllAsync();


            foreach (var employee in employees)
            {
                consoleTable.AddRow(employee.Id,
                        employee.FullName, employee.Age, employee.Address, employee.PhoneNumber, employee.Salary,employee.Gender);
            }
            consoleTable.Write();



            // Tableni ko'rib olish kerak
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Clear();

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "F.I", "Xodim yoshi", "Xodim addressi", "Telefon raqami", "Xodim oyligi", "jinsi");



            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    consoleTable1.AddRow(employee.Id,
                        employee.FullName, employee.Age, employee.Address, employee.PhoneNumber, employee.Salary, employee.Gender);
                }
            }

        lebel:
            Console.Clear();
            consoleTable1.Write();



            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfuly("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); Thread.Sleep(1000); goto lebel;


        }
    }
}
