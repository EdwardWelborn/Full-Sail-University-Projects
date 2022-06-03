/*
File:			UnitTests_Lab1.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		08.15.2021
Last Modified:	10.20.21
Purpose:		Declaration of Lab1 Unit Tests for DynArray
Notes:			Property of Full Sail University
*/

#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\\DynArray.h"

class UnitTests_Lab1 {

public:
#if LAB_1

	// Runs all active unit tests
	static void FullBattery();

	// Fills in a DynArray object with valid values
	//
	// In:	_object				The DynArray to populate
	//		_array				A pre-allocated array of values
	//		_size				Number of elements in _array (and also the size of the DynArray)
	//		_capacity			Capacity of DynArray (must be >= _size)
	static void PopulateDynArray(DynArray<int>& _object, int* _array = nullptr, size_t _size = 0, size_t _capacity = 0);

	// Protection in case that array is still set to -1
	static void ArrayNegativeOneProtection(DynArray<int>& _da);

#pragma region Test - Default Constructor (No Arguments)
	static void Battery_DefaultConstructorNoArgs();

	static FailResult Fail_DefaultConstructorNoArgs_MemoryIsAllocated();
	static FailResult Fail_DefaultConstructorNoArgs_Array_IsNotNullPointer();
	static FailResult Fail_DefaultConstructorNoArgs_Capacity_IsNotZero();
	static FailResult Fail_DefaultConstructorNoArgs_Size_IsNotZero();

	static bool Pass_DefaultConstructorNoArgs_NoMemoryAllocated();
	static bool Pass_DefaultConstructorNoArgs_Array_IsNullPointer();
	static bool Pass_DefaultConstructorNoArgs_Capacity_IsZero();
	static bool Pass_DefaultConstructorNoArgs_Size_IsZero();
#pragma endregion

#pragma region Test - Default Constructor (With Arguments)
	static void Battery_DefaultConstructorWithArgs();

	static FailResult Fail_DefaultConstructorWithArgs_Array_NoMemoryAllocated();
	static FailResult Fail_DefaultConstructorWithArgs_Array_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_DefaultConstructorWithArgs_Capacity_IncorrectValue();
	static FailResult Fail_DefaultConstructorWithArgs_Size_IsNotZero();

	static bool Pass_DefaultConstructorWithArgs_Array_IsDynamicallyAllocated();
	static bool Pass_DefaultConstructorWithArgs_Array_CorrectAmountOfMemoryAllocated();
	static bool Pass_DefaultConstructorWithArgs_Capacity_IsCorrectValue();
	static bool Pass_DefaultConstructorWithArgs_Size_IsZero();
#pragma endregion

#pragma region Test - [] Operator (Read-Only)
	static void Battery_BracketOperator();

	static FailResult Fail_BracketOperator_ValueAtIndex_ReturnsIncorrectValue();
	static FailResult Fail_BracketOperator_ValueAtIndex_WritesIncorrectValue();

	static bool Pass_BracketOperator_ValueAtIndex_ReturnsCorrectValue();
	static bool Pass_BracketOperator_ValueAtIndex_WritesCorrectValue();
#pragma endregion

#pragma region Test - Size Accessor
	static void Battery_SizeAccessor();

	static FailResult Fail_SizeAccessor_Size_ReturnsIncorrectValue();

	static bool Pass_SizeAccessor_Size_ReturnsCorrectValue();
#pragma endregion

#pragma region Test - Capacity Accessor
	static void Battery_CapacityAccessor();

	static FailResult Fail_CapacityAccessor_Capacity_ReturnsIncorrectValue();

	static bool Pass_CapacityAccessor_Capacity_ReturnsCorrectValue();
#pragma endregion

#pragma region Test - Reserve (Empty)
	static void Battery_ReserveEmpty();

	static FailResult Fail_ReserveEmpty_Array_IsNotDynamicallyAllocated();
	static FailResult Fail_ReserveEmpty_Array_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_ReserveEmpty_Capacity_IsNotOne();
	static FailResult Fail_ReserveEmpty_Size_IsNotOne();

