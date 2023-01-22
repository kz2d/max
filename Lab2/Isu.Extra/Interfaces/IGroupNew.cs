using Isu.Extra.Entities;
using Isu.Interfaces;

namespace Isu.Extra.Interfaces;

public interface IGroupNew : IGroup
{
    public Megafacultet Megafacultet { get; }
    public List<IStudentNew> Student { get; }
}