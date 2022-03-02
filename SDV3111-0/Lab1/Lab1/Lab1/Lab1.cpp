// Lab1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>


// Program Declarations and Forwards
void Program1();
void Program2();
void Program3();
void Program4();
void Program5();
void Program6();
void Program7();
void Program8();
void Program9();
void Program10();


int main()
{
//    Program1(); // Done
//    Program2(); // Done
//    Program3(); // Done
//    Program4(); // Done
//    Program5(); // Done
    Program6();
//    Program7();
//    Program8();
//    Program9();
//    Program10();
}

// Clear Buffer and Validation Methods
void ClearInputBuffer()
{
    std::cin.clear();
    std::cin.ignore(INT_MAX, '\n');
}
int ValidateInt(int x)
{
    while (true)
    {
        if (std::cin >> x)
        {
            ClearInputBuffer();
            return x;
        }
        ClearInputBuffer();
        std::cout << "Please enter a valid number: ";
    }
}
// Start of Lab1 Methods
// Program 1-1
void Program1()
{
    std::cout << "==================== Program 1-1 ====================\n";
    char initials[4]; 
    int age = 0;

    std::cout << "\nPlease enter your initials (No spaces please!): ";
    std::cin >> initials;
    std::cout << "Please enter your age: ";
    age = ValidateInt(age);
    age *= 365;
    std::cout << initials << ", you are a total of " << age << " days old? \n";
    ClearInputBuffer();
    std::cout << "\n";
}
//Program 1-2
void Program2()
{
    std::cout << "==================== Program 1-2 ====================\n";
    int integers[5];
    
    for (int x = 0; x < 5; x++)
    {
        std::cout << "Please Enter a number: ";
        integers[x] = ValidateInt(integers[x]);
    }
    std::cout << "The Numbers you entered are:  ";
    for (int x = 0; x < 5; x++)
    {
        std::cout << integers[x];
    }
    ClearInputBuffer();
    std::cout << "\n";
}

// Program 1-3
void Program3()
{
    std::cout << "==================== Program 1-3 ====================\n";
    int number1 = 0;
    int number2 = 0;
    int number3 = 0;
    int results = 0;

    std::cout << "Please enter a valid number for number 1:";
    number1 = ValidateInt(number1);
    std::cout << "Please enter a valid number for number 2:";
    number2 = ValidateInt(number2);
    std::cout << "Please enter a valid number for number 1:";
    number3 = ValidateInt(number3);

    results = number1 + 1 * number2 + 2 - number3;
    std::cout << "\na + 1 * b + 2 - c = " << results << "\n";
    results = (number1 + 1) * (number2 + 2) - number3;
    std::cout << "(a + 1) * (b + 2) - c = " << results;

    ClearInputBuffer();
    std::cout << "\n";
}

// Program 1-4
void Program4()
{
    std::cout << "==================== Program 1-4 ====================\n";
    std::cout << "Number Type" << "\t" << " Number Range\n";
    std::cout << "=====================================================\n";
    std::cout << "\nushort \t\t 0 - " << USHRT_MAX;
    std::cout << "\nshort \t\t" << SHRT_MIN << " - " << SHRT_MAX;
    std::cout << "\nuint \t\t 0 - " << UINT_MAX;
    std::cout << "\nint \t\t" << INT_MIN << " - " << INT_MAX;
    std::cout << "\nlonglong \t" << LLONG_MIN << " - " << LLONG_MAX;
    std::cout << "\nulonglong \t 0 - " << ULONG_MAX;

    ClearInputBuffer();
    std::cout << "\n";
}

// Program 1-5
void Program5()
{
    std::cout << "==================== Program 1-5 ====================\n";
    char name[32];

    std::cout << "Please Enter Your Name: ";
	std::cin.getline(name, 32);
    std::cout << "Greetings " << name << ", did you know, that the dot over the i is called a title?";

    ClearInputBuffer();
    std::cout << "\n";
}

// Program 1-6
void Program6()
{
    std::cout << "==================== Program 1-6 ====================\n";

    int age = 0;




}


