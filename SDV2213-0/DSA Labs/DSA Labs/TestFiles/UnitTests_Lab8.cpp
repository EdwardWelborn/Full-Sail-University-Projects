/*
File:			UnitTests_Lab8.cpp
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		03.28.2022
Last Modified:	03.28.2022
Purpose:		Definitions of Lab8 Unit Tests for Huffman compression
Notes:			Property of Full Sail University
*/

/************/
/* Includes */
/************/
#include "UnitTests_Lab8.h"
#include "Memory_Management.h"
#include "HuffmanLib.h"
#include <iostream>

#if LAB_8

UnitTests_Lab8::RandomFile UnitTests_Lab8::randomFile = {};

void UnitTests_Lab8::FullBattery() {
#if HUFFMAN_CTOR
	Battery_Constructor();
#endif
#if HUFFMAN_GENERATE_FREQUENCY
	Battery_GenerateFrequencyTable();
#endif
#if HUFFMAN_GENERATE_LEAFLIST
	Battery_GenerateLeafList();
#endif
#if HUFFMAN_GENERATE_TREE
	Battery_GenerateTree();
#endif
#if HUFFMAN_CLEAR_TREE
	Battery_ClearTree();
#endif
#if HUFFMAN_DTOR
	Battery_Destructor();
#endif
#if HUFFMAN_GENERATE_ENCODING
	Battery_GenerateEncodingTable();
#endif
#if HUFFMAN_COMPRESS
	Battery_Compress();
#endif
#if HUFFMAN_DECOMPRESS
	Battery_Decompress();
#endif
}

bool UnitTests_Lab8::HuffmanCompareTree(huffNode* _a, huffNode* _b) {
	if (_a == reinterpret_cast<huffNode*>(-1) || _b == reinterpret_cast<huffNode*>(-1))
		return false;
	
	// Check for empty
	if (!_a && !_b)
		return true;

	// One is empty
	else if (!_a || !_b)
		return false;

	// Both non-empty
	else {
		return (_a && _b &&
			_a->value == _b->value &&
			_a->freq == _b->freq &&
			HuffmanCompareTree(_a->left, _b->left) &&
			HuffmanCompareTree(_a->right, _b->right));
	}
}

void UnitTests_Lab8::ParseTree(huffNode* _node, huffVector& _nodeVec) {
	if (_node != reinterpret_cast<huffNode*>(-1) && _node) {
		ParseTree(_node->left, _nodeVec);
		_nodeVec.push_back(_node);
		ParseTree(_node->right, _nodeVec);
	}
}

void UnitTests_Lab8::GenerateRandomFile() {
	randomFile.name = "";
	memset(randomFile.freq, 0, 1024);
	for (int i = 0; i < 8; ++i)
		randomFile.name += (char)RandomInt('a', 'z');
	randomFile.name += ".bin";

	unsigned int total = 0;
	std::string data;
	for (int i = 0; i < 256; ++i) {
		randomFile.freq[i] = RandomInt(0, 10000);
		total += randomFile.freq[i];
		for (unsigned int c = 0; c < randomFile.freq[i]; ++c)
			data.push_back(i);
	}

	std::random_device rd;
	std::mt19937 g(rd());
	std::shuffle(data.begin(), data.end(), g);
	

	std::ofstream output(randomFile.name, std::ios::binary);
	output.write(data.c_str(), data.size());

	output.close();
}

void UnitTests_Lab8::NegativeOneProtection(Huffman& _huff) {
	if (_huff.mRoot == reinterpret_cast<Huffman::HuffNode*>(-1))
		_huff.mRoot = nullptr;
}


