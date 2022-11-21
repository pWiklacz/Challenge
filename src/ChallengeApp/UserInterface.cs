namespace ChallengeApp
{
    public class UserInterface
    {
        public void start()
        {
            var student = EnterStudentName();
            bool start = false;

            while (!start)
            {
                Console.WriteLine(
                    $"{student.Name}'s gradebook\n\n" +
                    "1. Add Grade\n" +
                    "2. Display student grades\n" +
                    "3. Display student statistics\n\n" +
                    "To end program press ESC!");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        EnterGrade(student);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine($"{student.Name}'s grades:\n");
                        student.DisplayGrades();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        ShowStats(student);
                        break;
                    case ConsoleKey.Escape:
                        start = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                if (!start)
                {
                    Console.Write("Press <Enter> to continue... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    Console.Clear();
                }
            }
        }


        private StudentBase EnterStudentName()
        {
            while (true)
            {
                Console.WriteLine("Enter student name: ");
                var input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    return new StudentInFile(input);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Name cannot be empty! Try again!");
                }
            }
        }

        private void EnterGrade(StudentBase student)
        {


            Console.WriteLine($"Enter grade for {student.Name} : ");
            var input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input))
            {
                Console.Clear();
                student.AddGrade(input);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Grade cannot be empty! Try again!");
            }
        }

        private void ShowStats(StudentBase student)
        {
            var stats = student.GetStatistics();
            Console.WriteLine(
                $"{student.Name}'s statistics:\n" +
                $"Highest grade : {stats.High}\n" +
                $"Lowest grade : {stats.Low}\n" +
                $"Avarage : {stats.Avarage}\n");
            if (stats.WhetherPassed)
            {
                Console.WriteLine($"{student.Name} passed to the next class with a grade of {stats.Letter}!");
            }
            else
            {
                Console.WriteLine($"{student.Name} failed to pass to the next class with a grade of {stats.Letter}!");
            }
        }

    }
}