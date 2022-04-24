﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class ClassCourse
    {
        public int ClassCourseId { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
