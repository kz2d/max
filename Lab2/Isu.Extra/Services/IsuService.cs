using Isu.Extra.Entities;
using Isu.Extra.Interfaces;
using Isu.Interfaces;
using Stream = Isu.Extra.Entities.Stream;

namespace Isu.Extra.Services;

public class IsuService
{
    private readonly List<ICourse> _courses;
    private readonly List<IGroupNew> _groups;

    public IsuService()
    {
        _courses = new List<ICourse>();
        _groups = new List<IGroupNew>();
    }

    public void AddCourse(ICourse course)
    {
        _courses.Add(course);
    }

    public void AddGroup(IGroupNew group)
    {
        _groups.Add(group);
    }

    public void RegisterStudent(IStudentNew st, IStream stream)
    {
        stream.AddStudent(st);
    }

    public void RemoveStudentFromCourse(IStudentNew st, IStream stream)
    {
        stream.DeleteStudent(st);
    }

    public List<IStream> GetSteams(ICourse c)
    {
        return c.Streams;
    }

    public List<IStudentNew> GetStudentsFromCourse(ICourse c)
    {
        return c.Streams.SelectMany(x => x.Students).ToList();
    }

    public List<IStudentNew> GetUnsubscribedStudents(IGroupNew group)
    {
        return group.Student.FindAll(x => x.CourseCount != 2).ToList();
    }
}
