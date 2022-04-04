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
 
    int number1 = 100;
    int number2 = 200;
    int number3 = 0;

    std::cout << number1 << std::endl << number2 << std::endl << number3 << std::endl;
    std::cout << "After adding: " << AddNumbersReturnInt(&number1, &number2) << std::endl << std::endl;


    int number4 = 1000;
    int number5 = 2000;
    int number6 = 0;

    std::cout << number4 << std::endl << number5 << std::endl << number6 << std::endl;
    AddNumbersReturnVoid(number4, number5, &number6);
    std::cout << "After adding: " << number6 << std::endl << std::endl << std::endl;


    std::cout << "Current:" << std::endl << number3 << std::endl << number6 << std::endl;
    SwapValues(&number3, &number6);
    std::cout << "Swapped:" << std::endl << number3 << std::endl << number6 << std::endl << std::endl;

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
    int j = 0;
    j = *a;
    *a = *b;
    *b = j;
}