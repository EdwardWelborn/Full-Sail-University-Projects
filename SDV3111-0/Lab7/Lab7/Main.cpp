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

std::vector<Base*> records;

int main()
{
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	//_CrtSetBreakAlloc(205);
	_CrtDumpMemoryLeaks();

	bool isRunning = true;

	while (isRunning)
	{
		Header("  Abstract Base Classes Lab  ");
		int options = GetValidatedInt("Please select an option. (Enter the number and press enter)\n1) Add Record\n2) Display Records\n3) Duplicate a Record\n4) Exit\n", 1, 4);
		system("cls");

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
			system("cls");
			isRunning = false;
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
	bool isRunning = true;

	while (isRunning)
	{
		Header("  Adding a Record  ");
		int optionsOne = GetValidatedInt("What type of record do you want to add?\n1) Add Employee\n2) Add Student\n3) Exit\n", 1, 3);
		system("cls");

		switch (optionsOne)
		{
		case 1:
		{
			while (true)
			{
				Header("  Employee  ");
				Employee* employee = new Employee;
				char* employeeName = nullptr;

				promptForText("Employee Name: ", employeeName);

				employee->SetName(employeeName);
				employee->SetSalary(GetValidatedInt("Employee Salary: ", 0));

				records.push_back(employee);
				system("cls");

				Header("  Employee  ");
				int repeated = GetValidatedInt("Add another Employee record?\n1) Yes\n2) No\n", 1, 2);
				switch (repeated)
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

				promptForText("Student Name: ", studentName);

				student->SetName(studentName);
				student->SetGPA(GetValidatedFloat("Student GPA: ", 0, 4.0));

				records.push_back(student);
				system("cls");

				Header("  Student  ");
				int repeated = GetValidatedInt("Add another Student record?\n1) Yes\n2) No\n", 1, 2);
				switch (repeated)
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
			isRunning = false;
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
	index = GetValidatedInt("Please enter a number for the index you want to copy: ", 0, records.size());

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
