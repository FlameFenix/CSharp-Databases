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
            // Console.WriteLine(GetEmployeesInPeriod(context));
            // Console.WriteLine(GetAddressesByTown(context));
            // Console.WriteLine(GetEmployee147(context));
            // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            // Console.WriteLine(GetLatestProjects(context));
            // Console.WriteLine(IncreaseSalaries(context));
            // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
            // Console.WriteLine(DeleteProjectById(context));
            // Console.WriteLine(RemoveTown(context));
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
            var employeesProjects = context
                .EmployeesProjects
                .Where(x => x.Project.StartDate >= new DateTime(2001, 1, 1) &&
                            x.Project.StartDate <= new DateTime(2003, 12, 31))
                .Select(x => new
                {
                    x.Employee,
                    x.Employee.Manager,
                    Projects = x.Employee.EmployeesProjects.Select(x => new
                    {
                        x.Project
                    })
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            List<string> names = new List<string>();

            foreach (var employee in employeesProjects)
            {
                if (names.Contains($"{employee.Employee.FirstName} {employee.Employee.LastName}"))
                {
                    continue;
                }

                sb.AppendLine($"{employee.Employee.FirstName} {employee.Employee.LastName} - Manager: {employee.Employee.Manager.FirstName} {employee.Employee.Manager.LastName}");
                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.Project.Name} - {project.Project.StartDate} - {(project.Project.EndDate == null ? "not finished" : $"{project.Project.EndDate}")}");
                }
                names.Add($"{employee.Employee.FirstName} {employee.Employee.LastName}");
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

        /* 10. Departments with More Than 5 Employees */

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(e => e.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    d.Manager,
                    d.Employees
                })
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var department in  departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName}");
                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        /* 11. Find Latest 10 Projects */

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context
                .Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var project in latestProjects.OrderBy(x => x.Name))
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString();
        }

        /* 12. Increase Salaries */

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" ||
                            x.Department.Name == "Tool Design" ||
                            x.Department.Name == "Marketing" ||
                            x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString();
        }

        /* 13. Find Employees by First Name Starting with "Sa" */

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString();
        }

        /* 14. Delete Project by Id */

        public static string DeleteProjectById(SoftUniContext context)
        {
            int desiredId = 2;

            var project = context.Projects.Where(x => x.ProjectId == desiredId).FirstOrDefault();

            var mapping = context.EmployeesProjects.Where(x => x.ProjectId == desiredId).ToArray();

            foreach (var proj in mapping)
            {
                context.EmployeesProjects.Remove(proj);
                
            }
            context.SaveChanges();

            context.Projects.Remove(project);
            
            context.SaveChanges();

            var projects = context.Projects.Take(10).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var currnetProject in projects)
            {
                sb.AppendLine(currnetProject.Name);
            }

            return sb.ToString();
        }

        /* 15. Remove Town */

        public static string RemoveTown(SoftUniContext context)
        {
            string desiredTown = "Seattle";

            var employees = context
                .Employees
                .Where(x => x.Address.Town.Name == desiredTown)
                .ToArray();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses.Where(x => x.Town.Name == desiredTown).ToArray();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            context.SaveChanges();

            var town = context.Towns.FirstOrDefault(x => x.Name == desiredTown);

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Length} addresses in {desiredTown} were deleted";
        }
    }
}
