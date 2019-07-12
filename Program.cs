using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise ChickenMonkey = new Exercise();
            ChickenMonkey.id = 1;
            ChickenMonkey.Name = "ChickenMonkey";
            ChickenMonkey.Language = "Javascript";

            Exercise TreeChallenge = new Exercise();
            TreeChallenge.id = 2;
            TreeChallenge.Name = "Tree Challenge";
            TreeChallenge.Language = "Javascript";

            Exercise StudentExercises = new Exercise();
            StudentExercises.id = 3;
            StudentExercises.Name = "Student Exercises";
            StudentExercises.Language = "C#";

            Exercise EnglishIdioms = new Exercise();
            EnglishIdioms.id = 4;
            EnglishIdioms.Name = "English Idioms";
            EnglishIdioms.Language = "C#";

            Exercise HowManySocks = new Exercise();
            HowManySocks.id = 5;
            HowManySocks.Name = "How Many Socks?";
            HowManySocks.Language = "Python";

            Exercise KandyKorner = new Exercise();
            KandyKorner.id = 6;
            KandyKorner.Name = "Kandy Korner";
            KandyKorner.Language = "React";

            Cohort Cohort32 = new Cohort();
            Cohort32.CohortId = 32;
            Cohort32.CohortTime = "Day";

            Cohort Cohort34 = new Cohort();
            Cohort34.CohortId = 34;
            Cohort34.CohortTime = "Day";

            Cohort Cohort10 = new Cohort();
            Cohort10.CohortId = 10;
            Cohort10.CohortTime = "Night";

            Cohort Cohort35 = new Cohort();
            Cohort35.CohortId = 35;
            Cohort35.CohortTime = "Day";

            Student Student1 = new Student();
            Student1.id = 1;
            Student1.FirstName = "Eliot";
            Student1.LastName = "Clarke";
            Student1.SlackHandle = "Eliot";
            Student1.Cohort = 32;

            Student Student2 = new Student();
            Student2.id = 2;
            Student2.FirstName = "Jason";
            Student2.LastName = "Brooks";
            Student2.SlackHandle = "JBrooks";
            Student2.Cohort = 32;

            Student Student3 = new Student();
            Student3.id = 3;
            Student3.FirstName = "Jacob";
            Student3.LastName = "Best-Wittenberg";
            Student3.SlackHandle = "JacobWittenberg";
            Student3.Cohort = 35;

            Student Student4 = new Student();
            Student4.id = 4;
            Student4.FirstName = "Sean";
            Student4.LastName = "Glavin";
            Student4.SlackHandle = "S.Glavin";
            Student4.Cohort = 32;

            Student Student5 = new Student();
            Student5.id = 5;
            Student5.FirstName = "Shelley";
            Student5.LastName = "Arnold";
            Student5.SlackHandle = "ItShelley";
            Student5.Cohort = 32;

            Instructor Instructor1 = new Instructor();
            Instructor1.id = 1;
            Instructor1.FirstName = "Steve";
            Instructor1.LastName = "Brownlee";
            Instructor1.SlackHandle = "coach";
            Instructor1.Cohort = 34;
            Instructor1.Specialty = "Pure Knowledge";

            Instructor Instructor2 = new Instructor();
            Instructor2.id = 2;
            Instructor2.FirstName = "Adam";
            Instructor2.LastName = "Shaeffer";
            Instructor2.SlackHandle = "TheAdam";
            Instructor2.Cohort = 32;
            Instructor2.Specialty = "Topical Humor";

            Instructor Instructor3 = new Instructor();
            Instructor3.id = 3;
            Instructor1.FirstName = "Jisie";
            Instructor1.LastName = "David";
            Instructor1.SlackHandle = "j-daaavey";
            Instructor1.Cohort = 32;
            Instructor1.Specialty = "Experience";

            Instructor Instructor4 = new Instructor();
            Instructor4.id = 4;
            Instructor4.FirstName = "Bryan";
            Instructor4.LastName = "Nilsen";
            Instructor4.SlackHandle = "BryanF*ckingNilsen";
            Instructor4.Cohort = 33;
            Instructor4.Specialty = "High Fives";

            Instructor1.AssignExercise(Student5, ChickenMonkey);
            Instructor1.AssignExercise(Student4, ChickenMonkey);

            Instructor2.AssignExercise(Student1, StudentExercises);
            Instructor2.AssignExercise(Student1, TreeChallenge);

            Instructor3.AssignExercise(Student2, EnglishIdioms);
            Instructor3.AssignExercise(Student4, HowManySocks);

            Instructor4.AssignExercise(Student1, KandyKorner);
            Instructor4.AssignExercise(Student2, TreeChallenge);

            List<Student> students = new List<Student>(){
                Student1, Student2, Student3, Student4, Student5
            };

            List<Exercise> exercises = new List<Exercise>(){
                ChickenMonkey, TreeChallenge, StudentExercises, EnglishIdioms, HowManySocks, KandyKorner
            };

            List<Cohort> cohorts = new List<Cohort>() {
                Cohort10, Cohort32, Cohort34, Cohort35
            };

            List<Instructor> instructors = new List<Instructor>() {
                Instructor1, Instructor2, Instructor3, Instructor4
            };

            exercises.ForEach(exe =>
            {
                var exerciseId = exe.id;
                Console.WriteLine();
                Console.WriteLine($"Current Students working on {exe.Name} are:");

                students.ForEach(stu =>
                {
                    stu.CurrentExercises.ForEach(currentExe =>
                    {
                        if (exe.id == currentExe.id)
                        {
                            Console.WriteLine($"{stu.FirstName} {stu.LastName}");
                        }
                    });
                });
            });
            Console.WriteLine();

            IEnumerable<Exercise> jsExercises =
                from exercise in exercises
                where exercise.Language == "Javascript"
                select exercise;

            IEnumerable<Student> students32 =
                from student in students
                where student.Cohort == 32
                select student;

            IEnumerable<Instructor> instructors32 =
                from instructor in instructors
                where instructor.Cohort == 32
                select instructor;

            List<Student> orderedStudents = students.OrderBy(n => n.LastName).ToList();

            IEnumerable<Student> newStudents =
                from student in students
                where student.CurrentExercises.Count == 0
                select student;

            Student busyStudent = students.OrderByDescending(n => n.CurrentExercises.Count).ToList()[0];

            var cohortCount =
                from student in students
                join cohort in cohorts on student.Cohort equals cohort.CohortId
                group student by student.Cohort into cohortGroup

                //unecessary list, but still cool that you can just make a list on the fly with LET
                let studentList = cohortGroup
                select new
                {
                    Cohort = cohortGroup.Key,
                    studentList = studentList
                };



            foreach (var group in cohortCount)
            {
                Console.WriteLine();
                Console.WriteLine($"There are {group.studentList.Count()} in Cohort {group.Cohort}:");
                foreach (var student in group.studentList)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }

            }

        }
    }
}
