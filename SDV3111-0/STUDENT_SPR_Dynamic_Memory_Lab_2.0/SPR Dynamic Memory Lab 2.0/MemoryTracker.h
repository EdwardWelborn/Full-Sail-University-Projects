#pragma once

class MemoryTracker
{
	static unsigned int m_InUse;
public:
	static void AddUse(unsigned int _amount);
	static void RemoveUse(unsigned int _amount);
	static unsigned int GetInUse();
};