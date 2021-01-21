unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;


var
  Form1: TForm1;

function DoIt(var p1:string;var p2:string):BOOL; stdcall; external 'ClassLibraryExports' name 'DoIt';


implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
  bResult : BOOL;
  p1:string;
  p2:string;
begin
  p1 := 'p1 val';
  p2 := 'p2 val';
  bResult := DoIt(p1,p2);

  ShowMessage(
   BoolToStr(bResult,true)
  );

  ShowMessage(p1);
  ShowMessage(p2);
end;

end.
