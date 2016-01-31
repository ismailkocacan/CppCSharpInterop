using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class LibraryExport
    {
        [DllExport("DoSomething", CallingConvention = CallingConvention.StdCall)]
        public static int DoSomething(string parameter1, string parameter2, ref MyStruct myStruct)
        {
            int result;
            MessageBox.Show(parameter1);
            MessageBox.Show(parameter2);

            try
            {
                /*
                myStruct.X = 5;
                myStruct.Y = 6.5;
                myStruct.Z = 25;

                myStruct.FirstName = "İsmail";
                myStruct.LastName = "Kocacan";

                myStruct.Array[0] = "value1";
                myStruct.Array[1] = "value2";
                myStruct.Array[2] = "value3";
                */

                
           
                
                myStruct.KeyValue[0].Key = "x key 1";
                myStruct.KeyValue[0].Value = "x value 1";
                MessageBox.Show("KeyValue : " + myStruct.KeyValue[0].Key);
           
                result = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                result = 0;
            }
            return result;
        }



    }
}
