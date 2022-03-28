#pragma once
class TriangleStack
{
private:
	float mBase;
	float mHeight;
public:
	TriangleStack();
	void SetBase(float b);
	void SetHeight(float h);
	float GetArea();
};

