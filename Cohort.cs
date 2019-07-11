using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Cohort
    {
        public int CohortId { get; set; }

        public string CohortTime { get; set; }

        public List<Student> Students = new List<Student>();

        public List<Instructor> Instructors = new List<Instructor>();

    }
}