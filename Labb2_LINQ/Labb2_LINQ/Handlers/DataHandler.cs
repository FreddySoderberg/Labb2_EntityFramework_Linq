using Labb2_LINQ.Data;
using Labb2_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2_LINQ.Handlers
{
    class DataHandler
    {
        //Hämta alla lärare som undervisar i “programmering 1”
        public static void GetAllTeachers()
        {
            using(var context = new SchoolDbContext())
            {
                var query = context.TeacherCourses.Where(x => x.CourseId == 1).Select(y => y.Teacher.TeacherName).ToList();

                foreach (var item in query)
                {
                    Console.WriteLine($"The teacher of programming 1 is {item}");
                }
            }
        }

        //Hämta alla elever med deras lärare, skriv ut både elevernas namn och namnet på alla lärare de har
        //Joins TeacherCourses and StudentCourses together, then cycles through them and writes them out.
        public static void GetStudentsAndTheirTeachers()
        {
            using(var context = new SchoolDbContext())
            {
                var query =
                    (from teach in context.TeacherCourses
                    join studentCourse in context.StudentCourses
                    on teach.CourseId equals studentCourse.CourseId
                    select new { StudentName = studentCourse.Student.StudentName, StudentId = studentCourse.Student.StudentId, TeacherName = teach.Teacher.TeacherName, TeacherId = teach.TeacherId }).ToList();

                var studId = new List<int>();

                foreach (var item in query) //Foreach annonymous item in joined call.
                {
                    foreach (var item2 in query) //Then, for every item, checks itself again
                    {
                        if (item.StudentName == item2.StudentName && item.TeacherName != item2.TeacherName && !studId.Contains(item.StudentId)) //If true, add StudentId to a list then write out 2 teachers
                        {
                            studId.Add(item2.StudentId);
                            Console.WriteLine("Student: " + item.StudentName + " - " + "Teachers: " + item.TeacherName + " And " + item2.TeacherName);
                        } 
                    }
                    if (!studId.Contains(item.StudentId))
                    {
                        Console.WriteLine("Student: " + item.StudentName + " - " + "Teachers: " + item.TeacherName);
                    }
                }
            }
        }
        //Hämta alla elever som läser “programmering 1” och skriv ut deras namn samt vilken lärare de har i den kursen
        //Joins TeacherCourses with StudentCourses, where CourseId is 1(Programming 1),
        public static void GetStudentsInCourse()
        {
            using (var context = new SchoolDbContext())
            {
                var query =
                   (from teach in context.TeacherCourses
                   join studentCourse in context.StudentCourses
                   on teach.CourseId equals studentCourse.CourseId
                   where studentCourse.CourseId == 1
                   select new { CourseName = studentCourse.Course.CourseName, StudentName = studentCourse.Student.StudentName}).ToList();


                Console.WriteLine(query[0].CourseName);
                foreach (var item in query)
                {
                    Console.WriteLine(item.StudentName);
                }
            }
        }

        //Editera ett ämne från “programmering 2” till “OOP”
        //Takes input and changes course name to input and update DB
        public static void ChangeFirstCourseName(string input)
        {
            using (var context = new SchoolDbContext())
            {
                var result = context.Courses.SingleOrDefault(c => c.CourseId == 2);
                if (result != null)
                {
                    result.CourseName = input;
                    context.SaveChanges();
                }
            }
        }

        //Uppdatera en elevs lärare i “programmering 1” från Anas till Reidar.
        //Takes input and changes the FKey of TeacherCourses to the choosen teacher
        public static void ChangeTeacherOfClass(int courseId, int teacherId)
        {
            using (var context = new SchoolDbContext())
            {
                var result = context.TeacherCourses.Where(c => c.CourseId == courseId).FirstOrDefault();

                if (result != null)
                {
                    result.TeacherId = teacherId;
                    context.SaveChanges();
                }
            }
        }

        public static List<Course> GetCourseList()
        {
            using(var context = new SchoolDbContext())
            {
                List<Course> courseList = context.Courses.ToList();
                return courseList;
            }
        }

        public static List<Teacher> GetTeacherList()
        {
            using (var context = new SchoolDbContext())
            {
                List<Teacher> courseList = context.Teachers.ToList();
                return courseList;
            }
        }
    }
}
