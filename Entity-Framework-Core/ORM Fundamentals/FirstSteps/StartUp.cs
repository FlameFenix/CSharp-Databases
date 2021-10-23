using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSteps
{
    class StartUp
    {
        static void Main(string[] args)
        {
            /* Using DB "SoftUni" */

            SoftUniContext db = new SoftUniContext();

            /* Employee with Max Salary */

            Employee employee = db.Employees.OrderByDescending(x => x.Salary).FirstOrDefault();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} Salary -> {employee.Salary}");

            /* Employee with ID = 5 */
            employee = db.Employees.Where(x => x.EmployeeId == 5).FirstOrDefault();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} ID -> {employee.EmployeeId}");

            /* Employee with ID = 7 address and town */

            employee = db.Employees.Where(x => x.EmployeeId == 7).FirstOrDefault();

            var address = db.Addresses.Where(x => x.AddressId == employee.AddressId).FirstOrDefault();

            var town = db.Towns.Where(x => x.TownId == address.TownId).FirstOrDefault();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} FROM Town: {town.Name}, Address: {address.AddressText}");

            /* Select Employees Hired after 2000 year */

            List<VEmployeesHiredAfter2000> employeesAfter2000 = db.VEmployeesHiredAfter2000s.ToList();

            foreach (var employeeAfter in employeesAfter2000)
            {
                Console.WriteLine($"{employeeAfter.FirstName} {employeeAfter.LastName}");
            }

            /* Select town by name */

            town = db.Towns.Where(x => x.Name == "Sofia").FirstOrDefault();

            Console.WriteLine($"Name: {town.Name} Id: {town.TownId}");

            /* Add new employee to database */

            db.Employees.Add(
                new Employee() { FirstName = "Yordan", LastName = "Dimitrov", JobTitle = "Junior .NET Developer", DepartmentId = 6, HireDate = DateTime.Now, Salary = 15000.00M, AddressId = 291 });

            db.SaveChanges();

            /* Update existing employee */

            employee = db.Employees.FirstOrDefault(x => x.FirstName == "Yordan" && x.LastName == "Dimitrov");

            employee.MiddleName = "Dianov";

            db.SaveChanges();


            /* Delete employee from database */

            employee = db.Employees.FirstOrDefault(x => x.FirstName == "Yordan" && x.LastName == "Dimitrov");

            db.Employees.Remove(employee);

            db.SaveChanges();
        }
    }
}
