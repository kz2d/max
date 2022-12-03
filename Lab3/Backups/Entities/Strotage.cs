using Backups.Interfaces;

namespace Backups.Entities;

public class Strotage : IStrotage
{
    public Strotage(string name, List<string> archives)
    {
        Name = name;
        Files = archives;
    }

    public string Name { get; }
    public List<string> Files { get; }
}