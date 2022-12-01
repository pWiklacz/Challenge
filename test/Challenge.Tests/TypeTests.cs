using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests;

public class TypeTest
{
    [Fact]
    public void GetStudentSameTest()
    {
       var student1 = GetStudent("Stu1");
       var student2 = student1;
        Assert.Same(student1,student2); 
        Assert.True(Object.ReferenceEquals(student1,student2));   
    }

     [Fact]
    public void GetStudentNotSameTest()
    {
       var student1 = GetStudent("Stu1");
       var student2 = GetStudent("Stu2");
        Assert.NotSame(student1,student2);
        Assert.False(Object.ReferenceEquals(student1,student2)); 
    }

    private IStudent GetStudent(string name)
    {
        return new StudentInMemory(name);
    }
}