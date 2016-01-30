using System;
using System.Text;
using System.Collections.Generic;


namespace ManagedLibrary
{
    public class Result
    {
        public bool State { get; set; }

        public string Message { get; set; }
    }

    public class MyClass
    {

        public void Method1()
        {

        }

        public int Method2()
        {
            return 0;
        }

        public Result Method3()
        {
            Result result = new Result();
            result.State = true;
            result.Message = "Test Message";
            return result;
        }

        public static Result SMethod3()
        {
            Result result = new Result();
            result.State = true;
            result.Message = "Test Message";
            return result;
        }

    }
}
