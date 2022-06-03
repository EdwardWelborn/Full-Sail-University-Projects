/*
File:			UnitTests_Lab7.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		03.28.2022
Last Modified:	03.28.2022
Purpose:		Declaration of Lab7 Unit Tests for BST
Notes:			Property of Full Sail University
*/

// Header protection
#pragma once

/************/
/* Includes */
/************/
#include "UnitTestHelper.h"
#include "..\BST.h"
#include <map>

class UnitTests_Lab7 {
#if LAB_7
	using BST = BST<int>;
	using Node = BST::Node;
	using NodePair = std::pair<int, Node*>;

	static std::map<int, Node*> treeNodes;

	static BST* GenerateTree();
	static void GetNodes(Node* _node, std::vector<Node*>& _nodeVec);

	static void NegativeOneProtection(BST& _bst);
	static void NegativeOneProtection(BST* _bst);

public:
	// Runs all active unit tests
	static void FullBattery();

#pragma region Tests - BST Constructor
	static void Battery_BSTConstructor();

	static FailResult Fail_BSTConstructor_RootIsNotNull();

	static bool Pass_BSTConstructor_RootIsNull();
#pragma endregion

#pragma region Tests - Node Constructor
	static void Battery_NodeConstructor();

	static FailResult Fail_NodeConstructor_DataIsIncorrect();
	static FailResult Fail_NodeConstructor_NotALeafNode();

	static bool Pass_NodeConstructor_DataIsCorrect();
	static bool Pass_NodeConstructor_IsALeafNode();
#pragma endregion

#pragma region Tests - Copy Constructor
	static void Battery_CopyConstructor();

	static FailResult Fail_CopyConstructor_TreeIsShallowCopied();
	static FailResult Fail_CopyConstructor_EntireTreeIsNotCopied();
	static FailResult Fail_CopyConstructor_NodesHaveIncorrectValues();
	static FailResult Fail_CopyConstructor_InsufficientMemoryAllocated();
	static FailResult Fail_CopyConstructor_TooMuchMemoryAllocated();

	static bool Pass_CopyConstructor_TreeIsDeepCopied();
	static bool Pass_CopyConstructor_NodesHaveCorrectValues();
	static bool Pass_CopyConstructor_CorrectAmountOfMemoryAllocated();
#pragma endregion

#pragma region Tests - Assignment Operator
	static void Battery_AssignmentOperator();
	
	static FailResult Fail_AssignmentOperator_NoSelfAssignmentCheck();
	static FailResult Fail_AssignmentOperator_TreeIsShallowCopied();
	static FailResult Fail_AssignmentOperator_EntireTreeIsNotCopied();
	static FailResult Fail_AssignmentOperator_NodesHaveIncorrectValues();
	static FailResult Fail_AssignmentOperator_InsufficientMemoryAllocated();
	static FailResult Fail_AssignmentOperator_TooMuchMemoryAllocated();

	static bool Pass_AssignmentOperator_HasSelfAssignmentCheck();
	static bool Pass_AssignmentOperator_TreeIsDeepCopied();
	static bool Pass_AssignmentOperator_NodesHaveCorrectValues();
	static bool Pass_AssignmentOperator_CorrectAmountOfMemoryAllocated();
#pragma endregion

#pragma region Tests - Clear
	static void Battery_Clear();

	static FailResult Fail_Clear_OnlyOneNodeDeleted();
	static FailResult Fail_Clear_NotAllNodesAreDeleted();
	static FailResult Fail_Clear_RootIsNotNull();

	static bool Pass_Clear_AllNodesAreDeleted();
	static bool Pass_Clear_RootIsNull();
#pragma endregion

#pragma region Tests - Destructor
	static void Battery_Destructor();

	static FailResult Fail_Destructor_OnlyOneNodeDeleted();
	static FailResult Fail_Destructor_NotAllNodesAreDeleted();

