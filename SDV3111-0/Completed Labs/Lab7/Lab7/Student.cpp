#pragma once
#include <iostream>
#include "Student.h"

void Student::SetGPA(float amount)
{
	_gpa = amount;
}

void Student::DisplayRecord()
{
	std::cout << "Student" << std::endl
		<< "Name: " << GetName() << std::endl
		<< "GPA: " << _gpa << std::endl << std::endl;
}
