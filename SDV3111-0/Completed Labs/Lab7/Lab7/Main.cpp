// Lab7.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include <vector>
#include "Base.h"
#include "Employee.h"
#include "Helper.h"
#include "Student.h"

void AddRecord(std::vector<Base*>& v);
void DisplayRecords(std::vector<Base*>& v);
void DuplicateRecord(std::vector<Base*>& v);
void MainMenu();
void AddMenu();
void yesNoMenu();

int options = 0;
int addOptions = 0;
int yesNo = 0;

std::vector<Base*> records;

int main()
{
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	_CrtDumpMemoryLeaks();

	bool canExit = false;

	while (!canExit)
	{
		Header("  Lab 7 Abstract Base Classes Lab  ");
		MainMenu();

		switch (options)
		{
		case 1:
			AddRecord(records);
			break;

		case 2:
			DisplayRecords(records);
			break;

		case 3:
			DuplicateRecord(records);
			break;
		case 4:
			canExit = true;
			system("cls");
			std::cout << "\nThank you for trying Lab7 / Abstract Base Classes\nPress Any Key to Exit." << std::endl;
			std::cin.get();
			break;
		}
	}

	for (size_t i = 0; i < records.size(); i++)
	{
		delete records[i];
	}
}

void AddRecord(std::vector<Base*>& v)
{
	bool canExit = false;

	while (!canExit)
	{
		Header("  Add a Record  ");
		AddMenu();
		system("cls");

		switch (addOptions)
		{
		case 1:
		{
			while (true)
			{
				Header("  Employee  ");
				Employee* employee = new Employee;
				char* employeeName = nullptr;

				textPrompt("Employee Name: ", employeeName);

				employee->SetName(employeeName);
				employee->SetSalary(ValidateInt("Employee Salary: ", 0));

				records.push_back(employee);
				system("cls");

				Header("  Employee  ");
				yesNoMenu();
				
				switch (yesNo)
				{
				case 1:
					system("cls");
					continue;
				case 2:
					system("cls");
					break;
				}
				break;
			}
			break;
		}
		case 2:
		{
			while (true)
			{
				Header("  Student  ");
				Student* student = new Student;
				char* studentName = nullptr;

				textPrompt("Student Name: ", studentName);

				student->SetName(studentName);
				student->SetGPA(ValidateFloat("Student GPA: ", 0, 4.0));

				records.push_back(student);
				system("cls");

				Header("  Student  ");
				yesNoMenu();
				switch (yesNo)
				{
				case 1:
					system("cls");
					continue;
				case 2:
					system("cls");
					break;
				}
				break;
			}
			break;
		}
		case 3:
			system("cls");
			canExit = true;
			break;
		}
	}
}

void DisplayRecords(std::vector<Base*>& v)
{
	Header("  Display Records  ");
	for (size_t i = 0; i < records.size(); i++)
	{
		records[i]->DisplayRecord();
	}
	Footer();
}

void DuplicateRecord(std::vector<Base*>& v)
{
	Header("  Duplicate a Record  ");
	int index = 0;
	index = ValidateInt("Please choose a record to copy: ", 0, records.size());

	Student* s = dynamic_cast<Student*>(records[index]);
	if (s != nullptr)
	{
		Student* student = new Student(*s);
		records.push_back(student);
	}

	Employee* e = dynamic_cast<Employee*>(records[index]);
	if (e != nullptr)
	{
		Employee* employee = new Employee(*e);
		records.push_back(employee);
	}
	system("cls");
}

void MainMenu()
{
	std::cout << "Main Menu\n" << std::endl;
	std::cout << "1.. Add Record" << std::endl;
	std::cout << "2.. Display Record" << std::endl;
	std::cout << "3.. Duplicate Record" << std::endl;
	std::cout << "4.. Exit Program\n" << std::endl;
	options = ValidateInt("Please choose an option: ", 1, 4);
	system("cls");
}

void AddMenu()
{
	std::cout << "Add Record Menu\n" << std::endl;
	std::cout << "1.. Add Employee" << std::endl;
	std::cout << "2.. Add Student" << std::endl;
	std::cout << "3.. Return to Main Menu\n" << std::endl;
	addOptions = ValidateInt("Please choose an option: ", 1, 3);
	system("cls");
}

void yesNoMenu()
{
	std::cout << "Add Record Menu\n" << std::endl;
	std::cout << "1.. Yes" << std::endl;
	std::cout << "2.. No\n" << std::endl;
	yesNo = ValidateInt("Please choose an option: ", 1, 2);
	system("cls");
}
