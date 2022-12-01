namespace ChallengeApp
{
    public class StudentInFile : StudentBase
    {
        private const string filename = "Grades.txt";
        private const string audit = "audit.txt";
        public override event IStudent.LowGradeDelegate LowGradeAdded;
        public StudentInFile(string _name) : base(_name)
        {
            LowGradeAdded += IfLowGradeAdded;
        }

        public override void AddGrade(string s)
        {
            using (var writer = File.AppendText(Name + "." + filename))
            {
                using (var writer2 = File.AppendText(Name + "." + audit))
                {
                    try
                    {
                        var grade = GradeFromString(s);
                        writer.WriteLine(grade);
                        writer2.WriteLine(grade + "\t\t\t" + DateTime.UtcNow.ToString());
                        Console.WriteLine("Grade added!");
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
            }
        }
        
        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            using (var reader = File.OpenText(Name + "." + filename))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    stats.Add(number);
                    line = reader.ReadLine();
                }
            }
            return stats;
        }

        public override void DisplayGrades()
        {
            using (var reader = File.OpenText(Name + "." + audit))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}