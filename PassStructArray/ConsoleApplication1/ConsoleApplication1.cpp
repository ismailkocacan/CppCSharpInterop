/*
 İSMAİL KOCACAN
 15 Mart 2018 Perşembe
*/

#include "stdafx.h"

typedef struct Value
{
	int fieldInt;
	double fieldDouble;

} *PValue;

typedef bool(*PPost)(PValue elementFirst, PValue elementLast);

typedef PValue(*PGetList)(int* arrayLength);


typedef void(*PMyCallbackMethod)(int x);
typedef void(*PTestCallBack)(PMyCallbackMethod test);


typedef void(*PShow)();
typedef PVOID (*PGetPointerOfObjectMethod)();


void myCallbackMethod(int x)
{
	printf("%d", x);
}

int main()
{
	int size = sizeof(Value);

	HMODULE hModule = LoadLibraryA("ClassLibrary1.dll");

	PGetPointerOfObjectMethod getPointerOfObjectMethod = (PGetPointerOfObjectMethod)GetProcAddress(hModule, "GetPointerOfObjectMethod");
	PShow show = (PShow)getPointerOfObjectMethod();
	show();


	/*
	PTestCallBack testCallBack = (PTestCallBack)GetProcAddress(hModule, "TestCallBack");
	testCallBack(&myCallbackMethod);
	system("pause");
	*/

	PPost post = (PPost)GetProcAddress(hModule, "Post");

	PGetList getList = (PGetList)GetProcAddress(hModule, "GetList");
	int arrayLength = 0;
	PValue  anArray = getList(&arrayLength);
	if (anArray != NULL && arrayLength > 0)
	{
		for (size_t i = 0; i < arrayLength; i++)
		{
			printf("fieldInt: %d fieldDouble: %f \n", anArray[i].fieldInt, anArray[i].fieldDouble);
		}
	}

	int count = 2;
	Value* dataArray = new Value[count];
	dataArray[0].fieldInt = 1;
	dataArray[0].fieldDouble = 1.1f;
	dataArray[1].fieldInt = 2;
	dataArray[1].fieldDouble = 2.2f;
	/*
	for (size_t i = 0; i < count; i++)
	{
		dataArray[i].fieldInt = i;
		dataArray[i].fieldDouble = i * 3;
	}
	*/
	Value* last = &dataArray[count - 1];
	bool result = post(dataArray, last);

	int dbgValue = dataArray[0].fieldInt;

	delete[] dataArray;

	FreeLibrary(hModule);
	return 0;
}

