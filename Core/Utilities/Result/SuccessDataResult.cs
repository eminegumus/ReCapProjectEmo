using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(true, data, message)
        {
        }

        public SuccessDataResult(T data) : base(true,data)
        {
        }

        public SuccessDataResult(string message):base(true,default, message)
        {
                
        }

        public SuccessDataResult():base(true,default)
        {
                
        }
        public T Data { get; }
    }
}