	static bool Pass_Destructor_AllNodesAreDeleted();
#pragma endregion

#pragma region Tests - Push To Empty Tree
	static void Battery_PushToEmptyTree();

	static FailResult Fail_PushToEmptyTree_NoMemoryIsAllocated();
	static FailResult Fail_PushToEmptyTree_TooMuchMemoryIsAllocated();
	static FailResult Fail_PushToEmptyTree_RootIsNull();
	static FailResult Fail_PushToEmptyTree_RootDataIsIncorrectValue();
	static FailResult Fail_PushToEmptyTree_RootIsNotALeafNode();
	static FailResult Fail_PushToEmptyTree_RootParentIsNotNull();

	static bool Pass_PushToEmptyTree_CorrectAmountOfMemoryAllocated();
	static bool Pass_PushToEmptyTree_RootIsNotNull();
	static bool Pass_PushToEmptyTree_RootDataIsCorrectValue();
	static bool Pass_PushToEmptyTree_RootIsALeafNode();
	static bool Pass_PushToEmptyTree_RootParentIsNull();
#pragma endregion

#pragma region Tests - Push Left On Tree With Only Root
	static void Battery_PushToRootLeft();

	static FailResult Fail_PushToRootLeft_NoMemoryIsAllocated();
	static FailResult Fail_PushToRootLeft_TooMuchMemoryIsAllocated();
	static FailResult Fail_PushToRootLeft_RootAddressIsChanged();
	static FailResult Fail_PushToRootLeft_NewNodeIsNotConnectedToRootLeft();
	static FailResult Fail_PushToRootLeft_NewNodeParentIsNotRoot();
	static FailResult Fail_PushToRootLeft_NewNodeIsNotALeafNode();
	static FailResult Fail_PushToRootLeft_NewNodeDataIsIncorrectValue();

	static bool Pass_PushToRootLeft_CorrectAmountOfMemoryAllocated();
	static bool Pass_PushToRootLeft_NewNodeIsConnectedToRootLeft();
	static bool Pass_PushToRootLeft_NewNodeParentIsRoot();
	static bool Pass_PushToRootLeft_NewNodeIsALeafNode();
	static bool Pass_PushToRootLeft_NewNodeDataIsCorrectValue();
#pragma endregion

#pragma region Tests - Push Right on Tree With Only Root
	static void Battery_PushToRootRight();

	static FailResult Fail_PushToRootRight_NoMemoryIsAllocated();
	static FailResult Fail_PushToRootRight_TooMuchMemoryIsAllocated();
	static FailResult Fail_PushToRootRight_RootAddressIsChanged();
	static FailResult Fail_PushToRootRight_NewNodeIsNotConnectedToRootRight();
	static FailResult Fail_PushToRootRight_NewNodeParentIsNotRoot();
	static FailResult Fail_PushToRootRight_NewNodeIsNotALeafNode();
	static FailResult Fail_PushToRootRight_NewNodeDataIsIncorrectValue();

	static bool Pass_PushToRootRight_CorrectAmountOfMemoryAllocated();
	static bool Pass_PushToRootRight_NewNodeIsConnectedToRootRight();
	static bool Pass_PushToRootRight_NewNodeParentIsRoot();
	static bool Pass_PushToRootRight_NewNodeIsALeafNode();
	static bool Pass_PushToRootRight_NewNodeDataIsCorrectValue();
#pragma endregion

#pragma region Tests - Push Left On Tree With Several Nodes
	static void Battery_PushToLeftNonRoot();
	
	static FailResult Fail_PushLeftNonRoot_NoMemoryIsAllocated();
	static FailResult Fail_PushLeftNonRoot_TooMuchMemoryIsAllocated();
	static FailResult Fail_PushLeftNonRoot_NewNodeIsNotConnectedToCorrectNodesLeft();
	static FailResult Fail_PushLeftNonRoot_NewNodeParentIsNotConnectedToCorrectNode();
	static FailResult Fail_PushLeftNonRoot_NewNodeIsNotALeafNode();
	static FailResult Fail_PushLeftNonRoot_NewNodeDataIsIncorrectValue();

