using System.Collections.Generic;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

//THIS PROGRAM CONTAINS SPOILERS FOR THE SHOW "SEVERANCE" - YOU HAVE BEEN WARNED
namespace Employee_MGMT_System
{
    internal class Program
    {
        static List<Employee> employees = new List<Employee> { 
            new Employee { EmployeeId = 1, FirstName = "Helly", LastName = "Eagan", Salary = 200000,  ProjectId = 1, DepartmentId = 1 }, 
            new Employee { EmployeeId = 2, FirstName = "Dylan", LastName = "Vance", Salary = 85000, ProjectId = 8, DepartmentId = 1 }, 
            new Employee { EmployeeId = 3, FirstName = "Irving", LastName = "Bailiff", Salary = 90000, ProjectId = 1, DepartmentId = 1 }, 
            new Employee { EmployeeId = 4, FirstName = "Mark", LastName = "Scout", Salary = 95000, ProjectId = 8, DepartmentId = 1 }, 
            new Employee { EmployeeId = 5, FirstName = "Clara", LastName = "Horne", Salary = 180000, ProjectId = 1, DepartmentId = 1 }, 
            new Employee { EmployeeId = 6, FirstName = "Selene", LastName = "Kade", Salary = 175000, ProjectId = 2, DepartmentId = 2 }, 
            new Employee { EmployeeId = 7, FirstName = "Felix", LastName = "Graves", Salary = 170000, ProjectId = 2, DepartmentId = 2 }, 
            new Employee { EmployeeId = 8, FirstName = "Lydia", LastName = "Pryce", Salary = 165000, ProjectId = 2, DepartmentId = 2 }, 
            new Employee { EmployeeId = 9, FirstName = "Mira", LastName = "Sloan", Salary = 165000, ProjectId = 3, DepartmentId = 3 }, 
            new Employee { EmployeeId = 10, FirstName = "Theo", LastName = "Cline", Salary = 170000, ProjectId = 3, DepartmentId = 3 }, 
            new Employee { EmployeeId = 11, FirstName = "Nora", LastName = "Beckett", Salary = 180000, ProjectId = 4, DepartmentId = 4 }, 
            new Employee { EmployeeId = 12, FirstName = "Silas", LastName = "Ward", Salary = 175000, ProjectId = 4, DepartmentId = 4 }, 
            new Employee { EmployeeId = 13, FirstName = "Elise", LastName = "Farrow", Salary = 185000, ProjectId = 4, DepartmentId = 4 }, 
            new Employee { EmployeeId = 14, FirstName = "Calvin", LastName = "Holt", Salary = 190000, ProjectId = 5, DepartmentId = 5 }, 
            new Employee { EmployeeId = 15, FirstName = "Tessa", LastName = "Lorne", Salary = 195000, ProjectId = 5, DepartmentId = 5 }, 
            new Employee { EmployeeId = 16, FirstName = "Amos", LastName = "Drake", Salary = 200000, ProjectId = 6, DepartmentId = 6 }, 
            new Employee { EmployeeId = 17, FirstName = "Vera", LastName = "Quinn", Salary = 205000, ProjectId = 6, DepartmentId = 6 }, 
            new Employee { EmployeeId = 18, FirstName = "Seth", LastName = "Milchick", Salary = 350000, ProjectId = 4, DepartmentId = 7 }, 
            new Employee { EmployeeId = 19, FirstName = "Harmony", LastName = "Cobel", Salary = 450000, ProjectId = 7, DepartmentId = 7 }, 
            new Employee { EmployeeId = 20, FirstName = "Jame", LastName = "Eagan", Salary = 500000, ProjectId = 9, DepartmentId = 7 }
        };

