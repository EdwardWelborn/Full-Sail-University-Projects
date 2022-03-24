#include "Base.h"
#include "Helper.h"

Base::Base() : name(nullptr)
{
}

Base::Base(Base& other)
{
	CopyString(other.GetName(), name);
}

Base::~Base()
{
	delete[] name;
	name = nullptr;
}

Base& Base::operator=(const Base& other)
{
	if (this != &other)
	{
		CopyString(other.GetName(), name);
	}
	return *this;
}

void Base::SetName(const char* name)
{
	CopyString(name, name);
}
