using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Instructor
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SlackHandle { get; set; }

        public int Cohort { get; set; }

        public string Specialty { get; set; }

        public void AssignExercise(Student StudentName, Exercise ExerciseName)
        {
            StudentName.CurrentExercises.Add(ExerciseName);
        }
    }
}