{
  ÝSMAÝL KOCACAN
  30 Mart 2018 Cuma 00:29 PM
}
program Project2;

{$APPTYPE CONSOLE}
{$R *.res}

uses
  System.SysUtils,
  Winapi.Windows,
  Vcl.Dialogs;

const
  LibName = 'ClassLibrary1.dll';

type

  TValue = record
    FieldInt: Integer;
    FieldDouble: double;
  end;

  PValue = ^TValue;

function Post(First, Last: PValue): Boolean; cdecl;
  external LibName name 'Post';

function GetList(ArrayLength: PINT): PValue; cdecl;
  external LibName name 'GetList';


function GetString(): PAnsiString; cdecl;
 external LibName name 'GetString';

procedure GetAnsiString(var Value:PAnsiChar); cdecl;
 external LibName name 'GetAnsiString';

procedure GetWideString(var Value:PChar); cdecl;
 external LibName name 'GetWideString';


var
  AList: array of TValue;

  AList2: PValue;
  I: Integer;
  ArrayLength: Integer;

  AString : string;
  AStrWideChar : PChar;
  AStrAnsiChar : PAnsiChar;
begin
  AString := string(GetString());
  GetAnsiString(AStrAnsiChar);
  GetWideString(AStrWideChar);

  SetLength(AList, 2);
  AList[0].FieldInt := 33;
  AList[0].FieldDouble := 33.33;

  AList[1].FieldInt := 34;
  AList[1].FieldDouble := 34.34;

  Post(@AList[Low(AList)], @AList[High(AList)]);

  AList2 := GetList(@ArrayLength);
  if (ArrayLength = 0) then
    exit;

  for I := 0 to Pred(ArrayLength) do
  begin
    ShowMessage(AList2^.FieldInt.ToString());
    Inc(AList2, sizeof(Pointer));
  end;

end.
