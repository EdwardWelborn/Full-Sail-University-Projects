#pragma once
#include "Base.h"
#include "Helper.h"

Base::Base() : _name(nullptr)
{
}

Base::Base(Base& other)
{
	CopyString(other.GetName(), _name);
}

Base::~Base()
{
	delete[] _name;
	_name = nullptr;
}

Base& Base::operator=(const Base& other)
{
	if (this != &other)
	{
		CopyString(other.GetName(), _name);
	}
	return *this;
}

void Base::SetName(const char* name)
{
	CopyString(name, _name);
}
