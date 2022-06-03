/*
File:			UnitTests_Lab3.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		09.19.2021
Last Modified:	09.19.2021
Purpose:		Declaration of Lab3 Unit Tests for DList
Notes:			Property of Full Sail University
*/

#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\\DList.h"

class UnitTests_Lab3 {
#if LAB_3
public:
	using List = DList<int>;
	using Node = List::Node;
	using Iterator = List::Iterator;

	// Runs all active unit tests
	static void FullBattery();

	// Protection in case pointers are still set to -1
	static void ListNegativeOneProtection(List& _list);

	// Test list for use with several unit tests
	static void CreateList(List& _list, std::vector<Node*>& _nodes, size_t _numNodes);

	// Clean up memory allocated within unit tests
	static void CleanList(std::vector<Node*> _nodes, List& _list);

#pragma region Test - List Default Constructor
	static void Battery_ListDefaultConstructor();

	static FailResult Fail_ListDefaultConstructor_HeadIsNotNull();
	static FailResult Fail_ListDefaultConstructor_TailIsNotNull();
	static FailResult Fail_ListDefaultConstructor_SizeIsNotZero();
	static FailResult Fail_ListDefaultConstructor_MemoryIsAllocated();

	static bool Pass_ListDefaultConstructor_HeadIsNull();
	static bool Pass_ListDefaultConstructor_TailIsNull();
	static bool Pass_ListDefaultConstructor_SizeIsZero();
	static bool Pass_ListDefaultConstructor_NoMemoryIsAllocated(); 
#pragma endregion

#pragma region Test - Node Constructor With Defaults
	static void Battery_NodeConstructorWithDefaults();

	static FailResult Fail_NodeConstructorWithDefaults_DataIsNotCorrectValue();
	static FailResult Fail_NodeConstructorWithDefaults_NextIsNotNull();
	static FailResult Fail_NodeConstructorWithDefaults_PrevIsNotNull();

	static bool Pass_NodeConstructorWithDefaults_DataIsCorrectValue();
	static bool Pass_NodeConstructorWithDefaults_NextIsNull();
	static bool Pass_NodeConstructorWithDefaults_PrevIsNull();
#pragma endregion

#pragma region Test - Node Constructor
	static void Battery_NodeConstructor();

	static FailResult Fail_NodeConstructor_DataIsIncorrectValue();
	static FailResult Fail_NodeConstructor_NextIsIncorrectAddress();
	static FailResult Fail_NodeConstructor_PrevIsIncorrectAddress();

	static bool Pass_NodeConstructor_DataIsCorrectValue();
	static bool Pass_NodeConstructor_NextIsCorrectAddress();
	static bool Pass_NodeConstructor_PrevIsCorrectAddress();
#pragma endregion
#endif

#pragma region Test - AddHead On Empty List
	static void Battery_AddHeadOnEmptyList();

	static FailResult Fail_AddHeadOnEmptyList_NoNodesAllocated();
	static FailResult Fail_AddHeadOnEmptyList_MoreThanOneNodeAllocated();
	static FailResult Fail_AddHeadOnEmptyList_HeadIsNotPointingToCreatedNode();
	static FailResult Fail_AddHeadOnEmptyList_TailIsNotPointingToCreatedNode();
	static FailResult Fail_AddHeadOnEmptyList_HeadAndTailAreNotPointingToSameNode();
	static FailResult Fail_AddheadOnEmptyList_HeadDataIsIncorrectValue();
	static FailResult Fail_AddHeadOnEmptyList_HeadPrevIsNotNull();
	static FailResult Fail_AddHeadOnEmptyList_TailNextIsNotNull();
	static FailResult Fail_AddHeadOnEmptyList_SizeIsNotOne();

