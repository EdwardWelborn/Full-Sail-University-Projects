/*
File:			UnitTests_Lab5.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		09.19.2021
Last Modified:	09.19.2021
Purpose:		Definitions of Lab4 Unit Tests for Dictionary
Notes:			Property of Full Sail University
*/


/************/
/* Includes */
/************/
#include "UnitTests_Lab5.h"
#include "Memory_Management.h"

#define SIZEOFEMPTYLIST	64
#define SIZEOFLISTNODE	24

#if LAB_5
using pairList = std::list<UnitTests_Lab5::Pair>;

const int numPrimeBuckets = 6;
const size_t primeBuckets[numPrimeBuckets] = { 11, 13, 17, 19, 23, 29 };
int numBucket = -1;
int randomBucket = -1;

void UnitTests_Lab5::DictionaryWithValues::CleanUp() {
	if (dict->mTable == reinterpret_cast<pairList*>(-1))
		dict->mTable = nullptr;
	delete dict;
	delete[] values;
}


void UnitTests_Lab5::FullBattery() {
#if LAB5_PAIR_CTOR
	Battery_PairConstructor();
#endif
#if LAB5_CTOR
	Battery_DictionaryConstructor();
#endif
#if LAB5_DTOR
	Battery_Destructor();
#endif
#if LAB5_CLEAR
	Battery_Clear();
#endif
#if LAB5_INSERT_NEW
	Battery_Insert_NewKey();
#endif
#if LAB5_INSERT_EXISTING
	Battery_Insert_OverwriteExistingKey();
#endif
#if LAB5_FIND
	Battery_Find_KeyExists();
#endif
#if LAB5_FIND_NOT_FOUND
	Battery_Find_KeyDoesNotExist();
#endif
#if LAB5_REMOVE
	Battery_Remove_KeyExists();
#endif
#if LAB5_REMOVE_NOT_FOUND
	Battery_Remove_KeyDoesNotExist();
#endif
#if LAB5_ASSIGNMENT_OP
	Battery_AssignmentOperator();
#endif
#if LAB5_COPY_CTOR
	Battery_CopyConstructor();
#endif
}

unsigned int UnitTests_Lab5::Hash(const float& _f) {
	unsigned int index = static_cast<unsigned int>(std::hash<float>()(_f));
	return index % primeBuckets[randomBucket];
}

UnitTests_Lab5::DictionaryWithValues UnitTests_Lab5::CreateDictionary() {
	DictionaryWithValues dictWithValues;
	randomBucket = RandomInt(0, numPrimeBuckets - 1);
	dictWithValues.size = primeBuckets[randomBucket];
	dictWithValues.values = new float[100];
	dictWithValues.dict = new Dict(dictWithValues.size, Hash);


	if (dictWithValues.dict->mTable == reinterpret_cast<std::list<Pair>*>(-1) || dictWithValues.dict->mTable == nullptr)
		dictWithValues.dict->mTable = new pairList[dictWithValues.size];

	if (dictWithValues.dict->mNumBuckets == -1 || dictWithValues.dict->mNumBuckets == 0)
		dictWithValues.dict->mNumBuckets = dictWithValues.size;

	if (dictWithValues.dict->mHashFunc == (void*)-1 || dictWithValues.dict->mHashFunc == nullptr)
		dictWithValues.dict->mHashFunc = Hash;

	// Generating random values and storing in dict
	int currBucket = 0;
	for (size_t i = 0; i < 100; ++i) {
		dictWithValues.values[i] = RandomFloat(0, 100);
		currBucket = Hash(dictWithValues.values[i]);
		dictWithValues.dict->mTable[currBucket].push_back(Pair(dictWithValues.values[i], dictWithValues.values[i] * 2));
	}

	return dictWithValues;
}

#pragma region Test - Pair Constructor
#if LAB5_PAIR_CTOR
void UnitTests_Lab5::Battery_PairConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_PairConstructor_KeyIsIncorrectValue);
	failVec.push_back(Fail_PairConstructor_ValueIsIncorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_PairConstructor_KeyIsCorrectValue);
	passVec.push_back(Pass_PairConstructor_ValueIsCorrectValue);

	UnitTestBattery("Testing Pair constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_PairConstructor_KeyIsIncorrectValue() {
	float randomFloat = RandomFloat(1, 100);
	Pair pair(randomFloat, 0);

	FailResult result;
	result.check = pair.key != randomFloat;
	result.msg = "Key has incorrect value";

	return result;
}

