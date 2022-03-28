#pragma once
#include <iostream>

int ValidateInt(const char* strMessage, int nMinimumRange = INT_MIN, int nMaximumRange = INT_MAX);
void Header(const char heading[32]);
void Footer();
void ClearInputBuffer();
int RandomNumber(int max = INT_MAX);
void CopyString(const char* source, char*& destination);
float ValidateFloat(const char* strMessage, float nMinimumRange = FLT_MIN, float nMaximumRange = FLT_MAX);
void textPrompt(const char* prompt, char*& text);
