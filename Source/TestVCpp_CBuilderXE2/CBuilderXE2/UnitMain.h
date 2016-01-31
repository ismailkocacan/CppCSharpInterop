//---------------------------------------------------------------------------

#ifndef UnitMainH
#define UnitMainH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
//---------------------------------------------------------------------------
class TFrmMain : public TForm
{
__published:	// IDE-managed Components
	TButton *btnLoadLib;
	TButton *btnFreeLib;
	TButton *btnSum;
	TEdit *edtX;
	TEdit *edtY;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *lblResult;
	void __fastcall btnLoadLibClick(TObject *Sender);
	void __fastcall btnSumClick(TObject *Sender);
	void __fastcall btnFreeLibClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TFrmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFrmMain *FrmMain;
//---------------------------------------------------------------------------
#endif