	static bool Pass_ReserveArray_Array_IsDynamicallyAllocated();
	static bool Pass_ReserveArray_Array_CorrectAmountOfMemoryAllocated();
	static bool Pass_ReserveArray_Capacity_IsOne();
	static bool Pass_ReserveArray_Size_IsZero();
#pragma endregion

#pragma region Test - Reserve (Double Capacity) 
	static void Battery_ReserveDoubleCapacity();

	static FailResult Fail_ReserveDoubleCapacity_Array_IsNotDynamicallyAllocated();
	static FailResult Fail_ReserveDoubleCapacity_Array_SameMemoryAddressAsOriginal();
	static FailResult Fail_ReserveDoubleCapacity_Array_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_ReserveDoubleCapacity_Array_DidntDeleteOldArray();
	static FailResult Fail_ReserveDoubleCapacity_Array_DataNotCopiedToNewArray();
	static FailResult Fail_ReserveDoubleCapacity_Array_Capacity_NotDoubled();
	static FailResult Fail_ReserveDoubleCapacity_Array_Size_WasChanged();
	
	static bool Pass_ReserveDoubleCapacity_Array_IsDynamicallyAllocated();
	static bool Pass_ReserveDoubleCapacity_Array_DifferentMemoryAddressThanOriginal();
	static bool Pass_ReserveDoubleCapacity_Array_CorrectAmoutnOfMemoryAllocated();
	static bool Pass_ReserveDoubleCapacity_Array_DeletedOldArray();
	static bool Pass_ReserveDoubleCapacity_Array_DataCopiedToNewArray();
	static bool Pass_ReserveDoubleCapacity_Capacity_ShouldBeDoubled();
	static bool Pass_ReserveDoubleCapacity_Size_WasNotChanged();
#pragma endregion

#pragma region Test - Reserve (Larger Capacity)
	static void Battery_ReserveLargerCapacity();

	static FailResult Fail_ReserveLargerCapacity_Array_IsNotDynamicallyAllocated();
	static FailResult Fail_ReserveLargerCapacity_Array_SameMemoryAddressThanOriginal();
	static FailResult Fail_ReserveLargerCapacity_Array_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_ReserveLargerCapacity_Array_DidntDeleteOldArray();
	static FailResult Fail_ReserveLargerCapacity_Array_DataNotCopiedToNewArray();
	static FailResult Fail_ReserveLargerCapacity_Capacity_NotChanged();
	static FailResult Fail_ReserveLargerCapacity_Size_WasChanged();

	static bool Pass_ReserveLargerCapacity_Array_IsDynamicallyAllocated();
	static bool Pass_ReserveLargerCapacity_Array_DifferentMemoryAddressThanOriginal();
	static bool Pass_ReserveLargerCapacity_Array_CorrectAmountOfMemoryAllocated();
	static bool Pass_ReserveLargerCapacity_Array_DeletedOldArray();
	static bool Pass_ReserveLargerCapacity_Array_DataCopiedToNewArray();
	static bool Pass_ReserveLargerCapacity_Capacity_ShouldBeUpdated();
	static bool Pass_ReserveLargerCapacity_Size_WasNotChanged();
#pragma endregion

#pragma region Test - Reserve (Smaller Capacity) 
	static void Battery_ReserveSmallerCapacity();

	static FailResult Fail_ReserveSmallerCapacity_Array_AddressWasChanged();
	static FailResult Fail_ReserveSmallerCapacity_Capacity_WasChanged();

	static bool Pass_ReserveSmallerCapacity_Array_DidNotChange();
	static bool Pass_ReserveSmallerCapacity_Capacity_ShouldNotChange();
#pragma endregion

#pragma region Test - Append (No Resize)
	static void Battery_AppendNoResize();

	static FailResult Fail_AppendNoResize_Array_DynamicMemoryWasAllocated();
	static FailResult Fail_AppendNoResize_Array_ValueWasNotAddedToNextAvailableElement();
	static FailResult Fail_AppendNoResize_Size_WasNotIncremented();
	static FailResult Fail_AppendNoResize_Capacity_WasChanged();