	static bool Pass_AddHeadOnEmptyList_OnlyOneNodeAllocated();
	static bool Pass_AddHeadOnEmptyList_HeadIsPointingToCreatedNode();
	static bool Pass_AddHeadOnEmptyList_TailIsPointingToCreatedNode();
	static bool Pass_AddHeadOnEmptyList_HeadAndTailArePointingToSameNode();
	static bool Pass_AddheadOnEmptyList_HeadDataIsCorrectValue();
	static bool Pass_AddHeadOnEmptyList_HeadPrevIsNull();
	static bool Pass_AddHeadOnEmptyList_TailNextIsNull();
	static bool Pass_AddHeadOnEmptyList_SizeIsOne();
#pragma endregion

#pragma region Test - AddHead On Non-Empty List
	static void Battery_AddHeadOnNonEmptyList();

	static FailResult Fail_AddHeadOnNonEmptyList_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_AddHeadOnNonEmptyList_HeadIsNotPointingToCreatedNode();
	static FailResult Fail_AddHeadOnNonEmptyList_HeadDataIsIncorrectValue();
	static FailResult Fail_AddHeadOnNonEmptyList_HeadPrevIsNotNull();
	static FailResult Fail_AddHeadOnNonEmptyList_HeadNextIsNotPointingToOldHead();
	static FailResult Fail_AddHeadOnNonEmptyList_OldHeadsPrevIsNotPointingToCreatedNode();
	static FailResult Fail_AddHeadOnNonEmptyList_TailAddressIsChanged();
	static FailResult Fail_AddHeadOnNonEmptyList_SizeIsNotIncremented();

	static bool Pass_AddHeadOnNonEmptyList_CorrectAmountOfMemoryAllocated();
	static bool Pass_AddHeadOnNonEmptyList_HeadIsPointingToCreatedNode();
	static bool Pass_AddHeadOnNonEmptyList_HeadDataIsCorrectValue();
	static bool Pass_AddHeadOnNonEmptyList_HeadPrevIsNull();
	static bool Pass_AddHeadOnNonEmptyList_HeadNextIsPointingToOldHead();
	static bool Pass_AddHeadOnNonEmptyList_OldHeadsPrevIsPointingToCreatedNode();
	static bool Pass_AddHeadOnNonEmptyList_TailAddressIsNotChanged();
	static bool Pass_AddHeadOnNonEmptyList_SizeIsIncremented();
#pragma endregion

#pragma region Test - AddTail On Empty List
	static void Battery_AddTailOnEmptyList();

	static FailResult Fail_AddTailOnEmptyList_NoNodesAllocated();
	static FailResult Fail_AddTailOnEmptyList_MoreThanOneNodeAllocated();
	static FailResult Fail_AddTailOnEmptyList_HeadIsNotPointingToCreatedNode();
	static FailResult Fail_AddTailOnEmptyList_TailIsNotPointingToCreatedNode();
	static FailResult Fail_AddTailOnEmptyList_HeadAndTailAreNotPointingToSameNode();
	static FailResult Fail_AddTailOnEmptyList_TailDataIsIncorrectValue();
	static FailResult Fail_AddTailOnEmptyList_HeadPrevIsNotNull();
	static FailResult Fail_AddTailOnEmptyList_TailNextIsNotNull();
	static FailResult Fail_AddTailOnEmptyList_SizeIsNotOne();

	static bool Pass_AddTailOnEmptyList_OnlyOneNodeAllocated();
	static bool Pass_AddTailOnEmptyList_HeadIsPointingToCreatedNode();
	static bool Pass_AddTailOnEmptyList_TailIsPointingToCreatedNode();
	static bool Pass_AddTailOnEmptyList_HeadAndTailArePointingToSameNode();
	static bool Pass_AddTailOnEmptyList_TailDataIsCorrectValue();
	static bool Pass_AddTailOnEmptyList_HeadPrevIsNull();
	static bool Pass_AddTailOnEmptyList_TailNextIsNull();
	static bool Pass_AddTailOnEmptyList_SizeIsOne();
#pragma endregion

#pragma region Test - AddTail On Non-Empty List
	static void Battery_AddTailOnNonEmptyList();

