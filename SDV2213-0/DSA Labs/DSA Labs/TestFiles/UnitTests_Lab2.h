/*
File:			UnitTests_Lab2.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		08.30.2021
Last Modified:	10.23.2021
Purpose:		Declaration of Lab2 Unit Tests for Lab2 (vector)
Notes:			Property of Full Sail University
*/

#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\\Lab2.h"

class UnitTests_Lab2 {

public:
#if LAB_2

	static std::string mTempFilename;

	// Runs all active unit tests
	static void FullBattery();

#pragma region Test - Palindrome Number
	static void Battery_PalindromeNumber();

	static FailResult Fail_PalindromeNumber_IsPalindromeNumber();
	static FailResult Fail_PalindromeNumber_IsNotPalindromeNumber();

	static bool Pass_PalindromeNumber_IsPalindromeNumber();
	static bool Pass_PalindromeNumber_IsNotPalindromeNumber();
#pragma endregion

#pragma region Test - Fill From File
	static void Battery_FillVectorFromFile();

	static FailResult Fail_FillVectorFromFile_FilenameIsHardCoded();
	static FailResult Fail_FillVectorFromFile_DataNotAddedToVector();
	static FailResult Fail_FillVectorFromFile_FileHeaderNotRead();
	static FailResult Fail_FillVectorFromFile_IncorrectNumberOfValuesStored();
	static FailResult Fail_FillVectorFromFile_IncorrectValuesStored();

	static bool Pass_FillVectorFromFile_DataAddedToVector();
	static bool Pass_FillVectorFromFile_FileHeaderRead();
	static bool Pass_FillVectorFromFile_CorrectNumberOfValuesStored();
	static bool Pass_FillVectorFromFile_CorrectValuesStored();
#pragma endregion

#pragma region Test - Fill From Array
	static void Battery_FillVectorFromArray();

	static FailResult Fail_FillVectorFromArray_DataNotAddedToVector();
	static FailResult Fail_FillVectorFromArray_IncorrectNumberOfValuesStored();
	static FailResult Fail_FillVectorFromArray_IncorrectValuesStored();

	static bool Pass_FillVectorFromArray_DataAddedToVector();
	static bool Pass_FillVectorFromArray_CorrectNumberOfValuesStored();
	static bool Pass_FillVectorFromArray_CorrectValuesStored();
#pragma endregion

#pragma region Test - Clear
	static void Battery_VectorClear();

	static FailResult Fail_VectorClear_SizeIsNotZero();
	static FailResult Fail_VectorClear_CapacityisNotZero();

	static bool Pass_VectorClear_SizeIsZero();
	static bool Pass_VectorClear_CapacityIsZero();
#pragma endregion

#pragma region Test - Sort Ascending
	static void Battery_VectorSortAscending();

	static FailResult Fail_VectorSortAscending_DoesNotUseStdSort();
	static FailResult Fail_VectorSortAscending_ValuesAreNotSorted();

	static bool Pass_VectorSortAscending_UsesStdSort();
	static bool Pass_VectorSortAscending_ValuesAreSorted();
#pragma endregion

#pragma region Test - Sort Descending
	static void Battery_VectorSortDescending();

	static FailResult Fail_VectorSortDescending_DoesNotUseStdSort();
	static FailResult Fail_VectorSortDescending_ValuesAreNotSorted();

	static bool Pass_VectorSortDescending_UsesStdSort();
	static bool Pass_VectorSortDescending_ValuesAreSorted();
#pragma endregion

#pragma region Test - Operator []
	static void Battery_ArrayBracketOperator();

	static FailResult Fail_ArrayBracketOperator_DoesNotUseBracketOperatorOrAt();
	static FailResult Fail_ArrayBracketOperator_UsesForLoop();
	static FailResult Fail_ArrayBracketOperator_DoesNotReturnValueAtIndex();

	static bool Pass_ArrayBracketOperator_UsesBracketOperatorOrAt();
	static bool Pass_ArrayBracketOperator_ReturnsValueAtIndex();
#pragma endregion

#pragma region Test - Contains True
	static void Battery_ContainsTrue();

	static FailResult Fail_ContainsTrue_ReturnsFalseIfValueIsPresent();

	static bool Pass_ContainsTrue_ReturnsTrueIfValueIsPresent();
#pragma endregion

#pragma region Test - Contains False
	static void Battery_ContainsFalse();

	static FailResult Fail_ContainsTrue_ReturnsTrueIfValueIsNotPresent();

	static bool ContainsTrue_ReturnsTrueIfValueIsPresent();
#pragma endregion

#pragma region Test - Remove Palindromes
	static void Battery_MovePalindromes();

	static FailResult Fail_MovePalindromes_DoesNotEraseTwoPalindromesAtBegin();
	static FailResult Fail_MovePalindromes_DoesNotEraseTwoPalindromesAtEnd();
	static FailResult Fail_MovePalindromes_DoesNotEraseTwoPalindromesInMiddle();
	static FailResult Fail_MovePalindromes_IncorrectValuesAddedToPalindromesVector();
	static FailResult Fail_MovePalindromes_IncorrectValuesRemovedFromValuesVector();

	static bool Pass_MovePalindromes_EraseTwoPalindromesAtBegin();
	static bool Pass_MovePalindromes_EraseTwoPalindromesAtEnd();
	static bool Pass_MovePalindromes_EraseTwoPalindromesInMiddle();
	static bool Pass_MovePalindromes_CorrectValuesAddedToPalindromesVector();
	static bool Pass_MovePalindromes_CorrectValuesRemovedFromValuesVector();
#pragma endregion
#endif
};