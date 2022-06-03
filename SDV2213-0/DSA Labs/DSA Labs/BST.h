/*
File:			BST.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
	Student:

Created:		03.05.2021
Last Modified:	03.21.2021
Purpose:		A binary search tree
Notes:			Property of Full Sail University
*/

// Header protection
#pragma once

/************/
/* Includes */
/************/
#include <string>

/***********/
/* Defines */
/***********/

/*
How to use:

	When working on a lab, turn that lab's #define from 0 to 1

		Example:	#define LAB_1	1

	When working on an individual unit test, turn that #define from 0 to 1

		Example:	#define DYNARRAY_DEFAULT_CTOR	1

NOTE: If the unit test is not on, that code will not be compiled!
*/


// Main toggle
#define LAB_7	0

// Individual unit test toggles
#define BST_CTOR								0
#define BST_NODE_CTOR							0
#define BST_PUSH_EMPTY							0
#define BST_PUSH_ROOT_LEFT						0
#define BST_PUSH_ROOT_RIGHT						0
#define BST_PUSH_LEFT							0
#define BST_PUSH_RIGHT							0
#define BST_CLEAR								0
#define BST_DTOR								0
#define BST_CONTAINS_FOUND						0
#define BST_CONTAINS_NOTFOUND					0
#define BST_REMOVE_CASE0_ROOT					0
#define BST_REMOVE_CASE0_LEFT					0
#define BST_REMOVE_CASE0_RIGHT					0
#define BST_REMOVE_CASE1_ROOT_LEFT				0
#define BST_REMOVE_CASE1_ROOT_RIGHT				0
#define BST_REMOVE_CASE1_LEFT_LEFT				0
#define BST_REMOVE_CASE1_LEFT_RIGHT				0
#define BST_REMOVE_CASE1_RIGHT_LEFT				0
#define BST_REMOVE_CASE1_RIGHT_RIGHT			0
#define BST_REMOVE_CASE2_CASE0					0
#define BST_REMOVE_CASE2_CASE1					0
#define BST_REMOVE_CASE0						0
#define BST_REMOVE_CASE1						0
#define BST_REMOVE_CASE2						0
#define BST_REMOVE_NOT_FOUND					0
#define BST_IN_ORDER_TRAVERSAL					0
#define BST_ASSIGNMENT_OP						0
#define BST_COPY_CTOR							0


// Templated binary search tree
template<typename Type>
class BST {

	friend class UnitTests_Lab7;	// Giving access to test code

	struct Node {
		Type data;					// The value being stored
		Node* left, * right;		// The left and right nodes
		Node* parent;				// The parent node

		// Constructor
		//		Always creates a leaf node
		//
		// In:	_data		The value to store in this node
		//		_parent		The parent pointer (optional)
		Node(const Type& _data, Node* _parent = nullptr) {
			// TODO: Implement this method

		}
	};

	// Data members
	// NOTE: All values set to -1 for unit test purposes
	Node* mRoot = reinterpret_cast<Node*>(-1);	// The top-most Node in the tree

public:

	// Default constructor
	//			Always creates an empty tree
	BST() {
		// TODO: Implement this method

	}

	// Destructor
	//			Clear all dynamic memory
	~BST() {
		// TODO: Implement this method

	}

	// Copy constructor
		//			Used to initialize one object to another
		//
		// In:	_copy		The object to copy from
	BST(const BST& _copy) {
		// TODO: Implement this method

	}

	// Assignment operator
	//			Used to assign one object to another
	//
	// In:	_assign		The object to assign from
	//
	// Return:	The invoking object (by reference)
	//		This allows us to daisy-chain
	BST& operator=(const BST& _assign) {
		// TODO: Implement this method
		
	}

private:
	// Recursive helper method for use with Rule of 3
	// 
	// In:	_curr		The current Node to copy
	//
	// NOTE:	Use pre-order traversal
	void Copy(const Node* _curr) {
		// TODO: Implement this method

	}

public:

	// Clears out the tree and readies it for re-use
	void Clear() {
		// TODO: Implement this method

	}

private:

	// Recursive helper method for use with Clear
	// 
	// In:	_curr		The current Node to clear
	//
	// NOTE:	Use post-order traversal
	void Clear(Node* _curr) {
		// TODO: Implement this method

	}

public:

	// Add a value into the tree
	//
	// In:	_val			The value to add
	void Push(const Type& _val) {
		// TODO: Implement this method

	}

private:

	// Optional recursive helper method for use with Push
	//
	// In:	_val		The value to add
	//		_curr		The current Node being looked at
	void Push(const Type& _val, Node* _curr) {
		
	}
	
public:

	// Checks to see if a value is in the tree
	//
	// In:	_val		The value to search for
	//
	// Return:	True, if found
	bool Contains(const Type& _val) {
		// TODO: Implement this method

	}

private:

	// Optional helper method for use with Contains and Remove methods
	//
	// In:	_val		The value to search for
	//
	// Return: The node containing _val (or nullptr if not found)
	Node* FindNode(const Type& _val) {
		
	}

	// Remove a leaf node from the tree
	//		Case 0
	// 	   
	// In:	_node		The node to remove
	void RemoveCase0(Node* _node) {
		// TODO: Implement this method

	}

	// Remove a node from the tree that has only one child
	//		Case 1
	//
	// In:	_node		The node to remove
	void RemoveCase1(Node* _node) {
		// TODO: Implement this method

	}

	// Remove a node from the tree that has both children
	//		Case 2
	//
	// In:	_node		The node to remove
	void RemoveCase2(Node* _node) {
		// TODO: Implement this method

	}

public:

	// Removes a value from tree (first instance only)
	//
	// In:	_val			The value to search for
	//
	// Return:	True, if a Node was removed
	// NOTE:	Keep in mind the three cases
	//			A) 2 children ("fix" tree)
	//			B) 0 children
	//			C) 1 child
	bool Remove(const Type& _val) {
		// TODO: Implement this method

	}

	// Returns a space-delimited string of the tree in order
	/*
	 Example:
			 24
			/ \
		   10  48
			\   \
			12   50

	 Should return: "10 12 24 48 50"
	*/

	std::string InOrder() {
		// TODO: Implement this method

	}

private:

	// Recursive helper method to help with InOrder
	//
	// In:	_curr		The current Node being looked at
	//		_str		The string to add to
	//
	// NOTE:	Use in-order traversal
	// NOTE:	Use to_string to convert an int to its string equivelent
	void InOrder(Node* _curr, std::string& _str) {
		// TODO: Implement this method
	}
};

