program Project2;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,
  Vcl.Dialogs;

const
  LibName = 'MyLib.dll';

type

 TDataType = (dtInteger, dtDouble);

 {
 16 Byte
 TUnionData = record
   FieldInteger : Integer; 
   FieldDouble : Double;
 end;
 }
 
 // 8 Byte
 TUnionData = record
   case Integer of
    0 : ( FieldInteger : Integer; );
    1 : ( FieldDouble : Double; );
 end;
  
 PUnionData = ^TUnionData;


 TData = record
   FieldInteger : Integer;
   FieldDouble : Double;
   DataType : TDataType;
   UnionData : TUnionData;
 end;

 PData = ^TData;

function CreateData:PData; cdecl; external LibName name 'CreateData';
procedure RemoveData(DataPtr:PData); cdecl; external LibName name 'RemoveData';

var
  DataPtr : PData;
begin
  ShowMessage(sizeof(TUnionData).ToString());
  
  try
    DataPtr := CreateData();

  except
    on E: Exception do
      Writeln(E.ClassName, ': ', E.Message);
  end;

end.
