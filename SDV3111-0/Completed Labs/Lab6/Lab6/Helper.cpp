#include <iostream>
#include "Helper.h"

int Helper::GetValidatedInt(const char* strMessage, int nMinimumRange, int nMaximumRange)
{
    int input;
    std::cout << strMessage;

    while (true)
    {
        std::cin >> input;

        if (nMinimumRange == 0 && nMaximumRange == 0)
        {
            nMinimumRange = INT_MIN;
            nMaximumRange = INT_MAX;
        }

        if (std::cin.fail() >> input || input < nMinimumRange || input > nMaximumRange)
        {
            std::cout << "Input number needs to be betwee " << nMinimumRange << " and " << nMaximumRange << "." << std::endl;
            std::cout << strMessage;
            ClearInputBuffer();
            continue;
        }

        std::cin.ignore((UINT_MAX), '\n');
        break;
    }
    return input;
}

void Helper::Header(const char heading[32])
{
    std::cout << "--------------------  " << heading << "  ---------------\n" << std::endl;
}

// Ends the current line, pauses for input, then clears the screen
void Helper::Footer()
{
    std::cout << std::endl;
    system("pause");
    system("cls");
}

// Clears input buffer and ignore until next \n
void Helper::ClearInputBuffer()
{
    std::cin.clear();
    std::cin.ignore((UINT_MAX), '\n');
}

// Creates a random number between given min and max. min can default to 0. max is not inclusive
int Helper::RandomNumber(int max)
{
    srand((unsigned)time(NULL));
    return rand() % max + 1;
}

// Copies a char array into another
void Helper::CopyString(const char* source, char*& destination)
{
    delete[] destination;
    size_t len = strlen(source) + 1;
    destination = new char[len];
    strcpy_s(destination, len, source);
}


float Helper::GetValidatedFloat(const char* strMessage, float nMinimumRange, float nMaximumRange)
{
    float input;
    std::cout << strMessage;

    while (true)
    {
        std::cin >> input;

        if (nMinimumRange == 0 && nMaximumRange == 0)
        {
            nMinimumRange = std::numeric_limits<float>::min();
            nMaximumRange = std::numeric_limits<float>::max();
        }

        if (std::cin.fail() >> (int)input || input < nMinimumRange || input > nMaximumRange)
        {
            std::cout << "Input number needs to be between " << nMinimumRange << " and " << nMaximumRange << "." << std::endl;
            std::cout << strMessage;
            ClearInputBuffer();
            continue;
        }

        std::cin.ignore((UINT_MAX), '\n');
        break;
    }
    return input;
}