#pragma region Test - Constructor
#if HUFFMAN_CTOR
void UnitTests_Lab8::Battery_Constructor() {
	FailVector failVec;
	failVec.push_back(Fail_Constructor_IncorrectFileName);
	failVec.push_back(Fail_Constructor_FrequencyTableIsNotZeroedOut);
	failVec.push_back(Fail_Constructor_LeafListIsNotEmpty);
	failVec.push_back(Fail_Constructor_RootIsNotNull);
	failVec.push_back(Fail_Constructor_EncodingTableIsNotEmpty);

	PassVector passVec;
	passVec.push_back(Pass_Constructor_CorrectFileName);
	passVec.push_back(Pass_Constructor_FrequencyTableIsZeroedOut);
	passVec.push_back(Pass_Constructor_LeafListIsEmpty);
	passVec.push_back(Pass_Constructor_RootIsNull);
	passVec.push_back(Pass_Constructor_EncodingTableIsEmpty);

	UnitTestBattery("Testing Huffman constructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_Constructor_IncorrectFileName() {
	std::string file;
	for (int i = 0; i < 8; ++i)
		file += (char)RandomInt('a', 'z');
	file += ".file";

	Huffman huff(file);

	FailResult result;
	result.check = huff.mFileName != file;
	result.msg = "Filename was not copied into data member";

	NegativeOneProtection(huff);

	return result;
}

FailResult UnitTests_Lab8::Fail_Constructor_FrequencyTableIsNotZeroedOut() {
	Huffman huff("freqZero");

	bool zeroedOut = true;
	for(int i = 0; i < 256; ++i)
		if (huff.mFrequencyTable[i] != 0) {
			zeroedOut = false;
			break;
		}
	
	FailResult result;
	result.check = zeroedOut == false;
	result.msg = "One (or more) indices of frequency table have not been set to 0";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_Constructor_LeafListIsNotEmpty() {
	Huffman huff("emptyLeaf");

	FailResult result;
	result.check = !huff.mLeafList.empty();
	result.msg = "Leaf list should be empty";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_Constructor_RootIsNotNull() {
	Huffman huff("rootNull");

	FailResult result;
	result.check = huff.mRoot != nullptr;
	result.msg = "Root should be null";

	NegativeOneProtection(huff);

	return result;
}

FailResult UnitTests_Lab8::Fail_Constructor_EncodingTableIsNotEmpty() {
	Huffman huff("encoding");

	bool emptyEncoding = true;
	for(int i = 0; i < 256; ++i)
		if (!huff.mEncodingTable[i].empty()) {
			emptyEncoding = false;
			break;
		}

	FailResult result;
	result.check = !emptyEncoding;
	result.msg = "All encoding tables should be empty";

	NegativeOneProtection(huff);
	
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_Constructor_CorrectFileName() {
	std::string file;
	for (int i = 0; i < 8; ++i)
		file += (char)RandomInt('a', 'z');
	file += ".file";

	Huffman huff(file);

	bool result = huff.mFileName == file;

	return result;
}

bool UnitTests_Lab8::Pass_Constructor_FrequencyTableIsZeroedOut() {
	Huffman huff("freqZero");

	bool zeroedOut = true;
	for (int i = 0; i < 256; ++i)
		if (huff.mFrequencyTable[i] != 0) {
			zeroedOut = false;
			break;
		}

	bool result = zeroedOut;

	return result;
}

bool UnitTests_Lab8::Pass_Constructor_LeafListIsEmpty() {
	Huffman huff("emptyLeaf");

	bool result = huff.mLeafList.empty();

	return result;
}

bool UnitTests_Lab8::Pass_Constructor_RootIsNull() {
	Huffman huff("rootNull");

	bool result = huff.mRoot == nullptr;

	return result;
}

bool UnitTests_Lab8::Pass_Constructor_EncodingTableIsEmpty() {
	Huffman huff("encoding");

	bool emptyEncoding = true;
	for (int i = 0; i < 256; ++i)
		if (!huff.mEncodingTable[i].empty()) {
			emptyEncoding = false;
			break;
		}

	bool result = emptyEncoding;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Generate Frequency Table
#if HUFFMAN_GENERATE_FREQUENCY
void UnitTests_Lab8::Battery_GenerateFrequencyTable() {
	GenerateRandomFile();

	FailVector failVec;
	failVec.push_back(Fail_GenerateFrequencyTable_ValuesAreIncorrect);
	failVec.push_back(Fail_GenerateFrequencyTable_OneValueIsOffByOne);

	PassVector passVec;
	passVec.push_back(Pass_GenerateFrequencyTable_ValuesAreCorrect);

	UnitTestBattery("Testing GenerateFrequencyTable", failVec, passVec);

	std::remove(randomFile.name.c_str());
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_GenerateFrequencyTable_ValuesAreIncorrect() {
	Huffman huff(randomFile.name);
	huff.GenerateFrequencyTable();

	FailResult result;
	result.check = memcmp(randomFile.freq, huff.mFrequencyTable, 1024) != 0;
	result.msg = "One or more values in frequency table are incorrect";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateFrequencyTable_OneValueIsOffByOne() {
	Huffman huff(randomFile.name);
	huff.GenerateFrequencyTable();

	bool offByOne = false;
	for (int i = 0; i < 256; ++i) {
		if (huff.mFrequencyTable[i] == randomFile.freq[i] + 1) {
			offByOne = true;
			break;
		}
	}

	FailResult result;
	result.check = offByOne;
	result.msg = "Loops one too many times. Move eof check directly after read";

	NegativeOneProtection(huff);

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_GenerateFrequencyTable_ValuesAreCorrect() {
	Huffman huff(randomFile.name);
	huff.GenerateFrequencyTable();

	bool result = memcmp(randomFile.freq, huff.mFrequencyTable, 1024) == 0;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Generate Leaf List
#if HUFFMAN_GENERATE_LEAFLIST
void UnitTests_Lab8::Battery_GenerateLeafList() {
	FailVector failVec;
	failVec.push_back(Fail_GenerateLeafList_DoesNotDynamicallyAllocateNodes);
	failVec.push_back(Fail_GenerateLeafList_VectorIsIncorrectSize);
	failVec.push_back(Fail_GenerateLeafList_ValuesAreIncorrect);
	failVec.push_back(Fail_GenerateLeafList_FrequenciesOfNodesAreIncorrect);

	PassVector passVec;
	passVec.push_back(Pass_GenerateLeafList_VectorIsCorrectSize);
	passVec.push_back(Pass_GenerateLeafList_ValuesAreCorrect);
	passVec.push_back(Pass_GenerateLeafList_FrequenciesOfNodesAreCorrect);

	UnitTestBattery("Testing GenerateLeafList", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_GenerateLeafList_DoesNotDynamicallyAllocateNodes() {
	bool dynamicallyAllocate = SearchFile("Huffman.h", "void GenerateLeafList", "void GenerateTree(", "new HuffNode");

	FailResult result;
	result.check = dynamicallyAllocate == false;
	result.msg = "Nodes should be dynamically allocated before put in leaf list";

	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateLeafList_VectorIsIncorrectSize() {
	Huffman huff("leafList");

	int size = 0;
	for (int i = 0; i < 256; ++i)
		if (RandomInt(0, 1)) {
			huff.mFrequencyTable[i] = 1;
			size++;
		}

	huff.GenerateLeafList();

	FailResult result;
	result.check = huff.mLeafList.size() != size;
	result.msg = "Leaf list is incorrect size";

	// Clean up
	for(auto iter = huff.mLeafList.begin(); iter != huff.mLeafList.end(); ++iter)
		delete *iter;

	NegativeOneProtection(huff);

	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateLeafList_ValuesAreIncorrect() {
	Huffman huff("leafList");

	unsigned int frequencies[256];
	memset(frequencies, 0, sizeof(unsigned int) * 256);
	int randomFrequency = 0;
	for (int i = 0; i < 256; ++i)
		if (RandomInt(0, 1)) {
			randomFrequency = RandomInt(100, 10000);
			huff.mFrequencyTable[i] = frequencies[i] = randomFrequency;
		}

	huff.GenerateLeafList();

	bool correctValues = true;
	for (int i = 0; i < 256; ++i) {
		if (frequencies[i] &&
			std::find_if(huff.mLeafList.begin(), huff.mLeafList.end(), [i](huffNode* _node) {
			return _node->value != i;
		}) == huff.mLeafList.end()) {
				correctValues = false;
				break;
		}
	}

	FailResult result;
	result.check = correctValues != true;
	result.msg = "One or more node's values are incorrect";

	NegativeOneProtection(huff);
	
	// Clean up
	for (size_t i = 0; i < huff.mLeafList.size(); ++i)
		delete huff.mLeafList[i];

	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateLeafList_FrequenciesOfNodesAreIncorrect() {
	Huffman huff("leafList");

	unsigned int frequencies[256];
	memset(frequencies, 0, sizeof(unsigned int) * 256);
	int randomFrequency = 0;
	for (int i = 0; i < 256; ++i)
		if (RandomInt(0, 1)) {
			randomFrequency = RandomInt(100, 10000);
			huff.mFrequencyTable[i] = frequencies[i] = randomFrequency;
		}

	huff.GenerateLeafList();

	bool correctFrequencies = true;
	unsigned int currFrequency;
	for (int i = 0; i < 256; ++i) {
		currFrequency = frequencies[i];
		if (frequencies[i] &&
			std::find_if(huff.mLeafList.begin(), huff.mLeafList.end(), [currFrequency](huffNode* _node) {
			return _node->freq != currFrequency;
		}) == huff.mLeafList.end()) {
			correctFrequencies = false;
			break;
		}
	}

	FailResult result;
	result.check = correctFrequencies == false;
	result.msg = "One or more node's frequencies is incorrect";

	NegativeOneProtection(huff);
	
	// Clean up
	for (size_t i = 0; i < huff.mLeafList.size(); ++i)
		delete huff.mLeafList[i];

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_GenerateLeafList_VectorIsCorrectSize() {
	Huffman huff("leafList");

	int size = 0;
	for (int i = 0; i < 256; ++i)
		if (RandomInt(0, 1)) {
			huff.mFrequencyTable[i] = 1;
			size++;
		}

	huff.GenerateLeafList();

	bool result = huff.mLeafList.size() == size;

	// Clean up
	for (auto iter = huff.mLeafList.begin(); iter != huff.mLeafList.end(); ++iter)
		delete* iter;

	return result;
}

bool UnitTests_Lab8::Pass_GenerateLeafList_ValuesAreCorrect() {
	Huffman huff("leafList");

	unsigned int frequencies[256];
	memset(frequencies, 0, sizeof(unsigned int) * 256);
	int randomFrequency = 0;
	for (int i = 0; i < 256; ++i)
		if (RandomInt(0, 1)) {
			randomFrequency = RandomInt(100, 10000);
			huff.mFrequencyTable[i] = frequencies[i] = randomFrequency;
		}

	huff.GenerateLeafList();

	bool correctValues = true;
	for (int i = 0; i < 256; ++i) {
		if (frequencies[i] &&
			std::find_if(huff.mLeafList.begin(), huff.mLeafList.end(), [i](huffNode* _node) {
			return _node->value != i;
		}) == huff.mLeafList.end()) {
			correctValues = false;
			break;
		}
	}

	bool result = correctValues;

	// Clean up
	for (size_t i = 0; i < huff.mLeafList.size(); ++i)
		delete huff.mLeafList[i];

	return result;
}

bool UnitTests_Lab8::Pass_GenerateLeafList_FrequenciesOfNodesAreCorrect() {
	Huffman huff("leafList");

	unsigned int frequencies[256];
	memset(frequencies, 0, sizeof(unsigned int) * 256);
	int randomFrequency = 0;
	for (int i = 0; i < 256; ++i)
		if (RandomInt(0, 1)) {
			randomFrequency = RandomInt(100, 10000);
			huff.mFrequencyTable[i] = frequencies[i] = randomFrequency;
		}

	huff.GenerateLeafList();

	bool correctFrequencies = true;
	unsigned int currFrequency;
	for (int i = 0; i < 256; ++i) {
		currFrequency = frequencies[i];
		if (frequencies[i] &&
			std::find_if(huff.mLeafList.begin(), huff.mLeafList.end(), [currFrequency](huffNode* _node) {
			return _node->freq != currFrequency;
		}) == huff.mLeafList.end()) {
			correctFrequencies = false;
			break;
		}
	}

	bool result = correctFrequencies;

	// Clean up
	for (size_t i = 0; i < huff.mLeafList.size(); ++i)
		delete huff.mLeafList[i];

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Generate Tree
#if HUFFMAN_GENERATE_TREE
using leaf = std::pair<short, unsigned int>;
leaf leafNodes[9] = {
	std::make_pair(' ', 3),
	std::make_pair('.', 1),
	std::make_pair('T', 1),
	std::make_pair('a', 1),
	std::make_pair('e', 1),
	std::make_pair('h', 1),
	std::make_pair('i', 2),
	std::make_pair('s', 3),
	std::make_pair('t', 2),
};

void UnitTests_Lab8::Battery_GenerateTree() {
	FailVector failVec;
	failVec.push_back(Fail_GenerateTree_PriorityQueueHasCorrectArguments);
	failVec.push_back(Fail_GenerateTree_RootIsNotPointingToValidNode);
	failVec.push_back(Fail_GenerateTree_RootParentIsNotNull); 
	failVec.push_back(Fail_GenerateTree_RootFrequencyIsNotTotal);
	failVec.push_back(Fail_GenerateTree_NodesDoNotHaveValidParents);
	failVec.push_back(Fail_GenerateTree_TreeIsNotCorrect);

	PassVector passVec;
	passVec.push_back(Pass_GenerateTree_RootIsPointingToValidNode);
	passVec.push_back(Pass_GenerateTree_RootFrequencyIsTotal);
	passVec.push_back(Pass_GenerateTree_NodesHaveValidParents);
	passVec.push_back(Pass_GenerateTree_TreeIsCorrect);

	UnitTestBattery("Testing GenerateTree", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_GenerateTree_PriorityQueueHasCorrectArguments() {
	bool correctPriorityQueue = SearchFile("Huffman.h", "void GenerateTree(", "void GenerateEncodingTable(", "vector<HuffNode*>, HuffCompare");

	FailResult result;
	result.check = correctPriorityQueue == false;
	result.msg = "correct second and third arguments were not passed to priority_queue";

	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateTree_RootIsNotPointingToValidNode() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));
	
	huff.GenerateTree();

	FailResult result;
	result.check = huff.mRoot == nullptr || huff.mRoot == reinterpret_cast<huffNode*>(-1);
	result.msg = "Root is not pointing to valid node";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateTree_RootParentIsNotNull() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	huff.GenerateTree();

	FailResult result;
	result.check = huff.mRoot != reinterpret_cast<huffNode*>(-1) && huff.mRoot && huff.mRoot->parent != nullptr;
	result.msg = "Root parent is not null";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateTree_RootFrequencyIsNotTotal() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	huff.GenerateTree();

	FailResult result;
	result.check = huff.mRoot != reinterpret_cast<huffNode*>(-1) && huff.mRoot && huff.mRoot->freq != 15;
	result.msg = "Root does not contain total frequency";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateTree_NodesDoNotHaveValidParents() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	huff.GenerateTree();

	huffVector nodes;
	ParseTree(huff.mRoot, nodes);

	bool validParents = true;
	for (auto iter = nodes.begin(); iter != nodes.end(); ++iter) {
		if (*iter != huff.mRoot && (*iter)->parent == nullptr) {
			validParents = false;
			break;
		}
	}

	FailResult result;
	result.check = validParents == false;
	result.msg = "Nodes do not have valid parent pointers";

	NegativeOneProtection(huff);
	
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateTree_TreeIsNotCorrect() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));
	
	// Creating tree in a convulated way to not give away the answer
	huffNode tree[17] = {
		/* 0 */		huffNode(-1,	15,	&tree[1],	&tree[2],	nullptr),
		/* 1 */		huffNode(-1,	6,	&tree[3],	&tree[4],	&tree[0]),
		/* 2 */		huffNode(-1,	9,	&tree[5],	&tree[6],	&tree[0]),
		/* 3 */		huffNode(-1,	3,	&tree[7],	&tree[8],	&tree[1]),
		/* 4 */		huffNode('s',	3,	nullptr,	nullptr,	&tree[1]),
		/* 5 */		huffNode(-1,	4,	&tree[9],	&tree[10],	&tree[2]),
		/* 6 */		huffNode(-1,	5,	&tree[11],	&tree[12],	&tree[2]),
		/* 7 */		huffNode('e',	1,	nullptr,	nullptr,	&tree[3]),
		/* 8 */		huffNode('i',	2,	nullptr,	nullptr,	&tree[3]),
		/* 9 */		huffNode(-1,	2,	&tree[13],	&tree[14],	&tree[5]),
		/* 10 */	huffNode(-1,	2,	&tree[15],	&tree[16],	&tree[5]),
		/* 11 */	huffNode('t',	2,	nullptr,	nullptr,	&tree[6]),
		/* 12 */	huffNode(' ',	3,	nullptr,	nullptr,	&tree[6]),
		/* 13 */	huffNode('h',	1,	nullptr,	nullptr,	&tree[9]),
		/* 14 */	huffNode('a',	1,	nullptr,	nullptr,	&tree[9]),
		/* 15 */	huffNode('.',	1,	nullptr,	nullptr,	&tree[10]),
		/* 16 */	huffNode('T',	1,	nullptr,	nullptr,	&tree[10]),
	};
	
	huff.GenerateTree();

	bool identicalTree = HuffmanCompareTree(huff.mRoot, &tree[0]);
	
	FailResult result;
	result.check = identicalTree == false;
	result.msg = "Trees are not identical. Double-check algorithm";

	NegativeOneProtection(huff);
	
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_GenerateTree_RootIsPointingToValidNode() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	huff.GenerateTree();

	bool result = huff.mRoot != nullptr && huff.mRoot != reinterpret_cast<huffNode*>(-1);

	return result;
}

bool UnitTests_Lab8::Pass_GenerateTree_RootFrequencyIsTotal() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	huff.GenerateTree();

	bool result = huff.mRoot && huff.mRoot->freq == 15;

	return result;
}

bool UnitTests_Lab8::Pass_GenerateTree_NodesHaveValidParents() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	huff.GenerateTree();

	huffVector nodes;
	ParseTree(huff.mRoot, nodes);

	bool validParents = true;
	for (auto iter = nodes.begin(); iter != nodes.end(); ++iter) {
		if (*iter != huff.mRoot && (*iter)->parent == nullptr) {
			validParents = false;
			break;
		}
	}

	bool result = validParents;

	return result;
}

bool UnitTests_Lab8::Pass_GenerateTree_TreeIsCorrect() {
	Huffman huff("tree");

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(new huffNode(leafNodes[i].first, leafNodes[i].second));

	// Creating tree in a convulated way to not give away the answer
	huffNode tree[17] = {
		/* 0 */		huffNode(-1,	15,	&tree[1],	&tree[2],	nullptr),
		/* 1 */		huffNode(-1,	6,	&tree[3],	&tree[4],	&tree[0]),
		/* 2 */		huffNode(-1,	9,	&tree[5],	&tree[6],	&tree[0]),
		/* 3 */		huffNode(-1,	3,	&tree[7],	&tree[8],	&tree[1]),
		/* 4 */		huffNode('s',	3,	nullptr,	nullptr,	&tree[1]),
		/* 5 */		huffNode(-1,	4,	&tree[9],	&tree[10],	&tree[2]),
		/* 6 */		huffNode(-1,	5,	&tree[11],	&tree[12],	&tree[2]),
		/* 7 */		huffNode('e',	1,	nullptr,	nullptr,	&tree[3]),
		/* 8 */		huffNode('i',	2,	nullptr,	nullptr,	&tree[3]),
		/* 9 */		huffNode(-1,	2,	&tree[13],	&tree[14],	&tree[5]),
		/* 10 */	huffNode(-1,	2,	&tree[15],	&tree[16],	&tree[5]),
		/* 11 */	huffNode('t',	2,	nullptr,	nullptr,	&tree[6]),
		/* 12 */	huffNode(' ',	3,	nullptr,	nullptr,	&tree[6]),
		/* 13 */	huffNode('h',	1,	nullptr,	nullptr,	&tree[9]),
		/* 14 */	huffNode('a',	1,	nullptr,	nullptr,	&tree[9]),
		/* 15 */	huffNode('.',	1,	nullptr,	nullptr,	&tree[10]),
		/* 16 */	huffNode('T',	1,	nullptr,	nullptr,	&tree[10]),
	};

	huff.GenerateTree();

	bool identicalTree = HuffmanCompareTree(huff.mRoot, &tree[0]);

	bool result = identicalTree;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Clear Tree
#if HUFFMAN_CLEAR_TREE
void UnitTests_Lab8::Battery_ClearTree() {
	FailVector failVec;
	failVec.push_back(Fail_ClearTree_MemoryIsNotDeleted);
	failVec.push_back(Fail_ClearTree_RootIsNotNull);

	PassVector passVec;
	passVec.push_back(Pass_ClearTree_MemoryIsDeleted);
	passVec.push_back(Pass_ClearTree_RootIsNull);

	UnitTestBattery("Testing ClearTree", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_ClearTree_MemoryIsNotDeleted() {
	Huffman huff("clear");

	size_t memoryDeltaStart = inUse;

	huffNode* tree[17];
	for (int i = 0; i < 17; ++i)
		tree[i] = new huffNode(-1, -1);

	/* 0 */		*tree[0] =  huffNode(-1, 15, tree[1], tree[2], nullptr);
	/* 1 */		*tree[1] =  huffNode(-1, 6, tree[3], tree[4], tree[0]);
	/* 2 */		*tree[2] =  huffNode(-1, 9, tree[5], tree[6], tree[0]);
	/* 3 */		*tree[3] =  huffNode(-1, 3, tree[7], tree[8], tree[1]);
	/* 4 */		*tree[4] =  huffNode('s', 3, nullptr, nullptr, tree[1]);
	/* 5 */		*tree[5] =  huffNode(-1, 4, tree[9], tree[10], tree[2]);
	/* 6 */		*tree[6] =  huffNode(-1, 5, tree[11], tree[12], tree[2]);
	/* 7 */		*tree[7] =  huffNode('e', 1, nullptr, nullptr, tree[3]);
	/* 8 */		*tree[8] =  huffNode('i', 2, nullptr, nullptr, tree[3]);
	/* 9 */		*tree[9] =  huffNode(-1, 2, tree[13], tree[14], tree[5]);
	/* 10 */	*tree[10] = huffNode(-1, 2, tree[15], tree[16], tree[5]);
	/* 11 */	*tree[11] = huffNode('t', 2, nullptr, nullptr, tree[6]);
	/* 12 */	*tree[12] = huffNode(' ', 3, nullptr, nullptr, tree[6]);
	/* 13 */	*tree[13] = huffNode('h', 1, nullptr, nullptr, tree[9]);
	/* 14 */	*tree[14] = huffNode('a', 1, nullptr, nullptr, tree[9]);
	/* 15 */	*tree[15] = huffNode('.', 1, nullptr, nullptr, tree[10]);
	/* 16 */	*tree[16] = huffNode('T', 1, nullptr, nullptr, tree[10]);
	huff.mRoot = tree[0];

	huff.ClearTree();

	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > 0;
	result.msg = "Not all nodes from tree were deleted";

	NegativeOneProtection(huff);

	return result;
}

FailResult UnitTests_Lab8::Fail_ClearTree_RootIsNotNull() {
	Huffman huff("clear");

	huff.mRoot = new huffNode(-1, -1);
	huff.ClearTree();
	
	FailResult result;
	result.check = huff.mRoot != nullptr;
	result.msg = "Root was not set to null after delete";

	NegativeOneProtection(huff);
	
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_ClearTree_MemoryIsDeleted() {
	Huffman huff("clear");

	size_t memoryDeltaStart = inUse;

	huffNode* tree[17];
	for (int i = 0; i < 17; ++i)
		tree[i] = new huffNode(-1, -1);

	/* 0 */		*tree[0] = huffNode(-1, 15, tree[1], tree[2], nullptr);
	/* 1 */		*tree[1] = huffNode(-1, 6, tree[3], tree[4], tree[0]);
	/* 2 */		*tree[2] = huffNode(-1, 9, tree[5], tree[6], tree[0]);
	/* 3 */		*tree[3] = huffNode(-1, 3, tree[7], tree[8], tree[1]);
	/* 4 */		*tree[4] = huffNode('s', 3, nullptr, nullptr, tree[1]);
	/* 5 */		*tree[5] = huffNode(-1, 4, tree[9], tree[10], tree[2]);
	/* 6 */		*tree[6] = huffNode(-1, 5, tree[11], tree[12], tree[2]);
	/* 7 */		*tree[7] = huffNode('e', 1, nullptr, nullptr, tree[3]);
	/* 8 */		*tree[8] = huffNode('i', 2, nullptr, nullptr, tree[3]);
	/* 9 */		*tree[9] = huffNode(-1, 2, tree[13], tree[14], tree[5]);
	/* 10 */	*tree[10] = huffNode(-1, 2, tree[15], tree[16], tree[5]);
	/* 11 */	*tree[11] = huffNode('t', 2, nullptr, nullptr, tree[6]);
	/* 12 */	*tree[12] = huffNode(' ', 3, nullptr, nullptr, tree[6]);
	/* 13 */	*tree[13] = huffNode('h', 1, nullptr, nullptr, tree[9]);
	/* 14 */	*tree[14] = huffNode('a', 1, nullptr, nullptr, tree[9]);
	/* 15 */	*tree[15] = huffNode('.', 1, nullptr, nullptr, tree[10]);
	/* 16 */	*tree[16] = huffNode('T', 1, nullptr, nullptr, tree[10]);
	huff.mRoot = tree[0];

	huff.ClearTree();

	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == 0;
	
	return result;
}

bool UnitTests_Lab8::Pass_ClearTree_RootIsNull() {
	Huffman huff("clear");

	huff.mRoot = new huffNode(-1, -1);
	huff.ClearTree();

	bool result = huff.mRoot == nullptr;

	
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Destructor
#if HUFFMAN_DTOR
void UnitTests_Lab8::Battery_Destructor() {
	FailVector failVec;
	failVec.push_back(Fail_Destructor_MemoryIsNotDeleted);

	PassVector passVec;
	passVec.push_back(Pass_Destructor_MemoryIsDeleted);

	UnitTestBattery("Testing destructor", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_Destructor_MemoryIsNotDeleted() {
	size_t memoryDeltaStart = inUse;
	
	Huffman* huff = new Huffman("destructor");
	huffNode* tree[17];
	for (int i = 0; i < 17; ++i)
		tree[i] = new huffNode(-1, -1);

	/* 0 */		*tree[0] = huffNode(-1, 15, tree[1], tree[2], nullptr);
	/* 1 */		*tree[1] = huffNode(-1, 6, tree[3], tree[4], tree[0]);
	/* 2 */		*tree[2] = huffNode(-1, 9, tree[5], tree[6], tree[0]);
	/* 3 */		*tree[3] = huffNode(-1, 3, tree[7], tree[8], tree[1]);
	/* 4 */		*tree[4] = huffNode('s', 3, nullptr, nullptr, tree[1]);
	/* 5 */		*tree[5] = huffNode(-1, 4, tree[9], tree[10], tree[2]);
	/* 6 */		*tree[6] = huffNode(-1, 5, tree[11], tree[12], tree[2]);
	/* 7 */		*tree[7] = huffNode('e', 1, nullptr, nullptr, tree[3]);
	/* 8 */		*tree[8] = huffNode('i', 2, nullptr, nullptr, tree[3]);
	/* 9 */		*tree[9] = huffNode(-1, 2, tree[13], tree[14], tree[5]);
	/* 10 */	*tree[10] = huffNode(-1, 2, tree[15], tree[16], tree[5]);
	/* 11 */	*tree[11] = huffNode('t', 2, nullptr, nullptr, tree[6]);
	/* 12 */	*tree[12] = huffNode(' ', 3, nullptr, nullptr, tree[6]);
	/* 13 */	*tree[13] = huffNode('h', 1, nullptr, nullptr, tree[9]);
	/* 14 */	*tree[14] = huffNode('a', 1, nullptr, nullptr, tree[9]);
	/* 15 */	*tree[15] = huffNode('.', 1, nullptr, nullptr, tree[10]);
	/* 16 */	*tree[16] = huffNode('T', 1, nullptr, nullptr, tree[10]);
	huff->mRoot = tree[0];

	delete huff;

	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	FailResult result;
	result.check = memoryAllocated > 0;
	result.msg = "Not all dynamic memory was freed";

	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_Destructor_MemoryIsDeleted() {
	size_t memoryDeltaStart = inUse;

	Huffman* huff = new Huffman("destructor");
	huffNode* tree[17];
	for (int i = 0; i < 17; ++i)
		tree[i] = new huffNode(-1, -1);

	/* 0 */		*tree[0] = huffNode(-1, 15, tree[1], tree[2], nullptr);
	/* 1 */		*tree[1] = huffNode(-1, 6, tree[3], tree[4], tree[0]);
	/* 2 */		*tree[2] = huffNode(-1, 9, tree[5], tree[6], tree[0]);
	/* 3 */		*tree[3] = huffNode(-1, 3, tree[7], tree[8], tree[1]);
	/* 4 */		*tree[4] = huffNode('s', 3, nullptr, nullptr, tree[1]);
	/* 5 */		*tree[5] = huffNode(-1, 4, tree[9], tree[10], tree[2]);
	/* 6 */		*tree[6] = huffNode(-1, 5, tree[11], tree[12], tree[2]);
	/* 7 */		*tree[7] = huffNode('e', 1, nullptr, nullptr, tree[3]);
	/* 8 */		*tree[8] = huffNode('i', 2, nullptr, nullptr, tree[3]);
	/* 9 */		*tree[9] = huffNode(-1, 2, tree[13], tree[14], tree[5]);
	/* 10 */	*tree[10] = huffNode(-1, 2, tree[15], tree[16], tree[5]);
	/* 11 */	*tree[11] = huffNode('t', 2, nullptr, nullptr, tree[6]);
	/* 12 */	*tree[12] = huffNode(' ', 3, nullptr, nullptr, tree[6]);
	/* 13 */	*tree[13] = huffNode('h', 1, nullptr, nullptr, tree[9]);
	/* 14 */	*tree[14] = huffNode('a', 1, nullptr, nullptr, tree[9]);
	/* 15 */	*tree[15] = huffNode('.', 1, nullptr, nullptr, tree[10]);
	/* 16 */	*tree[16] = huffNode('T', 1, nullptr, nullptr, tree[10]);
	huff->mRoot = tree[0];

	delete huff;

	size_t memoryDeltaEnd = inUse;
	size_t memoryAllocated = memoryDeltaEnd - memoryDeltaStart;

	bool result = memoryAllocated == 0;

	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Generate Encoding Table
#if HUFFMAN_GENERATE_ENCODING
void UnitTests_Lab8::Battery_GenerateEncodingTable() {
	FailVector failVec;
	failVec.push_back(Fail_GenerateEncodingTable_UsesArrowOperatorOnEncodingTable);
	failVec.push_back(Fail_GenerateEncodingTable_DataAddedToIncorrectIndices);
	failVec.push_back(Fail_GenerateEncodingTable_DataIsNotReversed);

	PassVector passVec;
	passVec.push_back(Pass_GenerateEncodingTable_CorrectDataInTable);

	UnitTestBattery("Testing GenerateEncodingTable", failVec, passVec);
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_GenerateEncodingTable_UsesArrowOperatorOnEncodingTable() {
	bool usesArrowOperator = SearchFile("Huffman.h", "void GenerateEncodingTable()", "void Compress()", "mEncodingTable->");

	FailResult result;
	result.check = usesArrowOperator;
	result.msg = "Using 'mEncodingTable->' is the same as using 'mEncodingTable[0].'";
	
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateEncodingTable_DataAddedToIncorrectIndices() {
	Huffman huff("encoding");

	// Generating data for string/file containing "This is a test."
		// Creating tree in a convuluted way to not give away the answer
	huffNode tree[17] = {
		/* 0 */		huffNode(-1,	15,	&tree[1],	&tree[2],	nullptr),
		/* 1 */		huffNode(-1,	6,	&tree[3],	&tree[4],	&tree[0]),
		/* 2 */		huffNode(-1,	9,	&tree[5],	&tree[6],	&tree[0]),
		/* 3 */		huffNode(-1,	3,	&tree[7],	&tree[8],	&tree[1]),
		/* 4 */		huffNode('s',	3,	nullptr,	nullptr,	&tree[1]),
		/* 5 */		huffNode(-1,	4,	&tree[9],	&tree[10],	&tree[2]),
		/* 6 */		huffNode(-1,	5,	&tree[11],	&tree[12],	&tree[2]),
		/* 7 */		huffNode('e',	1,	nullptr,	nullptr,	&tree[3]),
		/* 8 */		huffNode('i',	2,	nullptr,	nullptr,	&tree[3]),
		/* 9 */		huffNode(-1,	2,	&tree[13],	&tree[14],	&tree[5]),
		/* 10 */	huffNode(-1,	2,	&tree[15],	&tree[16],	&tree[5]),
		/* 11 */	huffNode('t',	2,	nullptr,	nullptr,	&tree[6]),
		/* 12 */	huffNode(' ',	3,	nullptr,	nullptr,	&tree[6]),
		/* 13 */	huffNode('h',	1,	nullptr,	nullptr,	&tree[9]),
		/* 14 */	huffNode('a',	1,	nullptr,	nullptr,	&tree[9]),
		/* 15 */	huffNode('.',	1,	nullptr,	nullptr,	&tree[10]),
		/* 16 */	huffNode('T',	1,	nullptr,	nullptr,	&tree[10]),
	};
	huff.mRoot = &tree[0];
	
	huffNode* leafNodes[9] = {
	&tree[12],	// ' '
	&tree[15],	// '.'
	&tree[16],	// 'T'
	&tree[14],	// 'a'
	&tree[7],	// 'e'
	&tree[13],	// 'h'
	&tree[8],	// 'i'
	&tree[4],	// 's'
	&tree[11],	// 't'
	};

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(leafNodes[i]);

	huff.GenerateEncodingTable();

	// Test data
	vector<bool> encodingData[9];
	int indices[9] = { ' ', '.', 'T', 'a', 'e', 'h', 'i', 's', 't' };
	encodingData[0].push_back(1); encodingData[0].push_back(1); encodingData[0].push_back(1);
	encodingData[1].push_back(1); encodingData[1].push_back(0); encodingData[1].push_back(1); encodingData[1].push_back(0);
	encodingData[2].push_back(1); encodingData[2].push_back(0); encodingData[2].push_back(1); encodingData[2].push_back(1);
	encodingData[3].push_back(1); encodingData[3].push_back(0); encodingData[3].push_back(0); encodingData[3].push_back(1);
	encodingData[4].push_back(0); encodingData[4].push_back(0); encodingData[4].push_back(0);
	encodingData[5].push_back(1); encodingData[5].push_back(0); encodingData[5].push_back(0); encodingData[5].push_back(0);
	encodingData[6].push_back(0); encodingData[6].push_back(0); encodingData[6].push_back(1);
	encodingData[7].push_back(0); encodingData[7].push_back(1);
	encodingData[8].push_back(1); encodingData[8].push_back(1); encodingData[8].push_back(0);

	FailResult result;
	result.check = huff.mEncodingTable[0].size() != 0;
	result.msg = "Bit codes added to incorrect indices (should be ascii values)";

	huff.mRoot = nullptr;
	return result;
}

FailResult UnitTests_Lab8::Fail_GenerateEncodingTable_DataIsNotReversed() {
	Huffman huff("encoding");

	// Generating data for string/file containing "This is a test."
		// Creating tree in a convuluted way to not give away the answer
	huffNode tree[17] = {
		/* 0 */		huffNode(-1,	15,	&tree[1],	&tree[2],	nullptr),
		/* 1 */		huffNode(-1,	6,	&tree[3],	&tree[4],	&tree[0]),
		/* 2 */		huffNode(-1,	9,	&tree[5],	&tree[6],	&tree[0]),
		/* 3 */		huffNode(-1,	3,	&tree[7],	&tree[8],	&tree[1]),
		/* 4 */		huffNode('s',	3,	nullptr,	nullptr,	&tree[1]),
		/* 5 */		huffNode(-1,	4,	&tree[9],	&tree[10],	&tree[2]),
		/* 6 */		huffNode(-1,	5,	&tree[11],	&tree[12],	&tree[2]),
		/* 7 */		huffNode('e',	1,	nullptr,	nullptr,	&tree[3]),
		/* 8 */		huffNode('i',	2,	nullptr,	nullptr,	&tree[3]),
		/* 9 */		huffNode(-1,	2,	&tree[13],	&tree[14],	&tree[5]),
		/* 10 */	huffNode(-1,	2,	&tree[15],	&tree[16],	&tree[5]),
		/* 11 */	huffNode('t',	2,	nullptr,	nullptr,	&tree[6]),
		/* 12 */	huffNode(' ',	3,	nullptr,	nullptr,	&tree[6]),
		/* 13 */	huffNode('h',	1,	nullptr,	nullptr,	&tree[9]),
		/* 14 */	huffNode('a',	1,	nullptr,	nullptr,	&tree[9]),
		/* 15 */	huffNode('.',	1,	nullptr,	nullptr,	&tree[10]),
		/* 16 */	huffNode('T',	1,	nullptr,	nullptr,	&tree[10]),
	};
	huff.mRoot = &tree[0];

	huffNode* leafNodes[9] = {
	&tree[12],	// ' '
	&tree[15],	// '.'
	&tree[16],	// 'T'
	&tree[14],	// 'a'
	&tree[7],	// 'e'
	&tree[13],	// 'h'
	&tree[8],	// 'i'
	&tree[4],	// 's'
	&tree[11],	// 't'
	};

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(leafNodes[i]);

	huff.GenerateEncodingTable();

	// Test data
	vector<bool> encodingData[9];
	int indices[9] = { ' ', '.', 'T', 'a', 'e', 'h', 'i', 's', 't' };
	encodingData[0].push_back(1); encodingData[0].push_back(1); encodingData[0].push_back(1);
	encodingData[1].push_back(1); encodingData[1].push_back(0); encodingData[1].push_back(1); encodingData[1].push_back(0);
	encodingData[2].push_back(1); encodingData[2].push_back(0); encodingData[2].push_back(1); encodingData[2].push_back(1);
	encodingData[3].push_back(1); encodingData[3].push_back(0); encodingData[3].push_back(0); encodingData[3].push_back(1);
	encodingData[4].push_back(0); encodingData[4].push_back(0); encodingData[4].push_back(0);
	encodingData[5].push_back(1); encodingData[5].push_back(0); encodingData[5].push_back(0); encodingData[5].push_back(0);
	encodingData[6].push_back(0); encodingData[6].push_back(0); encodingData[6].push_back(1);
	encodingData[7].push_back(0); encodingData[7].push_back(1);
	encodingData[8].push_back(1); encodingData[8].push_back(1); encodingData[8].push_back(0);

	FailResult result;
	result.check = huff.mEncodingTable[' '].empty() ||
		huff.mEncodingTable[' '] != encodingData[0];
	result.msg = "Encoding data is incorrect. Did you reverse the codes?";

	huff.mRoot = nullptr;
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_GenerateEncodingTable_CorrectDataInTable() {
	Huffman huff("encoding");

	// Generating data for string/file containing "This is a test."
		// Creating tree in a convuluted way to not give away the answer
	huffNode tree[17] = {
		/* 0 */		huffNode(-1,	15,	&tree[1],	&tree[2],	nullptr),
		/* 1 */		huffNode(-1,	6,	&tree[3],	&tree[4],	&tree[0]),
		/* 2 */		huffNode(-1,	9,	&tree[5],	&tree[6],	&tree[0]),
		/* 3 */		huffNode(-1,	3,	&tree[7],	&tree[8],	&tree[1]),
		/* 4 */		huffNode('s',	3,	nullptr,	nullptr,	&tree[1]),
		/* 5 */		huffNode(-1,	4,	&tree[9],	&tree[10],	&tree[2]),
		/* 6 */		huffNode(-1,	5,	&tree[11],	&tree[12],	&tree[2]),
		/* 7 */		huffNode('e',	1,	nullptr,	nullptr,	&tree[3]),
		/* 8 */		huffNode('i',	2,	nullptr,	nullptr,	&tree[3]),
		/* 9 */		huffNode(-1,	2,	&tree[13],	&tree[14],	&tree[5]),
		/* 10 */	huffNode(-1,	2,	&tree[15],	&tree[16],	&tree[5]),
		/* 11 */	huffNode('t',	2,	nullptr,	nullptr,	&tree[6]),
		/* 12 */	huffNode(' ',	3,	nullptr,	nullptr,	&tree[6]),
		/* 13 */	huffNode('h',	1,	nullptr,	nullptr,	&tree[9]),
		/* 14 */	huffNode('a',	1,	nullptr,	nullptr,	&tree[9]),
		/* 15 */	huffNode('.',	1,	nullptr,	nullptr,	&tree[10]),
		/* 16 */	huffNode('T',	1,	nullptr,	nullptr,	&tree[10]),
	};
	huff.mRoot = &tree[0];

	huffNode* leafNodes[9] = {
	&tree[12],	// ' '
	&tree[15],	// '.'
	&tree[16],	// 'T'
	&tree[14],	// 'a'
	&tree[7],	// 'e'
	&tree[13],	// 'h'
	&tree[8],	// 'i'
	&tree[4],	// 's'
	&tree[11],	// 't'
	};

	// Adding leaves to list
	for (int i = 0; i < 9; ++i)
		huff.mLeafList.push_back(leafNodes[i]);
	
	huff.GenerateEncodingTable();

	// Test data
	vector<bool> encodingData[9];
	int indices[9] = { ' ', '.', 'T', 'a', 'e', 'h', 'i', 's', 't' };
	encodingData[0].push_back(1); encodingData[0].push_back(1); encodingData[0].push_back(1);
	encodingData[1].push_back(1); encodingData[1].push_back(0); encodingData[1].push_back(1); encodingData[1].push_back(0);
	encodingData[2].push_back(1); encodingData[2].push_back(0); encodingData[2].push_back(1); encodingData[2].push_back(1);
	encodingData[3].push_back(1); encodingData[3].push_back(0); encodingData[3].push_back(0); encodingData[3].push_back(1);
	encodingData[4].push_back(0); encodingData[4].push_back(0); encodingData[4].push_back(0);
	encodingData[5].push_back(1); encodingData[5].push_back(0); encodingData[5].push_back(0); encodingData[5].push_back(0);
	encodingData[6].push_back(0); encodingData[6].push_back(0); encodingData[6].push_back(1);
	encodingData[7].push_back(0); encodingData[7].push_back(1);
	encodingData[8].push_back(1); encodingData[8].push_back(1); encodingData[8].push_back(0);

	bool correctEncoding = true;
	for(int i  = 0; i < 9; ++i)
		if (huff.mEncodingTable[indices[i]] != encodingData[i]) {
			correctEncoding = false;
			break;
		}

	bool result = correctEncoding;

	huff.mRoot = nullptr;
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Compress
#if HUFFMAN_COMPRESS
void UnitTests_Lab8::Battery_Compress() {
	std::cout << "\tNext test will take a few seconds\n";

	GenerateRandomFile();

	std::string compressedFilename = randomFile.name;
	size_t extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "check";
	HuffmanCompress(randomFile.name.c_str(), compressedFilename.c_str());

	FailVector failVec;
	failVec.push_back(Fail_Compress_DoesNotPassHeader);
	failVec.push_back(Fail_Compress_UsesSizeofForHeader);
	failVec.push_back(Fail_Compress_OpensIncorrectFileForReading);
	failVec.push_back(Fail_Compress_OpensIncorrectFileForWriting);
	failVec.push_back(Fail_Compress_CompressedFileIsIncorrect);

	PassVector passVec;
	passVec.push_back(Pass_Compress_CompressedFileIsCorrect);

	UnitTestBattery("Testing Compress", failVec, passVec);

	std::remove(randomFile.name.c_str());
	std::remove(compressedFilename.c_str());
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_Compress_DoesNotPassHeader() {
	bool passesFreqTable = SearchFile("Huffman.h", "void Compress(", "void Decompress(", ",(const char*)mFrequencyTable");

	FailResult result;
	result.check = passesFreqTable == false;
	result.msg = "Does not pass frequency table in to BitOfstream constructor";
	
	return result;
}

FailResult UnitTests_Lab8::Fail_Compress_UsesSizeofForHeader() {
	bool usesSizeof = SearchFile("Huffman.h", "void Compress(", "void Decompress(", "sizeof(mFrequencyTable)");

	FailResult result;
	result.check = usesSizeof;
	result.msg = "Uses sizeof(mFrequencyTable). Third argument should be the number of bytes of the frequency table";

	return result;
}

FailResult UnitTests_Lab8::Fail_Compress_OpensIncorrectFileForReading() {
	bool opensInputFileWithIfstream = SearchFile("Huffman.h", "void Compress(", "void Decompress(", "mFileName, std::ios::binary") ||
		SearchFile("Huffman.h", "void Compress(", "void Decompress(", "mFileName.c_str(), std::ios::binary");
	
	FailResult result;
	result.check = opensInputFileWithIfstream == false;
	result.msg = "mFilename not passed to ifstream (or not opened in binary)";

	return result;
}

FailResult UnitTests_Lab8::Fail_Compress_OpensIncorrectFileForWriting() {
	bool opensOutputFileWithBitIfstream = SearchFile("Huffman.h", "void Compress(", "void Decompress(", "_outputFile, (const char*)");

	FailResult result;
	result.check = opensOutputFileWithBitIfstream == false;
	result.msg = "_outputFile not passed to BitOfstream (or frequency table not passed)";

	return result;
}

FailResult UnitTests_Lab8::Fail_Compress_CompressedFileIsIncorrect() {
	string compressedFilename = randomFile.name;
	size_t extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "student";

	string checkFilename = randomFile.name;
	extPos = checkFilename.find_last_of('.');
	checkFilename.erase(extPos + 1, checkFilename.length());
	checkFilename += "check";

	Huffman huff(randomFile.name);
	huff.Compress(compressedFilename.c_str());

	bool identicalFiles = true;
	bool studentFileExists = true;

	// Open the two files to do byte-by-byte comparison
	std::ifstream checkFile(checkFilename.c_str(), std::ios::binary);
	std::ifstream studentFile(compressedFilename.c_str(), std::ios::binary);

	size_t studentSize = 0, checkSize = 0;
	unsigned char* studentBuffer = nullptr, * checkBuffer = nullptr;
	if (!studentFile.is_open())
		studentFileExists = false;
	else {
		// Read both files
		studentFile.seekg(0, std::ios::end);
		checkFile.seekg(0, std::ios::end);
		studentSize = studentFile.tellg();
		checkSize = checkFile.tellg();
		studentFile.seekg(0, std::ios::beg);
		checkFile.seekg(0, std::ios::beg);
		studentBuffer = new unsigned char[studentSize];
		checkBuffer = new unsigned char[checkSize];
		studentFile.read((char*)studentBuffer, studentSize);
		checkFile.read((char*)checkBuffer, checkSize);
		studentFile.close();
		checkFile.close();

		if (studentSize != checkSize) {
			identicalFiles = false;
		}
		else {
			identicalFiles = memcmp(studentBuffer, checkBuffer, studentSize) == 0;
		}
	}

	// Clean up!
	delete[] studentBuffer;
	delete[] checkBuffer;
	
	FailResult result;
	result.check = studentFileExists == false || identicalFiles == false;
	result.msg = "Data is incorrect (or file did not get created).";

	std::remove(compressedFilename.c_str());
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_Compress_CompressedFileIsCorrect() {
	string compressedFilename = randomFile.name;
	size_t extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "student";

	string checkFilename = randomFile.name;
	extPos = checkFilename.find_last_of('.');
	checkFilename.erase(extPos + 1, checkFilename.length());
	checkFilename += "check";

	Huffman huff(randomFile.name);
	huff.Compress(compressedFilename.c_str());

	bool identicalFiles = true;
	bool studentFileExists = true;

	// Open the two files to do byte-by-byte comparison
	std::ifstream checkFile(checkFilename.c_str(), std::ios::binary);
	std::ifstream studentFile(compressedFilename.c_str(), std::ios::binary);

	size_t studentSize = 0, checkSize = 0;
	unsigned char* studentBuffer = nullptr, * checkBuffer = nullptr;
	if (!studentFile.is_open())
		studentFileExists = false;
	else {
		// Read both files
		studentFile.seekg(0, std::ios::end);
		checkFile.seekg(0, std::ios::end);
		studentSize = studentFile.tellg();
		checkSize = checkFile.tellg();
		studentFile.seekg(0, std::ios::beg);
		checkFile.seekg(0, std::ios::beg);
		studentBuffer = new unsigned char[studentSize];
		checkBuffer = new unsigned char[checkSize];
		studentFile.read((char*)studentBuffer, studentSize);
		checkFile.read((char*)checkBuffer, checkSize);
		studentFile.close();
		checkFile.close();

		if (studentSize != checkSize) {
			identicalFiles = false;
		}
		else {
			identicalFiles = memcmp(studentBuffer, checkBuffer, studentSize) == 0;
		}
	}

	// Clean up!
	delete[] studentBuffer;
	delete[] checkBuffer;

	bool result = studentFileExists == true && identicalFiles == true;

	std::remove(compressedFilename.c_str());
	return result;
}
#pragma endregion
#endif
#pragma endregion

#pragma region Test - Decompress
#if HUFFMAN_DECOMPRESS
void UnitTests_Lab8::Battery_Decompress() {
	std::cout << "\tNext test will take a few seconds\n";

	GenerateRandomFile();

	std::string compressedFilename = randomFile.name;
	size_t extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "compressed";
	HuffmanCompress(randomFile.name.c_str(), compressedFilename.c_str());

	FailVector failVec;
	failVec.push_back(Fail_Decompress_DoesNotPassHeader);
	failVec.push_back(Fail_Decompress_UsesSizeofForHeader);
	failVec.push_back(Fail_Decompress_OpensIncorrectFileForWriting);
	failVec.push_back(Fail_Decompress_DecompressedFileIsTooLarge);
	failVec.push_back(Fail_Decompress_DecompressedFileIsIncorrect);

	PassVector passVec;
	passVec.push_back(Pass_Decompress_DecompressedFileIsCorrect);

	UnitTestBattery("Testing Decompress", failVec, passVec);

	std::remove(randomFile.name.c_str());
	std::remove(compressedFilename.c_str());
}

#pragma region Fail Tests
FailResult UnitTests_Lab8::Fail_Decompress_DoesNotPassHeader() {
	bool passesFreqTable = SearchFile("Huffman.h", "void Decompress(", "};", ",(char*)mFrequencyTable");

	FailResult result;
	result.check = passesFreqTable == false;
	result.msg = "Does not pass frequency table in to BitIfstream constructor";

	return result;
}

FailResult UnitTests_Lab8::Fail_Decompress_UsesSizeofForHeader() {
	bool usesSizeof = SearchFile("Huffman.h", "void Decompress(", "};", "sizeof(mFrequencyTable)");

	FailResult result;
	result.check = usesSizeof;
	result.msg = "Uses sizeof(mFrequencyTable). Third argument should be the number of bytes of the frequency table";

	return result;
}

FailResult UnitTests_Lab8::Fail_Decompress_OpensIncorrectFileForWriting() {
	bool opensInputFileWithIfstream = SearchFile("Huffman.h", "void Compress(", "void Decompress(", "mFileName, std::ios::binary") ||
		SearchFile("Huffman.h", "void Decompress(", "};", "_outputFile, std::ios::binary");

	FailResult result;
	result.check = opensInputFileWithIfstream == false;
	result.msg = "_outputFile not passed to ofstream (or not opened in binary)";

	return result;
}

FailResult UnitTests_Lab8::Fail_Decompress_DecompressedFileIsTooLarge() {
	string uncompressedFilename = randomFile.name;
	size_t extPos = uncompressedFilename.find_last_of('.');
	uncompressedFilename.erase(extPos + 1, uncompressedFilename.length());
	uncompressedFilename += "student";
	
	string compressedFilename = randomFile.name;
	extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "compressed";

	Huffman huff(compressedFilename);
	huff.Decompress(uncompressedFilename.c_str());

	bool studentFileExists = true;
	size_t studentSize = 0, checkSize = 0;

	// Open the two files
	std::ifstream checkFile(randomFile.name.c_str(), std::ios::binary);
	std::ifstream studentFile(uncompressedFilename.c_str(), std::ios::binary);

	if (!studentFile.is_open())
		studentFileExists = false;
	else {
		// Read both files
		studentFile.seekg(0, std::ios::end);
		checkFile.seekg(0, std::ios::end);
		studentSize = studentFile.tellg();
		checkSize = checkFile.tellg();
		studentFile.close();
		checkFile.close();
	}

	FailResult result;
	result.check = studentSize > checkSize;
	result.msg = "Your file is too large (possibly tried to uncompress trailing 0's)";

	std::remove(uncompressedFilename.c_str());
	return result;
}

FailResult UnitTests_Lab8::Fail_Decompress_DecompressedFileIsIncorrect() {
	string uncompressedFilename = randomFile.name;
	size_t extPos = uncompressedFilename.find_last_of('.');
	uncompressedFilename.erase(extPos + 1, uncompressedFilename.length());
	uncompressedFilename += "student";

	string compressedFilename = randomFile.name;
	extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "compressed";

	Huffman huff(compressedFilename);
	huff.Decompress(uncompressedFilename.c_str());

	bool identicalFiles = true;
	bool studentFileExists = true;
	size_t studentSize = 0, checkSize = 0;
	unsigned char* studentBuffer = nullptr, * checkBuffer = nullptr;

	// Open the two files
	std::ifstream checkFile(randomFile.name.c_str(), std::ios::binary);
	std::ifstream studentFile(uncompressedFilename.c_str(), std::ios::binary);

	if (!studentFile.is_open())
		studentFileExists = false;
	else {
		// Read both files
		studentFile.seekg(0, std::ios::end);
		checkFile.seekg(0, std::ios::end);
		studentSize = studentFile.tellg();
		checkSize = checkFile.tellg();
		studentFile.seekg(0, std::ios::beg);
		checkFile.seekg(0, std::ios::beg);
		studentBuffer = new unsigned char[studentSize];
		checkBuffer = new unsigned char[checkSize];
		studentFile.read((char*)studentBuffer, studentSize);
		checkFile.read((char*)checkBuffer, checkSize); studentFile.close();
		checkFile.close();

		if (studentSize != checkSize) {
			identicalFiles = false;
		}
		else {
			identicalFiles = memcmp(studentBuffer, checkBuffer, studentSize) == 0;
		}
	}

	// Clean up
	delete[] studentBuffer;
	delete[] checkBuffer;

	FailResult result;
	result.check = studentFileExists == false || identicalFiles == false;
	result.msg = "Data is incorrect (or file did not get created).";

	std::remove(uncompressedFilename.c_str());
	return result;
}
#pragma endregion

#pragma region Pass Tests
bool UnitTests_Lab8::Pass_Decompress_DecompressedFileIsCorrect() {
	string uncompressedFilename = randomFile.name;
	size_t extPos = uncompressedFilename.find_last_of('.');
	uncompressedFilename.erase(extPos + 1, uncompressedFilename.length());
	uncompressedFilename += "student";

	string compressedFilename = randomFile.name;
	extPos = compressedFilename.find_last_of('.');
	compressedFilename.erase(extPos + 1, compressedFilename.length());
	compressedFilename += "compressed";

	Huffman huff(compressedFilename);
	huff.Decompress(uncompressedFilename.c_str());

	bool identicalFiles = true;
	bool studentFileExists = true;
	size_t studentSize = 0, checkSize = 0;
	unsigned char* studentBuffer = nullptr, * checkBuffer = nullptr;

	// Open the two files
	std::ifstream checkFile(randomFile.name.c_str(), std::ios::binary);
	std::ifstream studentFile(uncompressedFilename.c_str(), std::ios::binary);

	if (!studentFile.is_open())
		studentFileExists = false;
	else {
		// Read both files
		studentFile.seekg(0, std::ios::end);
		checkFile.seekg(0, std::ios::end);
		studentSize = studentFile.tellg();
		checkSize = checkFile.tellg();
		studentFile.seekg(0, std::ios::beg);
		checkFile.seekg(0, std::ios::beg);
		studentBuffer = new unsigned char[studentSize];
		checkBuffer = new unsigned char[checkSize];
		studentFile.read((char*)studentBuffer, studentSize);
		checkFile.read((char*)checkBuffer, checkSize); studentFile.close();
		checkFile.close();

		if (studentSize != checkSize) {
			identicalFiles = false;
		}
		else {
			identicalFiles = memcmp(studentBuffer, checkBuffer, studentSize) == 0;
		}
	}

	// Clean up
	delete[] studentBuffer;
	delete[] checkBuffer;

	bool result = studentFileExists && identicalFiles;

	std::remove(uncompressedFilename.c_str());
	return result;
}
#pragma endregion
#endif
#pragma endregion
#endif