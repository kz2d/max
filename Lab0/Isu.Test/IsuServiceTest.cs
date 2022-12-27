using Isu.Interfaces;
using Isu.Services;
using NUnit.Framework;

namespace Isu.Test;

[TestFixture]
public class IsuServiceTest
{
    private IIsuService<IGroup, IStudent> _service = null!;

    [SetUp]
    public void SetUp()
    {
        _service = new IsuService();
    }

    [Test]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        // Arrange
        var group = _service.AddGroup("m3101");

        // Act
        var student = _service.AddStudent(group, "John");

        // Assert
        Assert.AreEqual(group, student.Group);
        Assert.Contains(student, _service.FindStudents("m3101"));
    }

    [Test]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        // Arrange
        var group = _service.AddGroup("m3101");
        for (int i = 0; i < 10; i++)
        {
            _service.AddStudent(group, $"Student {i}");
        }

        // Act and Assert
        Assert.Throws<ArgumentException>(() => _service.AddStudent(group, "John"));
    }

    [Test]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        var groupName1 = "m3101";
        var groupName2 = "m3201";

        // Arrange
        var group1 = _service.AddGroup(groupName1);
        var group2 = _service.AddGroup(groupName2);
        var student = _service.AddStudent(group1, "John");

        // Act
        _service.ChangeStudentGroup(student, group2);

        // Assert
        Assert.AreEqual(group2, student.Group);
        Assert.Contains(student, _service.FindStudents(groupName2));
        Assert.False(_service.FindStudents(groupName1).Contains(student));
    }
}