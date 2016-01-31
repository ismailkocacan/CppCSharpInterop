//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "UnitMain.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;


typedef struct TKeyValue
{

  char Key[15];
  char Value[15];

} TKeyValue;

typedef struct MyStruct
{
/*
  int X;
  double Y;
  float Z;

  char FirstName[15];
  char LastName[15];
  char *Array[3];
*/

  TKeyValue *KeyValue[1];

} TMyStruct;


typedef int (__stdcall *DoSomething)(char [],char[],TMyStruct *);

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{

}
//---------------------------------------------------------------------------

void __fastcall TForm1::btnInvokeMethodClick(TObject *Sender)
{
  wchar_t buf[256];
  String DLL_FILENAME = "ClassLibrary1.dll";
  HINSTANCE dllHandle = NULL;

  dllHandle = LoadLibrary(DLL_FILENAME.c_str());

  FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM, NULL, GetLastError(),MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), buf, 256, NULL);
  OutputDebugStringW(buf);

  if(dllHandle == NULL) return;
  int status = -1;

  DoSomething xDoSomething = (DoSomething)GetProcAddress(dllHandle, "DoSomething");
  FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM, NULL, GetLastError(),MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), buf, 256, NULL);
  OutputDebugStringW(buf);

  if (xDoSomething == NULL) return;

  try
  {
	  TMyStruct aMyStruct;
	  aMyStruct.KeyValue[0] = new TKeyValue();


	  char parameter1[15];
	  char parameter2[15];
	  strcpy(parameter1,"value1");
	  strcpy(parameter2,"value2");

	  int result = xDoSomething(parameter1,parameter2,&aMyStruct);

	  FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM, NULL, GetLastError(),MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), buf, 256, NULL);
	  OutputDebugStringW(buf);


	  ShowMessage(aMyStruct.KeyValue[0]->Key);
  }
  catch(EAccessViolation &err)
  {
	ShowMessage(err.Message);
  }

  FreeLibrary(dllHandle);
}
//---------------------------------------------------------------------------

