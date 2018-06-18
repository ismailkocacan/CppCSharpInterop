#include <stdio.h>
#include <Windows.h>
#include "library.h"

const char DLLNAME[] = "MyLib.dll";

int main()
{
	HMODULE hModule = LoadLibraryA(DLLNAME);
	PCreateData createData = (PCreateData)GetProcAddress(hModule, "CreateData");
	PData dataPtr = createData();

	printf("Size Of DataType : %d \n", sizeof(DataType));
	printf("Size Of UnionData: %d \n", sizeof(UnionData));
	printf("Size Of Data : %d \n", sizeof(Data));

	printf("Size Of dataPtr : %d \n", sizeof(dataPtr));
	printf("Size Of dataPtr : %d \n", sizeof(*dataPtr));

	printf("FieldInteger Value: %d \n", dataPtr->FieldInteger);
	printf("FieldDouble Value: %f \n", dataPtr->FieldDouble);

	switch (dataPtr->DataType)
	{
		case DT_INTEGER: {
			printf("Integer Value : %d \n", dataPtr->UnionData.FieldInteger);
			break;
		}
		case DT_DOUBLE: {
			printf("Double Value : %f \n", dataPtr->UnionData.FieldDouble);
			break;
		}
		default: {
			printf("UnKnown ");
			break;
		}
	}

	PRemoveData removeData = (PRemoveData)GetProcAddress(hModule, "RemoveData");
	removeData(dataPtr);

	FreeLibrary(hModule);
}