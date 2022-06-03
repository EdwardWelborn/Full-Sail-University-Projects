/*
File:			DSA_TestSuite_Lab7.cpp
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		03.38.2022
Last Modified:	03.38.2022
Purpose:		Definition of Lab7 Unit Tests for BST
Notes:			Property of Full Sail University
*/

/************/
/* Includes */
/************/
#include "UnitTests_Lab7.h"
#include "Memory_Management.h"
#include <iostream>

#if LAB_7

std::map<int, UnitTests_Lab7::Node*> UnitTests_Lab7::treeNodes;

void UnitTests_Lab7::FullBattery() {
#if BST_CTOR
	Battery_BSTConstructor();
#endif
#if BST_NODE_CTOR
	Battery_NodeConstructor();
#endif
#if BST_PUSH_EMPTY
	Battery_PushToEmptyTree();
#endif
#if BST_PUSH_ROOT_LEFT
	Battery_PushToRootLeft();
#endif
#if BST_PUSH_ROOT_RIGHT
	Battery_PushToRootRight();
#endif
#if BST_PUSH_LEFT
	Battery_PushToLeftNonRoot();
#endif
#if BST_PUSH_RIGHT
	Battery_PushToRightNonRoot();
#endif
#if BST_CLEAR
	Battery_Clear();
#endif
#if BST_DTOR
	Battery_Destructor();
#endif
#if BST_CONTAINS_FOUND
	Battery_ContainsFound();
#endif
#if BST_CONTAINS_NOTFOUND
	Battery_ContainsNotFound();
#endif
#if BST_REMOVE_CASE0_ROOT
	Battery_RemoveCase0_Root();
#endif
#if BST_REMOVE_CASE0_LEFT
	Battery_RemoveCase0_LeftChild();
#endif
#if BST_REMOVE_CASE0_RIGHT
	Battery_RemoveCase0_RightChild();
#endif
#if BST_REMOVE_CASE1_ROOT_LEFT
	Battery_RemoveCase1_RootWithLeftChild();
#endif
#if BST_REMOVE_CASE1_ROOT_RIGHT
	Battery_RemoveCase1_RootWithRightChild();
#endif
#if BST_REMOVE_CASE1_LEFT_LEFT
	Battery_RemoveCase1_LeftChildWithLeftChild();
#endif
#if BST_REMOVE_CASE1_LEFT_RIGHT
	Battery_RemoveCase1_LeftChildWithRightChild();
#endif
#if BST_REMOVE_CASE1_RIGHT_LEFT
	Battery_RemoveCase1_RightChildWithLeftChild();
#endif
#if BST_REMOVE_CASE1_RIGHT_RIGHT
	Battery_RemoveCase1_RightChildWithRightChild();
#endif
#if BST_REMOVE_CASE2_CASE0
	Battery_RemoveCase2_LeadsToCase0();
#endif
#if BST_REMOVE_CASE2_CASE1
	Battery_RemoveCase2_LeadsToCase1();
#endif
#if BST_REMOVE_CASE0
	Battery_Remove_Case0();
#endif
#if BST_REMOVE_CASE1
	Battery_Remove_Case1();
#endif
#if BST_REMOVE_CASE2
	Battery_Remove_Case2();
#endif
#if BST_REMOVE_NOT_FOUND
	Battery_Remove_NotFound();
#endif
#if BST_IN_ORDER_TRAVERSAL
	Battery_InOrder();
#endif
#if BST_ASSIGNMENT_OP
	Battery_AssignmentOperator();
#endif
#if BST_COPY_CTOR
	Battery_CopyConstructor();
#endif
}

/*
					50
					/\
			25				75
			/\				/\
		10		35		65		100
		  \		 \		/		/
		  15	 40	   60	  80

*/

UnitTests_Lab7::BST* UnitTests_Lab7::GenerateTree() {
	BST* bst = new BST;

	// Allocate all nodes
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	Node* val75 = new Node(75);
	Node* val10 = new Node(10);
	Node* val35 = new Node(35);
	Node* val65 = new Node(65);
	Node* val100 = new Node(100);
	Node* val15 = new Node(15);
	Node* val40 = new Node(40);
	Node* val60 = new Node(60);
	Node* val80 = new Node(80);

	// Removing all nodes from previous tests
	treeNodes.clear();

	// Adding all nodes to map for easy lookup
	treeNodes[50] = val50;
	treeNodes[25] = val25;
	treeNodes[75] = val75;
	treeNodes[10] = val10;
	treeNodes[35] = val35;
	treeNodes[65] = val65;
	treeNodes[100] = val100;
	treeNodes[15] = val15;
	treeNodes[40] = val40;
	treeNodes[60] = val60;
	treeNodes[80] = val80;

	//Manually linking all nodes
	val50->left = val25;	val50->right = val75;	val50->parent = nullptr;
	val25->left = val10;	val25->right = val35;	val25->parent = val50;
	val75->left = val65;	val75->right = val100;	val75->parent = val50;
	val10->left = nullptr;	val10->right = val15;	val10->parent = val25;
	val35->left = nullptr;	val35->right = val40;	val35->parent = val25;
	val65->left = val60;	val65->right = nullptr;	val65->parent = val75;
	val100->left = val80;	val100->right = nullptr; val100->parent = val75;
	val15->left = nullptr;	val15->right = nullptr;	val15->parent = val10;
	val40->left = nullptr;	val40->right = nullptr;	val40->parent = val35;
	val60->left = nullptr;	val60->right = nullptr;	val60->parent = val65;
	val80->left = nullptr;	val80->right = nullptr;	val80->parent = val100;

	bst->mRoot = val50;
	return bst;
}

void UnitTests_Lab7::GetNodes(Node* _node, std::vector<Node*>& _nodeVec) {
	if (_node != reinterpret_cast<Node*>(-1) && _node) {
		_nodeVec.push_back(_node);
		GetNodes(_node->left, _nodeVec);
		GetNodes(_node->right, _nodeVec);
	}
}

void UnitTests_Lab7::NegativeOneProtection(BST& _bst) {
	if (_bst.mRoot == reinterpret_cast<BST::Node*>(-1))
		_bst.mRoot = nullptr;
}

void UnitTests_Lab7::NegativeOneProtection(BST* _bst) {
	if (_bst->mRoot == reinterpret_cast<BST::Node*>(-1))
		_bst->mRoot = nullptr;
}


#pragma region Tests - BST Constructor
#if BST_CTOR
void UnitTests_Lab7::Battery_BSTConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_BSTConstructor_RootIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_BSTConstructor_RootIsNull);

	UnitTestBattery("Testing constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_BSTConstructor_RootIsNotNull() {
	BST bst;

	FailResult result;
	result.check = bst.mRoot != nullptr;
	result.msg = "Root should be null";

	NegativeOneProtection(bst);
	
	return result;
}
#pragma endregion

bool UnitTests_Lab7::Pass_BSTConstructor_RootIsNull() {
	BST bst;

	bool result = bst.mRoot == nullptr;
	
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Node Constructor
#if BST_NODE_CTOR
void UnitTests_Lab7::Battery_NodeConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_NodeConstructor_DataIsIncorrect);
	failVec.push_back(Fail_NodeConstructor_NotALeafNode);

	PassVector passVec;
	passVec.push_back(Pass_NodeConstructor_DataIsCorrect);
	passVec.push_back(Pass_NodeConstructor_IsALeafNode);

	UnitTestBattery("Testing Node constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_NodeConstructor_DataIsIncorrect() {
	int randomVal = RandomInt(1, 100);
	Node node(randomVal);

	FailResult result;
	result.check = node.data != randomVal;
	result.msg = "Data in node is incorrect";

	return result;
}

