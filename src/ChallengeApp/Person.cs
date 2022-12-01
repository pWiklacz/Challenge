namespace ChallengeApp
{
    public class Person
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
             set
            {
                this.name = value;
            }
        }

        public Person(string _name)
        {
            this.name = _name;
        }
    }
}