        static List<Project> projects = new List<Project> {
           new Project {ProjectId = 1, ProjectName = "Tumwater", DepartmentId = 1},
           new Project {ProjectId = 2, ProjectName = "Optic Harmonization", DepartmentId = 2},
           new Project {ProjectId = 3, ProjectName = "Asset Purge", DepartmentId = 3},
           new Project {ProjectId = 4, ProjectName = "Rhythm Directive", DepartmentId = 4},
           new Project {ProjectId = 5, ProjectName = "Equilibrium Audit", DepartmentId = 5},
           new Project {ProjectId = 6, ProjectName = "Instinct Calibration", DepartmentId = 6},
           new Project {ProjectId = 7, ProjectName = "Hierarchy Sync", DepartmentId = 7},
           new Project {ProjectId = 8, ProjectName = "Sienna", DepartmentId = 1},
           new Project {ProjectId = 9, ProjectName = "Directive Codex", DepartmentId = 7}
        };

        static List<Department> departments = new List<Department> {
            new Department {DepartmentId = 1, DepartmentName = "Macrodata Refinement" },
            new Department {DepartmentId = 2, DepartmentName = "Optics and Design" },
            new Department {DepartmentId = 3, DepartmentName = "Disposal and Reclaimation" },
            new Department {DepartmentId = 4, DepartmentName = "Choreography and Merriment" },
            new Department {DepartmentId = 5, DepartmentName = "Wellness" },
            new Department {DepartmentId = 6, DepartmentName = "Mammalian Nurturable" },
            new Department {DepartmentId = 7, DepartmentName = "Administration" }
        };

        static void Main(string[] args) {
            GroupByAndAggregate();
            PerformJoins();
            FilterandSelect();
            DepartmentStatistics();
            ComplexFiltering();
        }

        public static void GroupByAndAggregate() {
            Console.WriteLine("\nMethod 1: GroupBy and Aggregate");
            // Group employees by their departments.
            // Calculate and display the average salary for each department.
  
            var groups = employees
                .GroupBy(e => e.DepartmentId)
                .Join(departments,
                      group => group.Key,
                      dept => dept.DepartmentId,
                      (group, dept) => new {
                          DepartmentName = dept.DepartmentName,
                          Employees = group.ToList(),
                          EmployeeCount = group.Count(),
                          TotalSalary = group.Sum(e => e.Salary),
                          AverageSalary = group.Average(e => e.Salary)
                      });
            
            foreach (var group in groups) {
                Console.WriteLine($"Department: {group.DepartmentName}");
                Console.WriteLine($"Employee Count: {group.EmployeeCount}");
                Console.WriteLine($"Total Salary: ${group.TotalSalary:N0}");
                Console.WriteLine($"Average Salary: ${group.AverageSalary:N2}");
                Console.WriteLine("Employees:");
                foreach (var employee in group.Employees) {
                    Console.WriteLine($"  - {employee.FirstName} {employee.LastName} (Salary: ${employee.Salary:N0})");
                }
                Console.WriteLine();
            }

            // Identify the department with the highest total salary.
            var highestSalaryDepartment = groups
                .OrderByDescending(g => g.TotalSalary)
                .FirstOrDefault();

            if (highestSalaryDepartment != null) {
                Console.WriteLine("\n\nDepartment with Highest Total Salary");
                Console.WriteLine($"Department: {highestSalaryDepartment.DepartmentName}");
                Console.WriteLine($"Total Salary: ${highestSalaryDepartment.TotalSalary:N0}\n\n");
            }


            // Group employees by the projects they are involved in.
            var groupsByProject = employees
            .GroupBy(e => e.ProjectId)
            .Join(projects,
                  group => group.Key,
                  proj => proj.ProjectId,
                  (group, proj) => new {
                      ProjectName = proj.ProjectName,
                      DepartmentId = proj.DepartmentId, 
                      Employees = group.ToList(),
                      EmployeeCount = group.Count(),
                  })
            .Join(departments,
                  projGroup => projGroup.DepartmentId,
                  dept => dept.DepartmentId,
                  (projGroup, dept) => new {
                      projGroup.ProjectName,
                      DepartmentName = dept.DepartmentName,
                      projGroup.Employees,
                      projGroup.EmployeeCount,
                  });
            foreach (var group in groupsByProject) {
                Console.WriteLine($"Project: {group.ProjectName} (Department: {group.DepartmentName})");
                Console.WriteLine($"Employee Count: {group.EmployeeCount}");
                Console.WriteLine("Employees:");
                foreach (var employee in group.Employees) {
                    Console.WriteLine($"  - {employee.FirstName} {employee.LastName}");
                }
                Console.WriteLine();
            }

            // Calculate and display total number of projects per department.
            var projectsPerDepartment = projects
                .GroupBy(p => p.DepartmentId)
                .Join(departments,
                      group => group.Key,
                      dept => dept.DepartmentId,
                      (group, dept) => new {
                          DepartmentName = dept.DepartmentName,
                          ProjectCount = group.Count(),
                          Projects = group.Select(p => p.ProjectName).ToList()
                      });
            foreach (var dept in projectsPerDepartment.OrderBy(d => d.DepartmentName)) {
                Console.WriteLine($"Department: {dept.DepartmentName}");
                Console.WriteLine($"Number of Projects: {dept.ProjectCount}");
                Console.WriteLine("Projects:");
                foreach (var projectName in dept.Projects) {
                    Console.WriteLine($"  - {projectName}");
                }
                Console.WriteLine();
            }
        }

