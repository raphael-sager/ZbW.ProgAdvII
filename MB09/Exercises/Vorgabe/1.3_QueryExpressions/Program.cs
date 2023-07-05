using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace _1._3_QueryExpressions {
    static class Program {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T item in source)
                action(item);
        }

        static void Main(string[] args) {
            var departments = new List<Department> {
                new Department {Name = "Engineering", Id = 1},
                new Department {Name = "Marketing", Id = 2}
            };

            var employees = new List<Employee> {
                new Employee {Name = "Michael", Address = "SW Liverpool Lane", State = "WA", Salary = 5675, DepId = 1},
                new Employee {Name = "Jennifer", Address = "1245 NW Baypony Dr", State = "OR", Salary = 6555, DepId = 1},
                new Employee {Name = "Sean", Address = "55217 SW Estate Dr", State = "WA", Salary = 8888, DepId = 1},
                new Employee {Name = "Peter", Address = "Ma Lane", State = "WA", Salary = 9999, DepId = 2},
                new Employee {Name = "Henry", Address = "Ma Dr", State = "OR", Salary = 3209, DepId = 2}
            };

            var projects = new List<Project> {
                new Project {Name = "Saturn", ProjectManager = employees[0]},
                new Project {Name = "Uranus", ProjectManager = employees[2]},
                new Project {Name = "Pluto"}

            };
            projects[0].AddEmployee(employees[0]);
            projects[0].AddEmployee(employees[2]);
            projects[0].AddEmployee(employees[3]);
            projects[1].AddEmployee(employees[1]);
            projects[1].AddEmployee(employees[2]);

            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Mitarbeiter die im State WA wohnen. 

            // query syntax
            var queryWashington = from e in employees
                                  where e.State == "WA" select e;
            // extension Method
            var queryWashingtonTwo = employees.Where(e => e.State == "WA");

            Console.WriteLine("---------- \r\nListe der Mitarbeiter die im State WA wohnen");
            queryWashington.ForEach(e => Console.WriteLine(e.Name));






            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Namen und Adressen der Mitarbeiter im State WA. Sortiert nach Name absteigend. 

            // query syntax
            var queryWashingtonSorted = from e in employees
                                        where e.State == "WA" 
                                        orderby e.Name descending 
                                        select e ;

            // extension Method
            var queryWashingtonSortedTwo = employees
                .Where(e => e.State == "WA")
                .OrderByDescending(e => e.Name);


            Console.WriteLine("---------- \r\nListe der Namen und Adressen der Mitarbeiter im State WA");
            queryWashingtonSorted.ForEach(e => Console.WriteLine("Name: {0}, Phone: {1}", e.Name, e.Address));

            




            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Department-Namen und der Anzahl Mitarbeiter der Departments.  

            // query syntax
            var queryDepartments = from d in departments
                join e in employees on d.Id equals e.DepId
                group d by d.Name into g
                select new
                {
                    Department = g.Key,
                    EmployeeCount = g.Count()
                };

            // extension method
            var queryDepartmentsExtension = departments
                .Join(employees, department => department.Id, employee => employee.DepId, (department, employee) => new {
                    Department = department,
                    Employee = employee
                })
                .GroupBy(g => g.Department.Name)
                .Select(g => new { Department = g.Key, EmployeeCount = g.Count() });


            Console.WriteLine("---------- \r\nListe der Department-Namen und der Anzahl Mitarbeiter der Departments");
            queryDepartmentsExtension.ForEach(d => Console.WriteLine("Department: {0}, EmployeeCount: {1}", d.Department, d.EmployeeCount));









            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Departments mit ihren Mitarbeitern. 
            // Ausgabe: Name des Departments, Name des Mitarbeiters
            // Sortiert nach Departmentname 

            //query Syntax
            var empQueryTwo = from d in departments
                           join e in employees on d.Id equals e.DepId
                           orderby d.Name
                           select new
                           {
                               EmployeeName = e.Name,
                               DepartmentName = d.Name
                           };


            // extension Method
            var empQuery = employees
                .Join(departments, eKey => eKey.DepId, dKey => dKey.Id, (e, d) => new
                {
                    EmployeeName = e.Name,
                    DepartmentName = d.Name
                })
                .OrderBy(d => d.DepartmentName);


            Console.WriteLine("---------- \r\nListe der Departments mit ihren Mitarbeitern");
            empQuery.ForEach(c => Console.WriteLine("Name: {0}, Department: {1}", c.EmployeeName, c.DepartmentName));






            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Departments mit dem Salär des bestverdienenden Mitarbeiters. 
            // Ausgabe: Name des Departments, höchster Salär
            // Sortiert nach höchstem Salär, absteigend 
            // Tipp: Verwenden Sie die „let“ Klausel für das Speichern von Zwischenresultaten.


            // query Syntax
            var maxDeptSalaryTwo = from d in departments
                                join e in employees on d.Id equals e.DepId
                                group e by d.Name into g
                                let maxSalary = g.Max(em => em.Salary)
                                orderby maxSalary descending
                                select new
                                {
                                    DepartmentName = g.Key,
                                    MaxSalary = maxSalary
                                };

            // extension Method
            var maxDeptSalary = departments
                .GroupJoin(employees, dKey => dKey.Id, eKey => eKey.DepId, (d, e) => new
                {
                    DepartmentName = d.Name,
                    MaxSalary = e.Max(es => es.Salary)
                })
                .OrderByDescending(ms => ms.MaxSalary);


            Console.WriteLine("---------- \r\nListe der Departments mit dem Salär des bestverdienenden Mitarbeiters");
            maxDeptSalary.ForEach(c => Console.WriteLine("Department: {0}, Höchster Salär: {1}", c.DepartmentName, c.MaxSalary));






            // ------------------------------------------------------------------------------------------- //
            // TODO: Liste der Projekte mir den zugeordneten Mitarbeitern  
            // Ausgabe: Name des Projektes, Name des Mitarbeiters
            // Sortiert nach Name des Projektes, Name des Mitarbeiters 

            //query syntax
            //var projList = from p in projects
            //    from e in employees
            //    orderby p.Name, e.Name
            //    select new 
            //    {
            //        Project = p.Name,
            //        Employee = e.Name
            //    };

            // extension Method
            var projList = projects
                .SelectMany(p => p.Employees
                    .Select(e => new { Project = p.Name, Employee = e.Name }))
                .OrderBy(p => p.Project)
                .ThenBy(p => p.Employee);


            Console.WriteLine("---------- \r\nListe der Projekte und der beteiligten Mitarbeiter");
            projList.ForEach(p => Console.WriteLine("Projekt: {0} Mitarbeiter: {1}", p.Project, p.Employee));


            // ------------------------------------------------------------------------------------------- //
            // TODO: Projektstatistik: Liste der Projekte 
            // 
            // Ausgabe: Projektname, Name des Projektmanagers (falls nicht vorhanden "tba") , Anzahl Mitarbeiter im Projekt, 
            // Durchschnittliches Salaer der Mitarbeiter im Projekt
            // Sortiert nach Projektname, Anzahl Mitarbeiter

            //var projStatistics = 

            Console.WriteLine("---------- \r\nListe der Projekte und ihrer Statistik");
            //projStatistics.ForEach(p => Console.WriteLine("Project {0} Mgr {1} Number Employees {2} Average Salary {3}", p.Project, p.Mgr, p.EmpCount, p.AvgSalary));

            Console.ReadKey();
        }
    }
}