using System.IO;
using System.Xml.Linq;

namespace MDK0301
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XNamespace ns = "MDK0301";
            XElement students = new XElement(ns + "Students");

            using (StreamReader sr = new StreamReader("Input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    students.Add(new XElement(ns + "Student",
                        new XElement(ns + "LastName", parts[0].Trim()),
                        new XElement(ns + "FirstName", parts[1].Trim()),
                        new XElement(ns + "Group", parts[2].Trim()),
                        new XElement(ns + "Height", parts[3].Trim()),
                        new XElement(ns + "AverageGrade", parts[4].Trim()),
                        new XElement(ns + "Scholarship", parts[5].Trim())
                    ));
                }
            }

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"styles.css\""),
                students
            );

            doc.Save("students.xml");

            string css = @"
                            body {
                                font-family: 'Segoe UI', Arial, sans-serif;
                                background-color: #E1E1E1;
                            }

                            Students {
                                display: flex;
                                flex-wrap: wrap;
                                justify-content: space-between;
                                padding: 20px;
                            }

                            Student {
                                border: 1px solid #D6D6D6;
                                border-radius: 10px;
                                box-shadow: 0px 2px 15px rgba(0, 0, 0, 0.1);
                                margin: 10px;
                                padding: 20px;
                                width: calc(50% - 40px);
                                background-color: lightgoldenrodyellow;
                                transition: all 0.3s ease;
                            }

                            Student:hover {
                                box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
                            }

                            LastName, FirstName, Group, Height, AverageGrade, Scholarship {
                                display: block;
                                color: #4A4A4A;
                                margin-bottom: 10px; 
                            }

                            LastName {
                                font-weight: bold;
                                color: #000000;
                                font-size: 1.2em; 
                            }

                            AverageGrade {
                                color: #0078D7;
                                font-weight: bold; 
                            }";

            File.WriteAllText("styles.css", css);
        }
    }
}