        public static void PerformJoins() {
            Console.WriteLine("\nMethod 2: Perform Joins");
            //Perform inner joins between the Employee, Department, and Project lists based on the relevant IDs.
            var joinedData = employees
               .Join(projects,
                   emp => emp.ProjectId,
                   proj => proj.ProjectId,
                   (emp, proj) => new { Employee = emp, Project = proj })
               .Join(departments,
                   empProj => empProj.Project.DepartmentId,
                   dept => dept.DepartmentId,
                   (empProj, dept) => new {
                       EmployeeName = $"{empProj.Employee.FirstName} {empProj.Employee.LastName}",
                       ProjectName = empProj.Project.ProjectName,
                       DepartmentName = dept.DepartmentName
                   });
           
            foreach (var item in joinedData) {
                Console.WriteLine($"Employee: {item.EmployeeName}, Project: {item.ProjectName}, Department: {item.DepartmentName}");
            }
        }

        public static void FilterandSelect() {
            Console.WriteLine("\nMethod 3: Filter and Select");
            // Filter employees based on specific conditions (e.g., salary above a set threshold).
            // Select and display only the FirstName and LastName of employees and the ProjectName of the projects they are involved in.

            const int salaryThreshold = 150000;

            var filteredEmployees = employees
                .Where(emp => emp.Salary > salaryThreshold)
                .Join(projects,
                    emp => emp.ProjectId,
                    proj => proj.ProjectId,
                    (emp, proj) => new {
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        ProjectName = proj.ProjectName
                    })
                .OrderBy(result => result.LastName);

            
            Console.WriteLine($"\nEmployees with Salary > ${salaryThreshold:N0}");
            foreach (var item in filteredEmployees) {
                Console.WriteLine($"Employee: {item.FirstName} {item.LastName}, Project: {item.ProjectName}");
            }
        }
        public static void DepartmentStatistics() {
            // Calculate and display the total salary expense for each department.
            // Determine and display the highest and lowest salaries within each department.
            // Calculate the average number of projects per employee within each department.

            Console.WriteLine("\nMethod 4: Department Statistics");

            var departmentStats = employees
                .GroupBy(e => e.DepartmentId)
                .Join(departments,
                    group => group.Key,
                    dept => dept.DepartmentId,
                    (group, dept) => new {
                        DepartmentName = dept.DepartmentName,
                        TotalSalary = group.Sum(e => e.Salary),
                        HighestSalary = group.Max(e => e.Salary),
                        HighestSalaryEmployee = group.First(e => e.Salary == group.Max(e => e.Salary)),
                        LowestSalary = group.Min(e => e.Salary),
                        LowestSalaryEmployee = group.First(e => e.Salary == group.Min(e => e.Salary)),
                        EmployeeCount = group.Count(),
                        ProjectCount = group.Select(e => e.ProjectId).Distinct().Count()
                    })
                .OrderBy(d => d.DepartmentName);

            foreach (var dept in departmentStats) {
                Console.WriteLine($"Department: {dept.DepartmentName}");
                Console.WriteLine($"Total Salary Expense: ${dept.TotalSalary:N0}");
                Console.WriteLine($"Highest Salary: ${dept.HighestSalary:N0} (Employee: {dept.HighestSalaryEmployee.FirstName} {dept.HighestSalaryEmployee.LastName})");
                Console.WriteLine($"Lowest Salary: ${dept.LowestSalary:N0} (Employee: {dept.LowestSalaryEmployee.FirstName} {dept.LowestSalaryEmployee.LastName})");
                Console.WriteLine($"Average Projects per Employee: {(double)dept.ProjectCount / dept.EmployeeCount:N2}");
                Console.WriteLine();
            }
        }
        public static void ComplexFiltering() {
            Console.WriteLine("\nMethod 5: Complex Filtering");
            // Select employees with a salary above the department average.
            var departmentAverages = employees
                .GroupBy(e => e.DepartmentId)
                .Select(g => new {
                    DepartmentId = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                });

            var employeesAboveAverage = employees
                .Join(departmentAverages,
                    emp => emp.DepartmentId,
                    avg => avg.DepartmentId,
                    (emp, avg) => new { Employee = emp, AverageSalary = avg.AverageSalary })
                .Where(e => e.Employee.Salary > e.AverageSalary)
                .Join(departments,
                    e => e.Employee.DepartmentId,
                    dept => dept.DepartmentId,
                    (e, dept) => new {
                        FirstName = e.Employee.FirstName,
                        LastName = e.Employee.LastName,
                        Salary = e.Employee.Salary,
                        DepartmentName = dept.DepartmentName,
                        AverageSalary = e.AverageSalary
                    })
                .OrderBy(e => e.DepartmentName)
                .ThenBy(e => e.LastName);

            foreach (var emp in employeesAboveAverage) {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Salary: ${emp.Salary:N0}, Department: {emp.DepartmentName}, Avg Salary: ${emp.AverageSalary:N2}");
            }
  
        // Identify employees assigned to projects in a department other than their own.
            var crossDepartmentEmployees = employees
                .Join(projects,
                    emp => emp.ProjectId,
                    proj => proj.ProjectId,
                    (emp, proj) => new { Employee = emp, Project = proj })
                .Where(ep => ep.Employee.DepartmentId != ep.Project.DepartmentId)
                .Join(departments,
                    ep => ep.Employee.DepartmentId,
                    dept => dept.DepartmentId,
                    (ep, empDept) => new {
                        FirstName = ep.Employee.FirstName,
                        LastName = ep.Employee.LastName,
                        ProjectName = ep.Project.ProjectName,
                        EmployeeDepartment = empDept.DepartmentName,
                        ProjectDepartmentId = ep.Project.DepartmentId
                    })
                .Join(departments,
                    ep => ep.ProjectDepartmentId,
                    dept => dept.DepartmentId,
                    (ep, projDept) => new {
                        ep.FirstName,
                        ep.LastName,
                        ep.ProjectName,
                        ep.EmployeeDepartment,
                        ProjectDepartment = projDept.DepartmentName
                    })
                .OrderBy(e => e.EmployeeDepartment)
                .ThenBy(e => e.LastName);
            Console.WriteLine("\n\n");
            foreach (var emp in crossDepartmentEmployees)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Project: {emp.ProjectName}, Employee Dept: {emp.EmployeeDepartment}, Project Dept: {emp.ProjectDepartment}");
            }
        }
    }
}
     