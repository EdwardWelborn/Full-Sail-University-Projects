/*
File:			Lab2.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
	Student:

Created:		11.30.2020
Last Modified:	11.30.2020
Purpose:		Usage of the std::vector class
Notes:			Property of Full Sail University
*/

// Header protection

#pragma once

/***********/
/* Defines */
/***********/

/*
How to use:

	When working on a lab, turn that lab's #define from 0 to 1

		Example:	#define LAB_1	1

	When working on an individual unit test, turn that #define from 0 to 1

		Example:	#define DYNARRAY_DEFAULT_CTOR	1

NOTE: If the unit test is not on, that code will not be compiled!
*/

// Main toggle
#define LAB_2	1

// Individual unit test toggles
#define LAB2_PALINDROME_NUMBER		1
#define LAB2_FILL_FILE				1
#define LAB2_FILL_ARRAY				1
#define LAB2_CLEAR					1
#define LAB2_SORT_ASCENDING			1
#define LAB2_SORT_DESCENDING		1
#define LAB2_BRACKETS				1
#define LAB2_CONTAINS_TRUE			1
#define LAB2_CONTAINS_FALSE			1
#define LAB2_MOVE_PALINDROMES		1

/************/
/* Includes */
/************/
#include <string>
#include <vector>
#include <fstream>
#include <algorithm>
#include <iostream>

// Checks to see if a number is a palindrome (reads the same forwards and backwards)
//		An example of a palindrome word would be "racecar"
//
// In: _num			The number to check
//
// Return: True, if the number is a palindrome number
inline bool IsPalindromeNumber(unsigned int _num) {
	// TODO: Implement this function

	unsigned int number = _num; // variable to hold new number
	std::string temp;
	while (number > 0) {
		temp += std::to_string((number % 10)); // add the last digit to the string
		number /= 10; // decrement the number by 1 
	}
	number = std::stoi(temp); //copy new number from string back to original number

	if (number == _num) // are the values equal
		return true;
	else
		return false;
}

class DSA_Lab2
{
	friend class UnitTests_Lab2;	// Giving access to test code

private:

	std::vector<int> mValues;		// contains all of the values
	std::vector<int> mPalindromes;	// contains just the numbers that are palindromes (only used in MovePalindromes method)

public:

	// Fill out the mValues vector with the contents of the binary file
	//		First four bytes of the file are the number of ints in the file
	//
	// In:	_input		Name of the file to open
	void Fill(const char* _input) {
		// TODO: Implement this method

		std::ifstream binifl(_input, std::ios::binary); // open binary file

		int numOfValues; // initialize variable for 1st 4 bytes
		binifl.read((char*)&numOfValues, sizeof(int)); // read first 4 bytes to see how many ints total

		int value; // initialize variable to store each value read
		for (int i = 0; i < numOfValues; ++i) {
			binifl.read((char*)&value, sizeof(int)); // read the int
			mValues.push_back(value); // add int to vector
		}

		binifl.close(); // close the file
	}

	// Fill out the mValues vector with the contents of an array
	//
	// In:	_arr			The array of values
	//		_size			The number of elements in the array
	void Fill(const int* _arr, size_t _size) {
		// TODO: Implement this method

		for (int i = 0; i < _size; ++i)
			mValues.push_back(_arr[i]);
	}

	// Remove all elements from vector and decrease capacity to 0
	void Clear() {
		// TODO: Implement this method

		mValues.clear(); // erases all elements from vector
		mValues.shrink_to_fit(); // discards excess capacity
	}

	// Sort the vector 
//
// In:	_ascending		To sort in ascending order or not
//
// NOTE: Use the std::sort method in this implementation
	void Sort(bool _ascending) {
		// TODO: Implement this method

		if (_ascending) // check if we should sort
			std::sort(mValues.begin(), mValues.end()); // sort ascending
		else
			std::sort(mValues.rbegin(), mValues.rend()); // sort descending
	}

	// Get an individual element from the mValues vector
	int operator[](int _index) {
		// TODO: Implement this method

		return mValues.at(_index);
	}

	// Determine if a value is present in the vector
	// 
	// In:	_val		The value to find
	//
	// Return: True, if the value is present
	bool Contains(int _val) const {
		// TODO: Implement this method

		bool isTrue = false; // initialize variable to be returned - bool
		for (int i = 0; i < mValues.size(); i++) // loop through vector
			if (_val == mValues[i]) { // check if values are equal
				isTrue = true; // return true if value is present
				break;
			}
		return isTrue;
	}

	// Move all palindrome numbers from mValues vector to mPalindromes vector
	//
	// Pseudocode:
	//		iterate through the main values vector
	//			if the value is a palindrome
	//				add it to the palindrome vector
	//				remove it from the values vector
	void MovePalindromes() {
		// TODO: Implement this method

		for (std::vector<int>::iterator iter = mValues.begin(); iter != mValues.end(); ) { //iterate through vector
			if (IsPalindromeNumber((int)*iter) == true) { // check if palindrome
				mPalindromes.push_back(*iter); // add to vector if true
				iter = mValues.erase(iter); // erase from old vector & set iter to next pointer
			}
			else // if not not erase, increment iter
				++iter;
		}
	}
};