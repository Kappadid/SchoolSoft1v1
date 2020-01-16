using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSoft1v1
{
    public interface ITimemananger
    {
        bool ReturnDateTime(string Message1 ,string Message2, out DateTime ReturnDateTime);
    }
    public class TimeMananger : ITimemananger
    {
        public DateTime CT = DateTime.Now;
        public DayOfWeek DayOfWeek = new DayOfWeek();
        public bool ReturnDateTime(string Message1,string Message2, out DateTime ReturnDateTime)
        {
            EventHandler handler = new EventHandler();
            int TempHour, TempMin;
            handler.IntReturn(Message1, 0, 24,out TempHour);
            handler.IntReturn(Message2, 0, 60, out TempMin);
            ReturnDateTime = new DateTime(TempHour, TempMin, CT.Second);
            return true;

        }
    }
}
