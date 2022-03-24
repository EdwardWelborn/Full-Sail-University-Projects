#include <iostream>
#include "Student.h"

void Student::SetGPA(float amount)
{
	gpa = amount;
}

void Student::DisplayRecord()
{
	std::cout << "Student" << std::endl
		<< "Name: " << GetName() << std::endl
		<< "GPA: " << gpa << std::endl << std::endl;
}