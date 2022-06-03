/*
File:			UnitTests_Lab2.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		08.30.2021
Last Modified:	10.23.2021
Purpose:		Definitions of Lab2 Unit Tests for Lab2 (vector)
Notes:			Property of Full Sail University
*/

/************/
/* Includes */
/************/
#include "UnitTests_Lab2.h"
#include "Memory_Management.h"
#include <string>

#if LAB_2
std::string UnitTests_Lab2::mTempFilename;


void UnitTests_Lab2::FullBattery() {

#if LAB2_PALINDROME_NUMBER
	Battery_PalindromeNumber();
#endif
#if LAB2_FILL_FILE
	Battery_FillVectorFromFile();
#endif
#if LAB2_FILL_ARRAY
	Battery_FillVectorFromArray();
#endif
#if LAB2_CLEAR
	Battery_VectorClear();
#endif
#if LAB2_SORT_ASCENDING
	Battery_VectorSortAscending();
#endif
#if LAB2_SORT_DESCENDING
	Battery_VectorSortDescending();
#endif
#if LAB2_BRACKETS
	Battery_ArrayBracketOperator();
#endif
#if LAB2_CONTAINS_TRUE
	Battery_ContainsTrue();
#endif
#if LAB2_CONTAINS_FALSE
	Battery_ContainsFalse();
#endif
#if LAB2_MOVE_PALINDROMES
	Battery_MovePalindromes();
#endif
}

