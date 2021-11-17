using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDemo
{
    public class Student
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public List<Course> Courses { get; set; }
    }


    public class Course
    {
        public int Id { get; set; }

        public int StudentId { get; set; }


        public string CourseName { get; set; }


        public int Score { get; set; }
    }
}
