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
    Program1(); // Done
    Program2(); // Done
    Program3(); // Done
    Program4(); // Done
    Program5(); // Done
    Program6(); // Done
    Program7(); // Done
    Program8(); // Done
    Program9(); // Done
    Program10();// Done
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

    std::cout << "\n";
}
//Program 1-2
void Program2()
{
    std::cout << "==================== Program 1-2 ====================\n";
    int integers[5];
    
    for (int x = 0; x < 5; x++)
    {
        std::cout << "Please Enter a number: (" << x + 1 << " of 5) ";
        integers[x] = ValidateInt(integers[x]);
    }
    std::cout << "The Numbers you entered are:  ";
    for (int x = 0; x < 5; x++)
    {
        if (x < 4)
        {
            std::cout << integers[x] << ",";
        }
        else
        {
            std::cout << integers[x];
        }
    }
    std::cout << "\n\n";
}

// Program 1-3
void Program3()
{
    std::cout << "==================== Program 1-3 ====================\n";
    int number1 = 0;
    int number2 = 0;
    int number3 = 0;
    int results = 0;

    std::cout << "Please enter a valid number for number 1: ";
    number1 = ValidateInt(number1);
    std::cout << "Please enter a valid number for number 2: ";
    number2 = ValidateInt(number2);
    std::cout << "Please enter a valid number for number 1: ";
    number3 = ValidateInt(number3);

    results = number1 + 1 * number2 + 2 - number3;
    std::cout << "\na + 1 * b + 2 - c = " << results << "\n";
    results = (number1 + 1) * (number2 + 2) - number3;
    std::cout << "(a + 1) * (b + 2) - c = " << results;

    std::cout << "\n\n";
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

    std::cout << "\n\n";
}

// Program 1-5
void Program5()
{
    std::cout << "==================== Program 1-5 ====================\n";
    char name[32];

    std::cout << "Please Enter Your Name: ";
	std::cin.getline(name, 32);
    std::cout << "Greetings " << name << ", did you know, that the dot over the i is called a title?";

    std::cout << "\n\n";
}

// Program 1-6
void Program6()
{
    std::cout << "==================== Program 1-6 ====================\n";

    int age = 0;

    std::cout << "\nPlease enter your age: ";
    age = ValidateInt(age);

    if (age < 16)
    {
        std::cout << "\nYou are too young to be playing this game.";
    }
    else if (age >= 16 && age < 30)
    {
        std::cout << "\nYou are in the prime of your life, enjoy it!";
    }
    else if (age >= 30 && age < 45)
    {
        std::cout << "\nYou are in the middle of your life, go forth and have fun";
    }
    else if (age >= 45 && age < 65)
    {
        std::cout << "\nWork hard and save for your retirement";
    }
    else if (age > 65)
    {
        std::cout << "\nAWESOME! Travel time, enjoy your golden years.";
    }
    std::cout << "\n\n";
}

// Program 1-7
void Program7()
{
    std::cout << "==================== Program 1-7 ====================\n";
    int number = 0;

    std::cout << "\nPlease enter a number to check: ";
    number = ValidateInt(number);

    if (number % 2 == 0)
    {
        std::cout << "\nRight on! The number is even.";
    }
    else
    {
        std::cout << "\nNo sir, This number is NOT even.";
    }

    std::cout << "\n\n";

}

// Program 1-8
void Program8()
{
    std::cout << "==================== Program 1-8 ====================\n";
    int number = 0;
    int rndNumber = 0;
    srand(time(0));

    std::cout << "\nPlease enter a divisor to check: ";
    number = ValidateInt(number);

    for (int i = 1; i <=3; i++)
    {
        rndNumber = rand();
        if (rndNumber % number == 0)
        {
            std::cout << "\nRandom Number: \t" << rndNumber << "\tDivisible? " << "Yes";
        }
        else
        {
            std::cout << "\nRandom Number: \t" << rndNumber << "\tDivisible? " << "Nope";
        }
    }
    std::cout << "\n\n";
}

// Program 1.9
void Program9()
{
    std::cout << "==================== Program 1-9 ====================\n";
    int choice = 0;

    std::cout << "Colors of popcicles in my freezer\n";
    std::cout << "1.. Red\n";
    std::cout << "2.. Blue\n";
    std::cout << "3.. Yellow\n";
    std::cout << "4.. Orange\n";
    std::cout << "5.. Purple\n";
    std::cout << "6.. Green\n";
    std::cout << "Which color would you like: ";
    choice = ValidateInt(choice);
    
    switch (choice)
    {
    case 1:
        {
            std::cout << "\nCherry is always a great choice in flavors";
            break;
        }
    case 2:
        {
            std::cout << "\nBlueberry is always an interesting flavor";
            break;
        }
    case 3:
        {
            std::cout << "\nBanana is such a yummy taste";
            break;
        }
    case 4:
        {
            std::cout << "\nOrange is makes the tongue a fun color";
            break;
        }
    case 5:
        {
            std::cout << "\nGrape is not one of my favorite flavors.";
            break;
        }
    case 6:
        {
            std::cout << "\nGreen Apple always a fan favorite.";
            break;
        }
    default:
        {
            std::cout << "\nPlease choose a flavor I have in the freezer.";
            break;
        }
    }

    std::cout << "\n\n";
}

// Program 1-10
void Program10()
{
    std::cout << "==================== Program 1-10 ====================\n";
    int choice = 0;
    int rndNumber = 0;
    int number = 0;

    srand(time(0));

    std::cout << "\nPlease choose the level of difficulty to fight:";
    std::cout << "\n1.. Easy";
    std::cout << "\n2.. Medium";
    std::cout << "\n3.. Hard";
    std::cout << "\n4.. Extreme";
    std::cout << "\nChoose your destiny! ";
    number = ValidateInt(number);

    switch (number)
    {
    case 1:
	    {
		    rndNumber = rand() % 10;
		    std::cout << "\nYou will have to fight " << rndNumber << " monsters to get to the next level\n";
            break;
	    }
    case 2:
	    {
		    rndNumber = rand() % 10 + 30;
		    std::cout << "\nYou will have to fight " << rndNumber << " monsters to get to the next level\n";
            break;
	    }
    case 3:
	    {
		    rndNumber = rand() % 10 + 50;
		    std::cout << "\nYou will have to fight " << rndNumber << " monsters to get to the next level\n";
            break;
	    }
    case 4:
	    {
		    rndNumber = rand() % 100 + 50;
		    std::cout << "\nYou will have to fight " << rndNumber << " monsters, and hope to not die!\n";
            break;
	    }
    default:
	    {
		    std::cout << "\nPlease choose the correct destiny and difficulty";
            break;
	    }

    }
    ClearInputBuffer();
    std::cout << "\n";
}





