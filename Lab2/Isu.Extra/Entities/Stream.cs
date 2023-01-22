using Isu.Extra.Interfaces;
using Isu.Extra.Tools.Exceptions;

namespace Isu.Extra.Entities;

public class Stream : IStream
{
    public Stream(Course course, int maxPlaces)
    {
        Course = course;
        MaxPlaces = maxPlaces;
    }

    public Course Course { get; set; }
    public int MaxPlaces { get; set; }
    public List<IPair> Schedule { get; set; } = new List<IPair>();
    public List<IStudentNew> Students { get; set; } = new List<IStudentNew>();

    public void AddStudent(IStudentNew student)
    {
        if (Students.Count >= MaxPlaces)
        {
            CourseExeprions.OutOfPlaces();
        }

        if (student.Group.Megafacultet == Course.Megafacultet)
        {
            CourseExeprions.SameFacultet();
        }

        if (student.Pairs.Any(s => Schedule.Any(x => x.Time == s.Time)))
        {
            CourseExeprions.ConflictWithShedule();
        }

        Students.Add(student);
        student.Pairs.AddRange(Schedule);
        student.CourseCount += 1;
    }

    public void DeleteStudent(IStudentNew student)
    {
        Students.Remove(student);
        student.CourseCount -= 1;
        student.Pairs.RemoveAll(s => Schedule.Any(x => x.Time == s.Time));
    }
}