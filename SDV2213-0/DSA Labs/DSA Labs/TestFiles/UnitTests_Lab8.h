/*
File:			UnitTests_Lab8.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		03.28.2022
Last Modified:	03.28.2022
Purpose:		Declaration of Lab8 Unit Tests for Huffman Compression
Notes:			Property of Full Sail University
*/

// Header protection
#pragma once

/************/
/* Includes */
/************/

#include "UnitTestHelper.h"
#include "..\\Huffman.h"

class UnitTests_Lab8 {
#if LAB_8

	struct RandomFile {
		std::string name;
		unsigned int freq[256];
	};

	// static std::string mTempFilename;
	static RandomFile randomFile;
	using huffNode = Huffman::HuffNode;
	using huffVector = std::vector<huffNode*>;


	// Helper methods
	static bool HuffmanCompareTree(huffNode* _a, huffNode* _b);
	static void ParseTree(huffNode* _node, huffVector& _nodeVec);
	static void GenerateRandomFile();

	static void NegativeOneProtection(Huffman& _huff);


public:
	// Runs all active unit tests
	static void FullBattery();

#pragma region Test - Constructor
	static void Battery_Constructor();

	static FailResult Fail_Constructor_IncorrectFileName();
	static FailResult Fail_Constructor_FrequencyTableIsNotZeroedOut();
	static FailResult Fail_Constructor_LeafListIsNotEmpty();
	static FailResult Fail_Constructor_RootIsNotNull();
	static FailResult Fail_Constructor_EncodingTableIsNotEmpty();

	static bool Pass_Constructor_CorrectFileName();
	static bool Pass_Constructor_FrequencyTableIsZeroedOut();
	static bool Pass_Constructor_LeafListIsEmpty();
	static bool Pass_Constructor_RootIsNull();
	static bool Pass_Constructor_EncodingTableIsEmpty();
#pragma endregion

#pragma region Test - Generate Frequency Table
	static void Battery_GenerateFrequencyTable();

	static FailResult Fail_GenerateFrequencyTable_ValuesAreIncorrect();
	static FailResult Fail_GenerateFrequencyTable_OneValueIsOffByOne();

	static bool Pass_GenerateFrequencyTable_ValuesAreCorrect();
#pragma endregion

#pragma region Test - Generate Leaf List
	static void Battery_GenerateLeafList();

	static FailResult Fail_GenerateLeafList_DoesNotDynamicallyAllocateNodes();
	static FailResult Fail_GenerateLeafList_VectorIsIncorrectSize();
	static FailResult Fail_GenerateLeafList_ValuesAreIncorrect();
	static FailResult Fail_GenerateLeafList_FrequenciesOfNodesAreIncorrect();

	static bool Pass_GenerateLeafList_VectorIsCorrectSize();
	static bool Pass_GenerateLeafList_ValuesAreCorrect();
	static bool Pass_GenerateLeafList_FrequenciesOfNodesAreCorrect();
#pragma endregion


#pragma region Test - Generate Tree
	static void Battery_GenerateTree();

	static FailResult Fail_GenerateTree_PriorityQueueHasCorrectArguments();
	static FailResult Fail_GenerateTree_RootIsNotPointingToValidNode();
	static FailResult Fail_GenerateTree_RootParentIsNotNull();
	static FailResult Fail_GenerateTree_RootFrequencyIsNotTotal();
	static FailResult Fail_GenerateTree_NodesDoNotHaveValidParents();
	static FailResult Fail_GenerateTree_TreeIsNotCorrect();

	static bool Pass_GenerateTree_RootIsPointingToValidNode();
	static bool Pass_GenerateTree_RootFrequencyIsTotal();
	static bool Pass_GenerateTree_NodesHaveValidParents();
	static bool Pass_GenerateTree_TreeIsCorrect();
#pragma endregion

#pragma region Test - Clear Tree
	static void Battery_ClearTree();

	static FailResult Fail_ClearTree_MemoryIsNotDeleted();
	static FailResult Fail_ClearTree_RootIsNotNull();

	static bool Pass_ClearTree_MemoryIsDeleted();
	static bool Pass_ClearTree_RootIsNull();
#pragma endregion

#pragma region Test - Destructor
	static void Battery_Destructor();

	static FailResult Fail_Destructor_MemoryIsNotDeleted();

	static bool Pass_Destructor_MemoryIsDeleted();
#pragma endregion

#pragma region Test - Generate Encoding Table
	static void Battery_GenerateEncodingTable();

	static FailResult Fail_GenerateEncodingTable_UsesArrowOperatorOnEncodingTable();
	static FailResult Fail_GenerateEncodingTable_DataAddedToIncorrectIndices();
	static FailResult Fail_GenerateEncodingTable_DataIsNotReversed();

	static bool Pass_GenerateEncodingTable_CorrectDataInTable();
#pragma endregion

#pragma region Test - Compress
	static void Battery_Compress();

	static FailResult Fail_Compress_DoesNotPassHeader();
	static FailResult Fail_Compress_UsesSizeofForHeader();
	static FailResult Fail_Compress_OpensIncorrectFileForReading();
	static FailResult Fail_Compress_OpensIncorrectFileForWriting();
	static FailResult Fail_Compress_CompressedFileIsIncorrect();

	static bool Pass_Compress_CompressedFileIsCorrect();
#pragma endregion

#pragma region Test - Decompress
	static void Battery_Decompress();

	static FailResult Fail_Decompress_DoesNotPassHeader();
	static FailResult Fail_Decompress_UsesSizeofForHeader();
	static FailResult Fail_Decompress_OpensIncorrectFileForWriting();
	static FailResult Fail_Decompress_DecompressedFileIsTooLarge();
	static FailResult Fail_Decompress_DecompressedFileIsIncorrect();

	static bool Pass_Decompress_DecompressedFileIsCorrect();
#pragma endregion
#endif
};