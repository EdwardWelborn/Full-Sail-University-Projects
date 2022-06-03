/*
File:			UnitTests_Lab4.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		09.19.2021
Last Modified:	09.19.2021
Purpose:		Definitions of Lab4 Unit Tests for std::list
Notes:			Property of Full Sail University
*/

/************/
/* Includes */
/************/
#include "UnitTests_Lab4.h"

#if LAB_4
void UnitTests_Lab4::FullBattery() {
#if LAB4_QUEUE_ADD
	Battery_AddQueueOrdering(); 
#endif
#if LAB4_STACK_ADD
	Battery_AddStackOrdering();
#endif
#if LAB4_QUEUE_REMOVE
	Battery_RemoveQueueOrdering();
#endif
#if LAB4_STACK_REMOVE
	Battery_RemoveStackOrdering();
#endif
#if LAB4_INSERT_ITER
	Battery_InsertWithIterator();
#endif
#if LAB4_INSERT_INDEX
	Battery_InsertWithIndex();
#endif
#if LAB4_REMOVE_DECIMAL
	Battery_RemoveDecimalGreater();
#endif
}

#pragma region Test - Add Queue Ordering
#if LAB4_QUEUE_ADD
void UnitTests_Lab4::Battery_AddQueueOrdering() {
	FailVector failVec;
	failVec.push_back(Fail_AddQueueOrdering_NotAllValuesAddedToList);
	failVec.push_back(Fail_AddQueueOrdering_TooManyValuesAddedToList);
	failVec.push_back(Fail_AddQueueOrdering_IncorrectOrderOfValues);

	PassVector passVec;
	passVec.push_back(Pass_AddQueueOrdering_CorrectNumberOfValues);
	passVec.push_back(Pass_AddQueueOrdering_CorrectOrderOfValues);

	UnitTestBattery("Testing adding to a list using queue ordering", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab4::Fail_AddQueueOrdering_NotAllValuesAddedToList() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	
	DSA_Lab4 list;
	list.QueueOrderingAdd(&vec[0], randomSize);

	FailResult result;
	result.check = list.mList.size() < randomSize;
	result.msg = "Not all values were added to list";

	return result;
}

FailResult UnitTests_Lab4::Fail_AddQueueOrdering_TooManyValuesAddedToList() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.QueueOrderingAdd(&vec[0], randomSize);

	FailResult result;
	result.check = list.mList.size() > randomSize;
	result.msg = "Too many values were added to list";

	return result;
}

FailResult UnitTests_Lab4::Fail_AddQueueOrdering_IncorrectOrderOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.QueueOrderingAdd(&vec[0], randomSize);

	bool correctOrdering = true;
	auto listIter = list.mList.begin();
	if (listIter == list.mList.end())
		correctOrdering = false;
	else {
		for (float f : vec) {
			if (f != *listIter) {
				correctOrdering = false;
				break;
			}
			++listIter;
		}
	}

	FailResult result;
	result.check = correctOrdering == false;
	result.msg = "Values were not added with queue ordering";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::Pass_AddQueueOrdering_CorrectNumberOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.QueueOrderingAdd(&vec[0], randomSize);

	bool result = list.mList.size() == randomSize;

	return result;
}

bool UnitTests_Lab4::Pass_AddQueueOrdering_CorrectOrderOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.QueueOrderingAdd(&vec[0], randomSize);

	bool correctOrdering = true;
	auto listIter = list.mList.begin();
	for (float f : vec) {
		if (f != *listIter) {
			correctOrdering = false;
			break;
		}
		++listIter;
	}

	bool result = correctOrdering == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Add Stack Ordering
#if LAB4_STACK_ADD
void UnitTests_Lab4::Battery_AddStackOrdering() {
	FailVector failVec;
	failVec.push_back(Fail_AddStackOrdering_NotAllValuesAddedToList);
	failVec.push_back(Fail_AddStackOrdering_TooManyValuesAddedToList);
	failVec.push_back(Fail_AddStackOrdering_IncorrectOrderOfValues);

	PassVector passVec;
	passVec.push_back(Pass_AddStackOrdering_CorrectNumberOfValues);
	passVec.push_back(Pass_AddStackOrdering_CorrectOrderOfValues);

	UnitTestBattery("Testing adding to a list using stack ordering", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab4::Fail_AddStackOrdering_NotAllValuesAddedToList() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.StackOrderingAdd(&vec[0], randomSize);

	FailResult result;
	result.check = list.mList.size() < randomSize;
	result.msg = "Not all values were added to list";

	return result;
}

FailResult UnitTests_Lab4::Fail_AddStackOrdering_TooManyValuesAddedToList() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.StackOrderingAdd(&vec[0], randomSize);

	FailResult result;
	result.check = list.mList.size() > randomSize;
	result.msg = "Too many values were added to list";

	return result;
}

