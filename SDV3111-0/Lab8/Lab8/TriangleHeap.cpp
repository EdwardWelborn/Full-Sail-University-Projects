#include "TriangleHeap.h"
#include "Helper.h"

TriangleHeap::TriangleHeap()
{
	mBase = new float(0);
	mHeight = new float(0);
}

TriangleHeap::TriangleHeap(const TriangleHeap& other)
{
	mBase = new float(*other.mBase);
	mHeight = new float(*other.mHeight);
}

TriangleHeap::~TriangleHeap()
{
	delete mBase;
	delete mHeight;
	mBase = nullptr;
	mHeight = nullptr;
}

TriangleHeap& TriangleHeap::operator=(const TriangleHeap& other)
{
	if (this != &other)
	{
		mBase = other.mBase;
		mHeight = other.mHeight;
	}
	return *this;
}

void TriangleHeap::SetBase(float b)
{
	*mBase = b;
}

void TriangleHeap::SetHeight(float h)
{
	*mHeight = h;
}

float TriangleHeap::GetArea()
{
	return *mBase * (*mHeight / 2);
}
