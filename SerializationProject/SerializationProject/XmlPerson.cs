using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializationProject
{
    public class Person
    {
        [XmlElement("Person")]
        //[XmlIgnore]
        public string pName { get; set; }
        public int pAge { get; set; }
        public double pWeight { get; set; }
    }
    class XmlPerson
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(XmlPerson));
        static void Serialize()
        {
            FileStream file = null;
            try
            {
                Person prsn = new Person();
                prsn.pName = "Rahul";
                prsn.pAge = 33;
                prsn.pWeight = 59.30;
                XmlSerializer xs = new XmlSerializer(prsn.GetType());
                file = File.Create("person.xml");
                xs.Serialize(file, prsn);
            }
            catch (FileNotFoundException ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
        static void DeSerialize()
        {
            StreamReader file = null;
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(Person));
                file = new StreamReader("person.xml");
                Person prsn = (Person)reader.Deserialize(file);
                log.Info("Name : " + prsn.pName);
                log.Info("Age : " + prsn.pAge);
                log.Info("Weight : " + prsn.pWeight);
            }
            catch (FileNotFoundException ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                if (file != null)
                    file.Close();
            }


        }
        static void Main(string[] args)
        {
            Serialize();
            DeSerialize();
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
