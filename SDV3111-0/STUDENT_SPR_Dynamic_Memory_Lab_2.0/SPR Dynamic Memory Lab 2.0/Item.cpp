#include "Item.h"
#include <iostream>

Item::Item(const char* _name, int _value)
{
	m_Name = _name;
	m_Value = new int(_value);
	m_Value = new int(_value);
}

void Item::Print() const
{
	int* value = new int(GetValue());
	std::cout << m_Name << "\t" << *value << std::endl;
}