#pragma region Test - Palindrome Number
#if LAB2_PALINDROME_NUMBER
void UnitTests_Lab2::Battery_PalindromeNumber() {
	FailVector failVec;
	failVec.push_back(Fail_PalindromeNumber_IsPalindromeNumber);
	failVec.push_back(Fail_PalindromeNumber_IsNotPalindromeNumber);

	PassVector passVec;
	passVec.push_back(Pass_PalindromeNumber_IsPalindromeNumber);
	passVec.push_back(Pass_PalindromeNumber_IsNotPalindromeNumber);

	UnitTestBattery("Testing for palindrome numbers", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_PalindromeNumber_IsPalindromeNumber() {
	// Creating some palindrome numbers to test with
	std::vector<int> palindromeVec;
	palindromeVec.push_back(6);
	palindromeVec.push_back(55);
	palindromeVec.push_back(494);
	palindromeVec.push_back(7117);
	palindromeVec.push_back(45654);
	palindromeVec.push_back(123321);
	palindromeVec.push_back(7654567);
	palindromeVec.push_back(44566544);
	bool success = true;
	std::string msg;

	// Test palindromes
	for (auto iter = palindromeVec.begin(); iter != palindromeVec.end(); ++iter) {
		if (IsPalindromeNumber(*iter) == false) {
			msg += std::to_string(*iter) + " is not registering as a palindrome number";
			success = false;
			break;
		}
	}

	FailResult result;
	result.check = success == false;
	result.msg = msg.c_str();

	return result;
}

FailResult UnitTests_Lab2::Fail_PalindromeNumber_IsNotPalindromeNumber() {
	// Creating some non-palindrome numbers to test with
	std::vector<int> nonPalindromeVec;
	nonPalindromeVec.push_back(12);
	nonPalindromeVec.push_back(938);
	nonPalindromeVec.push_back(6423);
	nonPalindromeVec.push_back(27412);
	nonPalindromeVec.push_back(481474);
	nonPalindromeVec.push_back(5820485);
	nonPalindromeVec.push_back(18403412);
	bool success = true;
	std::string msg;

	// Test non-palindromes
	for (auto iter = nonPalindromeVec.begin(); iter != nonPalindromeVec.end(); ++iter) {
		if (IsPalindromeNumber(*iter) == true) {
			msg += std::to_string(*iter) + " is registering as a palindrome number";
			success = false;
			break;
		}
	}

	FailResult result;
	result.check = success == false;
	result.msg = msg.c_str();

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_PalindromeNumber_IsPalindromeNumber() {
	// Creating some palindrome numbers to test with
	std::vector<int> palindromeVec;
	palindromeVec.push_back(6);
	palindromeVec.push_back(55);
	palindromeVec.push_back(494);
	palindromeVec.push_back(7117);
	palindromeVec.push_back(45654);
	palindromeVec.push_back(123321);
	palindromeVec.push_back(7654567);
	palindromeVec.push_back(44566544);
	bool success = true;

	// Test palindromes
	for (auto iter = palindromeVec.begin(); iter != palindromeVec.end(); ++iter) {
		if (IsPalindromeNumber(*iter) == false) {
			success = false;
			break;
		}
	}

	bool result = success == true;

	return result;
}

bool UnitTests_Lab2::Pass_PalindromeNumber_IsNotPalindromeNumber() {
	// Creating some non-palindrome numbers to test with
	std::vector<int> nonPalindromeVec;
	nonPalindromeVec.push_back(12);
	nonPalindromeVec.push_back(938);
	nonPalindromeVec.push_back(6423);
	nonPalindromeVec.push_back(27412);
	nonPalindromeVec.push_back(481474);
	nonPalindromeVec.push_back(5820485);
	nonPalindromeVec.push_back(18403412);
	bool success = true;

	// Test non-palindromes
	for (auto iter = nonPalindromeVec.begin(); iter != nonPalindromeVec.end(); ++iter) {
		if (IsPalindromeNumber(*iter) == true) {
			success = false;
			break;
		}
	}

	bool result = success == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Fill From File
#if LAB2_FILL_FILE
void UnitTests_Lab2::Battery_FillVectorFromFile() {

	// Creating unique filename for test and duplicate file
	mTempFilename.clear();
	for (int i = 0; i < 8; ++i)
		mTempFilename += (char)RandomInt('a', 'z');
	mTempFilename += ".bin";
	CreateDuplicateFile("Files\\numbers.bin", mTempFilename.c_str());

	FailVector failVec;
	failVec.push_back(Fail_FillVectorFromFile_FilenameIsHardCoded);
	failVec.push_back(Fail_FillVectorFromFile_DataNotAddedToVector);
	failVec.push_back(Fail_FillVectorFromFile_FileHeaderNotRead);
	failVec.push_back(Fail_FillVectorFromFile_IncorrectNumberOfValuesStored);
	failVec.push_back(Fail_FillVectorFromFile_IncorrectValuesStored);

	PassVector passVec;
	passVec.push_back(Pass_FillVectorFromFile_DataAddedToVector);
	passVec.push_back(Pass_FillVectorFromFile_FileHeaderRead);
	passVec.push_back(Pass_FillVectorFromFile_CorrectNumberOfValuesStored);
	passVec.push_back(Pass_FillVectorFromFile_CorrectValuesStored);

	UnitTestBattery("Testing filling vector from a file", failVec, passVec);

	// Cleaning up after all tests have been run
	std::remove(mTempFilename.c_str());
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_FillVectorFromFile_FilenameIsHardCoded() {
	bool hardCodedFilename = SearchFile("Lab2.h", "void Fill(const char*", "void Fill(const int*", "numbers.bin");

	FailResult result;
	result.check = hardCodedFilename == true;
	result.msg = "Filename is hard-coded";

	return result;
}

FailResult UnitTests_Lab2::Fail_FillVectorFromFile_DataNotAddedToVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	vec.Fill(mTempFilename.c_str());

	FailResult result;
	result.check = vals.size() == 0;
	result.msg = "No values were added to mValues vector";

	return result;
}

FailResult UnitTests_Lab2::Fail_FillVectorFromFile_FileHeaderNotRead() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	vec.Fill(mTempFilename.c_str());

	FailResult result;
	result.check = vals.size() && vals.at(0) == 10000;
	result.msg = "File header was not read.  The first four bytes of the file stores the number of values in the file.";

	return result;
}


FailResult UnitTests_Lab2::Fail_FillVectorFromFile_IncorrectNumberOfValuesStored() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	vec.Fill(mTempFilename.c_str());

	FailResult result;
	result.check = vals.size() != 10000;
	result.msg = "Not all values were added to vector";

	return result;
}


FailResult UnitTests_Lab2::Fail_FillVectorFromFile_IncorrectValuesStored() {
	DSA_Lab2 vec;
	auto vals = vec.mValues;
	bool success = true;

	// Read the values out of the txt version of the file
	std::ifstream ifl("..\\Files\\numbers.txt");
	const int numValues = 10000;
	int* valuesArr = new int[numValues];
	for (int i = 0; i < numValues; ++i)
		ifl >> valuesArr[i];
	ifl.close();

	for (size_t i = 0; i < vals.size(); ++i)
		if (vals.at(i) != valuesArr[i]) {
			success = false;
			break;
		}
	delete[] valuesArr;

	FailResult result;
	result.check = success == false;
	result.msg = "One (or more) values were not read/added to vector correctly";

	return result;
}


#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_FillVectorFromFile_DataAddedToVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	vec.Fill(mTempFilename.c_str());

	bool result = vals.size() != 0;

	return result;
}


bool UnitTests_Lab2::Pass_FillVectorFromFile_FileHeaderRead() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	vec.Fill(mTempFilename.c_str());

	bool result = vals.size() && vals.at(0) != 10000;

	return result;
}