FailResult UnitTests_Lab4::Fail_AddStackOrdering_IncorrectOrderOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.StackOrderingAdd(&vec[0], randomSize);

	bool correctOrdering = true;
	auto listIter = list.mList.rbegin();
	if (listIter == list.mList.rend())
		correctOrdering = false;
	else {
		for (float f : vec) {
			if (f != *listIter) {
				correctOrdering = false;
				break;
			}
			++listIter;
		}
	}

	FailResult result;
	result.check = correctOrdering == false;
	result.msg = "Values were not added with stack ordering";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::Pass_AddStackOrdering_CorrectNumberOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.StackOrderingAdd(&vec[0], randomSize);

	bool result = list.mList.size() == randomSize;

	return result;
}

bool UnitTests_Lab4::Pass_AddStackOrdering_CorrectOrderOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.StackOrderingAdd(&vec[0], randomSize);

	bool correctOrdering = true;
	auto listIter = list.mList.rbegin();
	for (float f : vec) {
		if (f != *listIter) {
			correctOrdering = false;
			break;
		}
		++listIter;
	}

	bool result = correctOrdering == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Remove Queue Ordering
#if LAB4_QUEUE_REMOVE
void UnitTests_Lab4::Battery_RemoveQueueOrdering() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveQueueOrderingMoreThanOneValueRemoved);
	failVec.push_back(Fail_RemoveQueueOrderingNoValuesRemoved);
	failVec.push_back(Fail_RemoveQueueOrderingIncorrectValueReturned);
	failVec.push_back(Fail_RemoveQueueOrderingIncorrectValuesRemaining);

	PassVector passVec;
	passVec.push_back(Pass_RemoveQueueOrdering_CorrectNumberOfValues);
	passVec.push_back(Pass_RemoveQueueOrdering_CorrectValueReturned);
	passVec.push_back(Pass_RemoveQueueOrdering_CorrectValuesRemaining);

	UnitTestBattery("Testing removing from a list using queue ordering", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab4::Fail_RemoveQueueOrderingMoreThanOneValueRemoved() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	list.QueueOrderingRemove();

	FailResult result;
	result.check = list.mList.size() > randomSize - 1;
	result.msg = "Too many values were removed from list";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveQueueOrderingNoValuesRemoved() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	list.QueueOrderingRemove();

	FailResult result;
	result.check = list.mList.size() == randomSize;
	result.msg = "No values were removed from list";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveQueueOrderingIncorrectValueReturned() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	float val = list.QueueOrderingRemove();

	FailResult result;
	result.check = val != vec.at(0);
	result.msg = "Incorrect value returned (remember queue ordering)";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveQueueOrderingIncorrectValuesRemaining() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	list.QueueOrderingRemove();

	bool correctOrder = true;

	auto listIter = list.mList.begin();
	auto vecIter = ++vec.begin();

	while (listIter != list.mList.end() && vecIter != vec.end()) {
		if (*listIter != *vecIter) {
			correctOrder = false;
			break;
		}
		else {
			++vecIter;
			++listIter;
		}
	}

	FailResult result;
	result.check = correctOrder == false;
	result.msg = "Incorrect value removed from list (remember queue ordering)";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::Pass_RemoveQueueOrdering_CorrectNumberOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	list.QueueOrderingRemove();

	bool result = list.mList.size() == randomSize-1;

	return result;
}

bool UnitTests_Lab4::Pass_RemoveQueueOrdering_CorrectValueReturned() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	float val = list.QueueOrderingRemove();

	bool result = val == vec.at(0);

	return result;
}

bool UnitTests_Lab4::Pass_RemoveQueueOrdering_CorrectValuesRemaining() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.begin(), vec.end());

	list.QueueOrderingRemove();

	bool correctOrder = true;

	auto listIter = list.mList.begin();
	auto vecIter = ++vec.begin();

	while (listIter != list.mList.end() && vecIter != vec.end()) {
		if (*listIter != *vecIter) {
			correctOrder = false;
			break;
		}
		else {
			++vecIter;
			++listIter;
		}
	}

	bool result = correctOrder == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Remove Stack Ordering
