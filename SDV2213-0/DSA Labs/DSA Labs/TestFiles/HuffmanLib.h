#pragma once

// HuffmanLib.h - Contains declarations of Huffman functions

#ifdef HUFFMANLIB_EXPORTS
#define HUFFMANLIB_API __declspec(dllexport)
#else
#define HUFFMANLIB_API __declspec(dllimport)
#endif

// Compress a file using Huffman compression
extern "C" HUFFMANLIB_API void HuffmanCompress(const char* _uncompressedFilename, const char* _compressedFilename);

// Decompress a file using Huffman compression
extern "C" HUFFMANLIB_API void HuffmanDecompress(const char* _compressedFilename, const char* _uncompressedFilename);
