/*
File:			UnitTests_Lab3.cpp
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		09.19.2021
Last Modified:	09.19.2021
Purpose:		Definitions of Lab3 Unit Tests for DList
Notes:			Property of Full Sail University
*/

/************/
/* Includes */
/************/
#include "UnitTests_Lab3.h"
#include "Memory_Management.h"

#if LAB_3
void UnitTests_Lab3::FullBattery() {
#if LAB3_CTOR
	Battery_ListDefaultConstructor();
#endif
#if LAB3_NODE_CTOR_DEFAULT
	Battery_NodeConstructorWithDefaults();
#endif
#if LAB3_NODE_CTOR
	Battery_NodeConstructor();
#endif
#if LAB3_ADDHEAD_EMPTY
	Battery_AddHeadOnEmptyList();
#endif
#if LAB3_ADDHEAD
	Battery_AddHeadOnNonEmptyList();
#endif
#if LAB3_ADDTAIL_EMPTY
	Battery_AddTailOnEmptyList();
#endif
#if LAB3_ADDTAIL
	Battery_AddTailOnNonEmptyList();
#endif
#if LAB3_CLEAR
	Battery_Clear();
#endif
#if LAB3_DTOR
	Battery_Destructor();
#endif
#if LAB3_ITER_BEGIN
	Battery_IteratorBegin();
#endif
#if LAB3_ITER_END
	Battery_IteratorEnd();
#endif
#if LAB3_ITER_INCREMENT_PRE
	Battery_IteratorIncrementPreFix();
#endif
#if LAB3_ITER_INCREMENT_POST
	Battery_IteratorIncrementPostFix();
#endif
#if LAB3_ITER_DECREMENT_PRE
	Battery_IteratorDecrementPreFix();
#endif
#if LAB3_ITER_DECREMENT_POST
	Battery_IteratorDecrementPostFix();
#endif
#if LAB3_ITER_DEREFERENCE
	Battery_IteratorDereference();
#endif
#if LAB3_INSERT_EMPTY
	Battery_InsertOnEmptyList();
#endif
#if LAB3_INSERT_HEAD
	Battery_InsertAtHead();
#endif
#if LAB3_INSERT_MIDDLE
	Battery_InsertOnNonEmptyList();
#endif
#if LAB3_ERASE_EMPTY
	Battery_EraseEmpty();
#endif
#if LAB3_ERASE_HEAD
	Battery_EraseHead();
#endif
#if LAB3_ERASE_TAIL
	Battery_EraseTail();
#endif
#if LAB3_ERASE_MIDDLE
	Battery_EraseMiddle();
#endif
#if LAB3_ASSIGNMENT_OP
	Battery_AssignmentOperator();
#endif
#if LAB3_COPY_CTOR
	Battery_CopyConstructor();
#endif
}

// Protection in case pointers are still set to -1
void UnitTests_Lab3::ListNegativeOneProtection(List& _list) {
	if (_list.mHead == reinterpret_cast<Node*>(-1))
		_list.mHead = nullptr;
	if (_list.mTail == reinterpret_cast<Node*>(-1))
		_list.mTail = nullptr;
}

// Creating a test list for use with several unit tests
void UnitTests_Lab3::CreateList(List& _list, std::vector<Node*>& _nodes, size_t _numNodes) {
	for (size_t i = 0; i < _numNodes; ++i)
		_nodes.push_back(new Node((int)i));

	// Adding Nodes to list
	_list.mHead = _nodes.at(0);
	_list.mTail = _nodes.at(_numNodes - 1);
	// Connections
	_nodes[0]->next = _nodes[1];
	_nodes[0]->prev = nullptr;
	for (size_t i = 1; i < _numNodes - 1; ++i) {
		_nodes[i]->next = _nodes[i + 1];
		_nodes[i]->prev = _nodes[i - 1];
	}
	_nodes[_numNodes - 1]->prev = _nodes[_numNodes - 2];
	_nodes[_numNodes - 1]->next = nullptr;

	_list.mSize = _numNodes;
}

// Clean up memory allocated within unit tests
void UnitTests_Lab3::CleanList(std::vector<Node*> _nodes, List& _list) {
	for (Node* node : _nodes)
		delete node;
	_list.mHead = _list.mTail = nullptr;

}

