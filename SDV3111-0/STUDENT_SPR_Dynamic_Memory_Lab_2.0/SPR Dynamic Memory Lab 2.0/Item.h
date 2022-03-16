#pragma once

#include <string>

class Item
{
	std::string m_Name;
	int* m_Value = nullptr;

	int GetValue() const {
		return *m_Value;
	}

public:
	Item(const char* _name, int _value);
	void Print() const;
};