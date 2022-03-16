#pragma once

namespace Helper
{
	int GetValidatedInt(const char* strMessage, int nMinimumRange = INT_MIN, int nMaximumRange = INT_MAX);	
	void Header(const char header[32]);																		
	void Footer();																							
	void ClearInputBuffer();																				
	int RandomNumber(int max = INT_MAX);
	void MainMenu();
}