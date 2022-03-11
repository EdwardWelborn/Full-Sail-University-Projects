// Lab3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "Car.h"

// Global Definitions
Car cars[3];

int ValidateInt(int input, const char prompt[]);
void ClearInputBuffer();
void Header(const char heading[32]);
void Footer();
void ProgramOne();
void ProgramTwo();
void PrintValueAndAddress(int number, int* pointer);
void ProgramThree();
void PrintCar(Car car);
void PrintCar(Car* car);
void GetCarDetails();
void PrintCarDetails();
void ChangePaint();
void RepaintCar(Car* carPointer, EnumColorDefinition newColor);
void AddMileage(Car* carPointer, int addMiles);
void ChangeMileage();

int main()
{
    ProgramOne();     // Done
    ProgramTwo();     // Done  
    ProgramThree();   // Done
    ChangePaint();    // Done
    ChangeMileage();  // Done
}

int ValidateInt(int input, const char prompt[])
{
    std::cout << prompt;

    while (!(std::cin >> input))
    {
        std::cout << prompt;
        std::cin >> input;
        ClearInputBuffer();
    }
    ClearInputBuffer();
    return input;
}

void ClearInputBuffer()
{
    std::cin.clear();
    std::cin.ignore((300), '\n');
}

void Header(const char heading[32])
{
std::cout << "--------------------------  " << heading << "  --------------------------\n" << std::endl;
}

void Footer()
{
    std::cout << std::endl;
    system("pause");
    system("cls");
}

void ProgramOne()
{
    Header("Program 1");

    srand(time(NULL));
    int nums[15];

    for (size_t i = 0; i < 15; i++)
    {
        nums[i] = rand();
        std::cout << i << ".\tNumber: " << nums[i] << "\t\tMemory Address: " << &nums[i] << std::endl;
    }

    Footer();
}

void ProgramTwo()
{
    Header("Program 2");

    int numbers[15];

    for (int i = 0; i < 15; i++)
    {
        numbers[i] = rand();
        PrintValueAndAddress(numbers[i], &numbers[i]);
    }

    Footer();
 
}

void PrintValueAndAddress(int number, int* pointer)
{
    std::cout << "Number: " << number << "\t\tMemory Address: " << pointer << std::endl;
}

void ProgramThree()
{
    GetCarDetails();
    PrintCarDetails();
    Footer();
}

void GetCarDetails()
{
    for (int i = 0; i < 3; i++)
    {
        Header("Program Three - Making Cars");

        std::cout << "Car " << i + 1 << std::endl;
        std::cout << "Make    : ";                                                     
        std::cin.getline(cars[i].make, 32);                                         

        std::cout << "Model   : ";
        std::cin.getline(cars[i].model, 32);                                        

        cars[i].year = ValidateInt(cars[i].year, "Year    : ");                          

        cars[i].mileage = ValidateInt(cars[i].mileage, "Mileage : ");                 

        std::cout << "\nChoose a color for Car " << i + 1 << std::endl;
        std::cout << "1.. Red" << std::endl;
    	std::cout << "2.. Blue" << std::endl;
        std::cout << "3.. Green" << std::endl;
        std::cout << "4.. Yellow" << std::endl;
    	std::cout << "5.. Purple" << std::endl;
        std::cout << "6.. Orange" << std::endl;
        std::cout << "7.. Black\n" << std::endl;
        cars[i].color = (EnumColorDefinition)ValidateInt(cars[i].color, "Color: ");  //Gets the color

        system("cls");
    }
}

void PrintCarDetails()
{
    Header("Chosen Cars - Direct access");

    for (int i = 0; i < 3; i++)
    {
        std::cout << "Car " << i + 1;
        PrintCar(cars[i]);
    }

    std::cout << std::endl;

    Header("Chosen Cars - Memory access");

    for (int i = 0; i < 3; i++)
    {
        std::cout << "Car " << i + 1;
        PrintCar(&cars[i]);
    }
}

void PrintCar(Car car)
{
    std::cout << ". Year: " << car.year << "   Color: ";

    switch (car.color)
    {
    case Red:
        std::cout << "Red   ";
        break;
    case Blue:
        std::cout << "Blue  ";
        break;
    case Green:
        std::cout << "Green ";
        break;
    case Yellow:
        std::cout << "Yellow";
        break;
    case Purple:
        std::cout << "Purple";
        break;
    case Orange:
        std::cout << "Orange";
        break;
    case Black:
        std::cout << "Black";
        break;
    }

    std::cout
        << "\tMake: " << car.make
        << "\tModel: " << car.model
        << "\tMileage: " << car.mileage
        << std::endl;
}

void PrintCar(Car* carPointer)
{
    std::cout << ". Year: " << (*carPointer).year << "   Color: ";

    switch ((*carPointer).color)
    {
    case Red:
        std::cout << "Red   ";
        break;
    case Blue:
        std::cout << "Blue  ";
        break;
    case Green:
        std::cout << "Green ";
        break;
    case Yellow:
        std::cout << "Yellow";
        break;
    case Purple:
        std::cout << "Purple";
        break;
    case Orange:
        std::cout << "Orange";
        break;
    case Black:
        std::cout << "Black";
        break;
    }

    std::cout
        << "\tMake: " << (*carPointer).make
        << "\tModel: " << (*carPointer).model
        << "\tMileage: " << (*carPointer).mileage
        << std::endl;
}

void RepaintCar(Car* carPointer, EnumColorDefinition newColor)
{
    carPointer->color = newColor;
}

void ChangePaint()
{
    Header("Repaint Chosen Car");

    int repaintQuestion = 0;
    repaintQuestion = ValidateInt(repaintQuestion, "Please select which car to repaint: ") - 1;

    RepaintCar(&cars[repaintQuestion], Purple);
    std::cout << std::endl;
    PrintCarDetails();
    Footer();
}

void AddMileage(Car* carPointer, int addMiles)
{
    carPointer->mileage = carPointer->mileage + addMiles;
}

void ChangeMileage()
{
    Header("Change Chosen Car Mileage");

    int carChoice = 0;
    carChoice = ValidateInt(carChoice, "Please select which car to add mileage: ") - 1;

    int addMiles = 0;
    addMiles = ValidateInt(addMiles, "How many miles to add: ");

    AddMileage(&cars[carChoice], addMiles);
    std::cout << std::endl;
    PrintCarDetails();
    Footer();
}