#pragma region Test - List Default Constructor
#if LAB3_CTOR
void UnitTests_Lab3::Battery_ListDefaultConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_ListDefaultConstructor_HeadIsNotNull);
	failVec.push_back(Fail_ListDefaultConstructor_TailIsNotNull);
	failVec.push_back(Fail_ListDefaultConstructor_SizeIsNotZero);
	failVec.push_back(Fail_ListDefaultConstructor_MemoryIsAllocated);

	PassVector passVec;
	passVec.push_back(Pass_ListDefaultConstructor_HeadIsNull);
	passVec.push_back(Pass_ListDefaultConstructor_TailIsNull);
	passVec.push_back(Pass_ListDefaultConstructor_SizeIsZero);
	passVec.push_back(Pass_ListDefaultConstructor_NoMemoryIsAllocated);

	UnitTestBattery("Testing DList default constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_ListDefaultConstructor_HeadIsNotNull() {
	List list;

	FailResult result;
	result.check = list.mHead != nullptr;
	result.msg = "Head is not null";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_ListDefaultConstructor_TailIsNotNull() {
	List list;

	FailResult result;
	result.check = list.mTail != nullptr;
	result.msg = "Tail is not null";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_ListDefaultConstructor_SizeIsNotZero() {
	List list;

	FailResult result;
	result.check = list.mSize != 0;
	result.msg = "Size is not zero";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_ListDefaultConstructor_MemoryIsAllocated() {
	size_t memoryDeltaStart = inUse;
	List list;
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaStart;
	result.msg = "No memory should be allocated in an empty list";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_ListDefaultConstructor_HeadIsNull() {
	List list;

	bool result = list.mHead == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_ListDefaultConstructor_TailIsNull() {
	List list;

	bool result = list.mTail == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_ListDefaultConstructor_SizeIsZero() {
	List list;

	bool result = list.mSize == 0;

	return result;
}

bool UnitTests_Lab3::Pass_ListDefaultConstructor_NoMemoryIsAllocated() {
	size_t memoryDeltaStart = inUse;
	List list;
	size_t memoryDeltaEnd = inUse;

	bool result = memoryDeltaEnd == memoryDeltaStart;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Node Constructor With Defaults
#if LAB3_NODE_CTOR_DEFAULT
void UnitTests_Lab3::Battery_NodeConstructorWithDefaults() {
	FailVector failVec;
	failVec.push_back(Fail_NodeConstructorWithDefaults_DataIsNotCorrectValue);
	failVec.push_back(Fail_NodeConstructorWithDefaults_NextIsNotNull);
	failVec.push_back(Fail_NodeConstructorWithDefaults_PrevIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_NodeConstructorWithDefaults_DataIsCorrectValue);
	passVec.push_back(Pass_NodeConstructorWithDefaults_NextIsNull);
	passVec.push_back(Pass_NodeConstructorWithDefaults_PrevIsNull);

	UnitTestBattery("Testing Node constructor with default parameters", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_NodeConstructorWithDefaults_DataIsNotCorrectValue() {
	size_t randVal = RandomInt(1, 500);
	Node node((int)randVal);

	FailResult result;
	result.check = node.data != randVal;
	result.msg = "Data in node is incorrect";

	return result;
}

FailResult UnitTests_Lab3::Fail_NodeConstructorWithDefaults_NextIsNotNull() {
	Node node(1);

	FailResult result;
	result.check = node.next != nullptr;
	result.msg = "Node's next is not null";

	return result;
}

FailResult UnitTests_Lab3::Fail_NodeConstructorWithDefaults_PrevIsNotNull() {
	Node node(1);

	FailResult result;
	result.check = node.prev != nullptr;
	result.msg = "Node's prev is not null";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_NodeConstructorWithDefaults_DataIsCorrectValue() {
	size_t randVal = RandomInt(1, 500);
	Node node((int)randVal);

	bool result = node.data == randVal;

	return result;
}

bool UnitTests_Lab3::Pass_NodeConstructorWithDefaults_NextIsNull() {
	Node node(1);

	bool result = node.next == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_NodeConstructorWithDefaults_PrevIsNull() {
	Node node(1);

	bool result = node.prev == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Node Constructor
#if LAB3_NODE_CTOR
void UnitTests_Lab3::Battery_NodeConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_NodeConstructor_DataIsIncorrectValue);
	failVec.push_back(Fail_NodeConstructor_NextIsIncorrectAddress);
	failVec.push_back(Fail_NodeConstructor_PrevIsIncorrectAddress);

	PassVector passVec;
	passVec.push_back(Pass_NodeConstructor_DataIsCorrectValue);
	passVec.push_back(Pass_NodeConstructor_NextIsCorrectAddress);
	passVec.push_back(Pass_NodeConstructor_PrevIsCorrectAddress);

	UnitTestBattery("Testing Node constructor with valid next and prev pointers", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_NodeConstructor_DataIsIncorrectValue() {
	int randVal = RandomInt(1, 500);
	Node node(randVal);

	FailResult result;
	result.check = node.data != randVal;
	result.msg = "Data in node is incorrect";

	return result;
}

FailResult UnitTests_Lab3::Fail_NodeConstructor_NextIsIncorrectAddress() {
	Node next(0);
	Node node(0, &next);

	FailResult result;
	result.check = node.next != &next;
	result.msg = "Node's next is not pointing to correct node";

	return result;
}

FailResult UnitTests_Lab3::Fail_NodeConstructor_PrevIsIncorrectAddress() {
	Node prev(0);
	Node node(0, nullptr, &prev);

	FailResult result;
	result.check = node.prev != &prev;
	result.msg = "Node's prev is not pointing to correct node";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_NodeConstructor_DataIsCorrectValue() {
	int randVal = RandomInt(1, 500);
	Node node(randVal);

	bool result = node.data == randVal;

	return result;
}

bool UnitTests_Lab3::Pass_NodeConstructor_NextIsCorrectAddress() {
	Node next(0);
	Node node(0, &next);

	bool result = node.next == &next;

	return result;
}

bool UnitTests_Lab3::Pass_NodeConstructor_PrevIsCorrectAddress() {
	Node prev(0);
	Node node(0, nullptr, &prev);

	bool result = node.prev == &prev;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - AddHead On Empty List
#if LAB3_ADDHEAD_EMPTY
void UnitTests_Lab3::Battery_AddHeadOnEmptyList() {
	FailVector failVec;
	failVec.push_back(Fail_AddHeadOnEmptyList_NoNodesAllocated);
	failVec.push_back(Fail_AddHeadOnEmptyList_MoreThanOneNodeAllocated);
	failVec.push_back(Fail_AddHeadOnEmptyList_HeadIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddHeadOnEmptyList_TailIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddHeadOnEmptyList_HeadAndTailAreNotPointingToSameNode);
	failVec.push_back(Fail_AddheadOnEmptyList_HeadDataIsIncorrectValue);
	failVec.push_back(Fail_AddHeadOnEmptyList_HeadPrevIsNotNull);
	failVec.push_back(Fail_AddHeadOnEmptyList_TailNextIsNotNull);
	failVec.push_back(Fail_AddHeadOnEmptyList_SizeIsNotOne);

	PassVector passVec;
	passVec.push_back(Pass_AddHeadOnEmptyList_OnlyOneNodeAllocated);
	passVec.push_back(Pass_AddHeadOnEmptyList_HeadIsPointingToCreatedNode);
	passVec.push_back(Pass_AddHeadOnEmptyList_TailIsPointingToCreatedNode);
	passVec.push_back(Pass_AddHeadOnEmptyList_HeadAndTailArePointingToSameNode);
	passVec.push_back(Pass_AddheadOnEmptyList_HeadDataIsCorrectValue);
	passVec.push_back(Pass_AddHeadOnEmptyList_HeadPrevIsNull);
	passVec.push_back(Pass_AddHeadOnEmptyList_TailNextIsNull);
	passVec.push_back(Pass_AddHeadOnEmptyList_SizeIsOne);

	UnitTestBattery("Testing AddHead on empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_NoNodesAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddHead(RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryDelta == 0;
	result.msg = "No memory allocated";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_MoreThanOneNodeAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddHead(RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryDelta > sizeof(Node);
	result.msg = "Only one node should be allocated";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_HeadIsNotPointingToCreatedNode() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead == nullptr;
	result.msg = "Head is not pointing to created node";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_TailIsNotPointingToCreatedNode() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail == nullptr;
	result.msg = "Tail is not pointing to created node";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_HeadAndTailAreNotPointingToSameNode() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead && list.mHead != list.mTail;
	result.msg = "Head and Tail are not pointing to same node";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddheadOnEmptyList_HeadDataIsIncorrectValue() {
	List list;

	int randomVal = RandomInt(1, 100);
	list.AddHead(randomVal);

	FailResult result;
	result.check = list.mHead != reinterpret_cast<Node*>(-1) && list.mHead && list.mHead->data != randomVal;
	result.msg = "Node's data was not set correctly";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_HeadPrevIsNotNull() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead != reinterpret_cast<Node*>(-1) && list.mHead && list.mHead->prev != nullptr;
	result.msg = "Node's prev is not set to null";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_TailNextIsNotNull() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail != reinterpret_cast<Node*>(-1) && list.mTail && list.mTail->next != nullptr;
	result.msg = "Node's next is not set to null";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnEmptyList_SizeIsNotOne() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mSize != 1;
	result.msg = "Size was not incremented";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_OnlyOneNodeAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddHead(RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryDelta == sizeof(Node);
	
	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_HeadIsPointingToCreatedNode() {
	List list;

	list.AddHead(RandomInt(5, 10));

	bool result = list.mHead != nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_TailIsPointingToCreatedNode() {
	List list;

	list.AddHead(RandomInt(5, 10));

	bool result = list.mTail != nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_HeadAndTailArePointingToSameNode() {
	List list;

	list.AddHead(RandomInt(5, 10));

	bool result = list.mHead && list.mHead == list.mTail;

	return result;
}

bool UnitTests_Lab3::Pass_AddheadOnEmptyList_HeadDataIsCorrectValue() {
	List list;

	int randomVal = RandomInt(1, 100);
	list.AddHead(randomVal);

	bool result = list.mHead && list.mHead->data == randomVal;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_HeadPrevIsNull() {
	List list;

	list.AddHead(RandomInt(5, 10));

	bool result = list.mHead && list.mHead->prev == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_TailNextIsNull() {
	List list;

	list.AddHead(RandomInt(5, 10));

	bool result = list.mTail && list.mTail->next == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnEmptyList_SizeIsOne() {
	List list;

	list.AddHead(RandomInt(5, 10));

	bool result = list.mSize == 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - AddHead On Non-Empty List
#if LAB3_ADDHEAD

void UnitTests_Lab3::Battery_AddHeadOnNonEmptyList() {
	FailVector failVec;
	failVec.push_back(Fail_AddHeadOnNonEmptyList_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_HeadIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_HeadDataIsIncorrectValue);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_HeadPrevIsNotNull);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_HeadNextIsNotPointingToOldHead);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_OldHeadsPrevIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_TailAddressIsChanged);
	failVec.push_back(Fail_AddHeadOnNonEmptyList_SizeIsNotIncremented);

	PassVector passVec;
	passVec.push_back(Pass_AddHeadOnNonEmptyList_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_HeadIsPointingToCreatedNode);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_HeadDataIsCorrectValue);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_HeadPrevIsNull);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_HeadNextIsPointingToOldHead);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_OldHeadsPrevIsPointingToCreatedNode);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_TailAddressIsNotChanged);
	passVec.push_back(Pass_AddHeadOnNonEmptyList_SizeIsIncremented);

	UnitTestBattery("Testing AddHead on non-empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_IncorrectAmountOfMemoryAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddHead(RandomInt(10, 20));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated != sizeof(Node);
	result.msg = "Incorrect amount of memory allocated";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_HeadIsNotPointingToCreatedNode() {
	List list;

	list.AddHead(RandomInt(10, 20));

	FailResult result;
	result.check = list.mHead == nullptr;
	result.msg = "Head is not pointing to dynamically allocated node";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_HeadDataIsIncorrectValue() {
	List list;

	int randomVal = RandomInt(10, 20);
	list.AddHead(randomVal);

	FailResult result;
	result.check = list.mHead != reinterpret_cast<Node*>(-1) && list.mHead && list.mHead->data != randomVal;
	result.msg = "Data of node was not set correctly";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_HeadPrevIsNotNull() {
	List list;

	list.AddHead(RandomInt(10, 20));

	FailResult result;
	result.check = list.mHead != reinterpret_cast<Node*>(-1) && list.mHead && list.mHead->prev != nullptr;
	result.msg = "Head's prev is not pointing to null";

	// Error-protection
	ListNegativeOneProtection(list); 
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_HeadNextIsNotPointingToOldHead() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddHead(RandomInt(25, 50));

	FailResult result;
	result.check = list.mHead && list.mHead->next != &head;
	result.msg = "New head's next is not pointing to old head";

	// Clean up links to non-allocated nodes
	if (list.mHead != reinterpret_cast<Node*>(-1) && list.mHead)
		list.mHead->next = nullptr;

	// Error-protection
	ListNegativeOneProtection(list); 
	if (list.mHead == &head)
		list.mHead = nullptr;
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_OldHeadsPrevIsNotPointingToCreatedNode() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddHead(RandomInt(25, 50));

	FailResult result;
	result.check = head.prev != list.mHead;
	result.msg = "Old head's prev is not pointing to new head";

	// Clean up links to non-allocated nodes
	if (list.mHead != reinterpret_cast<Node*>(-1) && list.mHead)
		list.mHead->next = nullptr;

	// Error-protection
	ListNegativeOneProtection(list);
	if (list.mHead == &head)
		list.mHead = nullptr;
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_TailAddressIsChanged() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddHead(RandomInt(25, 50));

	FailResult result;
	result.check = list.mTail && list.mTail != &tail;
	result.msg = "Tail should not be changed when adding new head to non-empty list";

	// Clean up links to non-allocated nodes
	if (list.mHead != reinterpret_cast<Node*>(-1) && list.mHead)
		list.mHead->next = nullptr;

	// Error-protection
	ListNegativeOneProtection(list); 
	if (list.mHead == &head)
		list.mHead = nullptr;
	
	return result;
}

FailResult UnitTests_Lab3::Fail_AddHeadOnNonEmptyList_SizeIsNotIncremented() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;
	size_t listSize = list.mSize = 3;

	list.AddHead(RandomInt(25, 50));

	FailResult result;
	result.check = list.mSize < listSize + 1;
	result.msg = "Size member was not incremented";

	// Clean up links to non-allocated nodes
	if (list.mHead != reinterpret_cast<Node*>(-1) && list.mHead)
		list.mHead->next = nullptr;

	// Error-protection
	ListNegativeOneProtection(list); 
	if (list.mHead == &head)
		list.mHead = nullptr;
	
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_CorrectAmountOfMemoryAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddHead(RandomInt(10, 20));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_HeadIsPointingToCreatedNode() {
	List list;

	list.AddHead(RandomInt(10, 20));

	bool result = list.mHead != nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_HeadDataIsCorrectValue() {
	List list;

	int randomVal = RandomInt(10, 20);
	list.AddHead(randomVal);

	bool result = list.mHead && list.mHead->data == randomVal;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_HeadPrevIsNull() {
	List list;

	list.AddHead(RandomInt(10, 20));

	bool result = list.mHead && list.mHead->prev == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_HeadNextIsPointingToOldHead() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddHead(RandomInt(25, 50));

	bool result = list.mHead && list.mHead->next == &head;
	
	// Clean up links to non-allocated nodes
	if (list.mHead)
		list.mHead->next = nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_OldHeadsPrevIsPointingToCreatedNode() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddHead(RandomInt(25, 50));

	bool result = head.prev == list.mHead;

	// Clean up links to non-allocated nodes
	if (list.mHead)
		list.mHead->next = nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_TailAddressIsNotChanged() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddHead(RandomInt(25, 50));

	bool result = list.mTail && list.mTail == &tail;

	// Clean up links to non-allocated nodes
	if (list.mHead)
		list.mHead->next = nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddHeadOnNonEmptyList_SizeIsIncremented() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;
	size_t listSize = list.mSize = 3;

	list.AddHead(RandomInt(25, 50));

	bool result = list.mSize == listSize + 1;

	// Clean up links to non-allocated nodes
	if (list.mHead)
		list.mHead->next = nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - AddTail On Empty List
#if LAB3_ADDTAIL_EMPTY
void UnitTests_Lab3::Battery_AddTailOnEmptyList() {
	FailVector failVec;
	failVec.push_back(Fail_AddTailOnEmptyList_NoNodesAllocated);
	failVec.push_back(Fail_AddTailOnEmptyList_MoreThanOneNodeAllocated);
	failVec.push_back(Fail_AddTailOnEmptyList_HeadIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddTailOnEmptyList_TailIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddTailOnEmptyList_HeadAndTailAreNotPointingToSameNode);
	failVec.push_back(Fail_AddTailOnEmptyList_TailDataIsIncorrectValue);
	failVec.push_back(Fail_AddTailOnEmptyList_HeadPrevIsNotNull);
	failVec.push_back(Fail_AddTailOnEmptyList_TailNextIsNotNull);
	failVec.push_back(Fail_AddTailOnEmptyList_SizeIsNotOne);

	PassVector passVec;
	passVec.push_back(Pass_AddTailOnEmptyList_OnlyOneNodeAllocated);
	passVec.push_back(Pass_AddTailOnEmptyList_HeadIsPointingToCreatedNode);
	passVec.push_back(Pass_AddTailOnEmptyList_TailIsPointingToCreatedNode);
	passVec.push_back(Pass_AddTailOnEmptyList_HeadAndTailArePointingToSameNode);
	passVec.push_back(Pass_AddTailOnEmptyList_TailDataIsCorrectValue);
	passVec.push_back(Pass_AddTailOnEmptyList_HeadPrevIsNull);
	passVec.push_back(Pass_AddTailOnEmptyList_TailNextIsNull);
	passVec.push_back(Pass_AddTailOnEmptyList_SizeIsOne);

	UnitTestBattery("Testing AddTail on empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_NoNodesAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddTail(RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryDelta == 0;
	result.msg = "No memory allocated";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_MoreThanOneNodeAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddTail(RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryDelta > sizeof(Node);
	result.msg = "Only one node should be allocated";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_HeadIsNotPointingToCreatedNode() {
	List list;

	list.AddTail(RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead == nullptr;
	result.msg = "Head is not pointing to created node";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_TailIsNotPointingToCreatedNode() {
	List list;

	list.AddTail(RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail == nullptr;
	result.msg = "Tail is not pointing to created node";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_HeadAndTailAreNotPointingToSameNode() {
	List list;

	list.AddTail(RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail && list.mHead != list.mTail;
	result.msg = "Head and Tail are not pointing to same node";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_TailDataIsIncorrectValue() {
	List list;

	int randomVal = RandomInt(1, 100);
	list.AddTail(randomVal);

	FailResult result;
	result.check = list.mTail != reinterpret_cast<Node*>(-1) && list.mTail && list.mTail->data != randomVal;
	result.msg = "Node's data was not set correctly";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_HeadPrevIsNotNull() {
	List list;

	list.AddTail(RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead != reinterpret_cast<Node*>(-1) && list.mHead && list.mHead->prev != nullptr;
	result.msg = "Node's prev is not set to null";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_TailNextIsNotNull() {
	List list;

	list.AddTail(RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail != reinterpret_cast<Node*>(-1) && list.mTail && list.mTail->next != nullptr;
	result.msg = "Node's next is not set to null";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnEmptyList_SizeIsNotOne() {
	List list;

	list.AddHead(RandomInt(5, 10));

	FailResult result;
	result.check = list.mSize != 1;
	result.msg = "Size was not incremented";

	// Error protection
	ListNegativeOneProtection(list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_AddTailOnEmptyList_OnlyOneNodeAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddTail(RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;
	
	bool result = memoryDelta == sizeof(Node);
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_HeadIsPointingToCreatedNode() {
	List list;

	list.AddTail(RandomInt(5, 10));

	bool result = list.mHead != nullptr;
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_TailIsPointingToCreatedNode() {
	List list;

	list.AddTail(RandomInt(5, 10));
	
	bool result = list.mTail != nullptr;
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_HeadAndTailArePointingToSameNode() {
	List list;

	list.AddTail(RandomInt(5, 10));

	bool result = list.mTail && list.mHead == list.mTail;
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_TailDataIsCorrectValue() {
	List list;

	int randomVal = RandomInt(1, 100);
	list.AddTail(randomVal);

	bool result = list.mTail && list.mTail->data == randomVal;
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_HeadPrevIsNull() {
	List list;

	list.AddTail(RandomInt(5, 10));
	
	bool result = list.mHead && list.mHead->prev == nullptr;
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_TailNextIsNull() {
	List list;

	list.AddTail(RandomInt(5, 10));

	bool result = list.mTail && list.mTail->next == nullptr;
	
	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnEmptyList_SizeIsOne() {
	List list;

	list.AddTail(RandomInt(5, 10));
	
	bool result = list.mSize == 1;
	
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - AddTail On Non-Empty List
#if LAB3_ADDTAIL
void UnitTests_Lab3::Battery_AddTailOnNonEmptyList() {
	FailVector failVec;
	failVec.push_back(Fail_AddTailOnNonEmptyList_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_AddTailOnNonEmptyList_TailIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddTailOnNonEmptyList_TailDataIsIncorrectValue);
	failVec.push_back(Fail_AddTailOnNonEmptyList_TailNextIsNotNull);
	failVec.push_back(Fail_AddTailOnNonEmptyList_TailPrevIsNotPointingToOldTail);
	failVec.push_back(Fail_AddTailOnNonEmptyList_OldTailsPrevIsNotPointingToCreatedNode);
	failVec.push_back(Fail_AddTailOnNonEmptyList_HeadAddressIsChanged);
	failVec.push_back(Fail_AddTailOnNonEmptyList_SizeIsNotIncremented);

	PassVector passVec;
	passVec.push_back(Pass_AddTailOnNonEmptyList_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_AddTailOnNonEmptyList_TailIsPointingToCreatedNode);
	passVec.push_back(Pass_AddTailOnNonEmptyList_TailDataIsCorrectValue);
	passVec.push_back(Pass_AddTailOnNonEmptyList_TailNextIsNull);
	passVec.push_back(Pass_AddTailOnNonEmptyList_TailPrevIsPointingToOldTail);
	passVec.push_back(Pass_AddTailOnNonEmptyList_OldTailsPrevIsPointingToCreatedNode);
	passVec.push_back(Pass_AddTailOnNonEmptyList_HeadAddressIsNotChanged);
	passVec.push_back(Pass_AddTailOnNonEmptyList_SizeIsIncremented);

	UnitTestBattery("Testing AddTail on non-empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_IncorrectAmountOfMemoryAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddTail(RandomInt(10, 20));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated != sizeof(Node);
	result.msg = "Incorrect amount of memory allocated";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_TailIsNotPointingToCreatedNode() {
	List list;

	list.AddTail(RandomInt(10, 20));

	FailResult result;
	result.check = list.mTail == nullptr;
	result.msg = "Tail is not pointing to dynamically allocated node";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_TailDataIsIncorrectValue() {
	List list;

	int randomVal = RandomInt(10, 20);
	list.AddTail(randomVal);

	FailResult result;
	result.check = list.mTail != reinterpret_cast<Node*>(-1) && list.mTail && list.mTail->data != randomVal;
	result.msg = "Data of node was not set correctly";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_TailNextIsNotNull() {
	List list;

	list.AddTail(RandomInt(10, 20));

	FailResult result;
	result.check = list.mTail != reinterpret_cast<Node*>(-1) && list.mTail && list.mTail->next != nullptr;
	result.msg = "Tail's next is not pointing to null";

	// Error-protection
	ListNegativeOneProtection(list);

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_TailPrevIsNotPointingToOldTail() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddTail(RandomInt(25, 50));

	FailResult result;
	result.check = list.mTail && list.mTail->prev != &tail;
	result.msg = "New tail's prev is not pointing to old tail";

	// Clean up links to non-allocated nodes
	if (list.mTail != &tail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	// Error-protection
	if (list.mHead == &head)
		list.mHead = nullptr;

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_OldTailsPrevIsNotPointingToCreatedNode() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddTail(RandomInt(25, 50));

	FailResult result;
	result.check = tail.next != list.mTail;
	result.msg = "Old tail's next is not pointing to new tail";

	// Clean up links to non-allocated nodes
	if (list.mTail != &tail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	// Error-protection
	ListNegativeOneProtection(list);
	if (list.mHead == &head)
		list.mHead = nullptr;
	if (list.mTail == &tail)
		list.mTail = nullptr;

	return result;
}
FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_HeadAddressIsChanged() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddTail(RandomInt(25, 50));

	FailResult result;
	result.check = list.mHead && list.mHead != &head;
	result.msg = "Tail should not be changed when adding new tail to non-empty list";

	// Clean up links to non-allocated nodes
	if (list.mTail != &tail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	// Error-protection
	ListNegativeOneProtection(list);
	if (list.mHead == &head)
		list.mHead = nullptr;
	if (list.mTail == &tail)
		list.mTail = nullptr;

	return result;
}

FailResult UnitTests_Lab3::Fail_AddTailOnNonEmptyList_SizeIsNotIncremented() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;
	size_t listSize = list.mSize = 3;

	list.AddTail(RandomInt(25, 50));

	FailResult result;
	result.check = list.mSize < listSize + 1;
	result.msg = "Size member was not incremented";

	// Clean up links to non-allocated nodes
	if (list.mTail != &tail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	// Error-protection
	ListNegativeOneProtection(list);
	if (list.mHead == &head)
		list.mHead = nullptr;
	if (list.mTail == &tail)
		list.mTail = nullptr;

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_CorrectAmountOfMemoryAllocated() {
	List list;

	size_t memoryDeltaStart = inUse;
	list.AddTail(RandomInt(10, 20));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_TailIsPointingToCreatedNode() {
	List list;

	list.AddTail(RandomInt(10, 20));
	
	bool result = list.mTail != nullptr;

	return result;
}
bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_TailDataIsCorrectValue() {
	List list;

	int randomVal = RandomInt(10, 20);
	list.AddTail(randomVal);
	
	bool result = list.mTail && list.mTail->data == randomVal;

	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_TailNextIsNull() {
	List list;

	list.AddTail(RandomInt(10, 20));
	
	bool result = list.mTail && list.mTail->next == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_TailPrevIsPointingToOldTail() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddTail(RandomInt(25, 50));

	bool result = list.mTail && list.mTail->prev == &tail;

	// Clean up links to non-allocated nodes
	if (list.mTail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_OldTailsPrevIsPointingToCreatedNode() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddTail(RandomInt(25, 50));
	
	bool result = tail.next == list.mTail;
	
	// Clean up links to non-allocated nodes
	if (list.mTail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_HeadAddressIsNotChanged() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;

	list.AddTail(RandomInt(25, 50));
	
	bool result = list.mHead && list.mHead == &head;

	// Clean up links to non-allocated nodes
	if (list.mTail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	return result;
}

bool UnitTests_Lab3::Pass_AddTailOnNonEmptyList_SizeIsIncremented() {
	List list;

	// Creating some nodes to form a list
	Node head(RandomInt(10, 20));
	Node mid(RandomInt(10, 20));
	Node tail(RandomInt(10, 20));
	// Linking them together
	head.next = &mid;
	mid.prev = &head;
	mid.next = &tail;
	tail.prev = &mid;

	// Setting data members
	list.mHead = &head;
	list.mTail = &tail;
	size_t listSize = list.mSize = 3;

	list.AddTail(RandomInt(25, 50));

	bool result = list.mSize == listSize + 1;

	// Clean up links to non-allocated nodes
	if (list.mTail) {
		delete list.mTail;
		list.mHead = list.mTail = nullptr;
	}

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Clear
#if LAB3_CLEAR
void UnitTests_Lab3::Battery_Clear() {
	FailVector failVec;
	failVec.push_back(Fail_Clear_AllNodesAreNotDeleted);
	failVec.push_back(Fail_Clear_HeadIsNotNull);
	failVec.push_back(Fail_Clear_TailIsNotNull);
	failVec.push_back(Fail_Clear_SizeIsNotZero);

	PassVector passVec;
	passVec.push_back(Pass_Clear_AllNodesAreDeleted);
	passVec.push_back(Pass_Clear_HeadIsNull);
	passVec.push_back(Pass_Clear_TailIsNull);
	passVec.push_back(Pass_Clear_SizeIsZero);

	UnitTestBattery("Testing Clear", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_Clear_AllNodesAreNotDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryToClear = sizeof(Node) * numberOfNodes;

	size_t memoryDeltaStart = inUse;
	list.Clear();
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > (memoryDeltaStart - memoryToClear);
	result.msg = "Not all memory was cleared";

	return result;
}

FailResult UnitTests_Lab3::Fail_Clear_HeadIsNotNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	list.Clear();
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = list.mHead != nullptr;
	result.msg = "Head was not reset to null";

	return result;
}

FailResult UnitTests_Lab3::Fail_Clear_TailIsNotNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	list.Clear();
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = list.mTail != nullptr;
	result.msg = "Tail was not reset to null";

	return result;
}

FailResult UnitTests_Lab3::Fail_Clear_SizeIsNotZero() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	list.Clear();
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = list.mSize != 0;
	result.msg = "Size was not reset to zero";
	
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_Clear_AllNodesAreDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryToClear = sizeof(Node) * numberOfNodes;

	size_t memoryDeltaStart = inUse;
	list.Clear();
	size_t memoryDeltaEnd = inUse;

	bool result = memoryDeltaEnd == (memoryDeltaStart - memoryToClear);

	return result;
}

bool UnitTests_Lab3::Pass_Clear_HeadIsNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	list.Clear();

	bool result = list.mHead == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_Clear_TailIsNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	list.Clear();

	bool result = list.mTail == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_Clear_SizeIsZero() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	list.Clear();

	bool result = list.mSize == 0;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Destructor
#if LAB3_DTOR
void UnitTests_Lab3::Battery_Destructor() {
	FailVector failVec;
	failVec.push_back(Fail_Destructor_NotAllNodesAreDeleted);

	PassVector passVec;
	passVec.push_back(Pass_Destructor_AllNodesAreDeleted);

	UnitTestBattery("Testing destructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_Destructor_NotAllNodesAreDeleted() {
	List* list = new List;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(*list, nodes, numberOfNodes);

	size_t memoryToClear = sizeof(Node) * numberOfNodes + sizeof(List);

	size_t memoryDeltaStart = inUse;
	delete list;
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > (memoryDeltaStart - memoryToClear);
	result.msg = "Not all memory was cleared";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_Destructor_AllNodesAreDeleted() {
	List* list = new List;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(*list, nodes, numberOfNodes);

	size_t memoryToClear = sizeof(Node) * numberOfNodes + sizeof(List);

	size_t memoryDeltaStart = inUse;
	delete list;
	size_t memoryDeltaEnd = inUse;

	bool result = memoryDeltaEnd == (memoryDeltaStart - memoryToClear);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator Begin
#if LAB3_ITER_BEGIN
void UnitTests_Lab3::Battery_IteratorBegin() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorBegin_AllocatesDynamicMemory);
	failVec.push_back(Fail_IteratorBegin_CurrIsNotPointingToHead);

	PassVector passVec;
	passVec.push_back(Pass_IteratorBegin_CurrIsPointingToHead);

	UnitTestBattery("Testing Begin", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorBegin_AllocatesDynamicMemory() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	Iterator iter = list.Begin();
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd != memoryDeltaStart;
	result.msg = "No dynamic memory should be allocated in this method";

	return result;
}

FailResult UnitTests_Lab3::Fail_IteratorBegin_CurrIsNotPointingToHead() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter = list.Begin();

	FailResult result;
	result.check = iter.mCurr != nodes.at(0);
	result.msg = "Iterator's current is not pointing to head";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorBegin_CurrIsPointingToHead() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter = list.Begin();

	bool result = iter.mCurr == nodes.at(0);

	// Clean up
	for (Node* node : nodes)
		delete node;
	list.mHead = list.mTail = nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator End
#if LAB3_ITER_END
void UnitTests_Lab3::Battery_IteratorEnd() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorEnd_AllocatedDynamicMemory);
	failVec.push_back(Fail_IteratorEnd_CurrIsNotPointingToNull);

	PassVector passVec;
	passVec.push_back(Pass_IteratorEnd_CurrIsPointingToNull);

	UnitTestBattery("Testing End", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorEnd_AllocatedDynamicMemory() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	Iterator iter = list.End();
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd != memoryDeltaStart;
	result.msg = "No dynamic memory should be allocated in this method";

	return result;
}

FailResult UnitTests_Lab3::Fail_IteratorEnd_CurrIsNotPointingToNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter = list.End();

	FailResult result;
	result.check = iter.mCurr != nullptr;
	result.msg = "Iterator's current is not pointing to null";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorEnd_CurrIsPointingToNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter = list.End();

	bool result = iter.mCurr == nullptr;

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator Increment Pre-Fix
#if LAB3_ITER_INCREMENT_PRE
void UnitTests_Lab3::Battery_IteratorIncrementPreFix() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorIncrementPreFix_CurrIsNotPointingToNextNode);
	failVec.push_back(Fail_IteratorIncrementPreFix_DidNotReturnIteratorToNextNode);

	PassVector passVec;
	passVec.push_back(Pass_IteratorIncrementPreFix_CurrIsPointingToNextNode);
	passVec.push_back(Pass_IteratorIncrementPreFix_ReturnedIteratorToNextNode);

	UnitTestBattery("Testing Iterator ++ (pre-fix)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorIncrementPreFix_CurrIsNotPointingToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	++iter;

	FailResult result;
	result.check = iter.mCurr != nodes[2];
	result.msg = "Iter's current was not updated to next node";

	// Clean up
	CleanList(nodes, list);

	return result;
}

FailResult UnitTests_Lab3::Fail_IteratorIncrementPreFix_DidNotReturnIteratorToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	Iterator prefixIncrementIter = ++iter;

	FailResult result;
	result.check = prefixIncrementIter.mCurr != nodes[2];
	result.msg = "Did not return Iterator pointing to next node";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorIncrementPreFix_CurrIsPointingToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	++iter;

	bool result = iter.mCurr == nodes[2];

	// Clean up
	CleanList(nodes, list);

	return result;
}

bool UnitTests_Lab3::Pass_IteratorIncrementPreFix_ReturnedIteratorToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	Iterator prefixIncrementIter = ++iter;

	bool result = prefixIncrementIter.mCurr == nodes[2];

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator Increment Post-Fix
#if LAB3_ITER_INCREMENT_POST
void UnitTests_Lab3::Battery_IteratorIncrementPostFix() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorIncrementPostFix_CurrIsNotPointingToNextNode);
	failVec.push_back(Fail_IteratorIncrementPostFix_ReturnedIteratorIsNotPointingToOriginalNode);

	PassVector passVec;
	passVec.push_back(Pass_IteratorIncrementPostFix_CurrIsPointingToNextNode);
	passVec.push_back(Pass_IteratorIncrementPostFix_ReturnedIteratorIsPointingToOriginalNode);

	UnitTestBattery("Testing Iterator ++ (post-fix)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorIncrementPostFix_CurrIsNotPointingToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	iter++;

	FailResult result;
	result.check = iter.mCurr != nodes[2];
	result.msg = "Iter's current was not updated to next node";

	// Clean up
	CleanList(nodes, list);

	return result;
}

FailResult UnitTests_Lab3::Fail_IteratorIncrementPostFix_ReturnedIteratorIsNotPointingToOriginalNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	Iterator postFixIncrementIter = iter++;

	FailResult result;
	result.check = postFixIncrementIter.mCurr != nodes[1];
	result.msg = "Did not return Iterator pointing to original node";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorIncrementPostFix_CurrIsPointingToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	iter++;

	bool result = iter.mCurr == nodes[2];

	// Clean up
	CleanList(nodes, list);

	return result;
}

bool UnitTests_Lab3::Pass_IteratorIncrementPostFix_ReturnedIteratorIsPointingToOriginalNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[1];

	Iterator postFixIncrementIter = iter++;

	bool result = postFixIncrementIter.mCurr == nodes[1];

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator Decrement Pre-Fix
#if LAB3_ITER_DECREMENT_PRE
void UnitTests_Lab3::Battery_IteratorDecrementPreFix() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorDecrementPreFix_CurrIsNotPointingToPrevNode);
	failVec.push_back(Fail_IteratorDecrementPreFix_DidNotReturnIteratorToPrevNode);

	PassVector passVec;
	passVec.push_back(Pass_IteratorDecrementPreFix_CurrIsPointingToPrevNode);
	passVec.push_back(Pass_IteratorDecrementPreFix_ReturnedIteratorToPrevNode);

	UnitTestBattery("Testing Iterator -- (pre-fix)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorDecrementPreFix_CurrIsNotPointingToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	--iter;

	FailResult result;
	result.check = iter.mCurr != nodes[4];
	result.msg = "Iterator's current was not updated to previous node";

	// Clean up
	CleanList(nodes, list);

	return result;
}
FailResult UnitTests_Lab3::Fail_IteratorDecrementPreFix_DidNotReturnIteratorToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	Iterator prefixDecrementIter = --iter;

	FailResult result;
	result.check = prefixDecrementIter.mCurr != nodes[4];
	result.msg = "Did not return Iterator pointing to previous node";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorDecrementPreFix_CurrIsPointingToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	--iter;

	bool result = iter.mCurr == nodes[4];

	// Clean up
	CleanList(nodes, list);

	return result;
}
bool UnitTests_Lab3::Pass_IteratorDecrementPreFix_ReturnedIteratorToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	Iterator prefixDecrementIter = --iter;

	bool result = prefixDecrementIter.mCurr == nodes[4];

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator Decrement Post-Fix
#if LAB3_ITER_DECREMENT_POST
void UnitTests_Lab3::Battery_IteratorDecrementPostFix() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorDecrementPostFix_CurrIsNotPointingToPrevNode);
	failVec.push_back(Fail_IteratorDecrementPostFix_ReturnedIteratorIsNotPointingToOriginalNode);
	
	PassVector passVec;
	passVec.push_back(Pass_IteratorDecrementPostFix_CurrIsPointingToPrevNode);
	passVec.push_back(Pass_IteratorDecrementPostFix_ReturnedIteratorIsPointingToOriginalNode);

	UnitTestBattery("Testing Iterator -- (post-fix)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorDecrementPostFix_CurrIsNotPointingToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	iter--;

	FailResult result;
	result.check = iter.mCurr != nodes[4];
	result.msg = "Iterator's current was not updated to previous node";

	// Clean up
	CleanList(nodes, list);

	return result;
}

FailResult UnitTests_Lab3::Fail_IteratorDecrementPostFix_ReturnedIteratorIsNotPointingToOriginalNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	Iterator postfixDecrementIter = iter--;

	FailResult result;
	result.check = postfixDecrementIter.mCurr != nodes[5];
	result.msg = "Did not return Iterator pointing to original node";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorDecrementPostFix_CurrIsPointingToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	iter--;

	bool result = iter.mCurr == nodes[4];

	// Clean up
	CleanList(nodes, list);

	return result;
}

bool UnitTests_Lab3::Pass_IteratorDecrementPostFix_ReturnedIteratorIsPointingToOriginalNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	iter.mCurr = nodes[5];

	Iterator postfixDecrementIter = iter--;

	bool result = postfixDecrementIter.mCurr == nodes[5];

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Iterator Dereference
#if LAB3_ITER_DEREFERENCE
void UnitTests_Lab3::Battery_IteratorDereference() {
	FailVector failVec;
	failVec.push_back(Fail_IteratorDereferenceDoesNotReturnData);

	PassVector passVec;
	passVec.push_back(Pass_IteratorDereference_ReturnsData);

	UnitTestBattery("Testing Iterator * (dereference)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_IteratorDereferenceDoesNotReturnData() {
	List list;
	int numberOfNodes = RandomInt(2, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	int randomNode = RandomInt(0, numberOfNodes-1);
	iter.mCurr = nodes[randomNode];

	int value = *iter;

	FailResult result;
	result.check = value != nodes.at(randomNode)->data;
	result.msg = "Did not return correct value";

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_IteratorDereference_ReturnsData() {
	List list;
	int numberOfNodes = RandomInt(2, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);

	Iterator iter;
	int randomNode = RandomInt(0, numberOfNodes-1);
	iter.mCurr = nodes[randomNode];

	int value = *iter;

	bool result = value == nodes.at(randomNode)->data;

	// Clean up
	CleanList(nodes, list);

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert On Empty List
#if LAB3_INSERT_EMPTY
void UnitTests_Lab3::Battery_InsertOnEmptyList() {
	FailVector failVec;
	failVec.push_back(Fail_InsertOnEmptyList_NoNodesAreAllocated);
	failVec.push_back(Fail_InsertOnEmptyList_MoreThanOneNodeAllocated);
	failVec.push_back(Fail_InsertOnEmptyList_HeadIsNotPointingToCreatedNode);
	failVec.push_back(Fail_InsertOnEmptyList_TailIsNotPointingToCreatedNode);
	failVec.push_back(Fail_InsertOnEmptyList_HeadAndTailAreNotPointingToSameNode);
	failVec.push_back(Fail_InsertOnEmptyList_HeadDataIsNotCorrectValue);
	failVec.push_back(Fail_InsertOnEmptyList_HeadPrevIsNotNull);
	failVec.push_back(Fail_InsertOnEmptyList_TailNextIsNotNull);
	failVec.push_back(Fail_InsertOnEmptyList_IteratorIsNotPointingToInsertedNode);
	failVec.push_back(Fail_InsertOnEmptyList_SizeIsNotOne);

	PassVector passVec;
	passVec.push_back(Pass_InsertOnEmptyList_OnlyOneNodeAllocated);
	passVec.push_back(Pass_InsertOnEmptyList_HeadIsPointingToCreatedNode);
	passVec.push_back(Pass_InsertOnEmptyList_TailIsPointingToCreatedNode);
	passVec.push_back(Pass_InsertOnEmptyList_HeadAndTailArePointingToSameNode);
	passVec.push_back(Pass_InsertOnEmptyList_HeadDataIsCorrectValue);
	passVec.push_back(Pass_InsertOnEmptyList_HeadPrevIsNull);
	passVec.push_back(Pass_InsertOnEmptyList_TailNextIsNull);
	passVec.push_back(Pass_InsertOnEmptyList_IteratorIsPointingToInsertedNode);
	passVec.push_back(Pass_InsertOnEmptyList_SizeIsOne);

	UnitTestBattery("Testing Insert on an empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_NoNodesAreAllocated() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, 0);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryDelta == 0;
	result.msg = "No memory allocated";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_MoreThanOneNodeAllocated() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, 0);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDelta = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryDelta > sizeof(Node);
	result.msg = "Too much memory is allocated";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_HeadIsNotPointingToCreatedNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead == nullptr;
	result.msg = "Head is not pointing to created node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_TailIsNotPointingToCreatedNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail == nullptr;
	result.msg = "Tail is not pointing to created node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_HeadAndTailAreNotPointingToSameNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead && list.mHead != list.mTail;
	result.msg = "Head and Tail are not pointing to same node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_HeadDataIsNotCorrectValue() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	size_t randomVal = RandomInt(5, 10);
	list.Insert(iter, (int)randomVal);

	FailResult result;
	result.check = list.mHead && list.mHead->data != randomVal;
	result.msg = "Data of inserted node is incorrect";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_HeadPrevIsNotNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead && list.mHead->prev != nullptr;
	result.msg = "Inserted node's prev is not null";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_TailNextIsNotNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mTail && list.mTail->next != nullptr;
	result.msg = "Inserted node's next is not null";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_IteratorIsNotPointingToInsertedNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	Iterator insertIter = list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mHead && list.mHead != insertIter.mCurr;
	result.msg = "Returned Iterator's current does not point to inserted node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnEmptyList_SizeIsNotOne() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	FailResult result;
	result.check = list.mSize != 1;
	result.msg = "Size was not incremented";

	return result;
}

#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_InsertOnEmptyList_OnlyOneNodeAllocated() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(5, 10));
	size_t memoryDeltaEnd = inUse;

	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_HeadIsPointingToCreatedNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	bool result = list.mHead != nullptr;;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_TailIsPointingToCreatedNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	bool result = list.mTail != nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_HeadAndTailArePointingToSameNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	bool result = list.mHead && list.mHead == list.mTail;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_HeadDataIsCorrectValue() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	size_t randomVal = RandomInt(5, 10);
	list.Insert(iter, (int)randomVal);

	bool result = list.mHead && list.mHead->data == randomVal;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_HeadPrevIsNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	bool result = list.mHead && list.mHead->prev == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_TailNextIsNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	bool result = list.mTail && list.mTail->next == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_IteratorIsPointingToInsertedNode() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	Iterator insertIter = list.Insert(iter, RandomInt(5, 10));

	bool result = list.mHead && list.mHead == insertIter.mCurr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnEmptyList_SizeIsOne() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = nullptr;

	list.Insert(iter, RandomInt(5, 10));

	bool result = list.mSize == 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert At Head
#if LAB3_INSERT_HEAD
void UnitTests_Lab3::Battery_InsertAtHead() {
	FailVector failVec;
	failVec.push_back(Fail_InsertAtHead_NoNodesAreAllocated);
	failVec.push_back(Fail_InsertAtHead_MoreThanOneNodeAllocated);
	failVec.push_back(Fail_InsertAtHead_HeadIsNotPointingToCreatedNode);
	failVec.push_back(Fail_InsertAtHead_HeadDataIsIncorrectValue);
	failVec.push_back(Fail_InsertAtHead_HeadNextIsNotPointingToOldHead);
	failVec.push_back(Fail_InsertAtHead_HeadPrevIsNotNull);
	failVec.push_back(Fail_InsertAtHead_ReturnedIteratorIsNotPointingToInsertedNode);
	failVec.push_back(Fail_InsertAtHead_SizeIsNotIncremented);

	PassVector passVec;
	passVec.push_back(Pass_InsertAtHead_OnlyOneNodeAllocated);
	passVec.push_back(Pass_InsertAtHead_HeadIsPointingToCreatedNode);
	passVec.push_back(Pass_InsertAtHead_HeadDataIsCorrectValue);
	passVec.push_back(Pass_InsertAtHead_HeadNextIsPointingToOldHead);
	passVec.push_back(Pass_InsertAtHead_HeadPrevIsNull);
	passVec.push_back(Pass_InsertAtHead_ReturnedIteratorIsPointingToInsertedNode);
	passVec.push_back(Pass_InsertAtHead_SizeIsIncremented);

	return UnitTestBattery("Testing Insert at head on non-empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_InsertAtHead_NoNodesAreAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(1, 100));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;
	
	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No memory allocated";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_MoreThanOneNodeAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(1, 100));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "Too much memory is allocated";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_HeadIsNotPointingToCreatedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* oldHead = list.mHead;

	list.Insert(iter, RandomInt(1, 100));

	FailResult result;
	result.check = list.mHead == oldHead;
	result.msg = "Head is not pointing to inserted node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_HeadDataIsIncorrectValue() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	FailResult result;
	result.check = list.mHead && list.mHead->data != randomVal;
	result.msg = "Head's data is incorrect value";
	
	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_HeadNextIsNotPointingToOldHead() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* oldHead = list.mHead;

	list.Insert(iter, RandomInt(1, 100));

	FailResult result;
	result.check = list.mHead && list.mHead->next != oldHead;
	result.msg = "Head's next is not pointing to old head";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_HeadPrevIsNotNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Insert(iter, RandomInt(1, 100));

	FailResult result;
	result.check = list.mHead && list.mHead->prev != nullptr;
	result.msg = "Head's prev is not pointing to nullptr";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_ReturnedIteratorIsNotPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* oldIterAddress = iter.mCurr;

	Iterator newIter = list.Insert(iter, RandomInt(1, 100));

	FailResult result;
	result.check = newIter.mCurr == oldIterAddress;
	result.msg = "Iterator is not pointing to head node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertAtHead_SizeIsNotIncremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	size_t oldSize = list.mSize;

	list.Insert(iter, RandomInt(1, 100));

	FailResult result;
	result.check = list.mSize == oldSize;
	result.msg = "Size was not incremented";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_InsertAtHead_OnlyOneNodeAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(1, 100));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_InsertAtHead_HeadIsPointingToCreatedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* oldHead = list.mHead;

	list.Insert(iter, RandomInt(1, 100));

	bool result = list.mHead != oldHead;

	return result;
}

bool UnitTests_Lab3::Pass_InsertAtHead_HeadDataIsCorrectValue() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	bool result = list.mHead && list.mHead->data == randomVal;

	return result;
}

bool UnitTests_Lab3::Pass_InsertAtHead_HeadNextIsPointingToOldHead() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* oldHead = list.mHead;

	list.Insert(iter, RandomInt(1, 100));

	bool result = list.mHead && list.mHead->next == oldHead;

	return result;
}

bool UnitTests_Lab3::Pass_InsertAtHead_HeadPrevIsNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Insert(iter, RandomInt(1, 100));

	bool result = list.mHead && list.mHead->prev == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertAtHead_ReturnedIteratorIsPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* oldIterAddress = iter.mCurr;

	Iterator newIter = list.Insert(iter, RandomInt(1, 100));

	bool result = newIter.mCurr != oldIterAddress;

	return result;
}

bool UnitTests_Lab3::Pass_InsertAtHead_SizeIsIncremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	size_t oldSize = list.mSize;

	list.Insert(iter, RandomInt(1, 100));

	bool result = list.mSize == oldSize + 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Insert On Non-Empty List
#if LAB3_INSERT_MIDDLE
void UnitTests_Lab3::Battery_InsertOnNonEmptyList() {
	FailVector failVec;
	failVec.push_back(Fail_InsertOnNonEmptyList_NoNodesAreAllocated);
	failVec.push_back(Fail_InsertOnNonEmptyList_MoreThanOneNodeAllocated);
	failVec.push_back(Fail_InsertOnNonEmptyList_InsertedNodeDataIsIncorrectValue);
	failVec.push_back(Fail_InsertOnNonEmptyList_InsertedNodeNextIsNotNextNode);
	failVec.push_back(Fail_InsertOnNonEmptyList_InsertedNodePrevIsNotPrevNode);
	failVec.push_back(Fail_InsertOnNonEmptyList_PrevNodesNextIsNotPointingToInsertedNode);
	failVec.push_back(Fail_InsertOnNonEmptyList_NextNodesPrevIsNotPointingToInsertedNode);
	failVec.push_back(Fail_InsertOnNonEmptyList_ReturnedIteratorIsNotPointingToInsertedNode);
	failVec.push_back(Fail_InsertOnNonEmptyList_SizeIsNotIncremented);

	PassVector passVec;
	passVec.push_back(Pass_InsertOnNonEmptyList_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_InsertOnNonEmptyList_InsertedNodeDataIsCorrectValue);
	passVec.push_back(Pass_InsertOnNonEmptyList_InsertedNodesNextIsNextNode);
	passVec.push_back(Pass_InsertOnNonEmptyList_InsertedNodesPrevIsPrevNode);
	passVec.push_back(Pass_InsertOnNonEmptyList_PrevNodesNextIsPointingToInsertedNode);
	passVec.push_back(Pass_InsertOnNonEmptyList_NextNodesPrevIsPointingToInsertedNode);
	passVec.push_back(Pass_InsertOnNonEmptyList_ReturnedIteratorIsPointingToInsertedNode);
	passVec.push_back(Pass_InsertOnNonEmptyList_SizeIsIncremented);

	UnitTestBattery("Testing Insert in middle of list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_NoNodesAreAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(1, 100));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No memory allocated";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_MoreThanOneNodeAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(1, 100));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "No memory allocated";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_InsertedNodeDataIsIncorrectValue() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	FailResult result;
	result.check = after->prev->data != randomVal;
	result.msg = "Inserted node is not storing correct value";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_InsertedNodeNextIsNotNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	FailResult result;
	result.check = iter.mCurr->next != after;
	result.msg = "Inserted node's next is not pointing to correct node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_InsertedNodePrevIsNotPrevNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, static_cast<int>(numberOfNodes) - 1);
	Iterator iter;
	iter.mCurr = nodes[static_cast<int64_t>(randomNodePos)];

	Node* before = nodes[static_cast<int64_t>(randomNodePos-1)];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	FailResult result;
	result.check = iter.mCurr->prev != before;
	result.msg = "Inserted node's prev is not pointing to correct node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_PrevNodesNextIsNotPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* before = nodes[static_cast<int64_t>(randomNodePos - 1)];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	FailResult result;
	result.check = before->next != iter.mCurr;
	result.msg = "Node before inserted node's next is not pointing to inserted node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_NextNodesPrevIsNotPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	FailResult result;
	result.check = after->prev != iter.mCurr;
	result.msg = "Node after inserted node's prev is not pointing to inserted node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_ReturnedIteratorIsNotPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	Iterator newIter = list.Insert(iter, randomVal);
	
	FailResult result;
	result.check = newIter.mCurr != after->prev;
	result.msg = "Returned Iterator is not pointing to inserted node";

	return result;
}

FailResult UnitTests_Lab3::Fail_InsertOnNonEmptyList_SizeIsNotIncremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	list.Insert(iter, RandomInt(1, 100));

	FailResult result;
	result.check = list.mSize == numberOfNodes;
	result.msg = "Size was not incremented";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_CorrectAmountOfMemoryAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	size_t memoryDeltaStart = inUse;
	list.Insert(iter, RandomInt(1, 100));
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_InsertedNodeDataIsCorrectValue() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	bool result = after->prev->data == randomVal;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_InsertedNodesNextIsNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	bool result= iter.mCurr->next == after;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_InsertedNodesPrevIsPrevNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* before = nodes[randomNodePos - 1];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	bool result = iter.mCurr->prev == before;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_PrevNodesNextIsPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* before = nodes[randomNodePos - 1];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	bool result = before->next == iter.mCurr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_NextNodesPrevIsPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	list.Insert(iter, randomVal);

	bool result = after->prev == iter.mCurr;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_ReturnedIteratorIsPointingToInsertedNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	Node* after = nodes[randomNodePos];
	int randomVal = RandomInt(1, 100);
	Iterator newIter = list.Insert(iter, randomVal);

	bool result = newIter.mCurr == after->prev;

	return result;
}

bool UnitTests_Lab3::Pass_InsertOnNonEmptyList_SizeIsIncremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int randomNodePos = RandomInt(1, numberOfNodes - 1);
	Iterator iter;
	iter.mCurr = nodes[randomNodePos];

	list.Insert(iter, RandomInt(1, 100));

	bool result = list.mSize == numberOfNodes+1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Erase On Empty List
#if LAB3_ERASE_EMPTY
void UnitTests_Lab3::Battery_EraseEmpty() {
	FailVector failVec;
	failVec.push_back(Fail_EraseEmpty_NodesAreAllocated);
	failVec.push_back(Fail_EraseEmpty_HeadIsNotNull);
	failVec.push_back(Fail_EraseEmpty_TailIsNotNull);
	failVec.push_back(Fail_EraseEmpty_ReturnedIteratorIsNotNullPointer);

	PassVector passVec;
	passVec.push_back(Pass_EraseEmpty_NoNodesAreAllocated);
	passVec.push_back(Pass_EraseEmpty_HeadIsNull);
	passVec.push_back(Pass_EraseEmpty_TailIsNull);
	passVec.push_back(Pass_EraseEmpty_ReturnedIteratorIsNullPointer);

	UnitTestBattery("Testing Erase on an empty list", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_EraseEmpty_NodesAreAllocated() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;
	
	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaEnd;
	result.msg = "Should not dynamically allocate when erasing";
	
	return result;
}

FailResult UnitTests_Lab3::Fail_EraseEmpty_HeadIsNotNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Erase(iter);

	FailResult result;
	result.check = list.mHead != nullptr;
	result.msg = "Head should be pointing to null";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseEmpty_TailIsNotNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Erase(iter);

	FailResult result;
	result.check = list.mTail != nullptr;
	result.msg = "Tail should be pointing to null";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseEmpty_ReturnedIteratorIsNotNullPointer() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	Iterator newIter = list.Erase(iter);

	FailResult result;
	result.check = newIter.mCurr != nullptr;
	result.msg = "Returned Iterator's current should be storing a null pointer";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_EraseEmpty_NoNodesAreAllocated() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	bool result = memoryDeltaEnd == memoryDeltaEnd;

	return result;
}

bool UnitTests_Lab3::Pass_EraseEmpty_HeadIsNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Erase(iter);

	bool result = list.mHead == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_EraseEmpty_TailIsNull() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Erase(iter);

	bool result = list.mTail == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_EraseEmpty_ReturnedIteratorIsNullPointer() {
	List list;
	list.mHead = list.mTail = nullptr;
	list.mSize = 0;
	Iterator iter;
	iter.mCurr = list.mHead;

	Iterator newIter = list.Erase(iter);

	bool result = newIter.mCurr == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Erase Head
#if LAB3_ERASE_HEAD
void UnitTests_Lab3::Battery_EraseHead() {
	FailVector failVec;
	failVec.push_back(Fail_EraseHead_NoNodesAreDeleted);
	failVec.push_back(Fail_EraseHead_MoreThanOneNodeIsDeleted);
	failVec.push_back(Fail_EraseHead_MemoryIsAllocated);
	failVec.push_back(Fail_EraseHead_HeadIsNotUpdatedToNextNode);
	failVec.push_back(Fail_EraseHead_HeadsPrevIsNotNull);
	failVec.push_back(Fail_EraseHead_ReturnedIteratorIsNotUpdatedToNewHead);
	failVec.push_back(Fail_EraseHead_SizeIsNotDecremented);

	PassVector passVec;
	passVec.push_back(Pass_EraseHead_OneNodeIsDeleted);
	passVec.push_back(Pass_EraseHead_HeadIsUpdatedToNextNode);
	passVec.push_back(Pass_EraseHead_HeadsPrevIsNull);
	passVec.push_back(Pass_EraseHead_ReturnedIteratorIsUpdatedToNewHead);
	passVec.push_back(Pass_EraseHead_SizeIsDecremented);

	UnitTestBattery("Testing Erase on head", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_EraseHead_NoNodesAreDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaStart == memoryDeltaEnd;
	result.msg = "No nodes were deleted";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseHead_MoreThanOneNodeIsDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = (memoryDeltaStart - memoryDeltaEnd) > sizeof(Node);
	result.msg = "More than one node was deleted";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseHead_MemoryIsAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaStart;
	result.msg = "Should not dynamically allocate when erasing";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseHead_HeadIsNotUpdatedToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* newHead = nodes[1];

	list.Erase(iter);

	FailResult result;
	result.check = list.mHead != newHead;
	result.msg = "Head was not updated to point to next node in list";
	
	return result;
}

FailResult UnitTests_Lab3::Fail_EraseHead_HeadsPrevIsNotNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Erase(iter);

	FailResult result;
	result.check = list.mHead && list.mHead->prev != nullptr;
	result.msg = "Head's prev was not updated to null";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseHead_ReturnedIteratorIsNotUpdatedToNewHead() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* newHead = nodes[1];

	Iterator newIter = list.Erase(iter);

	FailResult result;
	result.check = newIter.mCurr != newHead;
	result.msg = "Returned Iterator's current is not updated to new head";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseHead_SizeIsNotDecremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	size_t oldSize = list.mSize;

	list.Erase(iter);

	FailResult result;
	result.check = list.mSize != oldSize - 1;
	result.msg = " Size was not decremented";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_EraseHead_OneNodeIsDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	bool result = (memoryDeltaStart - memoryDeltaEnd) == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_EraseHead_HeadIsUpdatedToNextNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* newHead = nodes[1];

	list.Erase(iter);

	bool result = list.mHead == newHead;

	return result;
}

bool UnitTests_Lab3::Pass_EraseHead_HeadsPrevIsNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;

	list.Erase(iter);

	bool result = list.mHead && list.mHead->prev == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_EraseHead_ReturnedIteratorIsUpdatedToNewHead() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	Node* newHead = nodes[1];

	Iterator newIter = list.Erase(iter);

	bool result = newIter.mCurr == newHead;

	return result;
}

bool UnitTests_Lab3::Pass_EraseHead_SizeIsDecremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mHead;
	size_t oldSize = list.mSize;

	list.Erase(iter);

	bool result = list.mSize == oldSize - 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Erase Tail
#if LAB3_ERASE_TAIL
void UnitTests_Lab3::Battery_EraseTail() {
	FailVector failVec;
	failVec.push_back(Fail_EraseTail_NoNodesAreDeleted);
	failVec.push_back(Fail_EraseTail_MoreThanOneNodeIsDeleted);
	failVec.push_back(Fail_EraseTail_MemoryIsAllocated);
	failVec.push_back(Fail_EraseTail_TailIsNotUpdatedToPrevNode);
	failVec.push_back(Fail_EraseTail_TailsNextIsNotNull);
	failVec.push_back(Fail_EraseTail_ReturnedIteratorIsNotANullPointer);
	failVec.push_back(Fail_EraseTail_SizeIsNotDecremented);

	PassVector passVec;
	passVec.push_back(Pass_EraseTail_OneNodeIsDeleted);
	passVec.push_back(Pass_EraseTail_TailIsUpdatedToPrevNode);
	passVec.push_back(Pass_EraseTail_TailsNextIsNull);
	passVec.push_back(Pass_EraseTail_ReturnedIteratorIsUpdatedToNullPointer);
	passVec.push_back(Pass_EraseTail_SizeIsDecremented);

	UnitTestBattery("Testing Erase on tail", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_EraseTail_NoNodesAreDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaStart == memoryDeltaEnd;
	result.msg = "No nodes were deleted";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseTail_MoreThanOneNodeIsDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = (memoryDeltaStart - memoryDeltaEnd) > sizeof(Node);
	result.msg = "More than one node was deleted";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseTail_MemoryIsAllocated() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaStart;
	result.msg = "Should not dynamically allocate when erasing";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseTail_TailIsNotUpdatedToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;
	Node* newTail = nodes[numberOfNodes-2];

	list.Erase(iter);

	FailResult result;
	result.check = list.mTail != newTail;
	result.msg = "Tail was not updated to point to prev node in list";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseTail_TailsNextIsNotNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	list.Erase(iter);

	FailResult result;
	result.check = list.mTail && list.mTail->next != nullptr;
	result.msg = "Tail's next was not updated to null";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseTail_ReturnedIteratorIsNotANullPointer() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	Iterator newIter = list.Erase(iter);

	FailResult result;
	result.check = newIter.mCurr != nullptr;
	result.msg = "Returned Iterator's current is not updated to null pointer";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseTail_SizeIsNotDecremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;
	size_t oldSize = list.mSize;

	list.Erase(iter);

	FailResult result;
	result.check = list.mSize != oldSize - 1;
	result.msg = " Size was not decremented";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_EraseTail_OneNodeIsDeleted() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	bool result = (memoryDeltaStart - memoryDeltaEnd) == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_EraseTail_TailIsUpdatedToPrevNode() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;
	Node* newTail = nodes[numberOfNodes - 2];

	list.Erase(iter);

	bool result = list.mTail == newTail;

	return result;
}

bool UnitTests_Lab3::Pass_EraseTail_TailsNextIsNull() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	list.Erase(iter);

	bool result = list.mTail && list.mTail->next == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_EraseTail_ReturnedIteratorIsUpdatedToNullPointer() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;

	Iterator newIter = list.Erase(iter);

	bool result = newIter.mCurr == nullptr;

	return result;
}

bool UnitTests_Lab3::Pass_EraseTail_SizeIsDecremented() {
	List list;
	int numberOfNodes = RandomInt(3, 5);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	Iterator iter;
	iter.mCurr = list.mTail;
	size_t oldSize = list.mSize;

	list.Erase(iter);

	bool result = list.mSize == oldSize - 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Erase Middle
#if LAB3_ERASE_MIDDLE
void UnitTests_Lab3::Battery_EraseMiddle() {
	FailVector failVec;
	failVec.push_back(Fail_EraseMiddle_NoNodesAreDeleted);
	failVec.push_back(Fail_EraseMiddle_MoreThanOneNodeIsDeleted);
	failVec.push_back(Fail_EraseMiddle_MemoryIsAllocated);
	failVec.push_back(Fail_EraseMiddle_ReturnedIteratorIsNotUpdatedToNextNode);
	failVec.push_back(Fail_EraseMiddle_PrevNodesNextIsNotPointingToNodeAfterErasedNode);
	failVec.push_back(Fail_EraseMiddle_NextNodesPrevIsNotPointingToNodeBeforeErasedNode);
	failVec.push_back(Fail_EraseMiddle_SizeIsNotDecremented);

	PassVector passVec;
	passVec.push_back(Pass_EraseMiddle_OneNodeIsDeleted);
	passVec.push_back(Pass_EraseMiddle_ReturnedIteratorIsUpdatedToNextNode);
	passVec.push_back(Pass_EraseMiddle_PrevNodesNextIsPointingToNodeAfterErasedNode);
	passVec.push_back(Pass_EraseMiddle_NextNodesPrevIsPointingToNodeBeforeErasedNode);
	passVec.push_back(Pass_EraseMiddle_SizeIsDecremented);

	UnitTestBattery("Testing Erase on a middle node", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_EraseMiddle_NoNodesAreDeleted() {
	List list;
	int numberOfNodes = RandomInt(6,10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaStart == memoryDeltaEnd;
	result.msg = "No nodes were deleted";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseMiddle_MoreThanOneNodeIsDeleted() {
	List list;
	int numberOfNodes = RandomInt(6,10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = (memoryDeltaStart - memoryDeltaEnd) > sizeof(Node);
	result.msg = "More than one node was deleted";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseMiddle_MemoryIsAllocated() {
	List list;
	int numberOfNodes = RandomInt(6,10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	FailResult result;
	result.check = memoryDeltaEnd > memoryDeltaStart;
	result.msg = "Should not dynamically allocate when erasing";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseMiddle_ReturnedIteratorIsNotUpdatedToNextNode() {
	List list;
	int numberOfNodes = RandomInt(6,10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];

	Iterator newIter = list.Erase(iter);

	FailResult result;
	result.check = newIter.mCurr != nodes[static_cast<int>(nodeToErase + 1)];
	result.msg = "Returned Iterator's current was not updated to next node in list";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseMiddle_PrevNodesNextIsNotPointingToNodeAfterErasedNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];
	Node* before = nodes[nodeToErase - 1];
	Node* after = nodes[nodeToErase + 1];

	list.Erase(iter);

	FailResult result;
	result.check = before->next != after;
	result.msg = "Node before erased node's next is not pointing to node after erased node";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseMiddle_NextNodesPrevIsNotPointingToNodeBeforeErasedNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];
	Node* before = nodes[static_cast<int>(nodeToErase - 1)];
	Node* after = nodes[static_cast<int>(nodeToErase + 1)];

	list.Erase(iter);

	FailResult result;
	result.check = after->prev != before;
	result.msg = "Node after erased node's prev is not pointing to node before erased node";

	return result;
}

FailResult UnitTests_Lab3::Fail_EraseMiddle_SizeIsNotDecremented() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];
	size_t oldSize = list.mSize;

	list.Erase(iter);

	FailResult result;
	result.check = list.mSize != oldSize - 1;
	result.msg = "Size was not decremented";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_EraseMiddle_OneNodeIsDeleted() {
	List list;
	int numberOfNodes = RandomInt(6,10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];

	size_t memoryDeltaStart = inUse;
	list.Erase(iter);
	size_t memoryDeltaEnd = inUse;

	bool result = (memoryDeltaStart - memoryDeltaEnd) == sizeof(Node);

	return result;
}

bool UnitTests_Lab3::Pass_EraseMiddle_ReturnedIteratorIsUpdatedToNextNode() {
	List list;
	int numberOfNodes = RandomInt(6,10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];

	Iterator newIter = list.Erase(iter);

	bool result = newIter.mCurr == nodes[static_cast<int64_t>(nodeToErase + 1)];

	return result;
}

bool UnitTests_Lab3::Pass_EraseMiddle_PrevNodesNextIsPointingToNodeAfterErasedNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];
	Node* before = nodes[static_cast<int64_t>(nodeToErase - 1)];
	Node* after = nodes[static_cast<int64_t>(nodeToErase + 1)];

	list.Erase(iter);

	bool result = before->next == after;

	return result;
}

bool UnitTests_Lab3::Pass_EraseMiddle_NextNodesPrevIsPointingToNodeBeforeErasedNode() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];
	Node* before = nodes[static_cast<int64_t>(nodeToErase - 1)];
	Node* after = nodes[static_cast<int64_t>(nodeToErase + 1)];

	list.Erase(iter);

	bool result = after->prev == before;

	return result;
}

bool UnitTests_Lab3::Pass_EraseMiddle_SizeIsDecremented() {
	List list;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list, nodes, numberOfNodes);
	int nodeToErase = RandomInt(2, numberOfNodes - 2);
	Iterator iter;
	iter.mCurr = nodes[nodeToErase];
	size_t oldSize = list.mSize;

	list.Erase(iter);

	bool result = list.mSize == oldSize - 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Assignment Operator
#if LAB3_ASSIGNMENT_OP
void UnitTests_Lab3::Battery_AssignmentOperator() {
	FailVector failVec;
	failVec.push_back(Fail_AssignmentOperator_NoSelfAssignmentCheck);
	failVec.push_back(Fail_AssignmentOperator_NodesAreNotDeleted);
	failVec.push_back(Fail_AssignmentOperator_NotEnoughMemoryAllocated);
	failVec.push_back(Fail_AssignmentOperator_DifferentNumberOfNodes);
	failVec.push_back(Fail_AssignmentOperator_SameAddressesAsArgument);
	failVec.push_back(Fail_AssignmentOperator_ValuesAreNotTheSameForwards);
	failVec.push_back(Fail_AssignmentOperator_ValuesAreNotTheSameBackwards);
	failVec.push_back(Fail_AssignmentOperator_SizeIsNotTheSame);

	PassVector passVec;
	passVec.push_back(Pass_AssignmentOperator_HasSelfAssignmentCheck);
	passVec.push_back(Pass_AssignmentOperator_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_AssignmentOperator_DifferentAddressesThanArgument);
	passVec.push_back(Pass_AssignmentOperator_ValuesAreTheSameForwards);
	passVec.push_back(Pass_AssignmentOperator_ValuesAreTheSameBackwards);
	passVec.push_back(Pass_AssignmentOperator_SizeIsTheSame);

	UnitTestBattery("Testing assignment operator", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_AssignmentOperator_NoSelfAssignmentCheck() {
	bool selfAssignmentFound = SearchFile("DList.h", "DList& operator=(const DList& _assign)", "private:", "if(this != &_assign)") || 
							   SearchFile("DList.h", "DList& operator=(const DList& _assign)", "private:", "if(this == &_assign)");

	FailResult result;
	result.check = selfAssignmentFound == false;
	result.msg = "Self-assignment check not found";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_NodesAreNotDeleted() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
    int numberOfNodes2 = RandomInt(numberOfNodes1+1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	size_t memoryDeltaStart = inUse;
	list2 = list1;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = (memoryDeltaStart - memoryDeltaEnd);
	size_t correctAmountOfMemory = sizeof(Node) * (numberOfNodes2-numberOfNodes1);

	FailResult result;
	result.check = memoryAllocated > correctAmountOfMemory;
	result.msg = "Too much memory allocated (forgot to clean up before deep copies?)";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_NotEnoughMemoryAllocated() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	size_t memoryDeltaStart = inUse;
	list2 = list1;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = (memoryDeltaStart - memoryDeltaEnd);
	size_t correctAmountOfMemory = sizeof(Node) * (numberOfNodes2 - numberOfNodes1);

	FailResult result;
	result.check = memoryAllocated < correctAmountOfMemory;
	result.msg = "Not enough memory allocated (did you deep copy every node?)";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_DifferentNumberOfNodes() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	std::vector<Node*> assignedNodes;
	Node* curr;
	if (curr = list2.mHead) {
		while (curr) {
			assignedNodes.push_back(curr);
			curr = curr->next;
		}
	}

	FailResult result;
	result.check = nodes1.size() != assignedNodes.size();
	result.msg = "Number of nodes in list is incorrect";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_SameAddressesAsArgument() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	bool sameAddress = false;

	Node* list1Curr = list1.mHead, * list2Curr = list2.mHead;

	while (list1Curr && list2Curr) {
		if (list1Curr != list2Curr) {
			list1Curr = list1Curr->next;
			list2Curr = list2Curr->next;
		}
		else {
			sameAddress = true;
			break;
		}
	}

	FailResult result;
	result.check = sameAddress;
	result.msg = "One (or more) nodes have been shallow copied";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_ValuesAreNotTheSameForwards() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if (curr = list2.mHead) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->next;
		}
	}

	bool differentValues = false;

	if (nodes1.size() == assignedValues.size()) {
		for (size_t i = 0; i < nodes1.size(); ++i) {
			if (nodes1[i]->data != assignedValues[i]) {
				differentValues = true;
				break;
			}
		}
	}

	FailResult result;
	result.check = differentValues;
	result.msg = "One (or more) nodes have incorrect values (or are linked forwards incorrectly)";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_ValuesAreNotTheSameBackwards() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if (curr = list2.mTail) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->prev;
		}
	}

	bool differentValues = false;

	if (nodes1.size() == assignedValues.size()) {
		for (int i = (int)nodes1.size()-1, j = 0; i >= 0; --i, ++j) {
			if (nodes1[i]->data != assignedValues[j]) {
				differentValues = true;
				break;
			}
		}
	}

	FailResult result;
	result.check = differentValues;
	result.msg = "One (or more) nodes have incorrect values (or are linked backwards incorrectly)";

	return result;
}

FailResult UnitTests_Lab3::Fail_AssignmentOperator_SizeIsNotTheSame() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	FailResult result;
	result.check = list2.mSize != list1.mSize;
	result.msg = "Size is not the same as other list";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_AssignmentOperator_HasSelfAssignmentCheck() {
	bool selfAssignmentFound = SearchFile("DList.h", "DList& operator=(const DList& _assign)", "private:", "if(this != &_assign)") || 
							   SearchFile("DList.h", "DList& operator=(const DList& _assign)", "private:", "if(this == &_assign)");

	bool result = selfAssignmentFound;

	return result;
}

bool UnitTests_Lab3::Pass_AssignmentOperator_CorrectAmountOfMemoryAllocated() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	size_t memoryDeltaStart = inUse;
	list2 = list1;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = (memoryDeltaStart - memoryDeltaEnd);
	size_t correctAmountOfMemory = sizeof(Node) * (numberOfNodes2 - numberOfNodes1);

	bool result = memoryAllocated == correctAmountOfMemory;

	return result;
}

bool UnitTests_Lab3::Pass_AssignmentOperator_DifferentAddressesThanArgument() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	bool sameAddress = false;

	Node* list1Curr = list1.mHead, * list2Curr = list2.mHead;

	while (list1Curr && list2Curr) {
		if (list1Curr != list2Curr) {
			list1Curr = list1Curr->next;
			list2Curr = list2Curr->next;
		}
		else {
			sameAddress = true;
			break;
		}
	}

	bool result = sameAddress == false;

	return result;
}

bool UnitTests_Lab3::Pass_AssignmentOperator_ValuesAreTheSameForwards() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if (curr = list2.mHead) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->next;
		}
	}

	bool differentValues = false;

	if (nodes1.size() == assignedValues.size()) {
		for (size_t i = 0; i < nodes1.size(); ++i) {
			if (nodes1[i]->data != assignedValues[i]) {
				differentValues = true;
				break;
			}
		}
	}

	bool result = differentValues == false;

	return result;
}

bool UnitTests_Lab3::Pass_AssignmentOperator_ValuesAreTheSameBackwards() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if (curr = list2.mTail) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->prev;
		}
	}

	bool differentValues = false;

	if (nodes1.size() == assignedValues.size()) {
		for (int i = (int)nodes1.size() - 1, j = 0; i >= 0; --i, ++j) {
			if (nodes1[i]->data != assignedValues[j]) {
				differentValues = true;
				break;
			}
		}
	}

	bool result = differentValues == false;

	return result;
}

bool UnitTests_Lab3::Pass_AssignmentOperator_SizeIsTheSame() {
	List list1, list2;
	int numberOfNodes1 = RandomInt(6, 10);
	int numberOfNodes2 = RandomInt(numberOfNodes1 + 1, 20);
	std::vector<Node*> nodes1, nodes2;
	CreateList(list1, nodes1, numberOfNodes1);
	CreateList(list2, nodes2, numberOfNodes2);

	list2 = list1;

	bool result = list2.mSize == list1.mSize;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Copy Constructor
#if LAB3_COPY_CTOR
void UnitTests_Lab3::Battery_CopyConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_CopyConstructor_NotEnoughMemoryAllocated);
	failVec.push_back(Fail_CopyConstructor_DifferentNumberOfNodes);
	failVec.push_back(Fail_CopyConstructor_SameAddressesAsArgument);
	failVec.push_back(Fail_CopyConstructor_ValuesAreNotTheSameForwards);
	failVec.push_back(Fail_CopyConstructor_ValuesAreNotTheSameBackwards);
	failVec.push_back(Fail_CopyConstructor_SizeIsNotTheSame);

	PassVector passVec;
	passVec.push_back(Pass_CopyConstructor_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_CopyConstructor_DifferentAddressesThanArgument);
	passVec.push_back(Pass_CopyConstructor_ValuesAreTheSameForwards);
	passVec.push_back(Pass_CopyConstructor_ValuesAreTheSameBackwards);
	passVec.push_back(Pass_CopyConstructor_SizeIsTheSame);

	UnitTestBattery("Testing copy constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab3::Fail_CopyConstructor_NotEnoughMemoryAllocated() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	List list2 = list1;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = (memoryDeltaStart - memoryDeltaEnd);
	size_t correctAmountOfMemory = sizeof(Node) * (numberOfNodes);

	FailResult result;
	result.check = memoryAllocated < correctAmountOfMemory;
	result.msg = "Not enough memory allocated (did you deep copy every node?)";

	return result;
}

FailResult UnitTests_Lab3::Fail_CopyConstructor_DifferentNumberOfNodes() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	std::vector<Node*> assignedNodes;
	Node* curr;
	if (curr = list2.mHead) {
		while (curr && curr != reinterpret_cast<Node*>(-1)) {
			assignedNodes.push_back(curr);
			curr = curr->next;
		}
	}

	FailResult result;
	result.check = nodes.size() != assignedNodes.size();
	result.msg = "Number of nodes in list is incorrect";

	return result;
}


FailResult UnitTests_Lab3::Fail_CopyConstructor_SameAddressesAsArgument() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	bool sameAddress = false;

	Node* list1Curr = list1.mHead, * list2Curr = list2.mHead;


	while ((list1Curr && list1Curr != reinterpret_cast<Node*>(-1)) && (list2Curr && list2Curr != reinterpret_cast<Node*>(-1))) {
		if (list1Curr != list2Curr) {
			list1Curr = list1Curr->next;
			list2Curr = list2Curr->next;
		}
		else {
			sameAddress = true;
			break;
		}
	}

	FailResult result;
	result.check = sameAddress;
	result.msg = "One (or more) nodes have been shallow copied";

	return result;
}

FailResult UnitTests_Lab3::Fail_CopyConstructor_ValuesAreNotTheSameForwards() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if ((curr = list2.mHead) && curr != reinterpret_cast<Node*>(-1)) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->next;
		}
	}

	bool differentValues = false;

	if (nodes.size() == assignedValues.size()) {
		for (size_t i = 0; i < nodes.size(); ++i) {
			if (nodes[i]->data != assignedValues[i]) {
				differentValues = true;
				break;
			}
		}
	}

	FailResult result;
	result.check = differentValues;
	result.msg = "One (or more) nodes have incorrect values (or are linked forwards incorrectly)";

	return result;
}

FailResult UnitTests_Lab3::Fail_CopyConstructor_ValuesAreNotTheSameBackwards() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if ((curr = list2.mTail) && curr != reinterpret_cast<Node*>(-1)) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->prev;
		}
	}

	bool differentValues = false;

	if (nodes.size() == assignedValues.size()) {
		for (int i = (int)nodes.size() - 1, j = 0; i >= 0; --i, ++j) {
			if (nodes[i]->data != assignedValues[j]) {
				differentValues = true;
				break;
			}
		}
	}

	FailResult result;
	result.check = differentValues;
	result.msg = "One (or more) nodes have incorrect values (or are linked backwards incorrectly)";

	return result;
}

FailResult UnitTests_Lab3::Fail_CopyConstructor_SizeIsNotTheSame() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	FailResult result;
	result.check = list2.mSize != list1.mSize;
	result.msg = "Size is not the same as other list";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab3::Pass_CopyConstructor_CorrectAmountOfMemoryAllocated() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	size_t memoryDeltaStart = inUse;
	List list2 = list1;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = (memoryDeltaEnd - memoryDeltaStart);
	size_t correctAmountOfMemory = sizeof(Node) * (numberOfNodes);

	bool result = memoryAllocated == correctAmountOfMemory;

	return result;
}

bool UnitTests_Lab3::Pass_CopyConstructor_DifferentAddressesThanArgument() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	bool sameAddress = false;

	Node* list1Curr = list1.mHead, * list2Curr = list2.mHead;

	while (list1Curr && list2Curr) {
		if (list1Curr != list2Curr) {
			list1Curr = list1Curr->next;
			list2Curr = list2Curr->next;
		}
		else {
			sameAddress = true;
			break;
		}
	}

	bool result = sameAddress == false;

	return result;
}

bool UnitTests_Lab3::Pass_CopyConstructor_ValuesAreTheSameForwards() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if (curr = list2.mHead) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->next;
		}
	}

	bool differentValues = false;

	if (nodes.size() == assignedValues.size()) {
		for (size_t i = 0; i < nodes.size(); ++i) {
			if (nodes[i]->data != assignedValues[i]) {
				differentValues = true;
				break;
			}
		}
	}

	bool result = differentValues == false;

	return result;
}

bool UnitTests_Lab3::Pass_CopyConstructor_ValuesAreTheSameBackwards() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	std::vector<int> assignedValues;
	Node* curr;
	if (curr = list2.mTail) {
		while (curr) {
			assignedValues.push_back(curr->data);
			curr = curr->prev;
		}
	}

	bool differentValues = false;

	if (nodes.size() == assignedValues.size()) {
		for (int i = (int)nodes.size() - 1, j = 0; i >= 0; --i, ++j) {
			if (nodes[i]->data != assignedValues[j]) {
				differentValues = true;
				break;
			}
		}
	}

	bool result = differentValues == false;

	return result;
}

bool UnitTests_Lab3::Pass_CopyConstructor_SizeIsTheSame() {
	List list1;
	int numberOfNodes = RandomInt(6, 10);
	std::vector<Node*> nodes;
	CreateList(list1, nodes, numberOfNodes);

	List list2 = list1;

	bool result = list2.mSize == list1.mSize;

	return result;
}
#pragma endregion
#endif
#pragma endregion
#endif