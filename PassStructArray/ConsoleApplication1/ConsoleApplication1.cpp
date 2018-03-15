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

int main()
{
	int size = sizeof(Value);

	HMODULE hModule = LoadLibraryA("ClassLibrary1.dll");
	PPost post = (PPost)GetProcAddress(hModule, "Post");

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

