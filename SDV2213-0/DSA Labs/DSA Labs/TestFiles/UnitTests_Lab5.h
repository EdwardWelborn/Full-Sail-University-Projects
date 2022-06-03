/*
File:			UnitTests_Lab5.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		09.19.2021
Last Modified:	09.19.2021
Purpose:		Declaration of Lab5 Unit Tests for Dictionary
Notes:			Property of Full Sail University
*/

// Header protection
#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\\Dictionary.h"

class UnitTests_Lab5 {
#if LAB_5
public:
	using Dict = Dictionary<float, float>;
	using Pair = Dict::Pair;

	struct DictionaryWithValues {
		Dict* dict;
		float* values;
		size_t size;

		void CleanUp();
	};

	// Runs all active unit tests
	static void FullBattery();

	static unsigned int Hash(const float& _f);
	static DictionaryWithValues CreateDictionary();

#pragma region Test - Pair Constructor
	static void Battery_PairConstructor();

	static FailResult Fail_PairConstructor_KeyIsIncorrectValue();
	static FailResult Fail_PairConstructor_ValueIsIncorrectValue();

	static bool Pass_PairConstructor_KeyIsCorrectValue();
	static bool Pass_PairConstructor_ValueIsCorrectValue();
#pragma endregion

#pragma region Test - Dictionary Constructor
	static void Battery_DictionaryConstructor();

	static FailResult Fail_DictionaryConstructor_TableIsNotAllocated();
	static FailResult Fail_DictionaryConstructor_TableContainsIncorrectNumberOfLists();
	static FailResult Fail_DictionaryConstructor_NumBucketsIsIncorrectValue();
	static FailResult Fail_DictionaryConstructor_HashFuncIsNotPointingToValidFunction();

	static bool Pass_DictionaryConstructor_TableContainsCorrectNumberOfLists();
	static bool Pass_DictionaryConstructor_NumBucketsIsCorrectValue();
	static bool Pass_DictionaryConstructor_HashFuncIsPointingToValidFunction();
#pragma endregion 

#pragma region Test - Destructor
	static void Battery_Destructor();

	static FailResult Fail_Destructor_MemoryIsNotDeleted();
	static FailResult Fail_Destructor_NotDeletedWithBrackets();

	static bool Pass_Destructor_MemoryIsDeleted();
#pragma endregion

#pragma region Test - Clear
	static void Battery_Clear();

	static FailResult Fail_Clear_CallsDelete();
	static FailResult Fail_Clear_NumBucketsIsChanged();
	static FailResult Fail_Clear_HashFuncIsChanged();
	static FailResult Fail_Clear_UsesArrowOperatorOnTable();
	static FailResult Fail_Clear_TableHasNotBeenCleared();

	static bool Pass_Clear_MemoryIsNotDeleted();
	static bool Pass_Clear_NumBucketsIsNotChanged();
	static bool Pass_Clear_HashFuncIsNotChanged();
	static bool Pass_Clear_TableHasBeenCleared();
#pragma endregion


#pragma region Test - Insert New Pair
	static void Battery_Insert_NewKey();

	static FailResult Fail_Insert_NewKey_UsesArrowOperatorOnTable();
	static FailResult Fail_Insert_NewKey_HashFuncIsNotCalled();
	static FailResult Fail_Insert_NewKey_MemoryHasBeenAllocated();
	static FailResult Fail_Insert_NewKey_PairIsNotInsertedIntoCorrectBucket();
	static FailResult Fail_Insert_NewKey_MoreThanOnePairIsAddedToBucket();
	static FailResult Fail_Insert_NewKey_PairHasIncorrectValue();

	static bool Pass_Insert_NewKey_PairIsInsertedIntoCorrectBucket();
	static bool Pass_Insert_NewKey_OnlyOnePairIsAddedToBucket();
	static bool Pass_Insert_NewKey_PairHasCorrectValue();

#pragma endregion

#pragma region Test - Insert Overwrite Existing Key
	static void Battery_Insert_OverwriteExistingKey();

	static FailResult Fail_Insert_OverwriteExistingKey_UsesArrowOperatorOnTable();
	static FailResult Fail_Insert_OverwriteExistingKey_HashFuncIsNotCalled();
	static FailResult Fail_Insert_OverwriteExistingKey_MemoryHasBeenAllocated();
	static FailResult Fail_Insert_OverwriteExistingKey_DuplicateKeyIsAddedToBucket();
	static FailResult Fail_Insert_OverwriteExistingKey_PairValueIsNotUpdated();

