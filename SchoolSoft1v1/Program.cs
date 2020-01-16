using System;
using System.IO;
using System.Collections.Generic;

namespace SchoolSoft1v1
{
    class Program
    {
        static void Main(string[] args)
        {
            Filehandler HandleFiles = new Filehandler();
            TimeMananger Time = new TimeMananger();
            HandleFiles.LoadObjectList(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"SchoolSoft1v1Me\Schedule\" + Time.DayOfWeek + ".json"));
            //LessonManager ClassMananger = new LessonManager();
            //if (ClassMananger.CurrentLessonSelect() == true)
            //{
            //    Lesson templesson = Lesson.MyList[LessonManager.CurrentLesson];
            //    Console.WriteLine(templesson.LessonName + " ends in " + (templesson.LessonEndTime - Time.CT));
            //}

        }
    }
}
