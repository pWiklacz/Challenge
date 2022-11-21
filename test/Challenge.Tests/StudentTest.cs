using ChallengeApp;

namespace Challenge.Tests;



public class UnitTest1
{
    [Fact]
    public void GetAvarageTest()
    {
        var student1 = new StudentInMemory("Patryk");

        student1.AddGrade("4");
        student1.AddGrade("3-");
        student1.AddGrade("2");

        var stats = student1.GetStatistics();

        Assert.Equal(4.4, stats.Avarage , 1);
        
    }
}