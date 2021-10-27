using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            // Console.WriteLine(GetEmployeesFullInformation(context));
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            // Console.WriteLine(AddNewAddressToEmployee(context));
            // Console.WriteLine(GetEmployeesInPeriod(context)); not finished !
            // Console.WriteLine(GetAddressesByTown(context));
            // Console.WriteLine(GetEmployee147(context));

        }

        /* 3. Employees Full Information */

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.OrderBy(e => e.EmployeeId).ToList();

            StringBuilder str = new StringBuilder();

            foreach (var employee in employees)
            {
                str.AppendLine($"{employee.FirstName} {employee.LastName} {(string.IsNullOrEmpty(employee.MiddleName) ? "" : $"{employee.MiddleName} ")}{employee.JobTitle} {employee.Salary:F2}");
            }

            return str.ToString();
        }

        /* 4. Employees with Salary Over 50 000 */

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Salary > 50000)
                                             .Select(e => new 
                                             {
                                                 e.FirstName,
                                                 e.Salary
                                             } )
                                             .OrderBy(e => e.FirstName)
                                             .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString();
        }

        /* 5. Employees from Research and Development */

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development")
                                             .Select(e => 
                                             new {
                                                    FirstName = e.FirstName,
                                                    LastName = e.LastName,
                                                    Department = e.Department.Name,
                                                    Salary = e.Salary})
                                             .OrderBy(e => e.Salary)
                                             .ThenByDescending(e => e.FirstName)
                                             .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department} - ${employee.Salary:F2}");
            }

            return sb.ToString();
        }

        /* 6. Adding a New Address and Updating Employee */

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address() 
            { 
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            var nakovEmployee = context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();

            nakovEmployee.Address = address;

            context.SaveChanges();

            var employees = context.Employees.OrderByDescending(e => e.Address.AddressId)
                                             .Select(e => new
                                         {
                                             e.Address.AddressText
                                         })
                                             .Take(10)
                                             .ToList();

            StringBuilder sb = new StringBuilder(10);

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString();
        }

        /* 7. Employees and Projects */

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employessFromDb = context.Employees.ToArray();

            List<Employee> employees = new List<Employee>();

            var projects = context.EmployeesProjects.Where(x => x.Project.StartDate >= new DateTime(2001, 1, 1) && x.Project.StartDate <= new DateTime(2003, 12, 31)).Take(10).ToArray();

            var allProjects = context.Projects.ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in projects)
            {
                Employee currentEmployee = employessFromDb.FirstOrDefault(x => x.EmployeeId == e.EmployeeId);
                if (!employees.Contains((currentEmployee)))
                {
                    employees.Add(currentEmployee);
                }
            }

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");

                foreach (var project in item.EmployeesProjects)
                {
                    sb.AppendLine($"Project: {project.Project.Name} - {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {project.Project.EndDate}");
                }
            }

            return sb.ToString();
        }

        /* 8. Address by town */

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressesByCount = context
                .Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(e => new
                {
                    e.AddressText,
                    e.Town.Name,
                    e.Employees.Count
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var town in addressesByCount)
            {
               sb.AppendLine($"{town.AddressText}, {town.Name} - {town.Count} employees");
            }

            return sb.ToString();
        }

        /* 9. Employee 147 */

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context
                .Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects
                        .Where(x => x.EmployeeId == 147)
                        .Select(x => new
                            {
                                projectName = x.Project.Name
                            })
                        .OrderBy(x => x.projectName)
                        .ToList()
                }).FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine(project.projectName);
            }

            return sb.ToString();
        }
    }
}
