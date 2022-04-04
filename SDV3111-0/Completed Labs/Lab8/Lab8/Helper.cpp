#include "Helper.h"

void CopyString(const char* source, char*& destination)
{
    delete[] destination;
    size_t len = strlen(source) + 1;
    destination = new char[len];
    strcpy_s(destination, len, source);
}