bool UnitTests_Lab2::Pass_FillVectorFromFile_CorrectNumberOfValuesStored() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	vec.Fill(mTempFilename.c_str());

	bool result = vals.size() == 10000;

	return result;
}


bool UnitTests_Lab2::Pass_FillVectorFromFile_CorrectValuesStored() {
	DSA_Lab2 vec;
	auto vals = vec.mValues;
	bool success = true;

	// Read the values out of the txt version of the file
	std::ifstream ifl("..\\Files\\numbers.txt");
	const int numValues = 10000;
	int* valuesArr = new int[numValues];
	for (int i = 0; i < numValues; ++i)
		ifl >> valuesArr[i];
	ifl.close();

	for (size_t i = 0; i < vals.size(); ++i)
		if (vals.at(i) != valuesArr[i]) {
			success = false;
			break;
		}
	delete[] valuesArr;

	bool result = success == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Fill From Array
#if LAB2_FILL_ARRAY
void UnitTests_Lab2::Battery_FillVectorFromArray() {
	FailVector failVec;
	failVec.push_back(Fail_FillVectorFromArray_DataNotAddedToVector);
	failVec.push_back(Fail_FillVectorFromArray_IncorrectNumberOfValuesStored);
	failVec.push_back(Fail_FillVectorFromArray_IncorrectValuesStored);

	PassVector passVec;
	passVec.push_back(Pass_FillVectorFromArray_DataAddedToVector);
	passVec.push_back(Pass_FillVectorFromArray_CorrectNumberOfValuesStored);
	passVec.push_back(Pass_FillVectorFromArray_CorrectValuesStored);

	UnitTestBattery("Testing filling array from an array", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_FillVectorFromArray_DataNotAddedToVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	// Creating an array of random values
	int randomSize = RandomInt(10, 50);
	auto* randomVals = CreateRandomArray(randomSize);

	vec.Fill(randomVals, randomSize);
	delete[] randomVals;

	FailResult result;
	result.check = vals.size() == 0;
	result.msg = "No values were added to mValues vector";

	return result;
}

FailResult UnitTests_Lab2::Fail_FillVectorFromArray_IncorrectNumberOfValuesStored() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	// Creating an array of random values
	int randomSize = RandomInt(10, 50);
	auto* randomVals = CreateRandomArray(randomSize);

	vec.Fill(randomVals, randomSize);
	delete[] randomVals;

	FailResult result;
	result.check = vals.size() != randomSize;
	result.msg = "Not all values were added to vector";

	return result;
}

FailResult UnitTests_Lab2::Fail_FillVectorFromArray_IncorrectValuesStored() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	bool success = true;

	// Creating an array of random values
	int randomSize = RandomInt(10, 50);
	auto* randomVals = CreateRandomArray(randomSize, 1, 100);

	vec.Fill(randomVals, randomSize);

	if (vals.size() == randomSize) {
		for (size_t i = 0; i < randomSize; ++i)
			if (vals.at(i) != randomVals[i]) {
				success = false;
				break;
			}
	}
	else
		success = false;
	delete[] randomVals;

	FailResult result;
	result.check = success == false;
	result.msg = "One (or more) values were not added to vector correctly";

	return result;

}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_FillVectorFromArray_DataAddedToVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	// Creating an array of random values
	int randomSize = RandomInt(10, 50);
	auto* randomVals = CreateRandomArray(randomSize);

	vec.Fill(randomVals, randomSize);
	delete[] randomVals;

	bool result = vals.size() != 0;

	return result;
}

