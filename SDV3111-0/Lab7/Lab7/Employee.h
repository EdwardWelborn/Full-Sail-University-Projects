#include "Base.h"

class Employee : public Base
{
private:
	int salary = 0;

public:
	void SetSalary(int amount);
	void DisplayRecord();
};
