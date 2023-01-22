using Isu.Extra.Entities;
using Isu.Interfaces;

namespace Isu.Extra.Interfaces;

public interface IStream
{
    public List<IPair> Schedule { get; }
    public List<IStudentNew> Students { get; }

    public void AddStudent(IStudentNew student);
    public void DeleteStudent(IStudentNew student);
}