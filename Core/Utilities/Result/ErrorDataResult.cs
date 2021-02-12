using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult( string message, T data) : base(false, data, message)
        {
        }

        public ErrorDataResult( T data) : base(false, data)
        {
        }

        public ErrorDataResult(string message):base(false,default, message)
        {
                
        }

        public ErrorDataResult():base(false,default)
        {
                
        }
    }
}
