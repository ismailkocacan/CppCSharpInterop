using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;


class Program
{

    public static void Procedure1()
    {
        Console.WriteLine("Procedure1");
    }

    public static void Procedure2()
    {
        Console.WriteLine("Procedure2");
    }

    static void Main(string[] args)
    {
        Queue<IntPtr> pointersQueue = new Queue<IntPtr>();

        Type type = typeof(Program);
        MethodInfo[] methods = type.GetMethods();
        foreach (MethodInfo method in methods)
        {
            if (method.DeclaringType != type) continue;
            pointersQueue.Enqueue(method.MethodHandle.GetFunctionPointer());
        }

        foreach (IntPtr intPtr in pointersQueue)
        {
            Marshal.GetDelegateForFunctionPointer(intPtr, typeof(Action)).DynamicInvoke(null);
        }

        while (pointersQueue.Count > 0)
        {
            Marshal.GetDelegateForFunctionPointer(pointersQueue.Dequeue(), typeof(Action)).DynamicInvoke(null);
        }

        Console.WriteLine(pointersQueue.Count.ToString());
    }
}