	static bool Pass_Insert_OverwriteExistingKey_NoPairsAddedToBucket();
	static bool Pass_Insert_OverwriteExistingKey_PairHasCorrectValue();
#pragma endregion

#pragma region Test - Find (Key Exists)
	static void Battery_Find_KeyExists();
	
	static FailResult Fail_Find_KeyExists_UsesArrowOperatorOnTable();
	static FailResult Fail_Find_KeyExists_HashFuncIsNotCalled();
	static FailResult Fail_Find_KeyExists_IncorrectAddressReturned();

	static bool Pass_Find_KeyExists_CorrectAddressReturned();
#pragma endregion

#pragma region Test - Find (Key Does not Exist)
	static void Battery_Find_KeyDoesNotExist();

	static FailResult Fail_Find_KeyDoesNotExist_UsesArrowOperatorOnTable();
	static FailResult Fail_Find_KeyDoesNotExist_HashFuncIsNotCalled();
	static FailResult Fail_Find_KeyDoesNotExist_NullPointerIsNotReturned();

	static bool Pass_Find_KeyDoesNotExist_NullPointerIsReturned();
#pragma endregion

#pragma region Test - Remove (Key Exists)
	static void Battery_Remove_KeyExists();

	static FailResult Fail_Remove_KeyExists_UsesArrowOperatorOnTable();
	static FailResult Fail_Remove_KeyExists_HashFuncIsNotCalled();
	static FailResult Fail_Remove_KeyExists_BucketIsClearedInsteadOfRemovingSinglePair();
	static FailResult Fail_Remove_KeyExists_PairIsNotRemovedFromBucket();
	static FailResult Fail_Remove_KeyExists_ReturnsFalse();

	static bool Pass_Remove_KeyExists_PairIsRemovedFromBucket();
	static bool Pass_Remove_KeyExists_ReturnsTrue();
#pragma endregion

#pragma region Test - Remove (Key Does not Exist)
	static void Battery_Remove_KeyDoesNotExist();
	
	static FailResult Fail_Remove_KeyDoesNotExist_UsesArrowOperatorOnTable();
	static FailResult Fail_Remove_KeyDoesNotExist_HashFuncIsNotCalled();
	static FailResult Fail_Remove_KeyDoesNotExist_BucketIsCleared();
	static FailResult Fail_Remove_KeyDoesNotExist_ReturnsTrue();

	static bool Pass_Remove_KeyDoesNotExist_NoPairsAreRemovedFromBucket();
	static bool Pass_Remove_KeyDoesNotExist_ReturnsFalse();
#pragma endregion

#pragma region Test - Assignment Operator
	static void Battery_AssignmentOperator();

	static FailResult Fail_AssignmentOperator_NoSelfAssignmentCheck();
	static FailResult Fail_AssignmentOperator_TableIsNotDeleted();
	static FailResult Fail_AssignmentOperator_TableIsShallowCopied();
	static FailResult Fail_AssignmentOperator_UsesArrowOperatorOnTable();
	static FailResult Fail_AssignmentOperator_ContentsOfAssignTableAreNotCopiedToInvokingObjectTable();
	static FailResult Fail_AssignmentOperator_NumBucketsIsNotCorrectValue();
	static FailResult Fail_AssignmentOperator_HashFuncIsNotCorrectValue();

	static bool Pass_Assignment_Operator_CorrectAmountOfMemoryAllocated();
	static bool Pass_Assignment_Operator_TableContainsCorrectData();
	static bool Pass_Assignment_Operator_NumBucketsIsCorrectValue();
	static bool Pass_Assignment_Operator_HashFuncIsCorrectValue();
#pragma endregion

#pragma region Test - Copy Constructor
	static void Battery_CopyConstructor();

	static FailResult Fail_CopyConstructor_TableIsShallowCopied();
	static FailResult Fail_CopyConstructor_UsesArrowOperatorOnTable();
	static FailResult Fail_CopyConstructor_ContentsOfAssignTableAreNotCopiedToInvokingObjectTable();
	static FailResult Fail_CopyConstructor_NumBucketsIsNotCorrectValue();
	static FailResult Fail_CopyConstructor_HashFuncIsNotCorrectValue();
	
	static bool Pass_Copy_Constructor_CorrectAmountOfMemoryAllocated();
	static bool Pass_Copy_Constructor_TableContainsCorrectData();
	static bool Pass_Copy_Constructor_NumBucketsIsCorrectValue();
	static bool Pass_Copy_Constructor_HashFuncIsCorrectValue();
#pragma endregion
#endif
};