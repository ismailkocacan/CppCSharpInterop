// ---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "UnitMain.h"
// ---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFrmMain *FrmMain;

HMODULE hLibModule;

// ---------------------------------------------------------------------------
__fastcall TFrmMain::TFrmMain(TComponent* Owner) : TForm(Owner)
{

}

// ---------------------------------------------------------------------------
void __fastcall TFrmMain::btnLoadLibClick(TObject *Sender)
{
	UnicodeString libName = "VisualCppLibrary.dll";
	hLibModule = LoadLibrary(libName.c_str());
}

// ---------------------------------------------------------------------------
void __fastcall TFrmMain::btnSumClick(TObject *Sender)
{
	int(__cdecl*Sum)(int, int);
	Sum = (int(__cdecl*)(int, int)) GetProcAddress(hLibModule, "Sum");

	if (Sum != NULL)
	{
		int x = StrToInt(edtX->Text.Trim());
		int y = StrToInt(edtY->Text.Trim());
		int sonuc = Sum(x,y);
		lblResult->Caption = "Result :"+IntToStr(sonuc);
	}
	else
	{
		ShowMessage("method not found");
	}

}
// ---------------------------------------------------------------------------
void __fastcall TFrmMain::btnFreeLibClick(TObject *Sender)
{
  FreeLibrary(hLibModule);
}
//---------------------------------------------------------------------------

