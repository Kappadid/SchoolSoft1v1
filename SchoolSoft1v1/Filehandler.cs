using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace SchoolSoft1v1
{
    public interface IFileHandler
    {
        bool WriteObjectList(string path, List<LessonManager> ObjectList);
        List<Lesson> LoadObjectList(string path);
    }
    public class Filehandler : IFileHandler
    {
        public bool WriteObjectList(string path,List<LessonManager> ObjectList)
        {
            using (StreamWriter writer = new StreamWriter(path))
                try
                { 
                    writer.WriteLine(JsonConvert.SerializeObject(ObjectList));
                }
                catch ( Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            return true;
        }
        public List<Lesson> LoadObjectList(string path)
        {
            TimeMananger Time = new TimeMananger();
            if (File.Exists(path) == false)
            {
                File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"SchoolSoft1v1Me\Schedule\" + Time.DayOfWeek + ".json"));
                Lesson templesson = new Lesson();
                Lesson.MyList.Add(templesson);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                try
                {
                    var Templist = new List<Lesson>();
                    Templist = JsonConvert.DeserializeObject<List<Lesson>>(reader.ReadToEnd());
                    if (Templist.Count == 0)
                    {
                        var TempLesson = new Lesson();
                        Templist.Add(TempLesson);
                    }
                    return Lesson.MyList;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Creating File for new day");
                    throw;
                }
            }
        }
    }
}