	static bool Pass_PushLeftNonRoot_CorrectAmountOfMemoryAllocated();
	static bool Pass_PushLeftNonRoot_NewNodeIsConnectedToCorrectNodesLeft();
	static bool Pass_PushLeftNonRoot_NewNodeParentIsConnectedToCorrectNode();
	static bool Pass_PushLeftNonRoot_NewNodeIsALeafNode();
	static bool Pass_PushLeftNonRoot_NewNodeDataIsCorrectValue();
#pragma endregion

#pragma region Tests - Push Right on Tree With Several Nodes
	static void Battery_PushToRightNonRoot();
	
	static FailResult Fail_PushRightNonRoot_NoMemoryIsAllocated();
	static FailResult Fail_PushRightNonRoot_TooMuchMemoryIsAllocated();
	static FailResult Fail_PushRightNonRoot_NewNodeIsNotConnectedToCorrectNodesRight();
	static FailResult Fail_PushRightNonRoot_NewNodeParentIsNotConnectedToCorrectNode();
	static FailResult Fail_PushRightNonRoot_NewNodeIsNotALeafNode();
	static FailResult Fail_PushRightNonRoot_NewNodeDataIsIncorrectValue();

	static bool Pass_PushRightNonRoot_CorrectAmountOfMemoryAllocated();
	static bool Pass_PushRightNonRoot_NewNodeIsConnectedToCorrectNodesRight();
	static bool Pass_PushRightNonRoot_NewNodeParentIsConnectedToCorrectNode();
	static bool Pass_PushRightNonRoot_NewNodeIsALeafNode();
	static bool Pass_PushRightNonRoot_NewNodeDataIsCorrectValue();
#pragma endregion

#pragma region Tests - Contains (Found)
	static void Battery_ContainsFound();

	static FailResult Fail_ContainsTrue_ReturnsFalseWhenNodeIsInTree();

	static bool Pass_ContainsTrue_ReturnsTrue_ReturnsTrueWhenNodeIsFound();

#pragma endregion

#pragma region Tests - Contains (Not Found)
	static void Battery_ContainsNotFound();

	static FailResult Fail_ContainsFalse_ReturnsTrueWhenNodeIsNotInTree();

	static bool Pass_ContainsFalse_ReturnsFalseWhenNodeIsNotFound();
#pragma endregion

#pragma region Tests - Remove Case 0 (Root)
	static void Battery_RemoveCase0_Root();

	static FailResult Fail_RemoveCase0_Root_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase0_Root_RootIsNotNull();

	static bool Pass_RemoveCase0_Root_OneNodeWasDeleted();
	static bool Pass_RemoveCase0_Root_RootIsNull();
#pragma endregion

#pragma region Tests - Remove Case 0 (Left Child)
	static void Battery_RemoveCase0_LeftChild();

	static FailResult Fail_RemoveCase0_LeftChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase0_LeftChild_ParentNodeLeftIsNotPointingToNull();

	static bool Pass_RemoveCase0_LeftChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase0_LeftChild_ParentNodeLeftIsPointingToNull();
#pragma endregion

#pragma region Tests - Remove Case 0 (Right Child)
	static void Battery_RemoveCase0_RightChild();

	static FailResult Fail_RemoveCase0_RightChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase0_RightChild_ParentNodeRightIsNotPointingToNull();

	static bool Pass_RemoveCase0_RightChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase0_RightChild_ParentNodeRightIsPointingToNull();
#pragma endregion

#pragma region Tests - Remove Case 1 (Root with Left Child)
	static void Battery_RemoveCase1_RootWithLeftChild();

	static FailResult Fail_RemoveCase1_RootWithLeftChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase1_RootWithLeftChild_RootIsNotPointingToLeftNode();
	static FailResult Fail_RemoveCase1_RootWithLeftChild_RootParentIsNotNull();

