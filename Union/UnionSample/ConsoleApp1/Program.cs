using System;
using System.Runtime.InteropServices;

enum DataType : int
{
    DtInteger,
    DtDouble
};

[StructLayout(LayoutKind.Explicit)]
struct UnionData
{
    [FieldOffset(0)]
    public int FieldInteger;

    [FieldOffset(0)]
    public double FieldDouble;
};


struct Data
{
    public int FieldInteger;
    public double FieldDouble;
    public DataType DataType;
    public UnionData UnionData;
};

unsafe class Program
{
    const string DllName = "MyLib.dll";

    [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr CreateData();


    [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
    static extern void RemoveData(IntPtr dataPtr);


    /*
    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    static extern bool FreeLibrary(IntPtr hModule);

    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
    */

    static void Main(string[] args)
    {
        Console.WriteLine(string.Format("Size Of UnionData : {0}", Marshal.SizeOf(typeof(UnionData))));
        Console.WriteLine(string.Format("Size Of Data : {0}", Marshal.SizeOf(typeof(Data))));

        IntPtr intPtr = CreateData();
        Data* dataPtr = (Data*)intPtr.ToPointer();

        Console.WriteLine(string.Format("FieldInteger Value : {0}", dataPtr->FieldInteger));
        Console.WriteLine(string.Format("FieldDouble Value : {0}", dataPtr->FieldDouble));

        switch (dataPtr->DataType)
        {
            case DataType.DtInteger:
                {
                    Console.WriteLine(string.Format("UnionData.FieldInteger Value : {0}", dataPtr->UnionData.FieldInteger));
                    break;
                }
            case DataType.DtDouble:
                {
                    Console.WriteLine(string.Format("UnionData.FieldDouble Value : {0}", dataPtr->UnionData.FieldDouble));

                    break;
                }
            default:
                {
                    Console.WriteLine("UnKnown ?? ");
                    break;
                }
        }
        RemoveData(intPtr);
    }
}
