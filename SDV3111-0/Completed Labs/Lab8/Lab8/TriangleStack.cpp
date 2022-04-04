#include "TriangleStack.h"

TriangleStack::TriangleStack()
{
	mBase = 0;
	mHeight = 0;
}

void TriangleStack::SetBase(float b)
{
	mBase = b;
}

void TriangleStack::SetHeight(float h)
{
	mHeight = h;
}

float TriangleStack::GetArea()
{
	return mBase * (mHeight / 2);
}
