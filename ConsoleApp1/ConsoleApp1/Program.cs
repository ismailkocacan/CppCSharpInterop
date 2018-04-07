using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Sequential)]
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public void Show()
    {
        MessageBox.Show(String.Format("{0},{1}", X, Y));
    }
}


unsafe class Program
{
    public delegate void Show();

 
    static void Main(string[] args)
    {
        Point point = new Point()
        {
            X = 31,
            Y = 32
        };

        Action show1 = point.Show;
        show1();
        // or 
        Show show2 = point.Show;
        show2();

        
        GCHandle hPoint = GCHandle.Alloc(point, GCHandleType.Pinned);
        void* P1 = hPoint.AddrOfPinnedObject().ToPointer();
        IntPtr pointer = hPoint.AddrOfPinnedObject();   
        int x = Marshal.ReadInt32(pointer);
        pointer += 4;
        int y = Marshal.ReadInt32(pointer);

        Show show = point.Show;
        // Converts a delegate into a function pointer that is callable from (unmanaged code).
        IntPtr fPtr = Marshal.GetFunctionPointerForDelegate(show);
        void* PVoid = fPtr.ToPointer();
        Show call = (Show)Marshal.GetDelegateForFunctionPointer(fPtr, typeof(Show));
        call();
        hPoint.Free();
        
        /*
        string text = "text";
        GCHandle handle = GCHandle.Alloc(text, GCHandleType.Pinned);
        char* P = (char*)handle.AddrOfPinnedObject().ToPointer();
        while (*P != '\0')
        {
            P++;
        }
        handle.Free();
        GC.Collect();
        */
    }
}