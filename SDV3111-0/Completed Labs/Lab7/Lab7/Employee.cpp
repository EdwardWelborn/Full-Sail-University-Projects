#pragma once
#include <iostream>
#include "Employee.h"

void Employee::SetSalary(int amount)
{
	_salary = amount;
}

void Employee::DisplayRecord()
{
	std::cout << "Employee" << std::endl
		<< "Name: " << GetName() << std::endl
		<< "Salary: " << _salary << std::endl << std::endl;
}