bool UnitTests_Lab2::Pass_FillVectorFromArray_CorrectNumberOfValuesStored() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	// Creating an array of random values
	int randomSize = RandomInt(10, 50);
	auto* randomVals = CreateRandomArray(randomSize);

	vec.Fill(randomVals, randomSize);
	delete[] randomVals;

	bool result = vals.size() == randomSize;

	return result;
}

bool UnitTests_Lab2::Pass_FillVectorFromArray_CorrectValuesStored() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	bool success = true;

	// Creating an array of random values
	int randomSize = RandomInt(10, 50);
	auto* randomVals = CreateRandomArray(randomSize, 1, 100);

	vec.Fill(randomVals, randomSize);

	if (vals.size() == randomSize) {
		for (size_t i = 0; i < randomSize; ++i)
			if (vals.at(i) != randomVals[i]) {
				success = false;
				break;
			}
	}
	else
		success = false;
	delete[] randomVals;

	bool result = success == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Clear
#if LAB2_CLEAR
void UnitTests_Lab2::Battery_VectorClear() {
	FailVector failVec;
	failVec.push_back(Fail_VectorClear_SizeIsNotZero);
	failVec.push_back(Fail_VectorClear_CapacityisNotZero);

	PassVector passVec;
	passVec.push_back(Pass_VectorClear_SizeIsZero);
	passVec.push_back(Pass_VectorClear_CapacityIsZero);

	UnitTestBattery("Testing Clear method", failVec, passVec);
}	

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_VectorClear_SizeIsNotZero() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	int randomSize = RandomInt(5, 50);

	for (int i = 0; i < randomSize; ++i)
		vals.push_back(i);

	vec.Clear();

	FailResult result;
	result.check = vals.size() != 0;
	result.msg = "Vector was not fully cleared";

	return result;
}

FailResult UnitTests_Lab2::Fail_VectorClear_CapacityisNotZero() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	int randomSize = RandomInt(5, 50);

	for (int i = 0; i < randomSize; ++i)
		vals.push_back(i);

	vec.Clear();

	FailResult result;
	result.check = vals.capacity() != 0;
	result.msg = "Vector capacity was not reset";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_VectorClear_SizeIsZero() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	int randomSize = RandomInt(5, 50);

	for (int i = 0; i < randomSize; ++i)
		vals.push_back(i);

	vec.Clear();

	bool result = vals.size() == 0;
	
	return result;
}