FailResult UnitTests_Lab5::Fail_PairConstructor_ValueIsIncorrectValue() {
	float randomFloat = RandomFloat(1, 100);
	Pair pair(0, randomFloat);

	FailResult result;
	result.check = pair.value != randomFloat;
	result.msg = "Key has incorrect value";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_PairConstructor_KeyIsCorrectValue() {
	float randomFloat = RandomFloat(1, 100);
	Pair pair(randomFloat, 0);

	bool result = pair.key == randomFloat;

	return result;
}

bool UnitTests_Lab5::Pass_PairConstructor_ValueIsCorrectValue() {
	float randomFloat = RandomFloat(1, 100);
	Pair pair(0, randomFloat);

	bool result = pair.value == randomFloat;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Dictionary Constructor
#if LAB5_CTOR
void UnitTests_Lab5::Battery_DictionaryConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_DictionaryConstructor_TableIsNotAllocated);
	failVec.push_back(Fail_DictionaryConstructor_TableContainsIncorrectNumberOfLists);
	failVec.push_back(Fail_DictionaryConstructor_NumBucketsIsIncorrectValue);
	failVec.push_back(Fail_DictionaryConstructor_HashFuncIsNotPointingToValidFunction);

	PassVector passVec;
	passVec.push_back(Pass_DictionaryConstructor_TableContainsCorrectNumberOfLists);
	passVec.push_back(Pass_DictionaryConstructor_NumBucketsIsCorrectValue);
	passVec.push_back(Pass_DictionaryConstructor_HashFuncIsPointingToValidFunction);

	UnitTestBattery("Testing Dictionary constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_DictionaryConstructor_TableIsNotAllocated() {
	const int randomBuckets = RandomInt(10, 20);
	Dict dict(randomBuckets, Hash);

	FailResult result;
	result.check = dict.mTable == reinterpret_cast<std::list<Pair>*>(-1) || dict.mTable == nullptr;
	result.msg = "Table is not allocated";

	// Clean up
	if (dict.mTable == reinterpret_cast<pairList*>(-1))
		dict.mTable = nullptr;

	return result;
}

FailResult UnitTests_Lab5::Fail_DictionaryConstructor_TableContainsIncorrectNumberOfLists() {
	const int randomBuckets = RandomInt(10, 20);
	
	size_t memoryDeltaStart = inUse;
	Dict dict(randomBuckets, Hash);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = int(memoryDeltaEnd) - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated != (((int64_t)randomBuckets * SIZEOFEMPTYLIST) + sizeof(void*));
	result.msg = "Incorrect number of buckets allocated (mTable is an array of std::lists)";

	// Clean up
	if (dict.mTable == reinterpret_cast<pairList*>(-1))
		dict.mTable = nullptr;

	return result;
}

FailResult UnitTests_Lab5::Fail_DictionaryConstructor_NumBucketsIsIncorrectValue() {
	const int randomBuckets = RandomInt(10, 20);
	Dict dict(randomBuckets, Hash);

	FailResult result;
	result.check = dict.mNumBuckets != randomBuckets;
	result.msg = "NumBuckets was not set to correct value";

	// Clean up
	if (dict.mTable == reinterpret_cast<pairList*>(-1))
		dict.mTable = nullptr;

	return result;
}

FailResult UnitTests_Lab5::Fail_DictionaryConstructor_HashFuncIsNotPointingToValidFunction() {
	const int randomBuckets = RandomInt(10, 20);
	Dict dict(randomBuckets, Hash);

	FailResult result;
	result.check = dict.mHashFunc != Hash;
	result.msg = "HashFunc was not set to correct value";

	// Clean up
	if (dict.mTable == reinterpret_cast<pairList*>(-1))
		dict.mTable = nullptr;

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_DictionaryConstructor_TableContainsCorrectNumberOfLists() {
	const int randomBuckets = RandomInt(10, 20);

	size_t memoryDeltaStart = inUse;
	Dict dict(randomBuckets, Hash);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = int(memoryDeltaEnd) - memoryDeltaStart;

	bool result = memoryAllocated == (((int64_t)randomBuckets * SIZEOFEMPTYLIST) + sizeof(void*));

	return result;
}

bool UnitTests_Lab5::Pass_DictionaryConstructor_NumBucketsIsCorrectValue() {
	const int randomBuckets = RandomInt(10, 20);
	Dict dict(randomBuckets, Hash);

	bool result = dict.mNumBuckets == randomBuckets;

	return result;
}

bool UnitTests_Lab5::Pass_DictionaryConstructor_HashFuncIsPointingToValidFunction() {
	const int randomBuckets = RandomInt(10, 20);
	Dict dict(randomBuckets, Hash);

	bool result = dict.mHashFunc == Hash;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Destructor
#if LAB5_DTOR
void UnitTests_Lab5::Battery_Destructor() {
	FailVector failVec;
	failVec.push_back(Fail_Destructor_NotDeletedWithBrackets);
	failVec.push_back(Fail_Destructor_MemoryIsNotDeleted);

	PassVector passVec;
	passVec.push_back(Pass_Destructor_MemoryIsDeleted);

	UnitTestBattery("Testing destructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Destructor_NotDeletedWithBrackets() {
	bool deletedWithBrackets = SearchFile("Dictionary.h", "~Dictionary()", "// Copy constructor", "delete[]");

	FailResult result;
	result.check = deletedWithBrackets == false;
	result.msg = "Array was not deleted with brackets";

	return result;
}

FailResult UnitTests_Lab5::Fail_Destructor_MemoryIsNotDeleted() {
	const int randomBuckets = RandomInt(10, 20);

	size_t memoryDeltaStart = inUse;
	Dict* dict = new Dict(randomBuckets, Hash);

	// Preventing crash due to -1
	if (dict->mTable == reinterpret_cast<pairList*>(-1))
		dict->mTable = nullptr;

	delete dict;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = int(memoryDeltaEnd) - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > 0;
	result.msg = "Memory for table was not freed";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Destructor_MemoryIsDeleted() {
	const int randomBuckets = RandomInt(10, 20);

	size_t memoryDeltaStart = inUse;
	Dict* dict = new Dict(randomBuckets, Hash);
	delete dict;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = int(memoryDeltaEnd) - memoryDeltaStart;

	bool result = memoryAllocated == 0;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Clear
#if LAB5_CLEAR
void UnitTests_Lab5::Battery_Clear() {
	FailVector failVec;
	failVec.push_back(Fail_Clear_CallsDelete);
	failVec.push_back(Fail_Clear_NumBucketsIsChanged);
	failVec.push_back(Fail_Clear_HashFuncIsChanged);
	failVec.push_back(Fail_Clear_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Clear_TableHasNotBeenCleared);

	PassVector passVec;
	passVec.push_back(Pass_Clear_MemoryIsNotDeleted);
	passVec.push_back(Pass_Clear_NumBucketsIsNotChanged);
	passVec.push_back(Pass_Clear_HashFuncIsNotChanged);
	passVec.push_back(Pass_Clear_TableHasBeenCleared);

	UnitTestBattery("Testing Clear", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Clear_CallsDelete() {
	bool callsDelete = SearchFile("Dictionary.h", "void Clear()", "void Insert", "delete");

	FailResult result;
	result.check = callsDelete == true;
	result.msg = "There should be no calls to delete";

	return result;
}

FailResult UnitTests_Lab5::Fail_Clear_NumBucketsIsChanged() {
	DictionaryWithValues dict = CreateDictionary();

	dict.dict->Clear();

	FailResult result;
	result.check = dict.dict->mNumBuckets != dict.size;
	result.msg = "NumBuckets should not be changed";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Clear_HashFuncIsChanged() {
	DictionaryWithValues dict = CreateDictionary();

	dict.dict->Clear();

	FailResult result;
	result.check = dict.dict->mHashFunc != Hash;
	result.msg = "HashFunc should not be changed";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Clear_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "void Clear()", "void Insert", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Clear_TableHasNotBeenCleared() {
	DictionaryWithValues dict = CreateDictionary();

	dict.dict->Clear();

	bool allTablesCleared = true;

	for(size_t i = 0; i < dict.dict->mNumBuckets; ++i)
		if (dict.dict->mTable[i].size() != 0) {
			allTablesCleared = false;
			break;
		}

	FailResult result;
	result.check = allTablesCleared == false;
	result.msg = "Not all lists in table have been cleared";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Clear_MemoryIsNotDeleted() {
	DictionaryWithValues dict = CreateDictionary();

	size_t memoryDeltaStart = inUse;
	size_t memoryAfterClear = memoryDeltaStart - (SIZEOFLISTNODE * 100);
	dict.dict->Clear();
	size_t memoryDeltaEnd = inUse;

	bool result = memoryDeltaEnd == memoryAfterClear;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Clear_NumBucketsIsNotChanged() {
	DictionaryWithValues dict = CreateDictionary();

	dict.dict->Clear();

	bool result = dict.dict->mNumBuckets == dict.size;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Clear_HashFuncIsNotChanged() {
	DictionaryWithValues dict = CreateDictionary();

	dict.dict->Clear();

	bool result = dict.dict->mHashFunc == Hash;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Clear_TableHasBeenCleared() {
	DictionaryWithValues dict = CreateDictionary();

	dict.dict->Clear();

	bool allTablesCleared = true;

	for (size_t i = 0; i < dict.dict->mNumBuckets; ++i)
		if (dict.dict->mTable[i].size() != 0) {
			allTablesCleared = false;
			break;
		}

	bool result = allTablesCleared == true;

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert (New Key)
#if LAB5_INSERT_NEW
void UnitTests_Lab5::Battery_Insert_NewKey() {
	FailVector failVec;
	failVec.push_back(Fail_Insert_NewKey_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Insert_NewKey_HashFuncIsNotCalled);
	failVec.push_back(Fail_Insert_NewKey_MemoryHasBeenAllocated);
	failVec.push_back(Fail_Insert_NewKey_PairIsNotInsertedIntoCorrectBucket);
	failVec.push_back(Fail_Insert_NewKey_MoreThanOnePairIsAddedToBucket);
	failVec.push_back(Fail_Insert_NewKey_PairHasIncorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_Insert_NewKey_PairIsInsertedIntoCorrectBucket);
	passVec.push_back(Pass_Insert_NewKey_OnlyOnePairIsAddedToBucket);
	passVec.push_back(Pass_Insert_NewKey_PairHasCorrectValue);

	UnitTestBattery("Testing Insert (new key)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Insert_NewKey_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "void Insert(", "const Value* Find", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_NewKey_HashFuncIsNotCalled() {
	bool usesHashFunc = SearchFile("Dictionary.h", "void Insert(", "const Value* Find", "mHashFunc(");

	FailResult result;
	result.check = usesHashFunc == false;
	result.msg = "Does not call hash function to determine correct bucket";

	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_NewKey_MemoryHasBeenAllocated() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);

	size_t memoryDeltaStart = inUse;
	dict.dict->Insert(newKey, newKey * 2);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaStart + SIZEOFLISTNODE;
	result.msg = "No memory should be manually allocated";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_NewKey_PairIsNotInsertedIntoCorrectBucket() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);
	int correctBucket = Hash(newKey);
	auto* bucket = &dict.dict->mTable[correctBucket];

	dict.dict->Insert(newKey, newKey * 2);

	auto found = std::find_if(bucket->begin(),
		bucket->end(), [newKey](Pair p) {
		return p.key == newKey;
	});

	FailResult result;
	result.check = found == bucket->end();
	result.msg = "Pair was not added, not added to correct bucket, or does not have correct key";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_NewKey_MoreThanOnePairIsAddedToBucket() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);
	int correctBucket = Hash(newKey);
	auto* bucket = &dict.dict->mTable[correctBucket];

	size_t bucketStartSize = bucket->size();
	dict.dict->Insert(newKey, newKey * 2);
	
	FailResult result;
	result.check = bucket->size() > bucketStartSize + 1;
	result.msg = "More than one pair was added to bucket";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_NewKey_PairHasIncorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);
	int correctBucket = Hash(newKey);
	auto* bucket = &dict.dict->mTable[correctBucket];

	dict.dict->Insert(newKey, newKey * 2);

	auto found = std::find_if(bucket->begin(),
		bucket->end(), [newKey](Pair p) {
		return p.key == newKey && p.value == newKey*2;
	});

	FailResult result;
	result.check = found == bucket->end();
	result.msg = "Inserted pair has incorrect value";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests

bool UnitTests_Lab5::Pass_Insert_NewKey_PairIsInsertedIntoCorrectBucket() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);
	int correctBucket = Hash(newKey);
	auto* bucket = &dict.dict->mTable[correctBucket];

	dict.dict->Insert(newKey, newKey * 2);

	auto found = std::find_if(bucket->begin(),
		bucket->end(), [newKey](Pair p) {
		return p.key == newKey;
	});

	bool result = found != bucket->end();

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Insert_NewKey_OnlyOnePairIsAddedToBucket() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);
	int correctBucket = Hash(newKey);
	auto* bucket = &dict.dict->mTable[correctBucket];

	size_t bucketStartSize = bucket->size();
	dict.dict->Insert(newKey, newKey * 2);

	bool result = bucket->size() == bucketStartSize + 1;

	dict.CleanUp();
	return result;
}


bool UnitTests_Lab5::Pass_Insert_NewKey_PairHasCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);
	int correctBucket = Hash(newKey);
	auto* bucket = &dict.dict->mTable[correctBucket];

	dict.dict->Insert(newKey, newKey * 2);

	auto found = std::find_if(bucket->begin(),
		bucket->end(), [newKey](Pair p) {
		return p.key == newKey && p.value == newKey * 2;
	});

	bool result = found != bucket->end();

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert (Overwrite)
#if LAB5_INSERT_EXISTING
void UnitTests_Lab5::Battery_Insert_OverwriteExistingKey() {
	FailVector failVec;
	failVec.push_back(Fail_Insert_OverwriteExistingKey_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Insert_OverwriteExistingKey_HashFuncIsNotCalled);
	failVec.push_back(Fail_Insert_OverwriteExistingKey_MemoryHasBeenAllocated);
	failVec.push_back(Fail_Insert_OverwriteExistingKey_DuplicateKeyIsAddedToBucket);
	failVec.push_back(Fail_Insert_OverwriteExistingKey_PairValueIsNotUpdated);

	PassVector passVec;
	passVec.push_back(Pass_Insert_OverwriteExistingKey_NoPairsAddedToBucket);
	passVec.push_back(Pass_Insert_OverwriteExistingKey_PairHasCorrectValue);

	UnitTestBattery("Testing Insert (existing key)", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Insert_OverwriteExistingKey_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "void Insert(", "const Value* Find", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_OverwriteExistingKey_HashFuncIsNotCalled() {
	bool usesHashFunc = SearchFile("Dictionary.h", "void Insert(", "const Value* Find", "mHashFunc(");

	FailResult result;
	result.check = usesHashFunc == false;
	result.msg = "Does not call hash function to determine correct bucket";

	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_OverwriteExistingKey_MemoryHasBeenAllocated() {
	DictionaryWithValues dict = CreateDictionary();
	float newKey = RandomFloat(101, 200);

	size_t memoryDeltaStart = inUse;
	dict.dict->Insert(newKey, newKey * 2);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaStart + SIZEOFLISTNODE;
	result.msg = "No memory should be manually allocated";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_OverwriteExistingKey_DuplicateKeyIsAddedToBucket() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float dupeKey = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size-1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			dupeKey = iter->key;
			break;
		}
	}

	int correctBucket = Hash(dupeKey);

	dict.dict->Insert(dupeKey, dupeKey);

	auto count = std::count_if(bucket->begin(),
		bucket->end(), [dupeKey](Pair p) {
		return p.key == dupeKey;
	});

	FailResult result;
	result.check = count > 1;
	result.msg = "Should not add any pairs when the key already exists";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Insert_OverwriteExistingKey_PairValueIsNotUpdated() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float dupeKey = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			dupeKey = iter->key;
			break;
		}
	}

	int correctBucket = Hash(dupeKey);

	dict.dict->Insert(dupeKey, dupeKey);

	auto found = std::find_if(bucket->begin(),
		bucket->end(), [dupeKey](Pair p) {
		return p.key == dupeKey && p.value == dupeKey;
	});

	FailResult result;
	result.check = found == bucket->end();
	result.msg = "Value of existing key was not updated";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Insert_OverwriteExistingKey_NoPairsAddedToBucket() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float dupeKey = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			dupeKey = iter->key;
			break;
		}
	}

	int correctBucket = Hash(dupeKey);

	dict.dict->Insert(dupeKey, dupeKey);

	auto count = std::count_if(bucket->begin(),
		bucket->end(), [dupeKey](Pair p) {
		return p.key == dupeKey;
	});

	bool result = count == 1;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Insert_OverwriteExistingKey_PairHasCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float dupeKey = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			dupeKey = iter->key;
			break;
		}
	}

	int correctBucket = Hash(dupeKey);

	dict.dict->Insert(dupeKey, dupeKey);

	auto found = std::find_if(bucket->begin(),
		bucket->end(), [dupeKey](Pair p) {
		return p.key == dupeKey && p.value == dupeKey;
	});

	bool result = found != bucket->end();

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Find (Existing Key)
#if LAB5_FIND
void UnitTests_Lab5::Battery_Find_KeyExists() {
	FailVector failVec;
	failVec.push_back(Fail_Find_KeyExists_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Find_KeyExists_HashFuncIsNotCalled);
	failVec.push_back(Fail_Find_KeyExists_IncorrectAddressReturned);

	PassVector passVec;
	passVec.push_back(Pass_Find_KeyExists_CorrectAddressReturned);

	UnitTestBattery("Testing Find (existing key)", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Find_KeyExists_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "const Value * Find(", "bool Remove(", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Find_KeyExists_HashFuncIsNotCalled() {
	bool usesHashFunc = SearchFile("Dictionary.h", "const Value * Find(", "bool Remove(", "mHashFunc(");

	FailResult result;
	result.check = usesHashFunc == false;
	result.msg = "Does not call hash function to determine correct bucket";

	return result;
}

FailResult UnitTests_Lab5::Fail_Find_KeyExists_IncorrectAddressReturned() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float findKey = 0.0f;
	const float* valueAddress = nullptr;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			findKey = iter->key;
			valueAddress = &iter->value;
			break;
		}
	}

	const float* foundValue = dict.dict->Find(findKey);

	FailResult result;
	result.check = foundValue != valueAddress;
	result.msg = "Address of value was not returned";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Find_KeyExists_CorrectAddressReturned() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float findKey = 0.0f;
	const float* valueAddress = nullptr;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			findKey = iter->key;
			valueAddress = &iter->value;
			break;
		}
	}

	const float* foundValue = dict.dict->Find(findKey);

	bool result = foundValue == valueAddress;

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Find (Key Not Found)
#if LAB5_FIND_NOT_FOUND
void UnitTests_Lab5::Battery_Find_KeyDoesNotExist() {
	FailVector failVec;
	failVec.push_back(Fail_Find_KeyDoesNotExist_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Find_KeyDoesNotExist_HashFuncIsNotCalled);
	failVec.push_back(Fail_Find_KeyDoesNotExist_NullPointerIsNotReturned);

	PassVector passVec;
	passVec.push_back(Pass_Find_KeyDoesNotExist_NullPointerIsReturned);

	UnitTestBattery("Testing Find (key not found)", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Find_KeyDoesNotExist_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "const Value * Find(", "bool Remove(", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Find_KeyDoesNotExist_HashFuncIsNotCalled() {
	bool usesHashFunc = SearchFile("Dictionary.h", "const Value * Find(", "bool Remove(", "mHashFunc(");

	FailResult result;
	result.check = usesHashFunc == false;
	result.msg = "Does not call hash function to determine correct bucket";

	return result;
}

FailResult UnitTests_Lab5::Fail_Find_KeyDoesNotExist_NullPointerIsNotReturned() {
	DictionaryWithValues dict = CreateDictionary();
	float findKey = RandomFloat(500, 1000);

	const float* foundValue = dict.dict->Find(findKey);

	FailResult result;
	result.check = foundValue != nullptr;
	result.msg = "Did not return null when key was not found";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests

bool UnitTests_Lab5::Pass_Find_KeyDoesNotExist_NullPointerIsReturned() {
	DictionaryWithValues dict = CreateDictionary();
	float findKey = RandomFloat(500, 1000);

	const float* foundValue = dict.dict->Find(findKey);

	bool result = foundValue == nullptr;

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Remove (Existing Key)
#if LAB5_REMOVE
void UnitTests_Lab5::Battery_Remove_KeyExists() {
	FailVector failVec;
	failVec.push_back(Fail_Remove_KeyExists_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Remove_KeyExists_HashFuncIsNotCalled);
	failVec.push_back(Fail_Remove_KeyExists_BucketIsClearedInsteadOfRemovingSinglePair);
	failVec.push_back(Fail_Remove_KeyExists_PairIsNotRemovedFromBucket);
	failVec.push_back(Fail_Remove_KeyExists_ReturnsFalse);

	PassVector passVec;
	passVec.push_back(Pass_Remove_KeyExists_PairIsRemovedFromBucket);
	passVec.push_back(Pass_Remove_KeyExists_ReturnsTrue);

	UnitTestBattery("Testing Remove (existing key)", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Remove_KeyExists_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "bool Remove(", "};", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyExists_HashFuncIsNotCalled() {
	bool usesHashFunc = SearchFile("Dictionary.h", "bool Remove(", "};", "mHashFunc(");

	FailResult result;
	result.check = usesHashFunc == false;
	result.msg = "Does not call hash function to determine correct bucket";

	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyExists_BucketIsClearedInsteadOfRemovingSinglePair() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float keyToRemove = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			keyToRemove = iter->key;
			break;
		}
	}

	dict.dict->Remove(keyToRemove);

	FailResult result;
	result.check = bucket->size() == 0;
	result.msg = "Bucket was emptied, rather than removing single pair";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyExists_PairIsNotRemovedFromBucket() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float keyToRemove = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			keyToRemove = iter->key;
			break;
		}
	}

	size_t bucketSize = bucket->size();

	dict.dict->Remove(keyToRemove);

	auto keyIter = std::find_if(bucket->begin(), bucket->end(), [keyToRemove](const Pair& p) {
		return p.key == keyToRemove;
	});

	FailResult result;
	result.check = keyIter != bucket->end() || bucket->size() == bucketSize;
	result.msg = "Pair was not removed from bucket";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyExists_ReturnsFalse() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float keyToRemove = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			keyToRemove = iter->key;
			break;
		}
	}

	bool removed = dict.dict->Remove(keyToRemove);
	
	FailResult result;
	result.check = removed == false;
	result.msg = "Returned false when key was actually removed";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Remove_KeyExists_PairIsRemovedFromBucket() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float keyToRemove = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			keyToRemove = iter->key;
			break;
		}
	}

	dict.dict->Remove(keyToRemove);

	auto keyIter = std::find_if(bucket->begin(), bucket->end(), [keyToRemove](const Pair& p) {
		return p.key == keyToRemove;
	});

	bool result = keyIter == bucket->end();

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Remove_KeyExists_ReturnsTrue() {
	DictionaryWithValues dict = CreateDictionary();
	pairList* bucket = nullptr;
	pairList::iterator iter;
	float keyToRemove = 0.0f;

	for (;;) {
		int randomBucket = RandomInt(0, (int)dict.size - 1);
		if (dict.dict->mTable[randomBucket].size() > 1) {
			bucket = &dict.dict->mTable[randomBucket];
			iter = bucket->begin();
			int randomNode = RandomInt(1, (int)bucket->size() - 1);
			std::advance(iter, randomNode);
			keyToRemove = iter->key;
			break;
		}
	}

	bool removed = dict.dict->Remove(keyToRemove);

	bool result = removed == true;

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Remove (Key Not Found)
#if LAB5_REMOVE_NOT_FOUND
void UnitTests_Lab5::Battery_Remove_KeyDoesNotExist() {
	FailVector failVec;
	failVec.push_back(Fail_Remove_KeyDoesNotExist_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_Remove_KeyDoesNotExist_HashFuncIsNotCalled);
	failVec.push_back(Fail_Remove_KeyDoesNotExist_BucketIsCleared);
	failVec.push_back(Fail_Remove_KeyDoesNotExist_ReturnsTrue);

	PassVector passVec;
	passVec.push_back(Pass_Remove_KeyDoesNotExist_NoPairsAreRemovedFromBucket);
	passVec.push_back(Pass_Remove_KeyDoesNotExist_ReturnsFalse);

	UnitTestBattery("Testing Remove (key not found)", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_Remove_KeyDoesNotExist_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "bool Remove(", "};", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyDoesNotExist_HashFuncIsNotCalled() {
	bool usesHashFunc = SearchFile("Dictionary.h", "bool Remove(", "};", "mHashFunc(");

	FailResult result;
	result.check = usesHashFunc == false;
	result.msg = "Does not call hash function to determine correct bucket";

	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyDoesNotExist_BucketIsCleared() {
	DictionaryWithValues dict = CreateDictionary();
	float keyToRemove = RandomFloat(500,1000);
	pairList* bucket = &dict.dict->mTable[Hash(keyToRemove)];
	
	dict.dict->Remove(keyToRemove);

	FailResult result;
	result.check = bucket->size() == 0;
	result.msg = "Bucket was emptied when key was not found";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_Remove_KeyDoesNotExist_ReturnsTrue() {
	DictionaryWithValues dict = CreateDictionary();
	float keyToRemove = RandomFloat(500, 1000);
	pairList* bucket = &dict.dict->mTable[Hash(keyToRemove)];

	dict.dict->Remove(keyToRemove);

	bool removed = dict.dict->Remove(keyToRemove);

	FailResult result;
	result.check = removed == true;
	result.msg = "Returned false when there was no key to remove";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Remove_KeyDoesNotExist_NoPairsAreRemovedFromBucket() {
	DictionaryWithValues dict = CreateDictionary();
	float keyToRemove = RandomFloat(500, 1000);
	pairList* bucket = &dict.dict->mTable[Hash(keyToRemove)];
	size_t bucketSize = bucket->size();

	dict.dict->Remove(keyToRemove);

	bool result = bucket->size() == bucketSize;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Remove_KeyDoesNotExist_ReturnsFalse() {
	DictionaryWithValues dict = CreateDictionary();
	float keyToRemove = RandomFloat(500, 1000);
	pairList* bucket = &dict.dict->mTable[Hash(keyToRemove)];

	dict.dict->Remove(keyToRemove);

	bool removed = dict.dict->Remove(keyToRemove);

	bool result = removed == false;

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Assignment Operator
#if LAB5_ASSIGNMENT_OP
void UnitTests_Lab5::Battery_AssignmentOperator() {
	FailVector failVec;
	failVec.push_back(Fail_AssignmentOperator_NoSelfAssignmentCheck);
	failVec.push_back(Fail_AssignmentOperator_TableIsNotDeleted);
	failVec.push_back(Fail_AssignmentOperator_TableIsShallowCopied);
	failVec.push_back(Fail_AssignmentOperator_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_AssignmentOperator_ContentsOfAssignTableAreNotCopiedToInvokingObjectTable);
	failVec.push_back(Fail_AssignmentOperator_NumBucketsIsNotCorrectValue);
	failVec.push_back(Fail_AssignmentOperator_HashFuncIsNotCorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_Assignment_Operator_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_Assignment_Operator_TableContainsCorrectData);
	passVec.push_back(Pass_Assignment_Operator_NumBucketsIsCorrectValue);
	passVec.push_back(Pass_Assignment_Operator_HashFuncIsCorrectValue);

	UnitTestBattery("Testing assignment operator", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_AssignmentOperator_NoSelfAssignmentCheck() {
	bool selfAssignmentFound = SearchFile("Dictionary.h", "Dictionary& operator=(const Dictionary& _assign)", "void Clear()", "if(this != &_assign)");

	FailResult result;
	result.check = selfAssignmentFound == false;
	result.msg = "Self-assignment check not found";

	return result;
}

FailResult UnitTests_Lab5::Fail_AssignmentOperator_TableIsNotDeleted() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();
	int64_t diff = dict.size - assign.size;
	int64_t correctDiff = (int64_t)SIZEOFEMPTYLIST*diff;

	int64_t memoryDeltaStart = (int64_t)inUse;
	*assign.dict = *dict.dict;
	int64_t memoryDeltaEnd = (int64_t)inUse;
	int64_t memoryDiff = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = (memoryDeltaEnd-memoryDeltaStart) != correctDiff;
	result.msg = "Table was not deleted before re-allocation";

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_AssignmentOperator_TableIsShallowCopied() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	FailResult result;
	result.check = assign.dict->mTable == dict.dict->mTable;
	result.msg = "Table was shallow-copied";

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_AssignmentOperator_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "Dictionary& operator=(", "void Clear(", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_AssignmentOperator_ContentsOfAssignTableAreNotCopiedToInvokingObjectTable() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	bool correctData = true;
	if(dict.size == assign.dict->mNumBuckets) 
		for (int i = 0; i < dict.size; ++i) {
			if (assign.dict->mTable[i] != dict.dict->mTable[i]) {
				correctData = false;
				break;
			}
		}

	FailResult result;
	result.check = correctData == false;
	result.msg = "One or more lists in table did not have their contents copied over";

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_AssignmentOperator_NumBucketsIsNotCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	FailResult result;
	result.check = assign.dict->mNumBuckets != dict.dict->mNumBuckets; 
	result.msg = "NumBuckets is not correct value";

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_AssignmentOperator_HashFuncIsNotCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	dict.dict->mHashFunc = nullptr;
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	FailResult result;
	result.check = assign.dict->mHashFunc != dict.dict->mHashFunc;
	result.msg = "HashFunc is not pointing to correct function";

	dict.CleanUp();
	assign.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Assignment_Operator_CorrectAmountOfMemoryAllocated() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();
	int64_t diff = dict.size - assign.size;
	int64_t correctDiff = (int64_t)SIZEOFEMPTYLIST * diff;

	int64_t memoryDeltaStart = (int64_t)inUse;
	*assign.dict = *dict.dict;
	int64_t memoryDeltaEnd = (int64_t)inUse;
	int64_t memoryDiff = memoryDeltaEnd - memoryDeltaStart;

	bool result = (memoryDeltaEnd - memoryDeltaStart) == correctDiff;

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Assignment_Operator_TableContainsCorrectData() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	bool correctData = true;
	if (dict.size == assign.dict->mNumBuckets)
		for (int i = 0; i < dict.size; ++i) {
			if (assign.dict->mTable[i] != dict.dict->mTable[i]) {
				correctData = false;
				break;
			}
		}

	bool result = correctData == true;

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Assignment_Operator_NumBucketsIsCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	bool result = assign.dict->mNumBuckets == dict.dict->mNumBuckets;

	dict.CleanUp();
	assign.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Assignment_Operator_HashFuncIsCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	dict.dict->mHashFunc = nullptr;
	DictionaryWithValues assign = CreateDictionary();

	*assign.dict = *dict.dict;

	bool result = assign.dict->mHashFunc == dict.dict->mHashFunc;

	dict.CleanUp();
	assign.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Copy Constructor
#if LAB5_COPY_CTOR
void UnitTests_Lab5::Battery_CopyConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_CopyConstructor_TableIsShallowCopied);
	failVec.push_back(Fail_CopyConstructor_UsesArrowOperatorOnTable);
	failVec.push_back(Fail_CopyConstructor_ContentsOfAssignTableAreNotCopiedToInvokingObjectTable);
	failVec.push_back(Fail_CopyConstructor_NumBucketsIsNotCorrectValue);
	failVec.push_back(Fail_CopyConstructor_HashFuncIsNotCorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_Copy_Constructor_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_Copy_Constructor_TableContainsCorrectData);
	passVec.push_back(Pass_Copy_Constructor_NumBucketsIsCorrectValue);
	passVec.push_back(Pass_Copy_Constructor_HashFuncIsCorrectValue);

	UnitTestBattery("Testing copy constructor", failVec, passVec);

}

#pragma region Fail Tests
FailResult UnitTests_Lab5::Fail_CopyConstructor_TableIsShallowCopied() {
	DictionaryWithValues dict = CreateDictionary();

	Dict copy = *dict.dict;

	FailResult result;
	result.check = copy.mTable == dict.dict->mTable;
	result.msg = "Table was shallow-copied";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_CopyConstructor_UsesArrowOperatorOnTable() {
	bool usesArrowOperator = SearchFile("Dictionary.h", "Dictionary(const Dictionary&", "Dictionary& operator=(", "mTable->");

	FailResult result;
	result.check = usesArrowOperator == true;
	result.msg = "Using 'mTable->' is the same as using 'mTable[0].'";

	return result;
}

FailResult UnitTests_Lab5::Fail_CopyConstructor_ContentsOfAssignTableAreNotCopiedToInvokingObjectTable() {
	DictionaryWithValues dict = CreateDictionary();

	Dict copy = *dict.dict;

	bool correctData = true;
	if (dict.size == copy.mNumBuckets)
		for (int i = 0; i < dict.size; ++i) {
			if (copy.mTable[i] != dict.dict->mTable[i]) {
				correctData = false;
				break;
			}
		}

	FailResult result;
	result.check = correctData == false;
	result.msg = "One or more lists in table did not have their contents copied over";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_CopyConstructor_NumBucketsIsNotCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();

	Dict copy = *dict.dict;

	FailResult result;
	result.check = copy.mNumBuckets != dict.dict->mNumBuckets;
	result.msg = "NumBuckets is not correct value";

	dict.CleanUp();
	return result;
}

FailResult UnitTests_Lab5::Fail_CopyConstructor_HashFuncIsNotCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	dict.dict->mHashFunc = nullptr;

	Dict copy = *dict.dict;

	FailResult result;
	result.check = copy.mHashFunc != dict.dict->mHashFunc;
	result.msg = "HashFunc is not pointing to correct function";

	dict.CleanUp();
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab5::Pass_Copy_Constructor_CorrectAmountOfMemoryAllocated() {
	size_t memoryBefore = inUse;
	DictionaryWithValues dict = CreateDictionary();
	size_t memoryAfter = inUse;
	size_t memoryDictAllocated = memoryAfter - memoryBefore;
	size_t correctDiff = SIZEOFEMPTYLIST * dict.size + SIZEOFLISTNODE * 100 + sizeof(void*);

	size_t memoryDeltaStart = inUse;
	Dict copy = *dict.dict;
	size_t memoryDeltaEnd = inUse;
	size_t memoryCopyAllocated = memoryDeltaEnd - memoryDeltaStart;


	bool result = memoryCopyAllocated == correctDiff;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Copy_Constructor_TableContainsCorrectData() {
	DictionaryWithValues dict = CreateDictionary();

	Dict copy = *dict.dict;

	bool correctData = true;
	if (dict.size == copy.mNumBuckets)
		for (int i = 0; i < dict.size; ++i) {
			if (copy.mTable[i] != dict.dict->mTable[i]) {
				correctData = false;
				break;
			}
		}

	bool result = correctData == true;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Copy_Constructor_NumBucketsIsCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();

	Dict copy = *dict.dict;

	bool result = copy.mNumBuckets == dict.dict->mNumBuckets;

	dict.CleanUp();
	return result;
}

bool UnitTests_Lab5::Pass_Copy_Constructor_HashFuncIsCorrectValue() {
	DictionaryWithValues dict = CreateDictionary();
	dict.dict->mHashFunc = nullptr;

	Dict copy = *dict.dict;

	bool result = copy.mHashFunc == dict.dict->mHashFunc;

	dict.CleanUp();
	return result;
}
#pragma endregion
#endif
#pragma endregion
#endif