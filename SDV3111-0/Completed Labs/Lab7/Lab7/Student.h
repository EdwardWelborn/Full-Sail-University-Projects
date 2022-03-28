#pragma once
#include "Base.h"

class Student : public Base
{
private:
	float _gpa = 0;

public:
	void SetGPA(float amount);
	void DisplayRecord();
};
