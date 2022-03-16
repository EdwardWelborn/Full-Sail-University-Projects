#include "main.h"
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
#include <iostream>
#include <math.h>
#include "Store.h"

// TODO
// Change this number to the line number the Output window shows you
// to follow a memory leak. Put -1 to disable.
#define MEMORY_LEAK_LINE 0

void ScopeMain()
{
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	_CrtSetBreakAlloc(MEMORY_LEAK_LINE); // DO NOT COMMENT OUT THIS LINE
	_CrtDumpMemoryLeaks();

	Store* s = new Store();
	s->Print();
}