	static FailResult Fail_AddTailOnNonEmptyList_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_AddTailOnNonEmptyList_TailIsNotPointingToCreatedNode();
	static FailResult Fail_AddTailOnNonEmptyList_TailDataIsIncorrectValue();
	static FailResult Fail_AddTailOnNonEmptyList_TailNextIsNotNull();
	static FailResult Fail_AddTailOnNonEmptyList_TailPrevIsNotPointingToOldTail();
	static FailResult Fail_AddTailOnNonEmptyList_OldTailsPrevIsNotPointingToCreatedNode();
	static FailResult Fail_AddTailOnNonEmptyList_HeadAddressIsChanged();
	static FailResult Fail_AddTailOnNonEmptyList_SizeIsNotIncremented();

	static bool Pass_AddTailOnNonEmptyList_CorrectAmountOfMemoryAllocated();
	static bool Pass_AddTailOnNonEmptyList_TailIsPointingToCreatedNode();
	static bool Pass_AddTailOnNonEmptyList_TailDataIsCorrectValue();
	static bool Pass_AddTailOnNonEmptyList_TailNextIsNull();
	static bool Pass_AddTailOnNonEmptyList_TailPrevIsPointingToOldTail();
	static bool Pass_AddTailOnNonEmptyList_OldTailsPrevIsPointingToCreatedNode();
	static bool Pass_AddTailOnNonEmptyList_HeadAddressIsNotChanged();
	static bool Pass_AddTailOnNonEmptyList_SizeIsIncremented();
#pragma endregion

#pragma region Test - Clear
	static void Battery_Clear();

	static FailResult Fail_Clear_AllNodesAreNotDeleted();
	static FailResult Fail_Clear_HeadIsNotNull();
	static FailResult Fail_Clear_TailIsNotNull();
	static FailResult Fail_Clear_SizeIsNotZero();

	static bool Pass_Clear_AllNodesAreDeleted();
	static bool Pass_Clear_HeadIsNull();
	static bool Pass_Clear_TailIsNull();
	static bool Pass_Clear_SizeIsZero();
#pragma endregion

#pragma region Test - Destructor
	static void Battery_Destructor();

	static FailResult Fail_Destructor_NotAllNodesAreDeleted();

	static bool Pass_Destructor_AllNodesAreDeleted();
#pragma endregion

#pragma region Test - Iterator Begin
	static void Battery_IteratorBegin();

	static FailResult Fail_IteratorBegin_AllocatesDynamicMemory();
	static FailResult Fail_IteratorBegin_CurrIsNotPointingToHead();

	static bool Pass_IteratorBegin_CurrIsPointingToHead();
#pragma endregion

#pragma region Test - Iterator End
	static void Battery_IteratorEnd();

	static FailResult Fail_IteratorEnd_AllocatedDynamicMemory();
	static FailResult Fail_IteratorEnd_CurrIsNotPointingToNull();
	
	static bool Pass_IteratorEnd_CurrIsPointingToNull();
#pragma endregion

#pragma region Test - Iterator Increment Pre-Fix
	static void Battery_IteratorIncrementPreFix();

	static FailResult Fail_IteratorIncrementPreFix_CurrIsNotPointingToNextNode();
	static FailResult Fail_IteratorIncrementPreFix_DidNotReturnIteratorToNextNode();

	static bool Pass_IteratorIncrementPreFix_CurrIsPointingToNextNode();
	static bool Pass_IteratorIncrementPreFix_ReturnedIteratorToNextNode();
#pragma endregion

#pragma region Test - Iterator Increment Post-Fix
	static void Battery_IteratorIncrementPostFix();

	static FailResult Fail_IteratorIncrementPostFix_CurrIsNotPointingToNextNode();
	static FailResult Fail_IteratorIncrementPostFix_ReturnedIteratorIsNotPointingToOriginalNode();

	static bool Pass_IteratorIncrementPostFix_CurrIsPointingToNextNode();
	static bool Pass_IteratorIncrementPostFix_ReturnedIteratorIsPointingToOriginalNode();
#pragma endregion

#pragma region Test - Iterator Decrement Pre-Fix
	static void Battery_IteratorDecrementPreFix();

	static FailResult Fail_IteratorDecrementPreFix_CurrIsNotPointingToPrevNode();
	static FailResult Fail_IteratorDecrementPreFix_DidNotReturnIteratorToPrevNode();

