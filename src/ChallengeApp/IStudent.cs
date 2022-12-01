namespace ChallengeApp
{
    public interface IStudent
    {
        delegate void LowGradeDelegate(object sender, EventArgs args);
        
        void AddGrade(string s);
        
        Statistics GetStatistics();
    }
}