bool UnitTests_Lab2::Pass_VectorClear_CapacityIsZero() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	int randomSize = RandomInt(5, 50);

	for (int i = 0; i < randomSize; ++i)
		vals.push_back(i);

	vec.Clear();

	bool result = vals.capacity() == 0;
	
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Sort Ascending
#if LAB2_SORT_ASCENDING
void UnitTests_Lab2::Battery_VectorSortAscending() {
	FailVector failVec;
	failVec.push_back(Fail_VectorSortAscending_DoesNotUseStdSort);
	failVec.push_back(Fail_VectorSortAscending_ValuesAreNotSorted);

	PassVector passVec;
	passVec.push_back(Pass_VectorSortAscending_UsesStdSort);
	passVec.push_back(Pass_VectorSortAscending_ValuesAreSorted);

	UnitTestBattery("Testing Sort in ascending order", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_VectorSortAscending_DoesNotUseStdSort() {
	bool usesStdSort = SearchFile("Lab2.h", "void Sort(bool", "operator[](", "sort(");

	FailResult result;
	result.check = usesStdSort == false;
	result.msg = "Does not use std::sort";

	return result;
}

FailResult UnitTests_Lab2::Fail_VectorSortAscending_ValuesAreNotSorted() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	bool sorted = true;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);

	// Sort randomValues
	for (size_t i = 0; i < static_cast<size_t>(randomSize) - 1; ++i)
		for (size_t j = i + 1; j < randomSize; ++j)
			if (randomVals[j] < randomVals[i])
				std::swap(randomVals[j], randomVals[i]);

	vec.Sort(true);

	for (size_t i = 0; i < vals.size(); ++i)
		if (vals.at(i) != randomVals[i]) {
			sorted = false;
			break;
		}
	delete[] randomVals;

	FailResult result;
	result.check = sorted == false;
	result.msg = "Vector is not sorted in ascending order";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_VectorSortAscending_UsesStdSort() {
	bool usesStdSort = SearchFile("Lab2.h", "void Sort(bool", "operator[](", "sort(");

	bool result = usesStdSort == true;

	return result;
}

bool UnitTests_Lab2::Pass_VectorSortAscending_ValuesAreSorted() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	bool sorted = true;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);

	// Sort randomValues
	for (size_t i = 0; i < static_cast<size_t>(randomSize) - 1; ++i)
		for (size_t j = i + 1; j < randomSize; ++j)
			if (randomVals[j] < randomVals[i])
				std::swap(randomVals[j], randomVals[i]);

	vec.Sort(true);

	for (size_t i = 0; i < vals.size(); ++i)
		if (vals.at(i) != randomVals[i]) {
			sorted = false;
			break;
		}
	delete[] randomVals;

	bool result = sorted == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Sort Descending
#if LAB2_SORT_DESCENDING
void UnitTests_Lab2::Battery_VectorSortDescending() {
	FailVector failVec;
	failVec.push_back(Fail_VectorSortDescending_DoesNotUseStdSort);
	failVec.push_back(Fail_VectorSortDescending_ValuesAreNotSorted);

	PassVector passVec;
	passVec.push_back(Pass_VectorSortDescending_UsesStdSort);
	passVec.push_back(Pass_VectorSortDescending_ValuesAreSorted);

	UnitTestBattery("Testing Sort in descending order", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_VectorSortDescending_DoesNotUseStdSort() {
	bool usesStdSort = SearchFile("Lab2.h", "void Sort(bool", "operator[](", "sort(");

	FailResult result;
	result.check = usesStdSort == false;
	result.msg = "Does not use std::sort";

	return result;
}

FailResult UnitTests_Lab2::Fail_VectorSortDescending_ValuesAreNotSorted() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	bool sorted = true;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);

	// Sort randomValues
	for (size_t i = 0; i < static_cast<size_t>(randomSize) - 1; ++i)
		for (size_t j = i + 1; j < randomSize; ++j)
			if (randomVals[j] > randomVals[i])
				std::swap(randomVals[j], randomVals[i]);

	vec.Sort(false);

	for (size_t i = 0; i < vals.size(); ++i)
		if (randomVals[i] != vals.at(i)) {
			sorted = false;
			break;
		}
	delete[] randomVals;

	FailResult result;
	result.check = sorted == false;
	result.msg = "Vector is not sorted in descending order";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_VectorSortDescending_UsesStdSort() {
	bool usesStdSort = SearchFile("Lab2.h", "void Sort(bool", "operator[](", "sort(");

	bool result = usesStdSort == true;

	return result;
}

bool UnitTests_Lab2::Pass_VectorSortDescending_ValuesAreSorted() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	bool sorted = true;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);

	// Sort randomValues
	for (size_t i = 0; i < static_cast<size_t>(randomSize) - 1; ++i)
		for (size_t j = i + 1; j < randomSize; ++j)
			if (randomVals[j] > randomVals[i])
				std::swap(randomVals[j], randomVals[i]);

	vec.Sort(false);

	for (size_t i = 0; i < vals.size(); ++i)
		if (randomVals[i] != vals.at(i)) {
			sorted = false;
			break;
		}
	delete[] randomVals;

	bool result = sorted == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Operator []
