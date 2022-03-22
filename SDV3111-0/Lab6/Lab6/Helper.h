#include <iostream>

namespace Helper
{
	int GetValidatedInt(const char* strMessage, int nMinimumRange = INT_MIN, int nMaximumRange = INT_MAX);
	void Header(const char header[32]);
	void Footer();
	void ClearInputBuffer();
	int RandomNumber(int max = INT_MAX);
	void CopyString(const char* source, char*& destination);
	float GetValidatedFloat(const char* strMessage, float nMinimumRange = std::numeric_limits<float>::min(), float nMaximumRange = std::numeric_limits<float>::max());
}