using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayGroung.Models
{
    public class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string YearLevel { get; set; }

       public List<Student> GetAllStudent()
        {
            List<Student> student = new List<Student>();


            Student student1 = new Student
            {
                StudentId = 1,
                Name = "chris",
                YearLevel = "4th"
            };
            student.Add(student1);
            Student student2 = new Student
            {
                StudentId = 2,
                Name = "Jessica",
                YearLevel = "3th"
            };
            student.Add(student2);
            Student student3 = new Student
            {
                StudentId = 3,
                Name = "Khae",
                YearLevel = "2th"
            };
            student.Add(student3);


            return student;
        }
    }
}