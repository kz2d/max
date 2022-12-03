using Backups.Entities;
using Backups.Interfaces;

namespace Backups.Tools;

public class SingleStrotageAlgoritm : IAlgorithm
{
    public IStrotage Run(List<IBackupObject> objs, IArchive arc, IRepository rep)
    {
        return new Strotage("hi", new List<string> { arc.Archive(objs, rep) });
    }
}