using System.Collections.Generic;

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
            new Employee { EmployeeId = 18, FirstName = "Seth", LastName = "Milchick", Salary = 350000, ProjectId = 7, DepartmentId = 7 }, 
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
            
        }
    }
}
