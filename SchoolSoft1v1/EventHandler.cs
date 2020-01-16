using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSoft1v1
{
    public interface IEventHandler
    {
        public bool StringReturn(in string message, out string ReturnString);
        public bool IntReturn(string message, int MIN_INPUT, int MAX_INPUT, out int ReturnInt);
    }
    public partial class EventHandler : IEventHandler
    {
        public bool StringReturn(in string message, out string ReturnString)
        {
            ReturnString = null;
            Console.WriteLine(message);
            while (ReturnString == null)
            {
                try
                {
                    ReturnString = Console.ReadLine();
                }
                catch
                {
                    throw;
                }
            }
            return true;
        }
    }

    public partial class EventHandler
    {
        public bool IntReturn(string message, int MIN_INPUT, int MAX_INPUT, out int ReturnInt)
        {
            ReturnInt = -2147483648;
            bool tempbool = false;
            if (message != null)
            {
                Console.WriteLine(message);
            }
            while(tempbool == false)
            {
                ReturnInt = int.Parse(Console.ReadLine());
                if(ReturnInt > MIN_INPUT || ReturnInt < MAX_INPUT)
                {
                    tempbool = true;
                }
            }
            return true;
        }
    }
                
}
