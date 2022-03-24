#include <iostream>
#include "Employee.h"

void Employee::SetSalary(int amount)
{
	salary = amount;
}

void Employee::DisplayRecord()
{
	std::cout << "Employee" << std::endl
		<< "Name: " << GetName() << std::endl
		<< "Salary: " << salary << std::endl << std::endl;
}
