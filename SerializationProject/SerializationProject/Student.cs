using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationProject
{
    [Serializable]
    class Student
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Student));
        int rollNo;
        string name;
        string standard;
        string school;
        public Student(int rollNo, string name, string standard, string school)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.standard = standard;
            this.school = school;
        }
        static void Serialize()
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream("E:\\BizRun.NET\\student.txt", FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                Student std = new Student(101, "kamil", "tenth", "dps");
                formatter.Serialize(stream, std);
            }
            catch(FileNotFoundException ex) { log.Error(ex.Message); }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        static void DeSerialize()
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream("E:\\BizRun.NET\\student.txt", FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                Student std = (Student)formatter.Deserialize(stream);
                log.Info("Roll no. : " + std.rollNo);
                log.Info("Name : " + std.name);
                log.Info("Standard : " + std.standard);
                log.Info("School : " + std.school);
            }
            catch (FileNotFoundException ex) { log.Error(ex.Message); }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        static void Main(string[] args)
        {
            Serialize();
            DeSerialize();
            Console.ReadKey();
        }
    }
}
