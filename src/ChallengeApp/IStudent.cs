namespace ChallengeApp
{
    public interface IStudent
    {
        string Name { get; set; }
        delegate void LowGradeDelegate(object sender, EventArgs args);
        
        void AddGrade(string s);
        
        Statistics GetStatistics();
    }
}