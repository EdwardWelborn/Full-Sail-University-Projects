/*
File:			UnitTests_Lab6.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		12.31.2021
Last Modified:	12.31.2021
Purpose:		Declaration of Lab6 Unit Tests for unordered_map
Notes:			Property of Full Sail University
*/

// Header protection
#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\\Lab6.h"

class UnitTests_Lab6 {
#if LAB_6
public:

	static std::string mTempFilename;

	// Runs all active unit tests
	static void FullBattery();

#pragma region Test - Populate Letter Values
	static void Battery_PopulateLetterValues();

	static FailResult Fail_PopulateLetterValues_CopiesAddressInsteadOfValues();
	static FailResult Fail_PopulateLetterValues_OnlyCopiesFirstElement();
	static FailResult Fail_PopulateLetterValues_DoesNotCopyAllElements();

	static bool Pass_PopulateLetterValues_AllElementsAreCopied();
#pragma endregion

#pragma region Test - Get Letter Value
	static void Battery_GetLetterValue();

	static FailResult Fail_GetLetterValue_DoesNotOffsetToGetToCorrectIndex();
	static FailResult Fail_GetLetterValue_DoesNotReturnCorrectValue();
	static FailResult Fail_GetLetterValue_UsesLoop();

	static bool Pass_GetLetterValue_ReturnsCorrectValue();
#pragma endregion

#pragma region Test - Get Word Value
	static void Battery_GetWordValue();

	static FailResult Fail_GetWordValue_DoesNotLoopThroughWord();
	static FailResult Fail_GetWordValue_DoesNotCallGetLetterValueOrUseOffset();
	static FailResult Fail_GetWordValue_DoesNotReturnCorrectValue();

	static bool Pass_GetWordValue_ReturnsCorrectValue();
#pragma endregion

#pragma region Test - Create Pair
	static void Battery_CreatePair();

	static FailResult Fail_CreatePair_AllocatesDynamicMemory();
	static FailResult Fail_CreatePair_FirstDoesNotStoreValue();
	static FailResult Fail_CreatePair_SecondDoesNotStoreCorrectValue();
	
	static bool Pass_CreatePair_FirstStoresCorrectValue();
	static bool Pass_CreatePair_SecondStoresCorrectValue();
#pragma endregion

#pragma region Test - Load File
	static void Battery_LoadFile();

	static FailResult Fail_LoadFile_MapIsIncorrectSize();
	static FailResult Fail_LoadFile_WordValuesAreIncorrect();

	static bool Pass_LoadFile_MapIsCorrectSize();
	static bool Pass_LoadFile_WordValuesAreCorrect();
#pragma endregion

#pragma region Test - Find Word Score
	static void Battery_FindWordScore();

	static FailResult Fail_FindWordScore_DoesNotCallFind();
	static FailResult Fail_FindWordScore_ReturnsIncorrectValueForFoundWord();
	static FailResult Fail_FindWordScore_ReturnsIncorrectValueForWordNotFound();

	static bool Pass_FindWordScore_CallsFind();
	static bool Pass_FindWordScore_ReturnsCorrectValueForFoundWord();
	static bool Pass_FindWordScore_ReturnsCorrectValueForWordNotFound();
#pragma endregion
#endif
};