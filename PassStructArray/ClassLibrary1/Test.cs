using RGiesecke.DllExport;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public struct Value
{
    public int FieldInt;
    public double FieldDouble;
}

public class Test
{
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