using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSoft1v1
{
    public interface ILessonMananger
    {
        bool LessonCreate();
        bool CurrentLessonSelect();
   }
    public class Lesson
    {
        public static List<Lesson> MyList = new List<Lesson>();
        public string LessonName;
        public DateTime LessonEndTime;
        public TimeSpan LessonDuration;
    }
    public class LessonManager : ILessonMananger
    {
        public static int CurrentLesson;
        public bool LessonCreate()
        {
            Lesson tempLesson = new Lesson();
            EventHandler HandleEvent = new EventHandler();
            TimeMananger timeMananger = new TimeMananger();
            HandleEvent.StringReturn("What is the name of the Lesson?",out tempLesson.LessonName);
            timeMananger.ReturnDateTime("Which hour does the lesson end?", "Which Minute does the lesson end?", out tempLesson.LessonEndTime);
            Lesson.MyList.Add(tempLesson);
            return true;
        }
        public bool CurrentLessonSelect()
        {
            bool tempbool = true;
            do
            {
                TimeMananger time = new TimeMananger();
                int i = 0;
                if(Lesson.MyList.Count == 0)
                {
                    Lesson templesson = new Lesson();
                    Lesson.MyList.Add(templesson);
                }
                foreach (Lesson x in Lesson.MyList)
                {
                    if (Lesson.MyList[i].LessonEndTime < time.CT.AddHours(-1))
                        i += i;
                }
                if (i == 0 && Lesson.MyList[0].LessonEndTime < time.CT.AddHours(-1))
                {
                    Console.WriteLine("You are not currently in a lesson");
                    return false;
                }
                else
                    CurrentLesson = i;
                tempbool = false;
                return true;
            } while (tempbool == true);
        }

    }
}
