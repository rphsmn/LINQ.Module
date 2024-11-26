﻿using LINQ.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. List All Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee(employees);
                        break;
                    case 2:
                        ListEmployees(employees);
                        break;
                    case 3:
                        FindEmployee(employees);
                        break;
                    case 4:
                        UpdateEmployee(employees);
                        break;
                    case 5:
                        DeleteEmployee(employees);
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }

        static void AddEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            if (employees.Any(e => e.Id == id))
            {
                Console.WriteLine("Employee ID already exists.");
                return;
            }

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
            Console.WriteLine("Employee added successfully.");
        }

        static void ListEmployees(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("Employee List:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        static void FindEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to find: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                Console.WriteLine("Employee Details:");
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void UpdateEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.Write("Enter New Name (leave blank to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) employee.Name = name;

            Console.Write("Enter New Position (leave blank to keep current): ");
            string position = Console.ReadLine();
            if (!string.IsNullOrEmpty(position)) employee.Position = position;

            Console.Write("Enter New Salary (leave blank to keep current): ");
            string salaryInput = Console.ReadLine();
            if (decimal.TryParse(salaryInput, out decimal salary)) employee.Salary = salary;

            Console.WriteLine("Employee updated successfully.");
        }

        static void DeleteEmployee(List<Employee> employees)
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

    }

}