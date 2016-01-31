// VisualCppLibrary.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "VisualCppLibrary.h"


extern "C" 	__declspec(dllexport)  int __cdecl Sum(int x, int y)
{
	return x + y;
}
