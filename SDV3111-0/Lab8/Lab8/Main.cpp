// Lab8.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include "TriangleHeap.h"
#include "TriangleStack.h"

int AddNumbersReturnInt(int* a, int* b);
void AddNumbersReturnVoid(int a, int b, int* sum);
void SwapValues(int* a, int* b);

int main()
{
    int* i;
    std::cout << *i;

    int num1 = 1;
    int num2 = 2;
    int num3 = 0;

    std::cout << num1 << std::endl << num2 << std::endl << num3 << std::endl;
    std::cout << "After adding: " << AddNumbersReturnInt(&num1, &num2) << std::endl << std::endl;


    int num4 = 10;
    int num5 = 22;
    int num6 = 0;

    std::cout << num4 << std::endl << num5 << std::endl << num6 << std::endl;
    AddNumbersReturnVoid(num4, num5, &num6);
    std::cout << "After adding: " << num6 << std::endl << std::endl << std::endl;


    std::cout << "Current:" << std::endl << num3 << std::endl << num6 << std::endl;
    SwapValues(&num3, &num6);
    std::cout << "Swapped:" << std::endl << num3 << std::endl << num6 << std::endl << std::endl;

    std::cout << "Triangle stack areas" << std::endl;
    TriangleStack a = TriangleStack();
    a.SetBase(10);
    a.SetHeight(20);

    TriangleStack b = TriangleStack();
    b.SetBase(10);
    b.SetHeight(20);

    std::vector<TriangleStack> triStack;
    triStack.push_back(a);
    triStack.push_back(b);

    for (size_t i = 0; i < triStack.size(); i++)
    {
        std::cout << triStack[i].GetArea() << std::endl;
    }
    std::cout << "Triangle Heap areas" << std::endl;
    TriangleHeap* c = new TriangleHeap();
    c->SetBase(10);
    c->SetHeight(20);

    TriangleHeap* d = new TriangleHeap();
    d->SetBase(30);
    d->SetHeight(40);

    std::vector<TriangleHeap> triHeap;
    triHeap.push_back(*c);
    triHeap.push_back(*d);

    for (size_t i = 0; i < triHeap.size(); i++)
    {
        std::cout << triHeap[i].GetArea() << std::endl;
        delete& triHeap[i];
    }

    system("pause");
}

int AddNumbersReturnInt(int* a, int* b)
{
    return *a + *b;
}

void AddNumbersReturnVoid(int a, int b, int* sum)
{
    *sum = a + b;
}

void SwapValues(int* a, int* b)
{
    int t = 0;
    t = *a;
    *a = *b;
    *b = t;
}