#if LAB4_STACK_REMOVE
void UnitTests_Lab4::Battery_RemoveStackOrdering() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveStackOrderingMoreThanOneValueRemoved);
	failVec.push_back(Fail_RemoveStackOrderingNoValuesRemoved);
	failVec.push_back(Fail_RemoveStackOrderingIncorrectValueReturned);
	failVec.push_back(Fail_RemoveStackOrderingIncorrectValuesRemaining);

	PassVector passVec;
	passVec.push_back(Pass_RemoveStackOrdering_CorrectNumberOfValues);
	passVec.push_back(Pass_RemoveStackOrdering_CorrectValueReturned);
	passVec.push_back(Pass_RemoveStackOrdering_CorrectValuesRemaining);

	UnitTestBattery("Testing removing from a list using stack ordering", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab4::Fail_RemoveStackOrderingMoreThanOneValueRemoved() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	list.StackOrderingRemove();

	FailResult result;
	result.check = list.mList.size() > randomSize - 1;
	result.msg = "Too many values were removed from list";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveStackOrderingNoValuesRemoved() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	list.StackOrderingRemove();

	FailResult result;
	result.check = list.mList.size() == randomSize;
	result.msg = "No values were removed from list";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveStackOrderingIncorrectValueReturned() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	float val = list.StackOrderingRemove();

	FailResult result;
	result.check = val != *vec.rbegin();
	result.msg = "Incorrect value returned (remember stack ordering)";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveStackOrderingIncorrectValuesRemaining() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	list.StackOrderingRemove();

	bool correctOrder = true;

	auto listIter = list.mList.begin();
	auto vecIter = ++vec.rbegin();

	while (listIter != list.mList.end() && vecIter != vec.rend()) {
		if (*listIter != *vecIter) {
			correctOrder = false;
			break;
		}
		else {
			++vecIter;
			++listIter;
		}
	}

	FailResult result;
	result.check = correctOrder == false;
	result.msg = "Incorrect value removed from list (remember stack ordering)";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::Pass_RemoveStackOrdering_CorrectNumberOfValues() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	list.StackOrderingRemove();

	bool result = list.mList.size() == randomSize-1;

	return result;
}

bool UnitTests_Lab4::Pass_RemoveStackOrdering_CorrectValueReturned() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	float val = list.StackOrderingRemove();

	bool result = val == *vec.rbegin();

	return result;
}

bool UnitTests_Lab4::Pass_RemoveStackOrdering_CorrectValuesRemaining() {
	size_t randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));

	DSA_Lab4 list;
	list.mList.insert(list.mList.begin(), vec.rbegin(), vec.rend());

	list.StackOrderingRemove();

	bool correctOrder = true;

	auto listIter = list.mList.begin();
	auto vecIter = ++vec.rbegin();

	while (listIter != list.mList.end() && vecIter != vec.rend()) {
		if (*listIter != *vecIter) {
			correctOrder = false;
			break;
		}
		else {
			++vecIter;
			++listIter;
		}
	}

	bool result = correctOrder == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert With Iterator
