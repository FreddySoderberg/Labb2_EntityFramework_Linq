using Labb2_LINQ.Data;
using Labb2_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2_LINQ.DummyData
{
    class CreateDummyData
    {
        public static void CreateAllDummyData()
        {
            //CreateDummyCourses();
            //CreateDummyTeachers();
            //CreateDummyClass();
            //CreateDummyStudents();

            CreateDummyClassCourses();
            CreateDummyStudentCourse();
            CreateDummyTeacherCourse();
        }

        public static void CreateDummyCourses()
        {
            using (var context = new SchoolDbContext())
            {
                List<Course> list = new List<Course>()
                {
                    new Course {CourseName = "Programming 1"},
                    new Course {CourseName = "Programming 2"},
                    new Course {CourseName = "Programming 3"}
                };
                foreach (var item in list)
                {
                    context.Courses.Add(item);
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyTeachers()
        {
            using(var context = new SchoolDbContext())
            {
                List<Teacher> list = new List<Teacher>()
                {
                    new Teacher {TeacherName = "Reidar"},
                    new Teacher {TeacherName = "Anas"},
                    new Teacher {TeacherName = "Tobias"}
                };

                foreach (var item in list)
                {
                    context.Teachers.Add(item);
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyClass()
        {
            using (var context = new SchoolDbContext())
            {
                List<Class> list = new List<Class>()
                {
                    new Class {ClassName = "Teknik 1"},
                    new Class {ClassName = "Teknik 2"},
                    new Class {ClassName = "Teknik 3"}
                };

                foreach (var item in list)
                {
                    context.Classes.Add(item);
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyStudents()
        {
            using (var context = new SchoolDbContext())
            {
                var classList = context.Classes.ToList();

                List<Student> list = new List<Student>()
                {
                    new Student {StudentName = "Maria", Class = classList[0]},
                    new Student {StudentName = "Erik", Class = classList[0]},
                    new Student {StudentName = "Anna", Class = classList[0]},
                    new Student {StudentName = "Lars", Class = classList[0]},
                    new Student {StudentName = "Margareta", Class = classList[0]},

                    new Student {StudentName = "Karl", Class = classList[1]},
                    new Student {StudentName = "Elisabeth", Class = classList[1]},
                    new Student {StudentName = "Anders", Class = classList[1]},
                    new Student {StudentName = "Eva", Class = classList[1]},
                    new Student {StudentName = "Johan", Class = classList[1]},

                    new Student {StudentName = "Kristina", Class = classList[2]},
                    new Student {StudentName = "Per", Class = classList[2]},
                    new Student {StudentName = "Birgitta", Class = classList[2]},
                    new Student {StudentName = "Carl", Class = classList[2]},
                    new Student {StudentName = "Karin", Class = classList[2]}
                };

                foreach (var item in list)
                {
                    context.Students.Add(item);
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyClassCourses()
        {
            using (var context = new SchoolDbContext())
            {
                List<ClassCourse> classCourses = new List<ClassCourse>()
                {
                    new ClassCourse {Class = context.Classes.Where(c => c.ClassId == 1).FirstOrDefault(), Course = context.Courses.Where(c => c.CourseId == 1).FirstOrDefault()},
                    new ClassCourse {Class = context.Classes.Where(c => c.ClassId == 2).FirstOrDefault(), Course = context.Courses.Where(c => c.CourseId == 2).FirstOrDefault()},
                    new ClassCourse {Class = context.Classes.Where(c => c.ClassId == 3).FirstOrDefault(), Course = context.Courses.Where(c => c.CourseId == 3).FirstOrDefault()}
                };

                foreach (var item in classCourses)
                {
                    context.ClassCourses.Add(item);
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyStudentCourse()
        {
            using (var context = new SchoolDbContext())
            {
                List<StudentCourse> studentCourseList = new List<StudentCourse>()
                {
                    //Class 1, Teknik 2, Course Programming 1
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 1).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 1).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 2).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 1).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 3).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 1).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 4).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 1).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 5).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 1).FirstOrDefault()},
                    //Class 2, Teknik 2, Course Programming 2
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 6).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 2).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 7).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 2).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 8).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 2).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 9).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 2).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 10).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 2).FirstOrDefault()},
                    //Class 2, Teknik 2, Course Programming 3
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 6).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 7).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 8).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 9).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 10).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    //Class 3, Teknik 3, Course Programming 3
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 11).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 12).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 13).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 14).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()},
                    new StudentCourse {Student = context.Students.Where(x => x.StudentId == 15).FirstOrDefault(), Course = context.Courses.Where(x => x.CourseId == 3).FirstOrDefault()}
                };

                foreach (var item in studentCourseList)
                {
                    context.StudentCourses.Add(item);
                }
                context.SaveChanges();
            }
        }

        public static void CreateDummyTeacherCourse()
        {
            using(var context = new SchoolDbContext())
            {
                List<TeacherCourse> teacherCoursesList = new List<TeacherCourse>()
                {
                    new TeacherCourse {Teacher = context.Teachers.Where(t => t.TeacherId == 1).FirstOrDefault(), Course = context.Courses.Where(c => c.CourseId == 1).FirstOrDefault()},
                    new TeacherCourse {Teacher = context.Teachers.Where(t => t.TeacherId == 2).FirstOrDefault(), Course = context.Courses.Where(c => c.CourseId == 2).FirstOrDefault()},
                    new TeacherCourse {Teacher = context.Teachers.Where(t => t.TeacherId == 3).FirstOrDefault(), Course = context.Courses.Where(c => c.CourseId == 3).FirstOrDefault()}
                };

                foreach (var item in teacherCoursesList)
                {
                    context.TeacherCourses.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
