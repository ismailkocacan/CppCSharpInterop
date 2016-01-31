using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct KeyValue
{
    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 15)]
    public string Key;

    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 15)]
    public string Value;
}


[ComVisible(true)]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct MyStruct
{
    /*
    public int X;

    public double Y;

    public float Z;


    /// char[15]
    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 15)]
    public string FirstName;

    /// char[15]
    [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 15)]
    public string LastName;


    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public string[] Array;

    */

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public KeyValue[] KeyValue;
}
