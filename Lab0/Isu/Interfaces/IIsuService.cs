using Isu.Entyties;

namespace Isu.Interfaces;

public interface IIsuService<TG, TS>
    where TG : IGroup
    where TS : IStudent
{
    TG AddGroup(string name);
    TS AddStudent(TG group, string name);

    TS? GetStudent(int id);
    List<TS> FindStudents(string groupName);
    List<TS> FindStudents(int courseNumber);

    TG? FindGroup(string groupName);
    List<TG> FindGroups(int courseNumber);

    void ChangeStudentGroup(TS student, TG newGroup);
}
