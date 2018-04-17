using RGiesecke.DllExport;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

public struct Value
{
    public int FieldInt;
    public double FieldDouble;
}

public class Test
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MyCallbackMethod(int x);


    [DllExport("TestCallBack", CallingConvention.Cdecl)]
    public static void TestCallBack(MyCallbackMethod myCallbackMethod)
    {
        if (myCallbackMethod == null) return;
        Thread thread = new Thread(delegate() {
            Thread.Sleep(5000);
            myCallbackMethod(31);
        });
        thread.Start();
    }

    [DllExport("GetString", CallingConvention.Cdecl)]
    public unsafe static char* GetString()
    {
        string retVal = "aaaa";
        fixed(char* p = retVal)
        {
            return p;
        }
    }

    [DllExport("GetWideString", CallingConvention.Cdecl)]
    public static void GetWideString([MarshalAs(UnmanagedType.LPWStr)] ref string value)
    {
        value = "my wide string test";
    }


    [DllExport("GetAnsiString", CallingConvention.Cdecl)]
    public static void GetAnsiString([MarshalAs(UnmanagedType.LPStr)] ref string value)
    {
        value = "my ansi string test";
    }


    [DllExport("Post", CallingConvention.Cdecl)]
    public static unsafe bool Post(ref Value elementFirst, ref Value elementLast)
    {
        Value* current, last;
        fixed (Value* tempFirst = &elementFirst, tempLast = &elementLast)
        {
            current = tempFirst;
            last = tempLast;
            current->FieldInt = 31;
            while (current <= last)
            {
                string value = string.Format("FInt: {0}, FDouble: {1}",
                            current->FieldInt, current->FieldDouble);
                MessageBox.Show(value, "Data");
                current++;
            }
        }
        return true;
    }

    [DllExport("GetList", CallingConvention.Cdecl)]
    public static unsafe Value* GetList(ref int arrayLength)
    {
        int count = 2;
        arrayLength = count;
        Value* result = null;
        Value[] data = new Value[count];
        for (int i = 0; i < count; i++)
        {
            Value value = new Value()
            {
                FieldInt = i,
                FieldDouble = i
            };
            data[i] = value;
        }
        fixed (Value* current = &data[0], last = &data[count - 1])
        {
            result = current;
            return result;
        }
    }
}