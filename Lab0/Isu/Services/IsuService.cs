using System.Diagnostics;
using Isu.Entyties;
using Isu.Interfaces;

namespace Isu.Services;

public class IsuService : IIsuService<IGroup, IStudent>
{
    private Dictionary<int, IStudent> _students;
    private Dictionary<string, IGroup> _groups;

    public IsuService()
    {
        _students = new Dictionary<int, IStudent>();
        _groups = new Dictionary<string, IGroup>();
    }

    public IGroup AddGroup(string name)
    {
        if (_groups.ContainsKey(name))
        {
            throw new ArgumentException($"Group with name {name} already exists.");
        }

        var group = new Group(name);
        _groups.Add(name, group);
        return group;
    }

    public IStudent AddStudent(IGroup group, string name)
    {
        if (_students.Count((x) => x.Value.Group.Name == group.Name) >= 10)
        {
            throw new ArgumentException("too many student in the group");
        }

        var student = new Student(group, name);
        _students.Add(student.Id, student);
        return student;
    }

    public IStudent GetStudent(int id)
    {
        if (!_students.ContainsKey(id))
        {
            throw new ArgumentException($"Student with id {id} does not exist.");
        }

        return _students[id];
    }

    public List<IStudent> FindStudents(string groupName)
    {
        if (!_groups.ContainsKey(groupName))
        {
            throw new ArgumentException($"Group with name {groupName} does not exist.");
        }

        return _students.Values.Where(s => s.Group.Name == groupName).ToList();
    }

    public List<IStudent> FindStudents(int courseNumber)
    {
        var groups = FindGroups(courseNumber);
        var students = new List<IStudent>();

        foreach (var group in groups)
        {
            students.AddRange(FindStudents(group.Name));
        }

        return students;
    }

    public IGroup? FindGroup(string groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }

    public List<IGroup> FindGroups(int courseNumber)
    {
        return _groups.Values.Where(g => g.CourseNumber == courseNumber).ToList();
    }

    public void ChangeStudentGroup(IStudent student, IGroup newGroup)
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