#if LAB2_BRACKETS
void UnitTests_Lab2::Battery_ArrayBracketOperator() {
	FailVector failVec;
	failVec.push_back(Fail_ArrayBracketOperator_DoesNotUseBracketOperatorOrAt);
	failVec.push_back(Fail_ArrayBracketOperator_UsesForLoop);
	failVec.push_back(Fail_ArrayBracketOperator_DoesNotReturnValueAtIndex);

	PassVector passVec;
	passVec.push_back(Pass_ArrayBracketOperator_UsesBracketOperatorOrAt);
	passVec.push_back(Pass_ArrayBracketOperator_ReturnsValueAtIndex);

	UnitTestBattery("Testing [] indexing", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_ArrayBracketOperator_DoesNotUseBracketOperatorOrAt() {
	bool usesBracketOperatorOrAt = SearchFile("Lab2.h", "operator[](", "bool Contains(", "mValues[") ||
		SearchFile("Lab2.h", "operator[](", "bool Contains(", "mValues.at(");

	FailResult result;
	result.check = usesBracketOperatorOrAt == false;
	result.msg = "Does not use [] or .at to return value at specified index";

	return result;
}

FailResult UnitTests_Lab2::Fail_ArrayBracketOperator_UsesForLoop() {
	bool usesForLoop = SearchFile("Lab2.h", "operator[](", "bool Contains(", "for");
	bool usesWhileLoop = SearchFile("Lab2.h", "operator[](", "bool Contains(", "while");

	FailResult result;
	result.check = usesForLoop || usesWhileLoop;
	result.msg = "Should not use any type of loop";

	return result;
}

FailResult UnitTests_Lab2::Fail_ArrayBracketOperator_DoesNotReturnValueAtIndex() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	int randomSize = size_t(RandomInt(5, 25));
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);

	int randomIndex = (int)RandomInt(1, randomSize - 1);

	bool correctValueReturned = vec[randomIndex] == randomVals[randomIndex];

	delete[] randomVals;

	FailResult result;
	result.check = correctValueReturned == false;
	result.msg = "operator[] does not return correct value";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_ArrayBracketOperator_UsesBracketOperatorOrAt() {
	bool usesBracketOperatorOrAt = SearchFile("Lab2.h", "operator[](", "bool Contains(", "mValues[") ||
		SearchFile("Lab2.h", "operator[](", "bool Contains(", "mValues.at(");

	bool result = usesBracketOperatorOrAt == true;

	return result;
}

bool UnitTests_Lab2::Pass_ArrayBracketOperator_ReturnsValueAtIndex() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	int randomSize = size_t(RandomInt(5, 25));
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);

	int randomIndex = (int)RandomInt(1, randomSize - 1);

	bool correctValueReturned = vec[randomIndex] == randomVals[randomIndex];

	delete[] randomVals;

	bool result = correctValueReturned == true;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Contains True