	static bool Pass_IteratorDecrementPreFix_CurrIsPointingToPrevNode();
	static bool Pass_IteratorDecrementPreFix_ReturnedIteratorToPrevNode();
#pragma endregion

#pragma region Test - Iterator Decrement Post-Fix
	static void Battery_IteratorDecrementPostFix();

	static FailResult Fail_IteratorDecrementPostFix_CurrIsNotPointingToPrevNode();
	static FailResult Fail_IteratorDecrementPostFix_ReturnedIteratorIsNotPointingToOriginalNode();

	static bool Pass_IteratorDecrementPostFix_CurrIsPointingToPrevNode();
	static bool Pass_IteratorDecrementPostFix_ReturnedIteratorIsPointingToOriginalNode();
#pragma endregion

#pragma region Test - Iterator Dereference
	static void Battery_IteratorDereference();

	static FailResult Fail_IteratorDereferenceDoesNotReturnData();

	static bool Pass_IteratorDereference_ReturnsData();
#pragma endregion

#pragma region Test - Insert On Empty List
	static void Battery_InsertOnEmptyList();

	static FailResult Fail_InsertOnEmptyList_NoNodesAreAllocated();
	static FailResult Fail_InsertOnEmptyList_MoreThanOneNodeAllocated();
	static FailResult Fail_InsertOnEmptyList_HeadIsNotPointingToCreatedNode();
	static FailResult Fail_InsertOnEmptyList_TailIsNotPointingToCreatedNode();
	static FailResult Fail_InsertOnEmptyList_HeadAndTailAreNotPointingToSameNode();
	static FailResult Fail_InsertOnEmptyList_HeadDataIsNotCorrectValue();
	static FailResult Fail_InsertOnEmptyList_HeadPrevIsNotNull();
	static FailResult Fail_InsertOnEmptyList_TailNextIsNotNull();
	static FailResult Fail_InsertOnEmptyList_IteratorIsNotPointingToInsertedNode();
	static FailResult Fail_InsertOnEmptyList_SizeIsNotOne();

	static bool Pass_InsertOnEmptyList_OnlyOneNodeAllocated();
	static bool Pass_InsertOnEmptyList_HeadIsPointingToCreatedNode();
	static bool Pass_InsertOnEmptyList_TailIsPointingToCreatedNode();
	static bool Pass_InsertOnEmptyList_HeadAndTailArePointingToSameNode();
	static bool Pass_InsertOnEmptyList_HeadDataIsCorrectValue();
	static bool Pass_InsertOnEmptyList_HeadPrevIsNull();
	static bool Pass_InsertOnEmptyList_TailNextIsNull();
	static bool Pass_InsertOnEmptyList_IteratorIsPointingToInsertedNode();
	static bool Pass_InsertOnEmptyList_SizeIsOne();
#pragma endregion

#pragma region Test - Insert At Head
	static void Battery_InsertAtHead();

	static FailResult Fail_InsertAtHead_NoNodesAreAllocated();
	static FailResult Fail_InsertAtHead_MoreThanOneNodeAllocated();
	static FailResult Fail_InsertAtHead_HeadIsNotPointingToCreatedNode();
	static FailResult Fail_InsertAtHead_HeadDataIsIncorrectValue();
	static FailResult Fail_InsertAtHead_HeadNextIsNotPointingToOldHead();
	static FailResult Fail_InsertAtHead_HeadPrevIsNotNull();
	static FailResult Fail_InsertAtHead_ReturnedIteratorIsNotPointingToInsertedNode();
	static FailResult Fail_InsertAtHead_SizeIsNotIncremented();

	static bool Pass_InsertAtHead_OnlyOneNodeAllocated();
	static bool Pass_InsertAtHead_HeadIsPointingToCreatedNode();
	static bool Pass_InsertAtHead_HeadDataIsCorrectValue();
	static bool Pass_InsertAtHead_HeadNextIsPointingToOldHead();
	static bool Pass_InsertAtHead_HeadPrevIsNull();
	static bool Pass_InsertAtHead_ReturnedIteratorIsPointingToInsertedNode();
	static bool Pass_InsertAtHead_SizeIsIncremented();
#pragma endregion

#pragma region Test - Insert On Non-Empty List
	static void Battery_InsertOnNonEmptyList();

