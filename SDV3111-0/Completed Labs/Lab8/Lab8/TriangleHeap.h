#pragma once
class TriangleHeap
{
private:
	float* mBase;
	float* mHeight;
public:
	TriangleHeap();
	TriangleHeap(const TriangleHeap& other);
	~TriangleHeap();
	TriangleHeap& operator=(const TriangleHeap& other);
	void SetBase(float b);
	void SetHeight(float h);
	float GetArea();
};
