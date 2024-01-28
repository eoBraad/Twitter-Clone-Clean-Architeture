using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class ValidateException : BaseException
{
    public List<string> ValidateMessage { get; set; }

    public ValidateException(List<string> Message)
    {
        ValidateMessage = Message;
    }
}
