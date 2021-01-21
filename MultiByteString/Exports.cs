using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ClassLibraryExports
{
    public static class Exports
    {

        [DllExport(ExportName = "DoIt", CallingConvention = CallingConvention.StdCall)]
        public static bool DoIt([MarshalAs(UnmanagedType.LPWStr)] ref string p1,
                                [MarshalAs(UnmanagedType.LPWStr)] ref string p2)
        {
            MessageBox.Show(p1);
            MessageBox.Show(p2);
            p2 = "test";
            return false;
        }
    }

}
