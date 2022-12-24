using IsuServiceTests.Entyties;

namespace IsuServiceTests.Interfaces;

public interface IIsuService
{
    Group AddGroup(string name);
    Student AddStudent(Group group, string name);

    Student GetStudent(int id);
    Student? FindStudent(int id);
    List<Student> FindStudents(string groupName);
    List<Student> FindStudents(int courseNumber);

    Group? FindGroup(string groupName);
    List<Group> FindGroups(int courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}
