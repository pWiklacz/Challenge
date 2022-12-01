namespace ChallengeApp
{

    public abstract class StudentBase : Person, IStudent
    {
        public StudentBase(string _name) : base(_name) {}

        public abstract event IStudent.LowGradeDelegate LowGradeAdded;

        public abstract void AddGrade(string s);

        public abstract Statistics GetStatistics();

        public abstract void DisplayGrades();

        protected virtual double GradeFromString(string s)
        {
            double d = 0;

            if (s.Length == 2 || s.Length == 1)
            {
                if (char.IsDigit(s[0]))
                {
                    int i = s[0] - 48;
                    if (i > 0 && i <= 6)
                    {
                        d += i;
                        if (s.Length == 2)
                        {
                            switch (s[1])
                            {
                                case '+':
                                    return d += 0.5;
                                case '-':
                                    return d -= 0.25;
                                default:
                                    throw new ArgumentException($"\"{s}\" is a invalid value of grade!");
                            }
                        }
                        else return d;
                    }
                    else throw new ArgumentException($"\"{s}\" is a invalid value of grade!");
                }
                else throw new FormatException($"\"{s}\" is a invalid grade format!");
            }
            else throw new FormatException($"\"{s}\" is a invalid grade format!");
        }
        
        protected virtual void IfLowGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no! We should inform student’s parents about this fact");
        }
    }
}