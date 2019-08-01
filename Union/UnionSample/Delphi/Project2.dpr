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
  try
    DataPtr := CreateData();
    
  	WriteLn(Format('Size Of TDataType : %d',[SizeOf(TDataType)]));
	  WriteLn(Format('Size Of TUnionData: %d',[SizeOf(TUnionData)]));
	  WriteLn(Format('Size Of TData : %d',[SizeOf(TData)]));
	  WriteLn(Format('Size Of DataPtr : %d',[SizeOf(DataPtr)]));
	  WriteLn(Format('Size Of DataPtr : %d',[SizeOf(DataPtr^)]));
                                    
    WriteLn(Format('FieldInteger Value: %d',[DataPtr^.FieldInteger]));
    WriteLn(Format('FieldDouble Value: %f',[DataPtr^.FieldDouble]));
  
    case DataPtr^.DataType of
      dtInteger:begin
       	WriteLn(Format('Integer Value : %d',[DataPtr^.UnionData.FieldInteger]));
      end;
      dtDouble:begin
       	WriteLn(Format('Double Value : %f',[DataPtr^.UnionData.FieldDouble]));
      end;
      else
       WriteLn('UnKnown'); 
    end;

  except
    on E: Exception do
      Writeln(E.ClassName, ': ', E.Message);
  end;
  RemoveData(DataPtr);  
end.
