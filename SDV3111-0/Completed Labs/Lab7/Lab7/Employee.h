#pragma once
#include "Base.h"

class Employee : public Base
{
private:
	int _salary = 0;

public:
	void SetSalary(int amount);
	void DisplayRecord();
};
