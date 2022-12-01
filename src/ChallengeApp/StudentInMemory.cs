using System;
using System.Collections;

namespace ChallengeApp
{
    public class StudentInMemory : StudentBase
    {
        List<double> grades;
        public override event IStudent.LowGradeDelegate LowGradeAdded;
        public StudentInMemory(string n) : base(n)
        {
            this.grades = new List<double>();
            LowGradeAdded += IfLowGradeAdded;
        }

        public override void AddGrade(string s)
        {
            try
            {
                var grade = GradeFromString(s);
                grades.Add(grade);
                if (grade < 3.0 && LowGradeAdded != null)
                {
                    LowGradeAdded(this, new EventArgs());
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // public void AddGradeFromString(string s)        Metoda z zadania 8, zakomentowałem ponieważ teraz używana jest lepsza wersja.
        // {
        //     if(int.TryParse(s, out int number))
        //     {
        //         grades.Add(number);
        //     }
        //     else Console.WriteLine($"\"{s}\" its not a Integer!");
        // }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();

            foreach (var item in grades)
            {
                stats.Add(item);
            }

            return stats;
        }
        
        private void ChangeName(string s)
        {
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    System.Console.WriteLine("Invalid name");
                }
                else this.Name = s;
            }

        }

        public override void DisplayGrades()
        {
            foreach (var item in grades)
            {
                Console.WriteLine(item + "\t\t\t" + DateTime.UtcNow.ToString());
            }
        }
    }
}