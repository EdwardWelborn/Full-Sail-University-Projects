// Lab6.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
#include "BaseAccount.h"
#include "CheckingAccount.h"
#include "SavingsAccount.h"
#include "CreditAccount.h"
#include "Helper.h"

// Global Declarations
int userChoice = 0;
int accountSelection = 0;
int subMenuChoice = 0;
void MainMenu();
void SubMenu(const char strMessage[25]);


int main()
{
	CheckingAccount* checking = new CheckingAccount;
	SavingsAccount* saving = new SavingsAccount;
	CreditAccount* credit = new CreditAccount;

	std::ifstream fin;
	fin.open("AccountBalances.txt");

	if (fin.is_open())
	{
		float temp;
		fin >> temp;
		fin.ignore(INT_MAX, '\n');
		checking->Deposit(temp);

		fin >> temp;
		fin.ignore(INT_MAX, '\n');
		saving->Deposit(temp);

		fin >> temp;
		fin.ignore(INT_MAX, '\n');
		credit->Deposit(temp);

		fin.close();
	}
	else
	{
		checking->Deposit(100);
		saving->Deposit(150);
		credit->Deposit(200);
	}

	bool isRunning = true;

	while (isRunning)
	{
		int action = 0;
		float amount = 0;
		system("cls");
		Helper::Header("  FunTimes Bank  ");
		MainMenu();

		switch (accountSelection)
		{
		case 1:
			SubMenu("Checking Account ");
			std::cout << "Balance: " << checking->GetBalance() << std::endl;

			switch (action)
			{
			case 1:
				amount = Helper::GetValidatedFloat("What Amount would you like to deposit: ");
				checking->Deposit(amount);
				system("cls");
				std::cout << "New balance: " << checking->GetBalance() << std::endl;
				Helper::Footer();
				break;

			case 2:
				amount = Helper::GetValidatedFloat("How much would you like to withdrawal: ");
				checking->Withdraw(amount);
				system("cls");
				std::cout << "New balance: " << checking->GetBalance() << std::endl;
				Helper::Footer();
				break;
			case 3:
				system("cls");
				break;
			}

			break;

		case 2:
			SubMenu("Savings Account ");
			std::cout << "Balance: " << saving->GetBalance() << std::endl;

			switch (action)
			{
			case 1:
				amount = Helper::GetValidatedFloat("What Amount would you like to deposit: ");
				saving->Deposit(amount);
				system("cls");
				std::cout << "New balance: " << saving->GetBalance() << std::endl;
				Helper::Footer();
				break;

			case 2:
				amount = Helper::GetValidatedFloat("How much would you like to withdrawal: ");
				saving->Withdraw(amount);
				system("cls");
				std::cout << "New balance: " << saving->GetBalance() << std::endl;
				Helper::Footer();
				break;
			case 3:
				system("cls");
				break;
			}

			break;

		case 3:
			SubMenu("Credit Account ");
			std::cout << "Balance: " << credit->GetBalance() << std::endl;
			switch (action)
			{
			case 1:
				amount = Helper::GetValidatedFloat("What Amount would you like to deposit:  ");
				credit->Deposit(amount);
				system("cls");
				std::cout << "New balance: " << credit->GetBalance() << std::endl;
				Helper::Footer();
				break;

			case 2:
				amount = Helper::GetValidatedFloat("How much would you like to withdrawal: ");
				credit->Withdraw(amount);
				system("cls");
				std::cout << "New balance: " << credit->GetBalance() << std::endl;
				Helper::Footer();
				break;
			case 3:
				system("cls");
				break;
			}
		case 4:
			system("cls");
			isRunning = false;
			break;

		}
	}

	Helper::Footer();
	std::ofstream fout;
	fout.open("AccountBalances.txt", 'w');

	if (fout.is_open())
	{
		fout << checking->GetBalance() << std::endl;
		fout << saving->GetBalance() << std::endl;
		fout << credit->GetBalance() << std::endl;

		fout.close();
	}

	delete checking;
	delete saving;
	delete credit;
}

void MainMenu()
{
	std::cout << "Main Menu\n" << std::endl;
	std::cout << "1.. Checking" << std::endl;
	std::cout << "2.. Savings" << std::endl;
	std::cout << "3.. Credit" << std::endl;
	std::cout << "4.. Exit Program\n" << std::endl;
	accountSelection = Helper::GetValidatedInt("Which account would you like to access: ", 1, 4);
	// system("cls");
}

void SubMenu(const char strMessage[25])
{
	system("cls");
	Helper::Header(strMessage);
	std::cout << strMessage << "Menu\n" << std::endl;
	std::cout << "1.. Deposit" << std::endl;
	std::cout << "2.. Withdraw" << std::endl;
	std::cout << "3.. Main Menu\n" << std::endl;
	subMenuChoice = Helper::GetValidatedInt("Please Select: ", 1, 3);
	// system("cls");
}