	static bool AppendNoResize_Array_NoDynamicMemoryWasAllocated();
	static bool AppendNoResize_Array_ValueAddedToNextAvailableElement();
	static bool AppendNoResize_Size_WasIncremented();
	static bool AppendNoResize_Capacity_DidNotChange();
#pragma endregion

#pragma region Test - Append (Resize)
	static void Battery_AppendResize();

	static FailResult Fail_AppendResize_Array_CapacityIsNotDoubled();
	static FailResult Fail_AppendResize_Array_DataIsNotCopiedToNewArray();
	static FailResult Fail_AppendResize_Array_ValueNotAddedToNextAvailableElement();
	static FailResult Fail_AppendResize_Size_WasNotIncremented();
	static FailResult Fail_AppendResize_Capacity_WasNotDoubled();

	static bool Pass_AppendResize_Array_CapacityIsDoubled();
	static bool Pass_AppendResize_Array_DataCopiedToNewArray();
	static bool Pass_AppendResize_Array_ValueAddedToNextAvailableElement();
	static bool Pass_AppendResize_Size_WasBeIncremented();
	static bool Pass_AppendResize_Capacity_WasDoubled();
#pragma endregion

#pragma region Test - Clear
	static void Battery_Clear();

	static FailResult Fail_Clear_Array_IsNotNullPointer();
	static FailResult Fail_Clear_Array_MemoryIsNotDeleted();
	static FailResult Fail_Clear_Array_NotDeletedWithBrackets();
	static FailResult Fail_Clear_Capacity_IsNotZero();
	static FailResult Fail_Clear_Size_IsNotZero();

	static bool Pass_Clear_Array_IsNullPointer();
	static bool Pass_Clear_Array_MemoryIsDeleted();
	static bool Pass_Clear_Capacity_IsZero();
	static bool Pass_Clear_Size_IsZero();
#pragma endregion

#pragma region Test - Destructor
	static void Battery_Destructor();

	static FailResult Fail_Destructor_MemoryIsNotDeleted();

	static bool Pass_Destructor_MemoryIsDeleted();
#pragma endregion

#pragma region Test - Assignment Operator
	static void Battery_AssignmentOperator();

	static FailResult Fail_AssignmentOperator_Argument_NoSelfAssignmentCheck();
	static FailResult Fail_AssignmentOperator_Array_SameAddressAsArgument();
	static FailResult Fail_AssignmentOperator_Array_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_AssignmentOperator_Array_DataNotCopiedToNewArray();
	static FailResult Fail_AssignmentOperator_Capacity_IsNotCorrectValue();
	static FailResult Fail_AssignmentOperator_Size_IsNotCorrectValue();

	static bool Pass_AssignmentOperator_Argument_HasSelfAssignmentCheck();
	static bool Pass_AssignmentOperator_Array_DifferentMemoryAddressThanArgument();
	static bool Pass_AssignmentOperator_Array_CorrectAmountOfMemoryAllocated();
	static bool Pass_AssignmentOperator_Array_DataCopiedToNewArray();
	static bool Pass_AssignmentOperator_Capacity_IsCorrectValue();
	static bool Pass_AssignmentOperator_Size_IsCorrectValue();
#pragma endregion

#pragma region Test - Copy Constructor
	static void Battery_CopyConstructor();

	static FailResult Fail_CopyConstructor_Array_SameMemoryAddressAsArgument();
	static FailResult Fail_CopyConstructor_Array_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_CopyConstructor_Array_DataNotCopiedToNewArray();
	static FailResult Fail_CopyConstructor_Capacity_IsIncorrectValue();
	static FailResult Fail_CopyConstructor_Size_IsIncorrectValue();

	static bool Pass_CopyConstructor_Array_DifferentMemoryAddressThanArgument();
	static bool Pass_CopyConstructor_Array_CorrectAmountOfMemoryAllocated();
	static bool Pass_CopyConstructor_Array_DataCopiedToNewArray();
	static bool Pass_CopyConstructor_Capacity_IsCorrectValue();
	static bool Pass_CopyConstructor_Size_IsCorrectValue();
#pragma endregion

#endif
};