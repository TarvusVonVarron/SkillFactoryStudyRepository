using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\\students.bin";
            var students = ReadFromBinaryFile<List<Student>>(path);

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Students");
            Directory.CreateDirectory(directoryPath);

            foreach (var student in students)
            {
                string filePath = Path.Combine(directoryPath, $"{student.Group}.txt");
                string studentData = $"{student.Name}, {student.DateOfBirth.ToString("dd.MM.yyyy")}";
                File.AppendAllText(filePath, studentData + Environment.NewLine);
            }
        }

        static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}