#if LAB4_INSERT_ITER
void UnitTests_Lab4::Battery_InsertWithIterator() {
	FailVector failVec;
	failVec.push_back(InsertWithIterator_ValueNotAdded);
	failVec.push_back(InsertWithIterator_ValueNotAddedAtCorrectLocation);

	PassVector passVec;
	passVec.push_back(InsertWithIterator_ValueAddedAtCorrectLocation);

	UnitTestBattery("Testing inserting into a list using an iterator", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab4::InsertWithIterator_ValueNotAdded() {
	int randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	int randomIndex = RandomInt(0, randomSize - 1);
	float randomVal = RandomFloat(101, 200);
	DSA_Lab4 list;
	list.mList = std::list<float>(vec.begin(), vec.end());

	vec.insert(vec.begin() + randomIndex, randomVal);

	auto listIter = list.mList.begin();
	for (int i = 0; i < randomIndex; ++i, ++listIter);
	list.Insert(listIter, randomVal);
	
	FailResult result;
	result.check = list.mList.size() < vec.size();
	result.msg = "Value was not added to list";

	return result;
}

FailResult UnitTests_Lab4::InsertWithIterator_ValueNotAddedAtCorrectLocation() {
	int randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	int randomIndex = RandomInt(0, randomSize - 1);
	float randomVal = RandomFloat(101, 200);
	DSA_Lab4 list;
	list.mList = std::list<float>(vec.begin(), vec.end());

	vec.insert(vec.begin() + randomIndex, randomVal);

	auto listIter = list.mList.begin();
	for (int i = 0; i < randomIndex; ++i, ++listIter);
	list.Insert(listIter, randomVal);


	FailResult result;
	result.check = *--listIter != vec.at(randomIndex);
	result.msg = "Value was not added at correct location in list";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::InsertWithIterator_ValueAddedAtCorrectLocation() {
	int randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	int randomIndex = RandomInt(0, randomSize - 1);
	float randomVal = RandomFloat(101, 200);
	DSA_Lab4 list;
	list.mList = std::list<float>(vec.begin(), vec.end());

	vec.insert(vec.begin() + randomIndex, randomVal);

	auto listIter = list.mList.begin();
	for (int i = 0; i < randomIndex; ++i, ++listIter);
	list.Insert(listIter, randomVal);


	bool result = *--listIter == vec.at(randomIndex);

	return result;;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert With Index
#if LAB4_INSERT_INDEX
void UnitTests_Lab4::Battery_InsertWithIndex() {
	FailVector failVec;
	failVec.push_back(InsertWithIndex_ValueNotAdded);
	failVec.push_back(InsertWithIndex_ValueNotAddedAtCorrectLocation);

	PassVector passVec;
	passVec.push_back(InsertWithIndex_ValueAddedAtCorrectLocation);

	UnitTestBattery("Testing inserting into a list at a specified index", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab4::InsertWithIndex_ValueNotAdded() {
	int randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	int randomIndex = RandomInt(0, randomSize - 1);
	float randomVal = RandomFloat(101, 200);
	DSA_Lab4 list;
	list.mList = std::list<float>(vec.begin(), vec.end());

	vec.insert(vec.begin() + randomIndex, randomVal);

	list.Insert(randomIndex, randomVal);
	
	FailResult result;
	result.check = list.mList.size() < vec.size();
	result.msg = "Value was not added to list";

	return result;
}

FailResult UnitTests_Lab4::InsertWithIndex_ValueNotAddedAtCorrectLocation() {
	int randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	int randomIndex = RandomInt(0, randomSize - 1);
	float randomVal = RandomFloat(101, 200);
	DSA_Lab4 list;
	list.mList = std::list<float>(vec.begin(), vec.end());

	vec.insert(vec.begin() + randomIndex, randomVal);

	list.Insert(randomIndex, randomVal);

	auto listIter = list.mList.begin();
	for (int i = 0; i < randomIndex; ++i, ++listIter);

	FailResult result;
	result.check = *listIter != vec.at(randomIndex);
	result.msg = "Value was not added at correct location in list";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::InsertWithIndex_ValueAddedAtCorrectLocation() {
	int randomSize = RandomInt(5, 10);
	std::vector<float> vec;
	for (size_t i = 0; i < randomSize; ++i)
		vec.push_back(RandomFloat(1, 100));
	int randomIndex = RandomInt(0, randomSize - 1);
	float randomVal = RandomFloat(101, 200);
	DSA_Lab4 list;
	list.mList = std::list<float>(vec.begin(), vec.end());

	vec.insert(vec.begin() + randomIndex, randomVal);

	list.Insert(randomIndex, randomVal);

	auto listIter = list.mList.begin();
	for (int i = 0; i < randomIndex; ++i, ++listIter);

	bool result = *listIter == vec.at(randomIndex);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Remove Decimal Values
#if LAB4_REMOVE_DECIMAL
void UnitTests_Lab4::Battery_RemoveDecimalGreater() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveDecimalGreaterFixed_NoValuesWereRemoved);
	failVec.push_back(Fail_RemoveDecimalGreaterFixed_IncorrectNumberOfValuesAreRemoved);
	failVec.push_back(Fail_RemoveDecimalGreaterFixed_IncorrectValuesRemoved);
	failVec.push_back(Fail_RemoveDecimalGreaterFixed_IncorrectValueReturned);
	failVec.push_back(Fail_RemoveDecimalGreaterRandom_IncorrectNumberOfValuesAreRemoved);
	failVec.push_back(Fail_RemoveDecimalGreaterRandom_IncorrectValuesRemoved);
	failVec.push_back(Fail_RemoveDecimalGreaterRandom_IncorrectValueReturned);

	PassVector passVec;
	passVec.push_back(Pass_RemoveDecimalGreaterFixed_CorrectNumberOfValuesAreRemoved);
	passVec.push_back(Pass_RemoveDecimalGreaterFixed_CorrectValuesRemoved);
	passVec.push_back(Pass_RemoveDecimalGreaterFixed_CorrectValueReturned);
	passVec.push_back(Pass_RemoveDecimalGreaterRandom_CorrectNumberOfValuesAreRemoved);
	passVec.push_back(Pass_RemoveDecimalGreaterRandom_CorrectValuesRemoved);
	passVec.push_back(Pass_RemoveDecimalGreaterRandom_CorrectValueReturned);

	UnitTestBattery("Testing removing values from list matching criteria", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterFixed_NoValuesWereRemoved() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	fixedList.mList.insert(iter, RandomInt(1, 100) + RandomFloat(0.0f, 0.1f));

	fixedList.RemoveDecimalGreater(0.15f);

	FailResult result;
	result.check = fixedList.mList.size() == 10;
	result.msg = "No values were removed";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterFixed_IncorrectNumberOfValuesAreRemoved() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	fixedList.mList.insert(iter, RandomInt(1, 100) + RandomFloat(0.0f, 0.1f));

	fixedList.RemoveDecimalGreater(0.15f);

	FailResult result;
	result.check = fixedList.mList.size() != 1;
	result.msg = "Not all values matching criteria were removed (fixed list)";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterFixed_IncorrectValuesRemoved() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	float randomDec = RandomInt(1, 100) + RandomFloat(0.0f, 0.1f);
	fixedList.mList.insert(iter, randomDec);

	fixedList.RemoveDecimalGreater(0.15f);

	FailResult result;
	result.check = *fixedList.mList.begin() != randomDec;
	result.msg = "Not all values matching criteria were removed (fixed list)";
	
	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterFixed_IncorrectValueReturned() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	float randomDec = RandomInt(1, 100) + RandomFloat(0.0f, 0.1f);
	fixedList.mList.insert(iter, randomDec);

	int removed = fixedList.RemoveDecimalGreater(0.15f);

	FailResult result;
	result.check = removed != 9;
	result.msg = "Did not return number of values removed (fixed list)";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterRandom_IncorrectNumberOfValuesAreRemoved() {
	DSA_Lab4 randomList;
	int randomSize = RandomInt(10, 20);
	float randomDec = RandomFloat(0.25f, 0.75f);
	std::list<float> lesser, greater;
	for (int i = 0; i < randomSize; ++i) {
		if (RandomInt(0, 1)) {
			lesser.push_back(RandomInt(1, 100) + RandomFloat(0, randomDec - 0.01f));
			randomList.mList.push_back(lesser.back());
		}
		else {
			greater.push_back(RandomInt(1, 100) + RandomFloat(randomDec + 0.01f, 0.99f));
			randomList.mList.push_back(greater.back());
		}
	}

	randomList.RemoveDecimalGreater(randomDec);

	FailResult result;
	result.check = randomList.mList.size() != lesser.size();
	result.msg = "Not all values matching criteria were removed (random list)";

	return FailResult();
}
FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterRandom_IncorrectValuesRemoved() {
	DSA_Lab4 randomList;
	int randomSize = RandomInt(10, 20);
	float randomDec = RandomFloat(0.25f, 0.75f);
	std::list<float> lesser, greater;
	for (int i = 0; i < randomSize; ++i) {
		if (RandomInt(0, 1)) {
			lesser.push_back(RandomInt(1, 100) + RandomFloat(0, randomDec - 0.01f));
			randomList.mList.push_back(lesser.back());
		}
		else {
			greater.push_back(RandomInt(1, 100) + RandomFloat(randomDec + 0.01f, 0.99f));
			randomList.mList.push_back(greater.back());
		}
	}

	randomList.RemoveDecimalGreater(randomDec);

	FailResult result;
	result.check = randomList.mList != lesser;
	result.msg = "Not all values matching criteria were removed (random list)";

	return result;
}

FailResult UnitTests_Lab4::Fail_RemoveDecimalGreaterRandom_IncorrectValueReturned() {
	DSA_Lab4 randomList;
	int randomSize = RandomInt(10, 20);
	float randomDec = RandomFloat(0.25f, 0.75f);
	std::list<float> lesser, greater;
	for (int i = 0; i < randomSize; ++i) {
		if (RandomInt(0, 1)) {
			lesser.push_back(RandomInt(1, 100) + RandomFloat(0, randomDec - 0.01f));
			randomList.mList.push_back(lesser.back());
		}
		else {
			greater.push_back(RandomInt(1, 100) + RandomFloat(randomDec + 0.01f, 0.99f));
			randomList.mList.push_back(greater.back());
		}
	}

	int removed = randomList.RemoveDecimalGreater(randomDec);

	FailResult result;
	result.check = removed != greater.size();
	result.msg = "Did not return number of values removed (random list)";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab4::Pass_RemoveDecimalGreaterFixed_CorrectNumberOfValuesAreRemoved() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	fixedList.mList.insert(iter, RandomInt(1, 100) + RandomFloat(0.0f, 0.1f));

	fixedList.RemoveDecimalGreater(0.15f);

	bool result = fixedList.mList.size() == 1;

	return result;
}

bool UnitTests_Lab4::Pass_RemoveDecimalGreaterFixed_CorrectValuesRemoved() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	float randomDec = RandomInt(1, 100) + RandomFloat(0.0f, 0.1f);
	fixedList.mList.insert(iter, randomDec);

	fixedList.RemoveDecimalGreater(0.15f);

	bool result = *fixedList.mList.begin() == randomDec;

	return result;
}

bool UnitTests_Lab4::Pass_RemoveDecimalGreaterFixed_CorrectValueReturned() {
	DSA_Lab4 fixedList;
	for (int i = 0; i < 9; ++i)
		fixedList.mList.push_back(RandomInt(1, 100) + RandomFloat(0.2f, 0.99f));
	auto iter = fixedList.mList.begin();
	std::advance(iter, 3);
	float randomDec = RandomInt(1, 100) + RandomFloat(0.0f, 0.1f);
	fixedList.mList.insert(iter, randomDec);

	int removed = fixedList.RemoveDecimalGreater(0.15f);

	bool result = removed == 9;

	return result;
}

bool UnitTests_Lab4::Pass_RemoveDecimalGreaterRandom_CorrectNumberOfValuesAreRemoved() {
	DSA_Lab4 randomList;
	int randomSize = RandomInt(10, 20);
	float randomDec = RandomFloat(0.25f, 0.75f);
	std::list<float> lesser, greater;
	for (int i = 0; i < randomSize; ++i) {
		if (RandomInt(0, 1)) {
			lesser.push_back(RandomInt(1, 100) + RandomFloat(0, randomDec - 0.01f));
			randomList.mList.push_back(lesser.back());
		}
		else {
			greater.push_back(RandomInt(1, 100) + RandomFloat(randomDec + 0.01f, 0.99f));
			randomList.mList.push_back(greater.back());
		}
	}

	randomList.RemoveDecimalGreater(randomDec);

	bool result = randomList.mList.size() == lesser.size();

	return result;
}

bool UnitTests_Lab4::Pass_RemoveDecimalGreaterRandom_CorrectValuesRemoved() {
	DSA_Lab4 randomList;
	int randomSize = RandomInt(10, 20);
	float randomDec = RandomFloat(0.25f, 0.75f);
	std::list<float> lesser, greater;
	for (int i = 0; i < randomSize; ++i) {
		if (RandomInt(0, 1)) {
			lesser.push_back(RandomInt(1, 100) + RandomFloat(0, randomDec - 0.01f));
			randomList.mList.push_back(lesser.back());
		}
		else {
			greater.push_back(RandomInt(1, 100) + RandomFloat(randomDec + 0.01f, 0.99f));
			randomList.mList.push_back(greater.back());
		}
	}

	randomList.RemoveDecimalGreater(randomDec);

	bool result = randomList.mList == lesser;

	return result;
}

bool UnitTests_Lab4::Pass_RemoveDecimalGreaterRandom_CorrectValueReturned() {
	DSA_Lab4 randomList;
	int randomSize = RandomInt(10, 20);
	float randomDec = RandomFloat(0.25f, 0.75f);
	std::list<float> lesser, greater;
	for (int i = 0; i < randomSize; ++i) {
		if (RandomInt(0, 1)) {
			lesser.push_back(RandomInt(1, 100) + RandomFloat(0, randomDec - 0.01f));
			randomList.mList.push_back(lesser.back());
		}
		else {
			greater.push_back(RandomInt(1, 100) + RandomFloat(randomDec + 0.01f, 0.99f));
			randomList.mList.push_back(greater.back());
		}
	}

	int removed = randomList.RemoveDecimalGreater(randomDec);

	bool result = removed == greater.size();

	return result;
}
#pragma endregion
#endif
#pragma endregion
#endif