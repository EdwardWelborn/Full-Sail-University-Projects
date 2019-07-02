
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace WelbornEdward_CE06
{
    class Program
    {
        const int SWP_NOSIZE = 0x0001;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr MyConsole = GetConsoleWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        
        static void Main(string[] args)
        {
            bool bProgramRunning = true;
            Employee currentEmployee = null;
            Program instance = new Program();
            List<Employee> Employees = new List<Employee>();
            Console.SetWindowSize(100, 20);
            int xpos = 650;
            int ypos = 275;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            while (bProgramRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "      CE06 Assignment\n" +
                        "---------------------------\n" +
                        "[1]..  Add Employee (ae)\n" +
                        "[2]..  remove employee (re)\n" +
                        "[3]..  Display Payroll (dp)\n" +
                        "[4]..  Exit Program (e)\n" +
                        "---------------------------\n");
                Console.WriteLine("Please Select a menu number");
                Console.WriteLine("You may also select the phrase");
                Console.WriteLine("Or abbreviate phrase in () ");
                Console.Write("\nSelect an Option: ");
                string input = Console.ReadLine().ToLower();

                switch(input)
                {
                    case "1":
                    case "add employee":
                    case "ae":
                    {
                        currentEmployee = instance.CreateEmployee();
                        Employees.Add(currentEmployee);
                    }
                    break;
                    case "2":
                    case "remove employee":
                    case "re":
                    {
                            instance.RemoveEmployee(Employees);
                        }
                        break;
                    case "3":
                    case "display payroll":
                    case "dp":
                        {
                            instance.DisplayPayroll(Employees);
                        }
                        break;
                    case "4":
                    case "e":
                    case "exit":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\r\nPlease choose a valid number between 1 and 4");
                            Console.WriteLine("You may also select the phrase");
                            Console.WriteLine("Or abbreviate phrase in () ");
                        }
                        break;
                }
                if (bProgramRunning)
                {
                   Utility.PressAnyKeyToContinue("Press Any Key To Continue");
                }
            }
            Utility.PressAnyKeyToContinue("Press Any Key to Exit");
        }
        public Employee CreateEmployee()
        {
            string sEmployeeName = string.Empty;
            string sEmployeeAddress = string.Empty;
            Employee newEmployee = null;
            List<Employee> Employees = new List<Employee>();

            Console.Write("\nPlease Enter Employee Name: ");
            string strName = Console.ReadLine();
            sEmployeeName = Validation.ValidateText(strName);
            Console.Write("\nPlease Enter Employee Address: ");
            string strAddress = Console.ReadLine();
            sEmployeeAddress = Validation.ValidateText(strAddress);
            Console.Write("\nPlease Enter Employee age: ");
            string strAge=  Console.ReadLine();
            int age = Validation.ValidateIntRange(18, 120, strAge);

            bool selectingUserType = true;

            while (selectingUserType)
            {
                Console.Write("\r\n" +
                    "-----------------\n" +
                    "[1].  Fulltime\n" +
                    "[2].  PartTime\n" +
                    "[3],  Contractor\n" +
                    "[4].  Salaried\n" +
                    "[5].  Manager\n" +
                    "----------------\n" +
                    "What Type of User is being created: ");
                string type = Console.ReadLine().ToLower();
                switch (type)
                {
                    case "1":
                    case "fulltime":
                        {
                            Console.Write("\nPlease Enter pay per hour: ");
                            string strInput = Console.ReadLine();
                            decimal payPerHour = Validation.ValidateDecimal(strInput);
                            newEmployee = new Fulltime(sEmployeeName, sEmployeeAddress, payPerHour, 40);
                            Employees.Add(newEmployee);
                            selectingUserType = false;
                        } 
                        break;
                    case "2":
                    case "parttime":
                    {
                        Console.Write("\nPlease Enter pay per hour: ");
                        string strInput = Console.ReadLine();
                        decimal payPerHour = Validation.ValidateDecimal(strInput);
                        Console.Write("\nPlease Enter Hours per Week: ");
                        string sHoursPerWeek = Console.ReadLine();
                        decimal hoursPerWeek = Validation.ValidateDecimalRange(1, 168, sHoursPerWeek);
                        newEmployee = new PartTime(sEmployeeName, sEmployeeAddress, payPerHour, hoursPerWeek);
                        Employees.Add(newEmployee);
                        selectingUserType = false;
                }
                        break;
                    case "3":
                    case "contractor":
                        {
                            Console.Write("\nPlease Enter pay per hour: ");
                            string sPayPerHour = Console.ReadLine();
                            decimal payPerHour = Validation.ValidateDecimal(sPayPerHour);
                            Console.Write("\nPlease Enter Hours per Week: ");
                            string sHoursPerWeek = Console.ReadLine();
                            decimal hoursPerWeek = Validation.ValidateDecimalRange(1, 168, sHoursPerWeek);
                            Console.Write("\nPlease Enter Non Benefit Bonus Percent: ");
                            string sNonBenefitBonus = Console.ReadLine();
                            decimal NoBenefitBonus = Validation.ValidateDecimalRange(1, 100, sNonBenefitBonus);
                            newEmployee = new Contractor(sEmployeeName, sEmployeeAddress, payPerHour, hoursPerWeek, NoBenefitBonus);
                            Employees.Add(newEmployee);
                            selectingUserType = false;
                        }
                        break;
                    case "4":
                    case "salaried":
                        {
                            Console.Write("\nPlease Enter base salary: ");
                            string sSalary = Console.ReadLine();
                            decimal salary = Validation.ValidateDecimal(sSalary);
                            newEmployee = new Salaried(sEmployeeName, sEmployeeAddress, salary);
                            Employees.Add(newEmployee);
                            selectingUserType = false;
                        }
                        break;
                    case "5":
                    case "manager":
                        {
                            Console.Write("\nPlease Enter base salary: ");
                            string sSalary = Console.ReadLine();
                            decimal salary = Validation.ValidateDecimal(sSalary);
                            Console.Write("\nPlease Enter yearly bonus: ");
                            string sBonus = Console.ReadLine();
                            decimal bonus = Validation.ValidateDecimal(sBonus);
                            newEmployee = new Manager(sEmployeeName, sEmployeeAddress, salary, bonus);
                            Employees.Add(newEmployee);
                            selectingUserType = false;
                        }
                        break;

                }
            }

            return newEmployee;
        }
        public void RemoveEmployee(List<Employee> Employees)
        {
            int i = 0;
            int iInput = 0;
            if (Employees.Count > 0)
            {

                foreach (Employee obj in Employees)
                {
                    ++i;
                    Console.WriteLine("[" + i + "] " + obj.ToString());
                }
                Console.Write("\nPlease Choose an Employee to Remove: ");
                string sRemoval = Console.ReadLine();
                iInput = Validation.ValidateIntRange(1, Employees.Count + 1, sRemoval);
                
                if (iInput <= Employees.Count)
                {
                    Console.Write($"Delete Employee at record: {iInput}: (y or n)");
                    string sInput = Console.ReadLine();

                    switch (sInput.ToLower())
                    {
                        case "y":
                        {
                            Console.WriteLine($"Removing Employee at record {iInput}");
                            Employees.RemoveAt(iInput - 1);
                        }
                            break;
                        case "n":
                        {
                            Console.WriteLine("Keeping Employee");
                        }
                            break;
                        default:
                        {
                            Console.WriteLine("Keeping Employee");
                        }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Please Choose A number from 1 to {Employees.Count}");
                }
            }
            else
            {
                Console.WriteLine("\nNo records were found in the employee list");
            }
        }
        public void DisplayPayroll(List<Employee> Employees)
        {
            decimal totalPay = 0;
            decimal totalPayRoll = 0;
            Employee.Sort(Employees);
            if (!(Employees.Count <= 0))
            {

                Console.WriteLine("\nName                           Address                                       Pay Per Year");
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                foreach (Employee emp in Employees)
                { 
                    if (emp is Fulltime)
                    {
                        var FullTimeEmployee = (Fulltime)emp;
                        totalPay = FullTimeEmployee.CalculatePay(FullTimeEmployee);
                        totalPayRoll = totalPay + totalPayRoll;
                        Console.WriteLine($"{FullTimeEmployee.ToString()} {totalPay.ToString("$#,##0.00")}");
                    }
                    else if (emp is PartTime)
                    {
                        var PartTimeEmployee = (PartTime)emp;
                        totalPay = PartTimeEmployee.CalculatePay(PartTimeEmployee);
                        totalPayRoll = totalPay + totalPayRoll;
                        Console.WriteLine($"{PartTimeEmployee.ToString()} {totalPay.ToString("$#,##0.00")}");
                    }
                    else if (emp is Contractor)
                    {
                        var ContractorEmployee = (Contractor)emp;
                        totalPay = ContractorEmployee.CalculatePay(ContractorEmployee);
                        totalPayRoll = totalPay + totalPayRoll;
                        Console.WriteLine($"{ContractorEmployee.ToString()} {totalPay.ToString("$#,##0.00")}");
                    }
                    else if (emp is Salaried)
                    {
                        var SalaryEmployee = (Salaried)emp;
                        totalPay = SalaryEmployee.CalculatePay(SalaryEmployee);
                        totalPayRoll = totalPay + totalPayRoll;
                        Console.WriteLine($"{SalaryEmployee.ToString()} {totalPay.ToString("$#,##0.00")}");
                    }
                    else if (emp is Manager)
                    {
                        var ManagerEmployee = (Manager)emp;
                        totalPay = ManagerEmployee.CalculatePay(ManagerEmployee);
                        totalPayRoll = totalPay + totalPayRoll;
                        Console.WriteLine($"{ManagerEmployee.ToString()} {totalPay.ToString("$#,##0.00"), -20}");
                    }

                }
                Console.WriteLine($"\nTotal Payroll for all Employees is: {totalPayRoll.ToString("$#,##0.##")}");
            }
            else
            {
                Console.WriteLine("\nThere are no employees on payroll at this time");
            }
        }
    }
}
/*
 
   
 */
