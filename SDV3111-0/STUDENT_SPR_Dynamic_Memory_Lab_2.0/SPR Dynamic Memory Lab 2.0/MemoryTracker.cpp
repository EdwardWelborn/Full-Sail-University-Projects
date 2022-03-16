#include "MemoryTracker.h"
#include <cstdlib>
#include <iostream>

unsigned int MemoryTracker::m_InUse = 0;

void MemoryTracker::AddUse(unsigned int _amount)
{
	m_InUse += _amount;
}

void MemoryTracker::RemoveUse(unsigned int _amount)
{
	m_InUse -= _amount;
}

unsigned int MemoryTracker::GetInUse()
{
	return m_InUse;
}

void* operator new(size_t _size) {
	// Allocating the memory (along with an extra header to keep track of the size)
	size_t* mem = (size_t*)malloc(_size + sizeof(size_t));
	// Set the size in the header
	mem[0] = _size;
	// Update the metrics
	//metrics.inUse += _size;
	MemoryTracker::AddUse((unsigned int)_size);
	// Send back the allocated memory (minus the header)
	return (void*)(&mem[1]);
}

// Overloaded delete that makes use of AllocationMetrics
//
// In:	_memory		Pointer to the first address of block to be deallocated
void operator delete(void* _memory) {
	if (!_memory)
		return;

	// Creating a temp pointer to make code easier to work with
	size_t* mem = (size_t*)_memory;
	// Extracting the header information which contains the number of bytes allocated
	//metrics.inUse -= mem[-1];
	MemoryTracker::RemoveUse((unsigned int)mem[-1]);
	// Get a pointer to the actual memory allocated (with the header)
	void* ptr = (void*)(&mem[-1]);
	// Release the memory back to the heap
	free(ptr);
}