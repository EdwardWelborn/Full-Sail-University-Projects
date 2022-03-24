class Base
{
private:
	char* name = nullptr;
public:
	Base(); 
	Base(Base& other); 
	~Base(); 
	Base& operator=(const Base& other); 
	void SetName(const char* name);
	const char* GetName() const { return name; }
	virtual void DisplayRecord() = 0;
};
