#include "Base.h"

class Student : public Base
{
private:
	float gpa = 0;

public:
	void SetGPA(float amount);
	void DisplayRecord();
};

