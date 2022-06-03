/*
File:			TestHarness.h
Author(s):
	Base:		Justin Tackett
				jtackett@fullsail.com
Created:		10.20.2021
Last Modified:	10.20.2021
Purpose:		
Notes:			Property of Full Sail University

				DO NOT CHANGE ANY CODE IN THIS FILE
*/

#pragma once

class TestHarness {

	static bool verboseMode;	// Keep track of when to run verbose messages

public:

	// Runs all the one-time only code
	void Init() const;

	// Deletes any dangling files from previous runs
	void CleanUpFiles() const;

	static bool GetVerboseMode();

	static void ToggleVerboseMode();

	// Display the main menu
	void DisplayMenu() const;

	// Run the main loop
	void Run();
};