	static bool Pass_RemoveCase1_RootWithLeftChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase1_RootWithLeftChild_RootIsPointingToLeftNode();
	static bool Pass_RemoveCase1_RootWithLeftChild_RootParentIsNull();
#pragma endregion

#pragma region Tests - Remove Case 1 (Root with Right Child)
	static void Battery_RemoveCase1_RootWithRightChild();

	static FailResult Fail_RemoveCase1_RootWithRightChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase1_RootWithRightChild_RootIsNotPointingToRightNode();
	static FailResult Fail_RemoveCase1_RootWithRightChild_RootParentIsNotNull();

	static bool Pass_RemoveCase1_RootWithRightChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase1_RootWithRightChild_RootIsPointingToRightNodee();
	static bool Pass_RemoveCase1_RootWithRightChild_RootParentIsNull();
#pragma endregion

#pragma region Tests - Remove Case 1 (Left Child with Left Child)
	static void Battery_RemoveCase1_LeftChildWithLeftChild();

	static FailResult Fail_RemoveCase1_LeftChildWithLeftChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase1_LeftChildWithLeftChild_ParentLeftIsNotPointingToLeftNode();
	static FailResult Fail_RemoveCase1_LeftChildWithLeftChild_LeftParentIsNotPointingToParent();

	static bool Pass_RemoveCase1_LeftChildWithLeftChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase1_LeftChildWithLeftChild_ParentLeftIsPointingToLeftNode();
	static bool Pass_RemoveCase1_LeftChildWithLeftChild_LeftParentIsPointingToParentNode();
#pragma endregion

#pragma region Tests - Remove Case 1 (Left Child with Right Child)
	static void Battery_RemoveCase1_LeftChildWithRightChild();

	static FailResult Fail_RemoveCase1_LeftChildWithRightChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase1_LeftChildWithRightChild_ParentLeftIsNotPointingToRightNode();
	static FailResult Fail_RemoveCase1_LeftChildWithRightChild_RightParentIsNotPointingToParent();

	static bool Pass_RemoveCase1_LeftChildWithRightChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase1_LeftChildWithRightChild_ParentLeftIsPointingToRightNode();
	static bool Pass_RemoveCase1_LeftChildWithRightChild_RightParentIsPointingToParentNode();
#pragma endregion

#pragma region Tests - Remove Case 1 (Right Child with Left Child)
	static void Battery_RemoveCase1_RightChildWithLeftChild();

	static FailResult Fail_RemoveCase1_RightChildWithLeftChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase1_RightChildWithLeftChild_ParentRightIsNotPointingToLeftNode();
	static FailResult Fail_RemoveCase1_RightChildWithLeftChild_LeftParentIsNotPointingToParentNode();

	static bool Pass_RemoveCase1_RightChildWithLeftChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase1_RightChildWithLeftChild_ParentRightIsPointingToLeftNode();
	static bool Pass_RemoveCase1_RightChildWithLeftChild_LeftParentIsPointingToParentNode();
#pragma endregion

#pragma region Tests - Remove Case 1 (Right Child with Right Child)
	static void Battery_RemoveCase1_RightChildWithRightChild();

	static FailResult Fail_RemoveCase1_RightChildWithRightChild_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase1_RightChildWithRightChild_ParentRightIsNotPointingToRightNode();
	static FailResult Fail_RemoveCase1_RightChildWithRightChild_RightParentIsNotPointingToParentNode();

	static bool Pass_RemoveCase1_RightChildWithRightChild_OneNodeWasDeleted();
	static bool Pass_RemoveCase1_RightChildWithRightChild_ParentRightIsPointingToRightNode();
	static bool Pass_RemoveCase1_RightChildWithRightChild_RightParentIsPointingToParentNode();
#pragma endregion

#pragma region Tests - Remove Case 2 (Leads to Case 0)
	static void Battery_RemoveCase2_LeadsToCase0();

