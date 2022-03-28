#pragma once
class Base
{
private:
	char* _name = nullptr;
public:
	Base(); //Default constructor
	Base(Base& other); //Copy Constructor
	~Base(); //Destructor
	Base& operator=(const Base& other); //Assignment operator
	void SetName(const char* name);
	const char* GetName() const { return _name; }

	virtual void DisplayRecord() = 0;
};

