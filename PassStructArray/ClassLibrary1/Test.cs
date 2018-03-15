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
    public static bool Post(ref Value elementFirst, ref Value elementLast)
    {
        unsafe
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
        }
        return true;
    }
}