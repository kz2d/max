using System.Diagnostics;
using IsuServiceTests.Entyties;
using IsuServiceTests.Interfaces;

namespace IsuServiceTests.Services;

public class IsuService : IIsuService
{
    private Dictionary<int, Student> _students;
    private Dictionary<string, Group> _groups;

    public IsuService()
    {
        _students = new Dictionary<int, Student>();
        _groups = new Dictionary<string, Group>();
    }

    public Group AddGroup(string name)
    {
        if (_groups.ContainsKey(name))
        {
            throw new ArgumentException($"Group with name {name} already exists.");
        }

        var group = new Group(name);
        _groups.Add(name, group);
        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        if (_students.Count((x) => x.Value.Group.Name == group.Name) >= 10)
        {
            throw new ArgumentException("too many student in the group");
        }

        var student = new Student(group, name);
        _students.Add(student.Id, student);
        return student;
    }

    public Student GetStudent(int id)
    {
        if (!_students.ContainsKey(id))
        {
            throw new ArgumentException($"Student with id {id} does not exist.");
        }

        return _students[id];
    }

    public Student? FindStudent(int id)
    {
        return _students.ContainsKey(id) ? _students[id] : null;
    }

    public List<Student> FindStudents(string groupName)
    {
        if (!_groups.ContainsKey(groupName))
        {
            throw new ArgumentException($"Group with name {groupName} does not exist.");
        }

        return _students.Values.Where(s => s.Group.Name == groupName).ToList();
    }

    public List<Student> FindStudents(int courseNumber)
    {
        var groups = FindGroups(courseNumber);
        var students = new List<Student>();

        foreach (var group in groups)
        {
            students.AddRange(FindStudents(group.Name));
        }

        return students;
    }

    public Group? FindGroup(string groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }

    public List<Group> FindGroups(int courseNumber)
    {
        return _groups.Values.Where(g => g.CourseNumber == courseNumber).ToList();
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        if (!_students.ContainsKey(student.Id))
        {
            throw new ArgumentException($"Student with id {student.Id} does not exist.");
        }

        if (!_groups.ContainsKey(newGroup.Name))
        {
            throw new ArgumentException($"Group with name {newGroup.Name} does not exist.");
        }

        student.Group = newGroup;
    }
}
