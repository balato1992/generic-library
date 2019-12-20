using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericModel.Other
{
    public class ExceptionHelper
    {
        public static string GetExceptionAllMessage(Exception e)
        {
            List<string> messages = new List<string>();

            while (e != null)
            {
                messages.Add(e.Message);
                e = e.InnerException;
            }

            return string.Join(" \r\n|| ", messages.ToArray());
        }
    }
}