	static FailResult Fail_RemoveCase2_LeadsToCase0_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase2_LeadsToCase0_ValueWasNotUpdated();
	static FailResult Fail_RemoveCase2_LeadsToCase0_IncorrectNodeDeleted();

	static bool Pass_RemoveCase2_LeadsToCase0_OneNodeWasDeleted();
	static bool Pass_RemoveCase2_LeadsToCase0_ValueWasUpdated();
	static bool Pass_RemoveCase2_LeadsToCase0_CorrectNodeDeleted();
#pragma endregion

#pragma region Tests - Remove Case 2 (Leads to Case 1)
	static void Battery_RemoveCase2_LeadsToCase1();

	static FailResult Fail_RemoveCase2_LeadsToCase1_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_RemoveCase2_LeadsToCase1_ValueWasNotUpdated();
	static FailResult Fail_RemoveCase2_LeadsToCase1_IncorrectNodeDeleted();

	static bool Pass_RemoveCase2_LeadsToCase1_OneNodeWasDeleted();
	static bool Pass_RemoveCase2_LeadsToCase1_ValueWasUpdated();
	static bool Pass_RemoveCase2_LeadsToCase1_CorrectNodeDeleted();
#pragma endregion

#pragma region Tests - Remove (Case 0) 
	static void Battery_Remove_Case0();

	static FailResult Fail_Remove_Case0_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_Remove_Case0_ParentChildNotPointingToNull();
	static FailResult Fail_Remove_Case0_ReturnsFalseWhenNodeIsFound();
	
	static bool Pass_Remove_Case0_OneNodeWasDeleted();
	static bool Pass_Remove_Case0_ParentChildPointsToNull();
	static bool Pass_Remove_Case0_ReturnsTrueWhenNodeIsFound();
#pragma endregion

#pragma region Tests - Remove (Case 1) 
	static void Battery_Remove_Case1();

	static FailResult Fail_Remove_Case1_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_Remove_Case1_ParentChildNotPointingToCorrectNode();
	static FailResult Fail_Remove_Case1_ChildParentNotPointingToParent();
	static FailResult Fail_Remove_Case1_ReturnsFalseWhenNodeIsFound();

	static bool Pass_Remove_Case1_OneNodeWasDeleted();
	static bool Pass_Remove_Case1_ParentChildPointsToCorrectNode();
	static bool Pass_Remove_Case1_ChildParentPointsToParent();
	static bool Pass_Remove_Case1_ReturnsTrueWhenNodeIsFound();
#pragma endregion

#pragma region Tests - Remove (Case 2)
	static void Battery_Remove_Case2();
	
	static FailResult Fail_Remove_Case2_IncorrectAmountOfMemoryAllocated();
	static FailResult Fail_Remove_Case2_ValueWasNotUpdated();
	static FailResult Fail_Remove_Case2_ReturnsFalseWhenNodeIsFound();

	static bool Pass_Remove_Case2_OneNodeWasDeleted();
	static bool Pass_Remove_Case2_ValueWasUpdated();
	static bool Pass_Remove_Case2_ReturnsTrueWhenNodeIsFound();
#pragma endregion

#pragma region Tests - Remove (Not Found) 
	static void Battery_Remove_NotFound();

	static FailResult Fail_Remove_NotFound_ReturnsTrueWhenNodeIsNotFound();

	static bool Pass_Remove_NotFound_ReturnsFaslseWhenNodeIsNotFound();
#pragma region

#pragma region Tests - InOrder
	static void Battery_InOrder();

	static FailResult Fail_InOrder_StringDoesNotSeperateValuesWithSpaces();
	static FailResult Fail_InOrder_StringHasTrailingSpace();
	static FailResult Fail_InOrder_ValuesAreNotInCorrectOrder();

	static bool Pass_InOrder_ValuesAreInCorrectOrder();
#pragma endregion
#endif
};