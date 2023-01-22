using Isu.Extra.Entities;

namespace Isu.Extra.Interfaces;

public interface ICourse
{
    public List<IStream> Streams { get; }
    public Megafacultet Megafacultet { get; }
}