	static FailResult Fail_InsertOnNonEmptyList_NoNodesAreAllocated();
	static FailResult Fail_InsertOnNonEmptyList_MoreThanOneNodeAllocated();
	static FailResult Fail_InsertOnNonEmptyList_InsertedNodeDataIsIncorrectValue();
	static FailResult Fail_InsertOnNonEmptyList_InsertedNodeNextIsNotNextNode();
	static FailResult Fail_InsertOnNonEmptyList_InsertedNodePrevIsNotPrevNode();
	static FailResult Fail_InsertOnNonEmptyList_PrevNodesNextIsNotPointingToInsertedNode();
	static FailResult Fail_InsertOnNonEmptyList_NextNodesPrevIsNotPointingToInsertedNode();
	static FailResult Fail_InsertOnNonEmptyList_ReturnedIteratorIsNotPointingToInsertedNode();
	static FailResult Fail_InsertOnNonEmptyList_SizeIsNotIncremented();

	static bool Pass_InsertOnNonEmptyList_CorrectAmountOfMemoryAllocated();
	static bool Pass_InsertOnNonEmptyList_InsertedNodeDataIsCorrectValue();
	static bool Pass_InsertOnNonEmptyList_InsertedNodesNextIsNextNode();
	static bool Pass_InsertOnNonEmptyList_InsertedNodesPrevIsPrevNode();
	static bool Pass_InsertOnNonEmptyList_PrevNodesNextIsPointingToInsertedNode();
	static bool Pass_InsertOnNonEmptyList_NextNodesPrevIsPointingToInsertedNode();
	static bool Pass_InsertOnNonEmptyList_ReturnedIteratorIsPointingToInsertedNode();
	static bool Pass_InsertOnNonEmptyList_SizeIsIncremented();
#pragma endregion

#pragma region Test - Erase On Empty List
	static void Battery_EraseEmpty();

	static FailResult Fail_EraseEmpty_NodesAreAllocated();
	static FailResult Fail_EraseEmpty_HeadIsNotNull();
	static FailResult Fail_EraseEmpty_TailIsNotNull();
	static FailResult Fail_EraseEmpty_ReturnedIteratorIsNotNullPointer();

	static bool Pass_EraseEmpty_NoNodesAreAllocated();
	static bool Pass_EraseEmpty_HeadIsNull();
	static bool Pass_EraseEmpty_TailIsNull();
	static bool Pass_EraseEmpty_ReturnedIteratorIsNullPointer();
#pragma endregion

#pragma region Test - Erase Head
	static void Battery_EraseHead();

	static FailResult Fail_EraseHead_NoNodesAreDeleted();
	static FailResult Fail_EraseHead_MoreThanOneNodeIsDeleted();
	static FailResult Fail_EraseHead_MemoryIsAllocated();
	static FailResult Fail_EraseHead_HeadIsNotUpdatedToNextNode();
	static FailResult Fail_EraseHead_HeadsPrevIsNotNull();
	static FailResult Fail_EraseHead_ReturnedIteratorIsNotUpdatedToNewHead();
	static FailResult Fail_EraseHead_SizeIsNotDecremented();

	static bool Pass_EraseHead_OneNodeIsDeleted();
	static bool Pass_EraseHead_HeadIsUpdatedToNextNode();
	static bool Pass_EraseHead_HeadsPrevIsNull();
	static bool Pass_EraseHead_ReturnedIteratorIsUpdatedToNewHead();
	static bool Pass_EraseHead_SizeIsDecremented();
#pragma endregion

#pragma region Test - Erase Tail
	static void Battery_EraseTail();

	static FailResult Fail_EraseTail_NoNodesAreDeleted();
	static FailResult Fail_EraseTail_MoreThanOneNodeIsDeleted();
	static FailResult Fail_EraseTail_MemoryIsAllocated();
	static FailResult Fail_EraseTail_TailIsNotUpdatedToPrevNode();
	static FailResult Fail_EraseTail_TailsNextIsNotNull();
	static FailResult Fail_EraseTail_ReturnedIteratorIsNotANullPointer();
	static FailResult Fail_EraseTail_SizeIsNotDecremented();

