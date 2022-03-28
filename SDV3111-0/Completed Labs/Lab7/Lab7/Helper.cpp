#pragma once
#include <iostream>
#include "Helper.h"


int ValidateInt(const char* strMessage, int nMinimumRange, int nMaximumRange)
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
            std::cout << "Please Input a valid number between " << nMinimumRange << " and " << nMaximumRange << "." << std::endl;
            std::cout << strMessage;
            ClearInputBuffer();
            continue;
        }

        std::cin.ignore((UINT_MAX), '\n');
        break;
    }
    return input;
}


void Header(const char heading[32])
{
    std::cout << "--------------------  " << heading << "  --------------------\n" << std::endl;
}


void Footer()
{
    std::cout << std::endl;
    system("pause");
    system("cls");
}


void ClearInputBuffer()
{
    std::cin.clear();
    std::cin.ignore((UINT_MAX), '\n');
}


int RandomNumber(int max)
{
    srand((unsigned)time(NULL));
    return rand() % max + 1;
}


void CopyString(const char* source, char*& destination)
{
    delete[] destination;
    size_t len = strlen(source) + 1;
    destination = new char[len];
    strcpy_s(destination, len, source);
}


float ValidateFloat(const char* strMessage, float nMinimumRange, float nMaximumRange)
{
    float input;
    std::cout << strMessage;

    while (true)
    {
        std::cin >> input;

        if (nMinimumRange == 0 && nMaximumRange == 0)
        {
            nMinimumRange = FLT_MIN;
            nMaximumRange = FLT_MAX;
        }

        if (std::cin.fail() >> (int)input || input < nMinimumRange || input > nMaximumRange)
        {
            std::cout << "V" << nMinimumRange << " and " << nMaximumRange << "." << std::endl;
            std::cout << strMessage;
            ClearInputBuffer();
            continue;
        }

        std::cin.ignore((UINT_MAX), '\n');
        break;
    }
    return input;
}

void textPrompt(const char* prompt, char*& text)
{
    char buffer[5000];
    std::cout << prompt;
    std::cin.getline(buffer, 5000);

    int length = strlen(buffer) + 1;

    text = new char[length];
    strcpy_s(text, length, buffer);
}