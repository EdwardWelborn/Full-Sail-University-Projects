// Lab2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "Console.h"

// Global Declarations
unsigned int bitField;
unsigned int bitF;
unsigned int data;
int userChoice = 0;
void Heading();
int IsValidInt(int input, const char prompt[]);
void MainMenu();
void TurnOn(int bit);
void TurnOff(int bit);
void Toggle(int bit);
void PrintBinaryNumber(unsigned int num, int size);
void ClearInputBuffer();
void Negate();
void LeftShift();
void RightShift();

int main()
{
	bool stopRunning = false;
	int bitToChange = 0;

	Heading();
	std::cout << "Please enter a number between " << 0 << " and " << UINT_MAX << ", then press enter." << std::endl;
	bitField = IsValidInt(bitField, "Number: ");
	system("cls");

	while (!stopRunning)
	{
		Heading();
		MainMenu();

		switch (userChoice)
		{
		case 1:
			Heading();
			std::cout << "Which bit would you like to turn on?" << std::endl;
			bitToChange = IsValidInt(bitToChange, "Bit: ");
			TurnOn(1 << bitToChange - 1);
			system("cls");
			break;
		case 2:
			Heading();
			std::cout << "Which bit would you like to turn off?" << std::endl;
			bitToChange = IsValidInt(bitToChange, "Bit: ");
			TurnOff(1 << bitToChange - 1);
			system("cls");
			break;
		case 3:
			Heading();
			std::cout << "Which bit would you like to toggle?" << std::endl;
			bitToChange = IsValidInt(bitToChange, "Bit: ");
			Toggle(1 << bitToChange - 1);
			system("cls");
			break;
		case 4:
			Heading();
			Negate();
			system("cls");
			break;
		case 5:
			Heading();
			LeftShift();
			system("cls");
			break;
		case 6:
			Heading();
			RightShift();

			system("cls");
			break;
		case 7:
			stopRunning = true;
			std::cout << "\nThank you for trying Bit Manipulation\nPress Any Key to Exit." << std::endl;
			std::cin.get();
			break;
		}
	}
	// system("pause");
}


void Heading()
{
	std::cout << "-------------------- Lab 2 Bit Manipulation --------------------\n" << std::endl;
	std::cout << "Bitfield: " << bitField << std::endl;
	std::cout << "Your number in bits: ";
	PrintBinaryNumber(bitField, 32);
	std::cout << std::endl;
}

void ClearInputBuffer()
{
	std::cin.clear();
	std::cin.ignore(300, '\n');
}

int IsValidInt(int choice, const char input[])
{
	std::cout << input;

	while (!(std::cin >> choice))
	{
		std::cout << input;
		std::cin >> choice;
		ClearInputBuffer();
	}

	return choice;
}

void PrintBinaryNumber(unsigned int number, int size)
{
	char* chr = new char[size + 1];
	chr[size] = '\0';

	for (int i = size - 1; i >= 0; i--)
	{
		if (number % 2 == 0)
		{
			chr[i] = '0';
		}
		else
		{
			chr[i] = '1';
		}
		number = number / 2;
	}

	for (int i = 0; i < size; i++)
	{
		if (i % 4 == 0)
		{
			std::cout << " ";
		}
		std::cout << chr[i];
	}
	std::cout << std::endl;
	delete[] chr;
}

void MainMenu()
{
	std::cout << "What bit manipulation would you like to accomplish today>" << std::endl;
	std::cout << "1.. Turn On" << std::endl;
	std::cout << "2.. Turn Off" << std::endl;
	std::cout << "3.. Toggle" << std::endl;
	std::cout << "4.. Negate" << std::endl;
	std::cout << "5.. Left Shift" << std::endl;
	std::cout << "6.. Right Shift\n" << std::endl;
	std::cout << "7.. Exit Program\n" << std::endl;
	userChoice = IsValidInt(userChoice, "Please Choose: ");
	// system("cls");
}

void TurnOn(int bit)
{
	bitField = bitField | bit;
}

void TurnOff(int bit)
{
	bitField = bitField & (~bit);
}

void Toggle(int bit)
{
	bitField = bitField ^ bit;
}

void Negate()
{
	bitField = ~bitField;
}

void LeftShift()
{
	bitField = bitField << 1;
}

void RightShift()
{
	bitField = bitField >> 1;
}