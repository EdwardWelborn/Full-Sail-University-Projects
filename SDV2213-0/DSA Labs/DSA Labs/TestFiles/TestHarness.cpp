/*
File:			TestHarness.cpp
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		10.20.2021
Last Modified:	10.20.2021
Purpose:
Notes:			Property of Full Sail University

				DO NOT CHANGE ANY CODE IN THIS FILE
*/

/************/
/* Includes */
/************/
#include "TestHarness.h"
#include "UnitTests_Lab1.h"
#include "UnitTests_Lab2.h"
#include "UnitTests_Lab3.h"
#include "UnitTests_Lab4.h"
#include "UnitTests_Lab5.h"
#include "UnitTests_Lab6.h"
#include "UnitTests_Lab7.h"
#include "UnitTests_Lab8.h"
#include <iostream>
#include <filesystem>

bool TestHarness::verboseMode = false;

#define LAB1	'1'
#define LAB2	'2'
#define LAB3	'3'
#define LAB4	'4'
#define LAB5	'5'
#define LAB6	'6'
#define LAB7	'7'
#define LAB8	'8'
#define EXIT	'0'
#define VERBOSE 'T'

// Runs all the one-time only code
void TestHarness::Init() const {
	CleanUpFiles();
	
	if (sizeof(void*) != 8) {
		std::cout << "Make sure you are running your program in x64 mode\n\n";
		std::system("pause");
	}

}

void TestHarness::CleanUpFiles() const {
	std::string temp, extension;
	size_t index;
	for (const auto& entry : std::filesystem::directory_iterator("..\\DSA Labs")) {
		// Finding files to be removed
		temp = entry.path().filename().string();
		index = temp.find_last_of('.') + 1;
		extension = temp.substr(index);

		// Removing files
		if (extension == "bin" || extension == "check" || extension == "student" || extension == "txt")
			std::filesystem::remove(entry);
	}
}

bool TestHarness::GetVerboseMode() {
	return verboseMode;
}

void TestHarness::ToggleVerboseMode() {
	verboseMode = !verboseMode;
}

// Display the main menu
void TestHarness::DisplayMenu() const {
	std::cout << "1) Lab 1 - DynArray\n"
		<< "2) Lab 2 - vector\n"
		<< "3) Lab 3 - DList\n"
		<< "4) Lab 4 - list\n"
		<< "5) Lab 5 - Dictionary\n"
		<< "6) Lab 6 - unordered_map\n"
		<< "7) Lab 7 - BST\n"
		<< "8) Lab 8 - Huffman compression\n"
		<< "0) Exit\n\n";
		// << "T) Toggle verbose mode " << (!verboseMode ? "on" : "off") << "\n";
}

// Run the main loop
void TestHarness::Run() {
	// Variables
	char choice = -1;
	bool exitLoop = false;



	// Main menu loop	
	while (!exitLoop) {

		// Clear the screen
		system("cls");

		DisplayMenu();

		// Input validation
		std::cout << "Lab Selection: ";
		std::cin >> choice;
		std::cin.clear();
		std::cin.ignore(INT_MAX, '\n');

		choice = toupper(choice);

		if (EXIT == choice)
			break;

		system("cls");
		switch (choice) {
		case LAB1:
#if LAB_1
			UnitTests_Lab1::FullBattery();
#else 
			std::cout << "LAB_1 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB2:
#if LAB_2
			UnitTests_Lab2::FullBattery();
#else
			std::cout << "LAB_2 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB3:
#if LAB_3
			UnitTests_Lab3::FullBattery();
#else
			std::cout << "LAB_3 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB4:
#if LAB_4
			UnitTests_Lab4::FullBattery();
#else
			std::cout << "LAB_4 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB5:
#if LAB_5
			UnitTests_Lab5::FullBattery();
#else
			std::cout << "LAB_5 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB6:
#if LAB_6
			UnitTests_Lab6::FullBattery();
#else
			std::cout << "LAB_6 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB7:
#if LAB_7
			UnitTests_Lab7::FullBattery();
#else
			std::cout << "LAB_7 #define not turned on\n";
#endif
			system("pause");
			break;
		case LAB8:
#if LAB_8
			UnitTests_Lab8::FullBattery();
#else
			std::cout << "LAB_8 #define not turned on\n";
#endif
			system("pause");
			break;
		case VERBOSE:
			ToggleVerboseMode();
			break;
		default:
			std::cout << "Invalid selection";
			break;
		}
	}
}