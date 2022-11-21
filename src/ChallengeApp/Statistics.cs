namespace ChallengeApp
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Sum;
        public int Count;
        public double Avarage
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public bool WhetherPassed
        {
            get
            {
                if (Avarage >= 1.51)
                    return true;
                else
                    return false;
            }
        }
        public char Letter
        {
            get
            {
                switch (Avarage)
                {
                    case var d when d >= 4.51:
                        return 'A';
                    case var d when d >= 3.51:
                        return 'B';
                    case var d when d >= 2.51:
                        return 'C';
                    case var d when d >= 1.51:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0.0;
            this.Low = double.MaxValue;
            this.High = double.MinValue;
        }
        public void Add(double number)
        {
            this.Sum += number;
            this.Count++;
            this.Low = Math.Min(number, this.Low);
            this.High = Math.Max(number, this.High);
        }
    }

}