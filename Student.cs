using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Student
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SlackHandle { get; set; }

        public int Cohort { get; set; }

        public List<Exercise> CurrentExercises = new List<Exercise>();
    }
}