using Isu.Extra.Entities;
using Isu.Interfaces;

namespace Isu.Extra.Interfaces;

public interface IStudentNew : IStudent
{
    public List<IPair> Pairs { get; set; }
    public new IGroupNew Group { get; }
    public int CourseCount { get; set; }
}