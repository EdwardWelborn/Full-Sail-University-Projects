#include <iostream>
#include "MemoryTracker.h"
#include "Console.h"
#include "main.h"
#include "Inventory.h"
using namespace System;

unsigned int Inventory::m_ItemsMade = 1;

int main()
{
    ScopeMain();

    unsigned int nInUse = MemoryTracker::GetInUse();
    std::cout << "\nMemory In Use: " << nInUse << std::endl;

	auto oldColor = Console::ForegroundColor();
	if (nInUse == 0)
	{
		Console::ForegroundColor(ConsoleColor::Green);
		std::cout << "PASS" << std::endl;
		Console::ForegroundColor(oldColor);
	}
	else
	{
		Console::ForegroundColor(ConsoleColor::Red);
		std::cout << "FAIL" << std::endl;
		Console::ForegroundColor(oldColor);
	}

	std::cout << std::endl;
    system("pause");
}