#if LAB2_CONTAINS_TRUE
void UnitTests_Lab2::Battery_ContainsTrue() {
	FailVector failVec;
	failVec.push_back(Fail_ContainsTrue_ReturnsFalseIfValueIsPresent);

	PassVector passVec;
	passVec.push_back(Pass_ContainsTrue_ReturnsTrueIfValueIsPresent);

	UnitTestBattery("Testing Contains for a value that is present", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_ContainsTrue_ReturnsFalseIfValueIsPresent() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);
	int randomValue = randomVals[RandomInt(1, randomSize - 1)];
	delete[] randomVals;

	bool contains = vec.Contains(randomValue);

	FailResult result;
	result.check = contains == false;
	result.msg = "Contains returned false when value was in vector";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_ContainsTrue_ReturnsTrueIfValueIsPresent() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);
	int randomValue = randomVals[RandomInt(1, randomSize - 1)];
	delete[] randomVals;

	bool contains = vec.Contains(randomValue);

	bool result = contains == true;

	return result;

}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Contains False
#if LAB2_CONTAINS_FALSE
void UnitTests_Lab2::Battery_ContainsFalse() {
	FailVector failVec;
	failVec.push_back(Fail_ContainsTrue_ReturnsTrueIfValueIsNotPresent);

	PassVector passVec;
	passVec.push_back(ContainsTrue_ReturnsTrueIfValueIsPresent);

	UnitTestBattery("Testing Contains for a value that is not present", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_ContainsTrue_ReturnsTrueIfValueIsNotPresent() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);
	int randomValue = (int)RandomInt(501, 1000);
	delete[] randomVals;

	bool contains = vec.Contains(randomValue);

	FailResult result;
	result.check = contains == true;
	result.msg = "Contains returned true when value was not in vector";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::ContainsTrue_ReturnsTrueIfValueIsPresent() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;

	int randomSize = RandomInt(5, 25);
	auto* randomVals = CreateRandomArray(randomSize, 100, 500);
	vals.assign(randomVals, randomVals + randomSize);
	int randomValue = (int)RandomInt(501, 1000);
	delete[] randomVals;

	bool contains = vec.Contains(randomValue);

	bool result = contains == false;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Remove Palindromes
#if LAB2_MOVE_PALINDROMES
void UnitTests_Lab2::Battery_MovePalindromes() {
	FailVector failVec;
	failVec.push_back(Fail_MovePalindromes_DoesNotEraseTwoPalindromesAtBegin);
	failVec.push_back(Fail_MovePalindromes_DoesNotEraseTwoPalindromesAtEnd);
	failVec.push_back(Fail_MovePalindromes_DoesNotEraseTwoPalindromesInMiddle);
	failVec.push_back(Fail_MovePalindromes_IncorrectValuesAddedToPalindromesVector);
	failVec.push_back(Fail_MovePalindromes_IncorrectValuesRemovedFromValuesVector);

	PassVector passVec;
	passVec.push_back(Pass_MovePalindromes_EraseTwoPalindromesAtBegin);
	passVec.push_back(Pass_MovePalindromes_EraseTwoPalindromesAtEnd);
	passVec.push_back(Pass_MovePalindromes_EraseTwoPalindromesInMiddle);
	passVec.push_back(Pass_MovePalindromes_CorrectValuesAddedToPalindromesVector);
	passVec.push_back(Pass_MovePalindromes_CorrectValuesRemovedFromValuesVector);

	UnitTestBattery("Testing moving and erasing palindromes", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab2::Fail_MovePalindromes_DoesNotEraseTwoPalindromesAtBegin() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	std::vector<int> nonPalindromes;

	// Adding values
	const int nums[] = { 68286, 405504, 4827, 12345, 99123 };
	vals.assign(nums, nums + 5);
	nonPalindromes.assign(nums + 2, nums + 5);

	vec.MovePalindromes();

	FailResult result;
	result.check = vals != nonPalindromes;
	result.msg = "Consecutive palindromes from beginning were not removed";

	return result;
}

FailResult UnitTests_Lab2::Fail_MovePalindromes_DoesNotEraseTwoPalindromesAtEnd() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	std::vector<int> nonPalindromes;

	// Adding values
	const int nums[] = { 45987, 18917, 4483, 5885, 3926293 };
	vals.assign(nums, nums + 5);
	nonPalindromes.assign(nums, nums + 3);

	vec.MovePalindromes();

	FailResult result;
	result.check = vals != nonPalindromes;
	result.msg = "Consecutive palindromes from end were not removed";

	return result;
}

FailResult UnitTests_Lab2::Fail_MovePalindromes_DoesNotEraseTwoPalindromesInMiddle() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	std::vector<int> nonPalindromes;

	// Adding values
	const int nums[] = { 4872, 67276, 481184, 239822, 10000 };
	vals.assign(nums, nums + 5);
	nonPalindromes = vals;
	nonPalindromes.erase(nonPalindromes.begin() + 1, nonPalindromes.begin() + 3);

	vec.MovePalindromes();

	FailResult result;
	result.check = vals != nonPalindromes;
	result.msg = "Consecutive palindromes from middle were not removed";

	return result;
}

