#include <iostream>
#include "Helper.h"

int Helper::GetValidatedInt(const char* strMessage, int nMinimumRange, int nMaximumRange)
{
    int input;
    std::cout << strMessage;

    while (true)
    {
        std::cin >> input;

        if (std::cin.fail() >> input || input < nMinimumRange || input > nMaximumRange)
        {
            std::cout << "Input was not a number between " << nMinimumRange << " and " << nMaximumRange << "." << std::endl;
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
    std::cout << "--------------------  " << heading << "  --------------------\n" << std::endl;
}


void Helper::Footer()
{
    std::cout << std::endl;
    system("pause");
    system("cls");
}


void Helper::ClearInputBuffer()
{
    std::cin.clear();
    std::cin.ignore((UINT_MAX), '\n');
}

int Helper::RandomNumber(int max)
{
    srand((unsigned)time(NULL));
    return rand() % max + 1;
}

void Helper::MainMenu()
{
    std::cout << "What bit manipulation would you like to accomplish today>" << std::endl;
    std::cout << "1.. Turn On" << std::endl;
    std::cout << "2.. Turn Off" << std::endl;
    std::cout << "3.. Toggle" << std::endl;
    std::cout << "4.. Negate" << std::endl;
    std::cout << "5.. Left Shift" << std::endl;
    std::cout << "6.. Right Shift\n" << std::endl;
    std::cout << "7.. Exit Program\n" << std::endl;
    int userChoice = GetValidatedInt("Please Choose: ", 1, 7);
    // system("cls");
}