FailResult UnitTests_Lab7::Fail_NodeConstructor_NotALeafNode() {
	Node node(1);

	FailResult result;
	result.check = node.left != nullptr || node.right != nullptr;
	result.msg = "Node is not a leaf node";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_NodeConstructor_DataIsCorrect() {
	int randomVal = RandomInt(1, 100);
	Node node(randomVal);

	bool result = node.data == randomVal;

	return result;
}

bool UnitTests_Lab7::Pass_NodeConstructor_IsALeafNode() {
	Node node(1);

	bool result = node.left == nullptr && node.right == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Copy Constructor
#if BST_COPY_CTOR
void UnitTests_Lab7::Battery_CopyConstructor() {
	FailVector failVec;
	failVec.push_back(Fail_CopyConstructor_TreeIsShallowCopied);
	failVec.push_back(Fail_CopyConstructor_EntireTreeIsNotCopied);
	failVec.push_back(Fail_CopyConstructor_NodesHaveIncorrectValues);
	failVec.push_back(Fail_CopyConstructor_InsufficientMemoryAllocated);
	failVec.push_back(Fail_CopyConstructor_TooMuchMemoryAllocated);

	PassVector passVec;
	passVec.push_back(Pass_CopyConstructor_TreeIsDeepCopied);
	passVec.push_back(Pass_CopyConstructor_NodesHaveCorrectValues);
	passVec.push_back(Pass_CopyConstructor_CorrectAmountOfMemoryAllocated);

	UnitTestBattery("Testing copy constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_CopyConstructor_TreeIsShallowCopied() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Copy constructor
	BST copy(*original);
	std::vector<Node*> copyVec;
	GetNodes(copy.mRoot, copyVec);

	FailResult result;
	result.check = copyVec.size() && copyVec == origVec;
	result.msg = "Tree needs to be deep copied";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_CopyConstructor_EntireTreeIsNotCopied() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Copy constructor
	BST copy(*original);
	std::vector<Node*> copyVec;
	GetNodes(copy.mRoot, copyVec);

	FailResult result;
	result.check = copyVec.size() != origVec.size();
	result.msg = "Trees are not the same size (number of nodes)";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_CopyConstructor_NodesHaveIncorrectValues() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Copy constructor
	BST copy(*original);
	std::vector<Node*> copyVec;
	GetNodes(copy.mRoot, copyVec);

	bool identicalValues = false;
	if (copyVec.size() == origVec.size()) {
		identicalValues = true;
		for (size_t i = 0; i < copyVec.size(); ++i)
			if (copyVec[i]->data != origVec[i]->data) {
				identicalValues = false;
				break;
			}
	}
	
	FailResult result;
	result.check = identicalValues == false;
	result.msg = "One (or more) nodes have incorrect value";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_CopyConstructor_InsufficientMemoryAllocated() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);
	
	// N allocated nodes + copy's root + pointer in vec
	size_t memoryCorrectAllocation = sizeof(Node) * origVec.size();

	size_t memoryDeltaStart = inUse;
	// Copy constructor
	BST copy(*original);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated < memoryCorrectAllocation;
	result.msg = "Not enough memory allocated - Did you not allocate memory for each node?";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_CopyConstructor_TooMuchMemoryAllocated() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// N allocated nodes
	size_t memoryCorrectAllocation = sizeof(Node) * origVec.size();

	size_t memoryDeltaStart = inUse;
	// Copy constructor
	BST copy(*original);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > memoryCorrectAllocation;
	result.msg = "Too much memory allocated (too many nodes allocated?)";

	delete original;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_CopyConstructor_TreeIsDeepCopied() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Copy constructor
	BST copy(*original);
	std::vector<Node*> copyVec;
	GetNodes(copy.mRoot, copyVec);

	bool result = copyVec.size() && copyVec != origVec;

	delete original;
	return result;
}

bool UnitTests_Lab7::Pass_CopyConstructor_NodesHaveCorrectValues() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Copy constructor
	BST copy(*original);
	std::vector<Node*> copyVec;
	GetNodes(copy.mRoot, copyVec);

	bool identicalValues = false;
	if (copyVec.size() == origVec.size()) {
		identicalValues = true;
		for (size_t i = 0; i < copyVec.size(); ++i)
			if (copyVec[i]->data != origVec[i]->data) {
				identicalValues = false;
				break;
			}
	}

	bool result = identicalValues;

	delete original;
	return result;
}

bool UnitTests_Lab7::Pass_CopyConstructor_CorrectAmountOfMemoryAllocated() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// N allocated nodes + copy's root + pointer in vec
	size_t memoryCorrectAllocation = sizeof(Node) * origVec.size();

	size_t memoryDeltaStart = inUse;
	// Copy constructor
	BST copy(*original);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == memoryCorrectAllocation;

	delete original;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Assignment Operator
#if BST_ASSIGNMENT_OP
void UnitTests_Lab7::Battery_AssignmentOperator() {
	FailVector failVec;
	failVec.push_back(Fail_AssignmentOperator_NoSelfAssignmentCheck);
	failVec.push_back(Fail_AssignmentOperator_TreeIsShallowCopied);
	failVec.push_back(Fail_AssignmentOperator_EntireTreeIsNotCopied);
	failVec.push_back(Fail_AssignmentOperator_NodesHaveIncorrectValues);
	failVec.push_back(Fail_AssignmentOperator_InsufficientMemoryAllocated);
	failVec.push_back(Fail_AssignmentOperator_TooMuchMemoryAllocated);

	PassVector passVec;
	passVec.push_back(Pass_AssignmentOperator_HasSelfAssignmentCheck);
	passVec.push_back(Pass_AssignmentOperator_TreeIsDeepCopied);
	passVec.push_back(Pass_AssignmentOperator_NodesHaveCorrectValues);
	passVec.push_back(Pass_AssignmentOperator_CorrectAmountOfMemoryAllocated);

	UnitTestBattery("Testing assignment operator", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_AssignmentOperator_NoSelfAssignmentCheck() {
	bool selfAssignmentFound = SearchFile("BST.h", "BST& operator=(const BST&", "void Clear(", "if(this != &_assign)");

	FailResult result;
	result.check = selfAssignmentFound == false;
	result.msg = "Self-assignment check not found";

	return result;
}

FailResult UnitTests_Lab7::Fail_AssignmentOperator_TreeIsShallowCopied() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Assignment operator
	BST assign;
	assign = *original;
	std::vector<Node*> assignVec;
	GetNodes(assign.mRoot, assignVec);

	FailResult result;
	result.check = assignVec.size() && assignVec == origVec;
	result.msg = "Tree needs to be deep copied";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_AssignmentOperator_EntireTreeIsNotCopied() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Assignment operator
	BST assign;
	assign = *original;
	std::vector<Node*> assignVec;
	GetNodes(assign.mRoot, assignVec);

	FailResult result;
	result.check = assignVec.size() != origVec.size();
	result.msg = "Trees are not the same size (number of nodes)";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_AssignmentOperator_NodesHaveIncorrectValues() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Assignment operator
	BST assign;
	assign = *original;
	std::vector<Node*> assignVec;
	GetNodes(assign.mRoot, assignVec);

	bool identicalValues = false;
	if (assignVec.size() == origVec.size()) {
		identicalValues = true;
		for (size_t i = 0; i < assignVec.size(); ++i)
			if (assignVec[i]->data != origVec[i]->data) {
				identicalValues = false;
				break;
			}
	}

	FailResult result;
	result.check = identicalValues == false;
	result.msg = "One (or more) nodes have incorrect value";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_AssignmentOperator_InsufficientMemoryAllocated() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// N allocated nodes
	size_t memoryCorrectAllocation = sizeof(Node) * origVec.size();

	size_t memoryDeltaStart = inUse;
	// Assignment operator
	BST assign;
	assign = *original;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated < memoryCorrectAllocation;
	result.msg = "Not enough memory allocated - Did you not allocate memory for each node?";

	delete original;
	return result;
}

FailResult UnitTests_Lab7::Fail_AssignmentOperator_TooMuchMemoryAllocated() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// N allocated nodes * 2 (two trees)
	size_t memoryCorrectAllocation = sizeof(Node) * origVec.size() * 2;

	// Assignment operator
	BST* assign = GenerateTree();
	size_t memoryDeltaStart = inUse;
	*assign = *original;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > memoryCorrectAllocation;
	result.msg = "Too much memory allocated - Did you not delete old tree?";

	delete original;
	delete assign;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_AssignmentOperator_HasSelfAssignmentCheck() {
	bool selfAssignmentFound = SearchFile("BST.h", "BST& operator=(const BST&", "void Clear(", "if(this != &_assign)");

	bool result = selfAssignmentFound;

	return result;
}

bool UnitTests_Lab7::Pass_AssignmentOperator_TreeIsDeepCopied() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Assignment operator
	BST assign;
	assign = *original;
	std::vector<Node*> assignVec;
	GetNodes(assign.mRoot, assignVec);

	bool result = assignVec.size() && assignVec != origVec;

	delete original;
	return result;
}

bool UnitTests_Lab7::Pass_AssignmentOperator_NodesHaveCorrectValues() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// Assignment operator
	BST assign;
	assign = *original;
	std::vector<Node*> assignVec;
	GetNodes(assign.mRoot, assignVec);

	bool identicalValues = false;
	if (assignVec.size() == origVec.size()) {
		identicalValues = true;
		for (size_t i = 0; i < assignVec.size(); ++i)
			if (assignVec[i]->data != origVec[i]->data) {
				identicalValues = false;
				break;
			}
	}

	bool result = identicalValues;

	delete original;
	return result;
}

