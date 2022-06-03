/*
File:			UnitTests_Lab4.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		09.19.2021
Last Modified:	09.19.2021
Purpose:		Declaration of Lab4 Unit Tests for std::list
Notes:			Property of Full Sail University
*/

#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\\Lab4.h"

class UnitTests_Lab4 {
#if LAB_4
public:
	// Runs all active unit tests
	static void FullBattery();

#pragma region Test - Add Queue Ordering
	static void Battery_AddQueueOrdering();

	static FailResult Fail_AddQueueOrdering_NotAllValuesAddedToList();
	static FailResult Fail_AddQueueOrdering_TooManyValuesAddedToList();
	static FailResult Fail_AddQueueOrdering_IncorrectOrderOfValues();
	
	static bool Pass_AddQueueOrdering_CorrectNumberOfValues();
	static bool Pass_AddQueueOrdering_CorrectOrderOfValues();
#pragma endregion

#pragma region Test - Add Stack Ordering
	static void Battery_AddStackOrdering();
	
	static FailResult Fail_AddStackOrdering_NotAllValuesAddedToList();
	static FailResult Fail_AddStackOrdering_TooManyValuesAddedToList();
	static FailResult Fail_AddStackOrdering_IncorrectOrderOfValues();

	static bool Pass_AddStackOrdering_CorrectNumberOfValues();
	static bool Pass_AddStackOrdering_CorrectOrderOfValues();
#pragma endregion

#pragma region Test - Remove Queue Ordering
	static void Battery_RemoveQueueOrdering();

	static FailResult Fail_RemoveQueueOrderingMoreThanOneValueRemoved();
	static FailResult Fail_RemoveQueueOrderingNoValuesRemoved();
	static FailResult Fail_RemoveQueueOrderingIncorrectValueReturned();
	static FailResult Fail_RemoveQueueOrderingIncorrectValuesRemaining();

	static bool Pass_RemoveQueueOrdering_CorrectNumberOfValues();
	static bool Pass_RemoveQueueOrdering_CorrectValueReturned();
	static bool Pass_RemoveQueueOrdering_CorrectValuesRemaining();
#pragma endregion

#pragma region Test - Remove Stack Ordering
	static void Battery_RemoveStackOrdering();

	static FailResult Fail_RemoveStackOrderingMoreThanOneValueRemoved();
	static FailResult Fail_RemoveStackOrderingNoValuesRemoved();
	static FailResult Fail_RemoveStackOrderingIncorrectValueReturned();
	static FailResult Fail_RemoveStackOrderingIncorrectValuesRemaining();

	static bool Pass_RemoveStackOrdering_CorrectNumberOfValues();
	static bool Pass_RemoveStackOrdering_CorrectValueReturned();
	static bool Pass_RemoveStackOrdering_CorrectValuesRemaining();
#pragma endregion

#pragma region Test - Insert With Iterator
	static void Battery_InsertWithIterator();

	static FailResult InsertWithIterator_ValueNotAdded();
	static FailResult InsertWithIterator_ValueNotAddedAtCorrectLocation();

	static bool InsertWithIterator_ValueAddedAtCorrectLocation();
#pragma endregion

#pragma region Test - Insert With Index
	static void Battery_InsertWithIndex();

	static FailResult InsertWithIndex_ValueNotAdded();
	static FailResult InsertWithIndex_ValueNotAddedAtCorrectLocation();

	static bool InsertWithIndex_ValueAddedAtCorrectLocation();
#pragma endregion

#pragma region Test - Remove Decimal Values
	static void Battery_RemoveDecimalGreater();

	static FailResult Fail_RemoveDecimalGreaterFixed_NoValuesWereRemoved();
	static FailResult Fail_RemoveDecimalGreaterFixed_IncorrectNumberOfValuesAreRemoved();
	static FailResult Fail_RemoveDecimalGreaterFixed_IncorrectValuesRemoved();
	static FailResult Fail_RemoveDecimalGreaterFixed_IncorrectValueReturned();
	static FailResult Fail_RemoveDecimalGreaterRandom_IncorrectNumberOfValuesAreRemoved();
	static FailResult Fail_RemoveDecimalGreaterRandom_IncorrectValuesRemoved();
	static FailResult Fail_RemoveDecimalGreaterRandom_IncorrectValueReturned();

	static bool Pass_RemoveDecimalGreaterFixed_CorrectNumberOfValuesAreRemoved();
	static bool Pass_RemoveDecimalGreaterFixed_CorrectValuesRemoved();
	static bool Pass_RemoveDecimalGreaterFixed_CorrectValueReturned();\
	static bool Pass_RemoveDecimalGreaterRandom_CorrectNumberOfValuesAreRemoved();
	static bool Pass_RemoveDecimalGreaterRandom_CorrectValuesRemoved();
	static bool Pass_RemoveDecimalGreaterRandom_CorrectValueReturned();
#pragma endregion

#endif

};