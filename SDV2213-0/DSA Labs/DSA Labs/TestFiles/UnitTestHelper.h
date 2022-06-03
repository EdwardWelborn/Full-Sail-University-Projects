/*
File:			UnitTestHelper.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		08.15.2021
Last Modified:	10.20.2021
Purpose:		Declarations of global functions used in all unit tests
Notes:			Property of Full Sail University

				DO NOT CHANGE ANY CODE IN THIS FILE
*/

/************/
/* Includes */
/************/
#include <vector>
#include <string>
#include <random>

#pragma once

#define PASS	1
#define FAIL	1

struct FailResult {
	bool check = false;
	std::string msg = "";
};

// Simplifies code in batteries
using PassVector = std::vector<bool(*)()>;
using FailVector = std::vector<FailResult(*)()>;

// Random number generator
extern std::mt19937 rng;

// Generate a random int type value
int RandomInt(int _min, int _max);

// Generate a random float type value
float RandomFloat(float _min, float _max);

// Creates a dynamic array of random values
// 
// In:	_numElements		The number of elements to allocate
//		_min				Minimum value for element
//		_max				Maximum value for element
// 
// Return: A dynamically allocated array
int* CreateRandomArray(size_t _numElements, int _min = INT_MIN, int _max = INT_MAX);

// Create a duplicate of a file
//		Used so that the original file does not get corrupted
//
// In:	_srcFile		The file to duplicate
//		_dstFileName	The name for the duplicated file
void CreateDuplicateFile(const char* _srcFile, const char* _dstFileName);

// Remove whitepspace from a string (in-place)
// In:	_str			String to remove whitespace from
void RemoveWhiteSpace(std::string& _str);

// Check to see if a file contains a particular line of code
//
// In:	_srcFile		The file to open
//		_searchStart	The area of the file to start searching from
//		_searchStop		The area of the file to stop searching
//		_searchCriteria	The code to search for
//
// Return: True, if the searchCriteria is found
bool SearchFile(const char* _srcFile, const std::string& _searchStart,
	const std::string& _searchStop, const std::string& _searchCriteria);

// Used to print out FAIL messages
//
// In:	_msg		The string to print (reason for failure)
void PrintMessage(const char* _msg);

// Used to print out SUCCESS message
void PrintMessage();

// Print out UNKNOWN error message for neither pass or fail
void PrintUnknownMessage();

// Perform a battery of unit tests
//
// In:	_msg		The message to display (the name of the unit test)
//		_failTests	vector containing all of the subtests for failure
//		_passTests	vector containing all of the subtests for passing
// 
// Return: True if all unit tests pass
void UnitTestBattery(const char* _msg, FailVector& _failTests, PassVector& _passTests);