bool UnitTests_Lab7::Pass_AssignmentOperator_CorrectAmountOfMemoryAllocated() {
	// Creating initial tree to copy from
	BST* original = GenerateTree();
	std::vector<Node*> origVec;
	GetNodes(original->mRoot, origVec);

	// N allocated nodes - number of nodes from assign before delete
	size_t memoryCorrectAllocation = sizeof(Node) * origVec.size() - sizeof(Node)*3;


	// Assignment operator
	BST assign;
	assign.mRoot = new Node(10);
	assign.mRoot->left = new Node(5);
	assign.mRoot->right = new Node(15);

	size_t memoryDeltaStart = inUse;
	assign = *original;
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == memoryCorrectAllocation;

	delete original;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Clear
#if BST_CLEAR
void UnitTests_Lab7::Battery_Clear() {
	FailVector failVec;
	failVec.push_back(Fail_Clear_OnlyOneNodeDeleted);
	failVec.push_back(Fail_Clear_NotAllNodesAreDeleted);
	failVec.push_back(Fail_Clear_RootIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_Clear_AllNodesAreDeleted);
	passVec.push_back(Pass_Clear_RootIsNull);
	
	UnitTestBattery("Testing Clear", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_Clear_OnlyOneNodeDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Clear();
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted == sizeof(Node);
	result.msg = "Only one node deleted - Did you delete just root?";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Clear_NotAllNodesAreDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Clear();
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted != sizeof(Node)*11;
	result.msg = "Not all nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Clear_RootIsNotNull() {
	BST* bst = GenerateTree();

	bst->Clear();

	FailResult result;
	result.check = bst->mRoot != nullptr;
	result.msg = "Root was not set back to null";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_Clear_AllNodesAreDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Clear();
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node) * 11;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Clear_RootIsNull() {
	BST* bst = GenerateTree();

	bst->Clear();

	bool result = bst->mRoot == nullptr;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Destructor
#if BST_DTOR
void UnitTests_Lab7::Battery_Destructor() {
	FailVector failVec;
	failVec.push_back(Fail_Destructor_OnlyOneNodeDeleted);
	failVec.push_back(Fail_Destructor_NotAllNodesAreDeleted);

	PassVector passVec;
	passVec.push_back(Pass_Destructor_AllNodesAreDeleted);

	UnitTestBattery("Testing destructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_Destructor_OnlyOneNodeDeleted() {
	size_t memoryDeltaStart = inUse;

	BST* bst = GenerateTree();
	delete bst;
	size_t memoryDeltaEnd = inUse;
	size_t memoryLeaked = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryLeaked == sizeof(Node)*10;
	result.msg = "Only one node deleted - Did you delete just root?";

	return result;
}

FailResult UnitTests_Lab7::Fail_Destructor_NotAllNodesAreDeleted() {

	size_t memoryDeltaStart = inUse;
	BST* bst = GenerateTree();
	delete bst;
	size_t memoryDeltaEnd = inUse;
	size_t memoryLeaked = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryLeaked != 0;
	result.msg = "Not all nodes were deleted";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_Destructor_AllNodesAreDeleted() {
	size_t memoryDeltaStart = inUse;

	BST* bst = GenerateTree();
	delete bst;
	size_t memoryDeltaEnd = inUse;
	size_t memoryLeaked = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryLeaked == 0;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Push To Empty Tree
#if BST_PUSH_EMPTY
void UnitTests_Lab7::Battery_PushToEmptyTree() {
	FailVector failVec;
	failVec.push_back(Fail_PushToEmptyTree_NoMemoryIsAllocated);
	failVec.push_back(Fail_PushToEmptyTree_TooMuchMemoryIsAllocated);
	failVec.push_back(Fail_PushToEmptyTree_RootIsNull);
	failVec.push_back(Fail_PushToEmptyTree_RootDataIsIncorrectValue);
	failVec.push_back(Fail_PushToEmptyTree_RootIsNotALeafNode);
	failVec.push_back(Fail_PushToEmptyTree_RootParentIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_PushToEmptyTree_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_PushToEmptyTree_RootIsNotNull);
	passVec.push_back(Pass_PushToEmptyTree_RootDataIsCorrectValue);
	passVec.push_back(Pass_PushToEmptyTree_RootIsALeafNode);
	passVec.push_back(Pass_PushToEmptyTree_RootParentIsNull);

	UnitTestBattery("Testing Push on empty tree", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_PushToEmptyTree_NoMemoryIsAllocated() {
	BST bst;

	size_t memoryDeltaStart = inUse;
	bst.Push(1);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No dynamic memory was allocated";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToEmptyTree_TooMuchMemoryIsAllocated() {
	BST bst;

	size_t memoryDeltaStart = inUse;
	bst.Push(1);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "Too much memory was allocated (should only allocate one node)";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToEmptyTree_RootIsNull() {
	BST bst;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot == nullptr;
	result.msg = "Root is still null (should point to allocated node)";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToEmptyTree_RootDataIsIncorrectValue() {
	int randomVal = RandomInt(1, 100);
	BST bst;

	bst.Push(randomVal);

	FailResult result;
	result.check = bst.mRoot != reinterpret_cast<Node*>(-1) && bst.mRoot && bst.mRoot->data != randomVal;
	result.msg = "Node's value is incorrect";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToEmptyTree_RootIsNotALeafNode() {
	BST bst;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot != reinterpret_cast<Node*>(-1) && bst.mRoot && (bst.mRoot->left || bst.mRoot->right);
	result.msg = "Node is not a leaf node";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToEmptyTree_RootParentIsNotNull() {
	BST bst;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot != reinterpret_cast<Node*>(-1) && bst.mRoot && bst.mRoot->parent;
	result.msg = "Node's parent is not null";

	NegativeOneProtection(bst);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_PushToEmptyTree_CorrectAmountOfMemoryAllocated() {
	BST bst;

	size_t memoryDeltaStart = inUse;
	bst.Push(1);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	NegativeOneProtection(bst);

	return result;
}

bool UnitTests_Lab7::Pass_PushToEmptyTree_RootIsNotNull() {
	BST bst;

	bst.Push(1);

	bool result = bst.mRoot;

	return result;
}

bool UnitTests_Lab7::Pass_PushToEmptyTree_RootDataIsCorrectValue() {
	int randomVal = RandomInt(1, 100);
	BST bst;

	bst.Push(randomVal);

	bool result = bst.mRoot && bst.mRoot->data == randomVal;

	return result;
}

bool UnitTests_Lab7::Pass_PushToEmptyTree_RootIsALeafNode() {
	BST bst;

	bst.Push(1);

	bool result = bst.mRoot && bst.mRoot->left == nullptr && bst.mRoot->right == nullptr;

	return result;
}

bool UnitTests_Lab7::Pass_PushToEmptyTree_RootParentIsNull() {
	BST bst;

	bst.Push(1);

	bool result = bst.mRoot && bst.mRoot->parent == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Push Left On Tree With Only Root
#if BST_PUSH_ROOT_LEFT
void UnitTests_Lab7::Battery_PushToRootLeft() {
	FailVector failVec;
	failVec.push_back(Fail_PushToRootLeft_NoMemoryIsAllocated);
	failVec.push_back(Fail_PushToRootLeft_TooMuchMemoryIsAllocated);
	failVec.push_back(Fail_PushToRootLeft_RootAddressIsChanged);
	failVec.push_back(Fail_PushToRootLeft_NewNodeIsNotConnectedToRootLeft);
	failVec.push_back(Fail_PushToRootLeft_NewNodeParentIsNotRoot);
	failVec.push_back(Fail_PushToRootLeft_NewNodeIsNotALeafNode);
	failVec.push_back(Fail_PushToRootLeft_NewNodeDataIsIncorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_PushToRootLeft_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_PushToRootLeft_NewNodeIsConnectedToRootLeft);
	passVec.push_back(Pass_PushToRootLeft_NewNodeParentIsRoot);
	passVec.push_back(Pass_PushToRootLeft_NewNodeIsALeafNode);
	passVec.push_back(Pass_PushToRootLeft_NewNodeDataIsCorrectValue);

	UnitTestBattery("Testing Push left with only root", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_PushToRootLeft_NoMemoryIsAllocated() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;

	size_t memoryDeltaStart = inUse;
	bst.Push(1);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No dynamic memory was allocated";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootLeft_TooMuchMemoryIsAllocated() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;

	size_t memoryDeltaStart = inUse;
	bst.Push(1);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "Too much memory was allocated (should only allocate one node)";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootLeft_RootAddressIsChanged() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot != rootAddress;
	result.msg = "Root's address should not be changed";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootLeft_NewNodeIsNotConnectedToRootLeft() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->left == nullptr;
	result.msg = "New node was not linked to root's left";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootLeft_NewNodeParentIsNotRoot() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->left && bst.mRoot->left->parent == nullptr;
	result.msg = "New node's parent is incorrect";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootLeft_NewNodeIsNotALeafNode() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->left && (bst.mRoot->left->left || bst.mRoot->left->right);
	result.msg = "New node is not a leaf node";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootLeft_NewNodeDataIsIncorrectValue() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->left && bst.mRoot->left->data != 1;
	result.msg = "New node's data is incorrect";

	NegativeOneProtection(bst);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_PushToRootLeft_CorrectAmountOfMemoryAllocated() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;

	size_t memoryDeltaStart = inUse;
	bst.Push(1);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootLeft_NewNodeIsConnectedToRootLeft() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	bool result = bst.mRoot && bst.mRoot->left != nullptr;

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootLeft_NewNodeParentIsRoot() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	bool result = bst.mRoot && bst.mRoot->left && bst.mRoot->left->parent == bst.mRoot;

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootLeft_NewNodeIsALeafNode() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	bool result = bst.mRoot && bst.mRoot->left && 
		bst.mRoot->left->left == nullptr && bst.mRoot->left->right == nullptr;

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootLeft_NewNodeDataIsCorrectValue() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(1);

	bool result = bst.mRoot && bst.mRoot->left && bst.mRoot->left->data == 1;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Push Right on Tree With Only Root
#if BST_PUSH_ROOT_RIGHT
void UnitTests_Lab7::Battery_PushToRootRight() {
	FailVector failVec;
	failVec.push_back(Fail_PushToRootRight_NoMemoryIsAllocated);
	failVec.push_back(Fail_PushToRootRight_TooMuchMemoryIsAllocated);
	failVec.push_back(Fail_PushToRootRight_RootAddressIsChanged);
	failVec.push_back(Fail_PushToRootRight_NewNodeIsNotConnectedToRootRight);
	failVec.push_back(Fail_PushToRootRight_NewNodeParentIsNotRoot);
	failVec.push_back(Fail_PushToRootRight_NewNodeIsNotALeafNode);
	failVec.push_back(Fail_PushToRootRight_NewNodeDataIsIncorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_PushToRootRight_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_PushToRootRight_NewNodeIsConnectedToRootRight);
	passVec.push_back(Pass_PushToRootRight_NewNodeParentIsRoot);
	passVec.push_back(Pass_PushToRootRight_NewNodeIsALeafNode);
	passVec.push_back(Pass_PushToRootRight_NewNodeDataIsCorrectValue);

	UnitTestBattery("Testing Push right with only root", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_PushToRootRight_NoMemoryIsAllocated() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;

	size_t memoryDeltaStart = inUse;
	bst.Push(3);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No dynamic memory was allocated";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootRight_TooMuchMemoryIsAllocated() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;

	size_t memoryDeltaStart = inUse;
	bst.Push(3);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "Too much memory was allocated (should only allocate one node)";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootRight_RootAddressIsChanged() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	FailResult result;
	result.check = bst.mRoot != rootAddress;
	result.msg = "Root's address should not be changed";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootRight_NewNodeIsNotConnectedToRootRight() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->right == nullptr;
	result.msg = "New node was not linked to root's right";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootRight_NewNodeParentIsNotRoot() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->right && bst.mRoot->right->parent == nullptr;
	result.msg = "New node's parent is incorrect";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootRight_NewNodeIsNotALeafNode() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->right && (bst.mRoot->right->left || bst.mRoot->right->right);
	result.msg = "New node is not a leaf node";

	NegativeOneProtection(bst);

	return result;
}

FailResult UnitTests_Lab7::Fail_PushToRootRight_NewNodeDataIsIncorrectValue() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->right && bst.mRoot->right->data != 3;
	result.msg = "New node's data is incorrect";

	NegativeOneProtection(bst);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_PushToRootRight_CorrectAmountOfMemoryAllocated() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;

	size_t memoryDeltaStart = inUse;
	bst.Push(3);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootRight_NewNodeIsConnectedToRootRight() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	bool result = bst.mRoot && bst.mRoot->right != nullptr;

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootRight_NewNodeParentIsRoot() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	bool result = bst.mRoot && bst.mRoot->right && bst.mRoot->right->parent == bst.mRoot;

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootRight_NewNodeIsALeafNode() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	bool result = bst.mRoot && bst.mRoot->right &&
		bst.mRoot->right->left == nullptr && bst.mRoot->right->right == nullptr;

	return result;
}

bool UnitTests_Lab7::Pass_PushToRootRight_NewNodeDataIsCorrectValue() {
	BST bst;
	bst.mRoot = new Node(2);
	bst.mRoot->left = bst.mRoot->right = bst.mRoot->parent = nullptr;
	Node* rootAddress = bst.mRoot;

	bst.Push(3);

	bool result = bst.mRoot && bst.mRoot->right && bst.mRoot->right->data == 3;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Push Left On Tree With Several Nodes
#if BST_PUSH_LEFT
void UnitTests_Lab7::Battery_PushToLeftNonRoot() {
	FailVector failVec;
	failVec.push_back(Fail_PushLeftNonRoot_NoMemoryIsAllocated);
	failVec.push_back(Fail_PushLeftNonRoot_TooMuchMemoryIsAllocated);
	failVec.push_back(Fail_PushLeftNonRoot_NewNodeIsNotConnectedToCorrectNodesLeft);
	failVec.push_back(Fail_PushLeftNonRoot_NewNodeParentIsNotConnectedToCorrectNode);
	failVec.push_back(Fail_PushLeftNonRoot_NewNodeIsNotALeafNode);
	failVec.push_back(Fail_PushLeftNonRoot_NewNodeDataIsIncorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_PushLeftNonRoot_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_PushLeftNonRoot_NewNodeIsConnectedToCorrectNodesLeft);
	passVec.push_back(Pass_PushLeftNonRoot_NewNodeParentIsConnectedToCorrectNode);
	passVec.push_back(Pass_PushLeftNonRoot_NewNodeIsALeafNode);
	passVec.push_back(Pass_PushLeftNonRoot_NewNodeDataIsCorrectValue);

	UnitTestBattery("Testing Push left on tree with many nodes", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_PushLeftNonRoot_NoMemoryIsAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Push(30);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No dynamic memory was allocated";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushLeftNonRoot_TooMuchMemoryIsAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Push(30);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "Too much memory was allocated (should only allocate one node)";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushLeftNonRoot_NewNodeIsNotConnectedToCorrectNodesLeft() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	FailResult result;
	result.check = node35->left == nullptr;
	result.msg = "New node was not linked to correct node's left";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushLeftNonRoot_NewNodeParentIsNotConnectedToCorrectNode() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	FailResult result;
	result.check = node35->left && node35->left->parent != node35;
	result.msg = "New node's parent is incorrect";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushLeftNonRoot_NewNodeIsNotALeafNode() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	FailResult result;
	result.check = node35->left && (node35->left->left || node35->left->right);
	result.msg = "New node is not a leaf node";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushLeftNonRoot_NewNodeDataIsIncorrectValue() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	FailResult result;
	result.check = node35->left && node35->left->data != 30;
	result.msg = "New node's data is incorrect";

	NegativeOneProtection(*bst);

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_PushLeftNonRoot_CorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Push(30);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushLeftNonRoot_NewNodeIsConnectedToCorrectNodesLeft() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	bool result = node35->left != nullptr;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushLeftNonRoot_NewNodeParentIsConnectedToCorrectNode() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	bool result = node35->left && node35->left->parent == node35;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushLeftNonRoot_NewNodeIsALeafNode() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	bool result = node35->left && (node35->left->left == nullptr && node35->left->right == nullptr);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushLeftNonRoot_NewNodeDataIsCorrectValue() {
	BST* bst = GenerateTree();

	bst->Push(30);
	Node* node35 = treeNodes[35];

	bool result = node35->left && node35->left->data == 30;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Push Right on Tree With Several Nodes
#if BST_PUSH_RIGHT
void UnitTests_Lab7::Battery_PushToRightNonRoot() {
	FailVector failVec;
	failVec.push_back(Fail_PushRightNonRoot_NoMemoryIsAllocated);
	failVec.push_back(Fail_PushRightNonRoot_TooMuchMemoryIsAllocated);
	failVec.push_back(Fail_PushRightNonRoot_NewNodeIsNotConnectedToCorrectNodesRight);
	failVec.push_back(Fail_PushRightNonRoot_NewNodeParentIsNotConnectedToCorrectNode);
	failVec.push_back(Fail_PushRightNonRoot_NewNodeIsNotALeafNode);
	failVec.push_back(Fail_PushRightNonRoot_NewNodeDataIsIncorrectValue);

	PassVector passVec;
	passVec.push_back(Pass_PushRightNonRoot_CorrectAmountOfMemoryAllocated);
	passVec.push_back(Pass_PushRightNonRoot_NewNodeIsConnectedToCorrectNodesRight);
	passVec.push_back(Pass_PushRightNonRoot_NewNodeParentIsConnectedToCorrectNode);
	passVec.push_back(Pass_PushRightNonRoot_NewNodeIsALeafNode);
	passVec.push_back(Pass_PushRightNonRoot_NewNodeDataIsCorrectValue);

	UnitTestBattery("Testing Push right on tree with many nodes", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_PushRightNonRoot_NoMemoryIsAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Push(70);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated == 0;
	result.msg = "No dynamic memory was allocated";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushRightNonRoot_TooMuchMemoryIsAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Push(70);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > sizeof(Node);
	result.msg = "Too much memory was allocated (should only allocate one node)";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushRightNonRoot_NewNodeIsNotConnectedToCorrectNodesRight() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	FailResult result;
	result.check = node65->right == nullptr;
	result.msg = "New node was not linked to correct node's right";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushRightNonRoot_NewNodeParentIsNotConnectedToCorrectNode() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	FailResult result;
	result.check = node65->right && node65->right->parent != node65;
	result.msg = "New node's parent is incorrect";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushRightNonRoot_NewNodeIsNotALeafNode() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	FailResult result;
	result.check = node65->right && (node65->right->left || node65->right->right);
	result.msg = "New node is not a leaf node";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_PushRightNonRoot_NewNodeDataIsIncorrectValue() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	FailResult result;
	result.check = node65->right && node65->right->data != 70;
	result.msg = "New node's data is incorrect";

	NegativeOneProtection(bst);

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_PushRightNonRoot_CorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Push(70);
	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushRightNonRoot_NewNodeIsConnectedToCorrectNodesRight() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	bool result = node65->right != nullptr;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushRightNonRoot_NewNodeParentIsConnectedToCorrectNode() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	bool result = node65->right && node65->right->parent == node65;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushRightNonRoot_NewNodeIsALeafNode() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	bool result = node65->right && (node65->right->left == nullptr && node65->right->right == nullptr);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_PushRightNonRoot_NewNodeDataIsCorrectValue() {
	BST* bst = GenerateTree();

	bst->Push(70);
	Node* node65 = treeNodes[65];

	bool result = node65->right && node65->right->data == 70;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Contains (Found)
#if BST_CONTAINS_FOUND
void UnitTests_Lab7::Battery_ContainsFound() {
	FailVector failVec;
	failVec.push_back(Fail_ContainsTrue_ReturnsFalseWhenNodeIsInTree);

	PassVector passVec;
	passVec.push_back(Pass_ContainsTrue_ReturnsTrue_ReturnsTrueWhenNodeIsFound);

	UnitTestBattery("Testing Contains (found)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_ContainsTrue_ReturnsFalseWhenNodeIsInTree() {
	BST* bst = GenerateTree();

	bool found = bst->Contains(60);

	FailResult result;
	result.check = found == false;
	result.msg = "Contains returned false - Value was in tree";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_ContainsTrue_ReturnsTrue_ReturnsTrueWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool found = bst->Contains(60);

	bool result = found;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Contains (Not Found)
#if BST_CONTAINS_NOTFOUND
void UnitTests_Lab7::Battery_ContainsNotFound() {
	FailVector failVec;
	failVec.push_back(Fail_ContainsFalse_ReturnsTrueWhenNodeIsNotInTree);

	PassVector passVec;
	passVec.push_back(Pass_ContainsFalse_ReturnsFalseWhenNodeIsNotFound);

	UnitTestBattery("Testing Contains (not found)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_ContainsFalse_ReturnsTrueWhenNodeIsNotInTree() {
	BST* bst = GenerateTree();

	bool found = bst->Contains(20);

	FailResult result;
	result.check = found;
	result.msg = "Contains returned true - Value was not in tree";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_ContainsFalse_ReturnsFalseWhenNodeIsNotFound() {
	BST* bst = GenerateTree();

	bool found = bst->Contains(20);

	bool result = found == false;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 0 (Root)
#if BST_REMOVE_CASE0_ROOT
void UnitTests_Lab7::Battery_RemoveCase0_Root() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase0_Root_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase0_Root_RootIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase0_Root_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase0_Root_RootIsNull);

	UnitTestBattery("Testing RemoveCase0 (Root)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase0_Root_IncorrectAmountOfMemoryAllocated() {
	BST bst;
	Node* node = new Node(50);
	node->left = node->right = node->parent = nullptr;
	bst.mRoot = node;

	size_t memoryDeltaStart = inUse;
	bst.RemoveCase0(node);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase0_Root_RootIsNotNull() {
	BST bst;
	Node* node = new Node(50);
	node->left = node->right = node->parent = nullptr;
	bst.mRoot = node;

	bst.RemoveCase0(node);

	FailResult result;
	result.check = bst.mRoot != nullptr;
	result.msg = "Root was not set back to null";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase0_Root_OneNodeWasDeleted() {
	BST bst;
	Node* node = new Node(50);
	node->left = node->right = node->parent = nullptr;
	bst.mRoot = node;

	size_t memoryDeltaStart = inUse;
	bst.RemoveCase0(node);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase0_Root_RootIsNull() {
	BST bst;
	Node* node = new Node(50);
	node->left = node->right = node->parent = nullptr;
	bst.mRoot = node;

	bst.RemoveCase0(node);

	bool result = bst.mRoot == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 0 (Left Child)
#if BST_REMOVE_CASE0_LEFT
void UnitTests_Lab7::Battery_RemoveCase0_LeftChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase0_LeftChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase0_LeftChild_ParentNodeLeftIsNotPointingToNull);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase0_LeftChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase0_LeftChild_ParentNodeLeftIsPointingToNull);

	UnitTestBattery("Testing RemoveCase0 (Left Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase0_LeftChild_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase0(treeNodes[60]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
	
	return FailResult();
}

FailResult UnitTests_Lab7::Fail_RemoveCase0_LeftChild_ParentNodeLeftIsNotPointingToNull() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[65];

	bst->RemoveCase0(treeNodes[60]);

	FailResult result;
	result.check = parent->left != nullptr;
	result.msg = "Parent's left is not null";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase0_LeftChild_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase0(treeNodes[60]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase0_LeftChild_ParentNodeLeftIsPointingToNull() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[65];

	bst->RemoveCase0(treeNodes[60]);

	bool result = parent->left == nullptr;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 0 (Right Child)
#if BST_REMOVE_CASE0_RIGHT
void UnitTests_Lab7::Battery_RemoveCase0_RightChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase0_RightChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase0_RightChild_ParentNodeRightIsNotPointingToNull);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase0_RightChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase0_RightChild_ParentNodeRightIsPointingToNull);

	UnitTestBattery("Testing RemoveCase0 (Right Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase0_RightChild_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase0(treeNodes[15]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;

	return FailResult();
}

FailResult UnitTests_Lab7::Fail_RemoveCase0_RightChild_ParentNodeRightIsNotPointingToNull() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[10];

	bst->RemoveCase0(treeNodes[15]);

	FailResult result;
	result.check = parent->right != nullptr;
	result.msg = "Parent's right is not null";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase0_RightChild_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase0(treeNodes[15]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase0_RightChild_ParentNodeRightIsPointingToNull() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[10];

	bst->RemoveCase0(treeNodes[15]);

	bool result = parent->right == nullptr;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 1 (Root with Left Child)
#if BST_REMOVE_CASE1_ROOT_LEFT
void UnitTests_Lab7::Battery_RemoveCase1_RootWithLeftChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase1_RootWithLeftChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase1_RootWithLeftChild_RootIsNotPointingToLeftNode);
	failVec.push_back(Fail_RemoveCase1_RootWithLeftChild_RootParentIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase1_RootWithLeftChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase1_RootWithLeftChild_RootIsPointingToLeftNode);
	passVec.push_back(Pass_RemoveCase1_RootWithLeftChild_RootParentIsNull);

	UnitTestBattery("Testing RemoveCase1 (Root with Left Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase1_RootWithLeftChild_IncorrectAmountOfMemoryAllocated() {
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	val50->left = val25;	val50->right = nullptr;	val50->parent = nullptr;
	val25->left = nullptr;	val25->right = nullptr;	val25->parent = val50;

	BST bst;
	bst.mRoot = val50;

	size_t memoryDeltaStart = inUse;
	bst.RemoveCase1(val50);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RootWithLeftChild_RootIsNotPointingToLeftNode() {
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	val50->left = val25;	val50->right = nullptr;	val50->parent = nullptr;
	val25->left = nullptr;	val25->right = nullptr;	val25->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	FailResult result;
	result.check = bst.mRoot != val25;
	result.msg = "Root is not updated to left child";

	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RootWithLeftChild_RootParentIsNotNull() {
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	val50->left = val25;	val50->right = nullptr;	val50->parent = nullptr;
	val25->left = nullptr;	val25->right = nullptr;	val25->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->parent != nullptr;
	result.msg = "Root's parent is not null";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase1_RootWithLeftChild_OneNodeWasDeleted() {
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	val50->left = val25;	val50->right = nullptr;	val50->parent = nullptr;
	val25->left = nullptr;	val25->right = nullptr;	val25->parent = val50;

	BST bst;
	bst.mRoot = val50;

	size_t memoryDeltaStart = inUse;
	bst.RemoveCase1(val50);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RootWithLeftChild_RootIsPointingToLeftNode() {
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	val50->left = val25;	val50->right = nullptr;	val50->parent = nullptr;
	val25->left = nullptr;	val25->right = nullptr;	val25->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	bool result = bst.mRoot == val25;

	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RootWithLeftChild_RootParentIsNull() {
	Node* val50 = new Node(50);
	Node* val25 = new Node(25);
	val50->left = val25;	val50->right = nullptr;	val50->parent = nullptr;
	val25->left = nullptr;	val25->right = nullptr;	val25->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	bool result = bst.mRoot && bst.mRoot->parent == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 1 (Root with Right Child)
#if BST_REMOVE_CASE1_ROOT_RIGHT
void UnitTests_Lab7::Battery_RemoveCase1_RootWithRightChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase1_RootWithRightChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase1_RootWithRightChild_RootIsNotPointingToRightNode);
	failVec.push_back(Fail_RemoveCase1_RootWithRightChild_RootParentIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase1_RootWithRightChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase1_RootWithRightChild_RootIsPointingToRightNodee);
	passVec.push_back(Pass_RemoveCase1_RootWithRightChild_RootParentIsNull);

	UnitTestBattery("Testing RemoveCase1 (Root with Right Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase1_RootWithRightChild_IncorrectAmountOfMemoryAllocated() {
	Node* val50 = new Node(50);
	Node* val75 = new Node(75);
	val50->left = nullptr;	val50->right = val75;	val50->parent = nullptr;
	val75->left = nullptr;	val75->right = nullptr;	val75->parent = val50;

	BST bst;
	bst.mRoot = val50;

	size_t memoryDeltaStart = inUse;
	bst.RemoveCase1(val50);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RootWithRightChild_RootIsNotPointingToRightNode() {
	Node* val50 = new Node(50);
	Node* val75 = new Node(75);
	val50->left = nullptr;	val50->right = val75;	val50->parent = nullptr;
	val75->left = nullptr;	val75->right = nullptr;	val75->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	FailResult result;
	result.check = bst.mRoot != val75;
	result.msg = "Root is not updated to right child";

	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RootWithRightChild_RootParentIsNotNull() {
	Node* val50 = new Node(50);
	Node* val75 = new Node(75);
	val50->left = nullptr;	val50->right = val75;	val50->parent = nullptr;
	val75->left = nullptr;	val75->right = nullptr;	val75->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	FailResult result;
	result.check = bst.mRoot && bst.mRoot->parent != nullptr;
	result.msg = "Root's parent is not null";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase1_RootWithRightChild_OneNodeWasDeleted() {
	Node* val50 = new Node(50);
	Node* val75 = new Node(75);
	val50->left = nullptr;	val50->right = val75;	val50->parent = nullptr;
	val75->left = nullptr;	val75->right = nullptr;	val75->parent = val50;

	BST bst;
	bst.mRoot = val50;

	size_t memoryDeltaStart = inUse;
	bst.RemoveCase1(val50);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RootWithRightChild_RootIsPointingToRightNodee() {
	Node* val50 = new Node(50);
	Node* val75 = new Node(75);
	val50->left = nullptr;	val50->right = val75;	val50->parent = nullptr;
	val75->left = nullptr;	val75->right = nullptr;	val75->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	bool result = bst.mRoot == val75;

	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RootWithRightChild_RootParentIsNull() {
	Node* val50 = new Node(50);
	Node* val75 = new Node(75);
	val50->left = nullptr;	val50->right = val75;	val50->parent = nullptr;
	val75->left = nullptr;	val75->right = nullptr;	val75->parent = val50;

	BST bst;
	bst.mRoot = val50;

	bst.RemoveCase1(val50);

	bool result = bst.mRoot && bst.mRoot->parent == nullptr;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 1 (Left Child with Left Child)
#if BST_REMOVE_CASE1_LEFT_LEFT
void UnitTests_Lab7::Battery_RemoveCase1_LeftChildWithLeftChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase1_LeftChildWithLeftChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase1_LeftChildWithLeftChild_ParentLeftIsNotPointingToLeftNode);
	failVec.push_back(Fail_RemoveCase1_LeftChildWithLeftChild_LeftParentIsNotPointingToParent);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase1_LeftChildWithLeftChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase1_LeftChildWithLeftChild_ParentLeftIsPointingToLeftNode);
	passVec.push_back(Pass_RemoveCase1_LeftChildWithLeftChild_LeftParentIsPointingToParentNode);

	UnitTestBattery("Testing RemoveCase1 (Left Child with Left Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase1_LeftChildWithLeftChild_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[65]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_LeftChildWithLeftChild_ParentLeftIsNotPointingToLeftNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[60];

	bst->RemoveCase1(treeNodes[65]);

	FailResult result;
	result.check = parent->left != child;
	result.msg = "Parent of deleted node did not update its left";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_LeftChildWithLeftChild_LeftParentIsNotPointingToParent() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[60];

	bst->RemoveCase1(treeNodes[65]);

	FailResult result;
	result.check = child->parent != parent;
	result.msg = "Child of deleted node did not update its parent";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase1_LeftChildWithLeftChild_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[65]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_LeftChildWithLeftChild_ParentLeftIsPointingToLeftNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[60];

	bst->RemoveCase1(treeNodes[65]);

	bool result = parent->left == child;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_LeftChildWithLeftChild_LeftParentIsPointingToParentNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[60];

	bst->RemoveCase1(treeNodes[65]);

	bool result = child->parent == parent;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 1 (Left Child with Right Child)
#if BST_REMOVE_CASE1_LEFT_RIGHT
void UnitTests_Lab7::Battery_RemoveCase1_LeftChildWithRightChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase1_LeftChildWithRightChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase1_LeftChildWithRightChild_ParentLeftIsNotPointingToRightNode);
	failVec.push_back(Fail_RemoveCase1_LeftChildWithRightChild_RightParentIsNotPointingToParent);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase1_LeftChildWithRightChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase1_LeftChildWithRightChild_ParentLeftIsPointingToRightNode);
	passVec.push_back(Pass_RemoveCase1_LeftChildWithRightChild_RightParentIsPointingToParentNode);

	UnitTestBattery("Testing RemoveCase1 (Left Child with Right Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase1_LeftChildWithRightChild_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[10]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_LeftChildWithRightChild_ParentLeftIsNotPointingToRightNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[15];

	bst->RemoveCase1(treeNodes[10]);

	FailResult result;
	result.check = parent->left != child;
	result.msg = "Parent of deleted node did not update its left";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_LeftChildWithRightChild_RightParentIsNotPointingToParent() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[15];

	bst->RemoveCase1(treeNodes[10]);

	FailResult result;
	result.check = child->parent != parent;
	result.msg = "Child of deleted node did not update its parent";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase1_LeftChildWithRightChild_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[10]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_LeftChildWithRightChild_ParentLeftIsPointingToRightNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[15];

	bst->RemoveCase1(treeNodes[10]);

	bool result = parent->left == child;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_LeftChildWithRightChild_RightParentIsPointingToParentNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[15];

	bst->RemoveCase1(treeNodes[10]);

	bool result = child->parent == parent;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 1 (Right Child with Left Child)
#if BST_REMOVE_CASE1_RIGHT_LEFT
void UnitTests_Lab7::Battery_RemoveCase1_RightChildWithLeftChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase1_RightChildWithLeftChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase1_RightChildWithLeftChild_ParentRightIsNotPointingToLeftNode);
	failVec.push_back(Fail_RemoveCase1_RightChildWithLeftChild_LeftParentIsNotPointingToParentNode);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase1_RightChildWithLeftChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase1_RightChildWithLeftChild_ParentRightIsPointingToLeftNode);
	passVec.push_back(Pass_RemoveCase1_RightChildWithLeftChild_LeftParentIsPointingToParentNode);

	UnitTestBattery("Testing RemoveCase1 (Right Child with Left Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase1_RightChildWithLeftChild_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[100]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RightChildWithLeftChild_ParentRightIsNotPointingToLeftNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[80];

	bst->RemoveCase1(treeNodes[100]);

	FailResult result;
	result.check = parent->right != child;
	result.msg = "Parent of deleted node did not update its right";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RightChildWithLeftChild_LeftParentIsNotPointingToParentNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[80];

	bst->RemoveCase1(treeNodes[100]);

	FailResult result;
	result.check = child->parent != parent;
	result.msg = "Child of deleted node did not update its parent";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase1_RightChildWithLeftChild_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[100]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RightChildWithLeftChild_ParentRightIsPointingToLeftNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[80];

	bst->RemoveCase1(treeNodes[100]);

	bool result = parent->right == child;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RightChildWithLeftChild_LeftParentIsPointingToParentNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[75];
	Node* child = treeNodes[80];

	bst->RemoveCase1(treeNodes[100]);

	bool result = child->parent == parent;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 1 (Right Child with Right Child)
#if BST_REMOVE_CASE1_RIGHT_RIGHT
void UnitTests_Lab7::Battery_RemoveCase1_RightChildWithRightChild() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase1_RightChildWithRightChild_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase1_RightChildWithRightChild_ParentRightIsNotPointingToRightNode);
	failVec.push_back(Fail_RemoveCase1_RightChildWithRightChild_RightParentIsNotPointingToParentNode);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase1_RightChildWithRightChild_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase1_RightChildWithRightChild_ParentRightIsPointingToRightNode);
	passVec.push_back(Pass_RemoveCase1_RightChildWithRightChild_RightParentIsPointingToParentNode);

	UnitTestBattery("Testing RemoveCase1 (Right Child with Right Child)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase1_RightChildWithRightChild_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[35]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RightChildWithRightChild_ParentRightIsNotPointingToRightNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->RemoveCase1(treeNodes[35]);

	FailResult result;
	result.check = parent->right != child;
	result.msg = "Parent of deleted node did not update its right";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase1_RightChildWithRightChild_RightParentIsNotPointingToParentNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->RemoveCase1(treeNodes[35]);

	FailResult result;
	result.check = child->parent != parent;
	result.msg = "Child of deleted node did not update its parent";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase1_RightChildWithRightChild_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase1(treeNodes[35]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RightChildWithRightChild_ParentRightIsPointingToRightNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->RemoveCase1(treeNodes[35]);

	bool result = parent->right == child;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase1_RightChildWithRightChild_RightParentIsPointingToParentNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->RemoveCase1(treeNodes[35]);

	bool result = child->parent == parent;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 2 (Leads to Case 0)
#if BST_REMOVE_CASE2_CASE0
void UnitTests_Lab7::Battery_RemoveCase2_LeadsToCase0() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase2_LeadsToCase0_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase2_LeadsToCase0_ValueWasNotUpdated);
	failVec.push_back(Fail_RemoveCase2_LeadsToCase0_IncorrectNodeDeleted);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase2_LeadsToCase0_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase2_LeadsToCase0_ValueWasUpdated);
	passVec.push_back(Pass_RemoveCase2_LeadsToCase0_CorrectNodeDeleted);

	UnitTestBattery("Testing RemoveCase2 (Leads to Case 0)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase2_LeadsToCase0_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase2(treeNodes[75]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase2_LeadsToCase0_ValueWasNotUpdated() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[75]);

	FailResult result;
	result.check = treeNodes[75]->data != 80;
	result.msg = "Data was not updated to min value of right subtree";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase2_LeadsToCase0_IncorrectNodeDeleted() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[75]);

	FailResult result;
	result.check = treeNodes[100]->left != nullptr;
	result.msg = "Incorrect node was deleted";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase2_LeadsToCase0_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase2(treeNodes[75]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase2_LeadsToCase0_ValueWasUpdated() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[75]);

	bool result = treeNodes[75]->data == 80;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase2_LeadsToCase0_CorrectNodeDeleted() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[75]);

	bool result = treeNodes[100]->left == nullptr;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove Case 2 (Leads to Case 1)
#if BST_REMOVE_CASE2_CASE1
void UnitTests_Lab7::Battery_RemoveCase2_LeadsToCase1() {
	FailVector failVec;
	failVec.push_back(Fail_RemoveCase2_LeadsToCase1_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_RemoveCase2_LeadsToCase1_ValueWasNotUpdated);
	failVec.push_back(Fail_RemoveCase2_LeadsToCase1_IncorrectNodeDeleted);

	PassVector passVec;
	passVec.push_back(Pass_RemoveCase2_LeadsToCase1_OneNodeWasDeleted);
	passVec.push_back(Pass_RemoveCase2_LeadsToCase1_ValueWasUpdated);
	passVec.push_back(Pass_RemoveCase2_LeadsToCase1_CorrectNodeDeleted);

	UnitTestBattery("Testing RemoveCase2 (Leads to Case 1)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_RemoveCase2_LeadsToCase1_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase2(treeNodes[25]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase2_LeadsToCase1_ValueWasNotUpdated() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[25]);

	FailResult result;
	result.check = treeNodes[25]->data != 35;
	result.msg = "Data was not updated to min value of right subtree";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_RemoveCase2_LeadsToCase1_IncorrectNodeDeleted() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[25]);

	FailResult result;
	result.check = treeNodes[25]->right != treeNodes[40];
	result.msg = "Incorrect node was deleted";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_RemoveCase2_LeadsToCase1_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->RemoveCase2(treeNodes[25]);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase2_LeadsToCase1_ValueWasUpdated() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[25]);

	bool result = treeNodes[25]->data == 35;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_RemoveCase2_LeadsToCase1_CorrectNodeDeleted() {
	BST* bst = GenerateTree();

	bst->RemoveCase2(treeNodes[25]);

	bool result = treeNodes[25]->right == treeNodes[40];

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove (Case 0) 
#if BST_REMOVE_CASE0
void UnitTests_Lab7::Battery_Remove_Case0() {
	FailVector failVec;
	failVec.push_back(Fail_Remove_Case0_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_Remove_Case0_ParentChildNotPointingToNull);
	failVec.push_back(Fail_Remove_Case0_ReturnsFalseWhenNodeIsFound);

	PassVector passVec;
	passVec.push_back(Pass_Remove_Case0_OneNodeWasDeleted);
	passVec.push_back(Pass_Remove_Case0_ParentChildPointsToNull);
	passVec.push_back(Pass_Remove_Case0_ReturnsTrueWhenNodeIsFound);

	UnitTestBattery("Testing Remove (Case 0)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_Remove_Case0_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Remove(60);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case0_ParentChildNotPointingToNull() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[65];

	bst->Remove(60);

	FailResult result;
	result.check = parent->left != nullptr;
	result.msg = "Parent's child is not null";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case0_ReturnsFalseWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool removed = bst->Remove(60);

	FailResult result;
	result.check = removed == false;
	result.msg = "Returned false when Node was removed";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_Remove_Case0_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Remove(60);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case0_ParentChildPointsToNull() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[65];

	bst->Remove(60);

	bool result = parent->left == nullptr;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case0_ReturnsTrueWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool removed = bst->Remove(60);

	bool result = removed;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove (Case 1) 
#if BST_REMOVE_CASE1
void UnitTests_Lab7::Battery_Remove_Case1() {
	FailVector failVec;
	failVec.push_back(Fail_Remove_Case1_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_Remove_Case1_ParentChildNotPointingToCorrectNode);
	failVec.push_back(Fail_Remove_Case1_ChildParentNotPointingToParent);
	failVec.push_back(Fail_Remove_Case1_ReturnsFalseWhenNodeIsFound);

	PassVector passVec;
	passVec.push_back(Pass_Remove_Case1_OneNodeWasDeleted);
	passVec.push_back(Pass_Remove_Case1_ParentChildPointsToCorrectNode);
	passVec.push_back(Pass_Remove_Case1_ChildParentPointsToParent);
	passVec.push_back(Pass_Remove_Case1_ReturnsTrueWhenNodeIsFound);

	UnitTestBattery("Testing Remove (Case 1)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_Remove_Case1_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Remove(35);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";
	
	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case1_ParentChildNotPointingToCorrectNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->Remove(35);

	FailResult result;
	result.check = parent->right != child;
	result.msg = "Parent of deleted node did not update its child";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case1_ChildParentNotPointingToParent() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->Remove(35);

	FailResult result;
	result.check = child->parent != parent;
	result.msg = "Child of deleted node did not update its parent";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case1_ReturnsFalseWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool removed = bst->Remove(35);

	FailResult result;
	result.check = removed == false;
	result.msg = "Returned false when Node was removed";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_Remove_Case1_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Remove(35);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case1_ParentChildPointsToCorrectNode() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->Remove(35);

	bool result = parent->right == child;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case1_ChildParentPointsToParent() {
	BST* bst = GenerateTree();
	Node* parent = treeNodes[25];
	Node* child = treeNodes[40];

	bst->Remove(35);

	bool result = child->parent == parent;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case1_ReturnsTrueWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool removed = bst->Remove(35);

	bool result = removed;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove (Case 2)
#if BST_REMOVE_CASE2
void UnitTests_Lab7::Battery_Remove_Case2() {
	FailVector failVec;
	failVec.push_back(Fail_Remove_Case2_IncorrectAmountOfMemoryAllocated);
	failVec.push_back(Fail_Remove_Case2_ValueWasNotUpdated);
	failVec.push_back(Fail_Remove_Case2_ReturnsFalseWhenNodeIsFound);

	PassVector passVec;
	passVec.push_back(Pass_Remove_Case2_OneNodeWasDeleted);
	passVec.push_back(Pass_Remove_Case2_ValueWasUpdated);
	passVec.push_back(Pass_Remove_Case2_ReturnsTrueWhenNodeIsFound);

	UnitTestBattery("Testing Remove (Case 2)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_Remove_Case2_IncorrectAmountOfMemoryAllocated() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Remove(75);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	FailResult result;
	result.check = memoryDeleted < sizeof(Node);
	result.msg = "No nodes were deleted";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case2_ValueWasNotUpdated() {
	BST* bst = GenerateTree();
	
	bst->Remove(75);

	FailResult result;
	result.check = treeNodes[75]->data != 80;
	result.msg = "Data was not updated to min value of right subtree";

	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_Remove_Case2_ReturnsFalseWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool removed = bst->Remove(75);

	FailResult result;
	result.check = removed == false;
	result.msg = "Returned false when Node was removed";

	delete bst;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_Remove_Case2_OneNodeWasDeleted() {
	BST* bst = GenerateTree();

	size_t memoryDeltaStart = inUse;
	bst->Remove(75);
	size_t memoryDeltaEnd = inUse;
	size_t memoryDeleted = memoryDeltaStart - memoryDeltaEnd;

	bool result = memoryDeleted == sizeof(Node);

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case2_ValueWasUpdated() {
	BST* bst = GenerateTree();

	bst->Remove(75);

	bool result = treeNodes[75]->data == 80;

	delete bst;
	return result;
}

bool UnitTests_Lab7::Pass_Remove_Case2_ReturnsTrueWhenNodeIsFound() {
	BST* bst = GenerateTree();

	bool removed = bst->Remove(75);

	bool result = removed;

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - Remove (Not Found) 
#if BST_REMOVE_NOT_FOUND
void UnitTests_Lab7::Battery_Remove_NotFound() {
	FailVector failVec;
	failVec.push_back(Fail_Remove_NotFound_ReturnsTrueWhenNodeIsNotFound);

	PassVector passVec;
	passVec.push_back(Pass_Remove_NotFound_ReturnsFaslseWhenNodeIsNotFound);

	UnitTestBattery("Testing Remove (Not Found)", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_Remove_NotFound_ReturnsTrueWhenNodeIsNotFound() {
	BST bst;

	bool removed = bst.Remove(999);

	FailResult result;
	result.check = removed;
	result.msg = "Returns true when node is not in tree";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_Remove_NotFound_ReturnsFaslseWhenNodeIsNotFound() {
	BST bst;

	bool removed = bst.Remove(999);

	bool result = removed == false;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Tests - InOrder
#if BST_IN_ORDER_TRAVERSAL
void UnitTests_Lab7::Battery_InOrder() {
	FailVector failVec;
	failVec.push_back(Fail_InOrder_StringDoesNotSeperateValuesWithSpaces);
	failVec.push_back(Fail_InOrder_StringHasTrailingSpace);
	failVec.push_back(Fail_InOrder_ValuesAreNotInCorrectOrder);

	PassVector passVec;
	passVec.push_back(Pass_InOrder_ValuesAreInCorrectOrder);

	UnitTestBattery("Testing InOrder", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab7::Fail_InOrder_StringDoesNotSeperateValuesWithSpaces() {
	BST* bst = GenerateTree();

	std::string values = bst->InOrder();

	FailResult result;
	result.check = values == "10152535405060657580100";
	result.msg = "Does not seperate values with spaces";

	delete bst;
	return result;
}
#pragma endregion

FailResult UnitTests_Lab7::Fail_InOrder_StringHasTrailingSpace() {
	BST* bst = GenerateTree();

	std::string values = bst->InOrder();

	FailResult result;
	result.check = values.length() > 0 && (values.back() == ' ' || values.front() == ' ');
	result.msg = "String has leading or trailing space";
	
	delete bst;
	return result;
}

FailResult UnitTests_Lab7::Fail_InOrder_ValuesAreNotInCorrectOrder() {
	BST* bst = GenerateTree();

	std::string values = bst->InOrder();

	FailResult result;
	result.check = values != "10 15 25 35 40 50 60 65 75 80 100";
	result.msg = "String is in incorrect order (or not correct at all) (or has leading or trailing space)";

	delete bst;
	return result;
}

#pragma region Pass Tests
bool UnitTests_Lab7::Pass_InOrder_ValuesAreInCorrectOrder() {
	BST* bst = GenerateTree();

	std::string values = bst->InOrder();

	bool result = values == "10 15 25 35 40 50 60 65 75 80 100";

	delete bst;
	return result;
}
#pragma endregion
#endif
#pragma endregion
#endif