	static bool Pass_EraseTail_OneNodeIsDeleted();
	static bool Pass_EraseTail_TailIsUpdatedToPrevNode();
	static bool Pass_EraseTail_TailsNextIsNull();
	static bool Pass_EraseTail_ReturnedIteratorIsUpdatedToNullPointer();
	static bool Pass_EraseTail_SizeIsDecremented();
#pragma endregion

#pragma region Test - Erase Middle
	static void Battery_EraseMiddle();

	static FailResult Fail_EraseMiddle_NoNodesAreDeleted();
	static FailResult Fail_EraseMiddle_MoreThanOneNodeIsDeleted();
	static FailResult Fail_EraseMiddle_MemoryIsAllocated();
	static FailResult Fail_EraseMiddle_ReturnedIteratorIsNotUpdatedToNextNode();
	static FailResult Fail_EraseMiddle_PrevNodesNextIsNotPointingToNodeAfterErasedNode();
	static FailResult Fail_EraseMiddle_NextNodesPrevIsNotPointingToNodeBeforeErasedNode();
	static FailResult Fail_EraseMiddle_SizeIsNotDecremented();

	static bool Pass_EraseMiddle_OneNodeIsDeleted();
	static bool Pass_EraseMiddle_ReturnedIteratorIsUpdatedToNextNode();
	static bool Pass_EraseMiddle_PrevNodesNextIsPointingToNodeAfterErasedNode();
	static bool Pass_EraseMiddle_NextNodesPrevIsPointingToNodeBeforeErasedNode();
	static bool Pass_EraseMiddle_SizeIsDecremented();
#pragma endregion

#pragma region Test - Assignment Operator
	static void Battery_AssignmentOperator();

	static FailResult Fail_AssignmentOperator_NoSelfAssignmentCheck();
	static FailResult Fail_AssignmentOperator_NodesAreNotDeleted();
	static FailResult Fail_AssignmentOperator_NotEnoughMemoryAllocated();
	static FailResult Fail_AssignmentOperator_DifferentNumberOfNodes();
	static FailResult Fail_AssignmentOperator_SameAddressesAsArgument();
	static FailResult Fail_AssignmentOperator_ValuesAreNotTheSameForwards();
	static FailResult Fail_AssignmentOperator_ValuesAreNotTheSameBackwards();
	static FailResult Fail_AssignmentOperator_SizeIsNotTheSame();

	static bool Pass_AssignmentOperator_HasSelfAssignmentCheck();
	static bool Pass_AssignmentOperator_CorrectAmountOfMemoryAllocated();
	static bool Pass_AssignmentOperator_DifferentAddressesThanArgument();
	static bool Pass_AssignmentOperator_ValuesAreTheSameForwards();
	static bool Pass_AssignmentOperator_ValuesAreTheSameBackwards();
	static bool Pass_AssignmentOperator_SizeIsTheSame();
#pragma endregion

#pragma region Test - Copy Constructor
	static void Battery_CopyConstructor();

	static FailResult Fail_CopyConstructor_NotEnoughMemoryAllocated();
	static FailResult Fail_CopyConstructor_DifferentNumberOfNodes();
	static FailResult Fail_CopyConstructor_SameAddressesAsArgument();
	static FailResult Fail_CopyConstructor_ValuesAreNotTheSameForwards();
	static FailResult Fail_CopyConstructor_ValuesAreNotTheSameBackwards();
	static FailResult Fail_CopyConstructor_SizeIsNotTheSame();

	static bool Pass_CopyConstructor_CorrectAmountOfMemoryAllocated();
	static bool Pass_CopyConstructor_DifferentAddressesThanArgument();
	static bool Pass_CopyConstructor_ValuesAreTheSameForwards();
	static bool Pass_CopyConstructor_ValuesAreTheSameBackwards();
	static bool Pass_CopyConstructor_SizeIsTheSame();
#pragma endregion
};