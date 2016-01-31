object FrmMain: TFrmMain
  Left = 0
  Top = 0
  Caption = 'Client'
  ClientHeight = 251
  ClientWidth = 165
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 36
    Top = 112
    Width = 16
    Height = 13
    Caption = 'X : '
  end
  object Label2: TLabel
    Left = 36
    Top = 136
    Width = 16
    Height = 13
    Caption = 'Y : '
  end
  object lblResult: TLabel
    Left = 36
    Top = 172
    Width = 30
    Height = 13
    Caption = 'Result'
  end
  object btnLoadLib: TButton
    Left = 36
    Top = 20
    Width = 97
    Height = 25
    Caption = 'Load Library'
    TabOrder = 0
    OnClick = btnLoadLibClick
  end
  object btnFreeLib: TButton
    Left = 36
    Top = 60
    Width = 97
    Height = 25
    Caption = 'Free Library'
    TabOrder = 1
    OnClick = btnFreeLibClick
  end
  object btnSum: TButton
    Left = 36
    Top = 201
    Width = 97
    Height = 25
    Caption = 'Sum'
    TabOrder = 2
    OnClick = btnSumClick
  end
  object edtX: TEdit
    Left = 58
    Top = 109
    Width = 57
    Height = 21
    TabOrder = 3
  end
  object edtY: TEdit
    Left = 58
    Top = 134
    Width = 57
    Height = 21
    TabOrder = 4
  end
end