FailResult UnitTests_Lab2::Fail_MovePalindromes_IncorrectValuesAddedToPalindromesVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	auto& pals = vec.mPalindromes;
	std::vector<int> palindromes;

	// Adding values
	const int nums[] = {		   7447, 4995994, 29837, 54737, 444, 14818, 572275, 1, 40211, 393393, 54445 };
	const int palindromeNums[] = { 7447, 4995994,               444,        572275, 1,        393393, 54445 };
	vals.assign(nums, nums + 11);
	palindromes.assign(palindromeNums, palindromeNums + 7);

	vec.MovePalindromes();

	FailResult result;
	result.check = pals != palindromes;
	result.msg = "Palindrome values were not added to palindrome vector";

	return result;
}

FailResult UnitTests_Lab2::Fail_MovePalindromes_IncorrectValuesRemovedFromValuesVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	auto& pals = vec.mPalindromes;
	std::vector<int> nonpalindromes;

	// Adding values
	const int nums[] = {		      7447, 4995994, 29837, 54737, 444, 14818, 572275, 1, 40211, 393393, 54445 };
	const int nonpalindromeNums[] = {				 29837, 54737,      14818,            40211 };
	vals.assign(nums, nums + 11);
	nonpalindromes.assign(nonpalindromeNums, nonpalindromeNums + 4);

	vec.MovePalindromes();

	FailResult result;
	result.check = vals != nonpalindromes;
	result.msg = "Palindrome values were not removed from values vector";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab2::Pass_MovePalindromes_EraseTwoPalindromesAtBegin() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	std::vector<int> nonPalindromes;

	// Adding values
	const int nums[] = { 68286, 405504, 4827, 12345, 99123 };
	vals.assign(nums, nums + 5);
	nonPalindromes.assign(nums + 2, nums + 5);

	vec.MovePalindromes();

	bool result = vals == nonPalindromes;

	return result;
}

bool UnitTests_Lab2::Pass_MovePalindromes_EraseTwoPalindromesAtEnd() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	std::vector<int> nonPalindromes;

	// Adding values
	const int nums[] = { 45987, 18917, 4483, 5885, 3926293 };
	vals.assign(nums, nums + 5);
	nonPalindromes.assign(nums, nums + 3);

	vec.MovePalindromes();

	bool result= vals == nonPalindromes;

	return result;
}

bool UnitTests_Lab2::Pass_MovePalindromes_EraseTwoPalindromesInMiddle() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	std::vector<int> nonPalindromes;

	// Adding values
	const int nums[] = { 4872, 67276, 481184, 239822, 10000 };
	vals.assign(nums, nums + 5);
	nonPalindromes = vals;
	nonPalindromes.erase(nonPalindromes.begin() + 1, nonPalindromes.begin() + 3);

	vec.MovePalindromes();

	bool result = vals == nonPalindromes;

	return result;
}

bool UnitTests_Lab2::Pass_MovePalindromes_CorrectValuesAddedToPalindromesVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	auto& pals = vec.mPalindromes;
	std::vector<int> palindromes;

	// Adding values
	const int nums[] = { 7447, 4995994, 29837, 54737, 444, 14818, 572275, 1, 40211, 393393, 54445 };
	const int palindromeNums[] = { 7447, 4995994,               444,        572275, 1,        393393, 54445 };
	vals.assign(nums, nums + 11);
	palindromes.assign(palindromeNums, palindromeNums + 7);

	vec.MovePalindromes();

	bool result = pals == palindromes;

	return result;
}

bool UnitTests_Lab2::Pass_MovePalindromes_CorrectValuesRemovedFromValuesVector() {
	DSA_Lab2 vec;
	auto& vals = vec.mValues;
	auto& pals = vec.mPalindromes;
	std::vector<int> nonpalindromes;

	// Adding values
	const int nums[] = { 7447, 4995994, 29837, 54737, 444, 14818, 572275, 1, 40211, 393393, 54445 };
	const int nonpalindromeNums[] = {   29837, 54737,      14818,            40211 };
	vals.assign(nums, nums + 11);
	nonpalindromes.assign(nonpalindromeNums, nonpalindromeNums + 4);

	vec.MovePalindromes();
	
	bool result = vals == nonpalindromes;

	return result;
}
#pragma endregion
#endif
#pragma endregion
#endif