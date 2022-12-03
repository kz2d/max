using Backups.Entities;
using Backups.Interfaces;

namespace Backups.Tools;

public class MultipleStrotageAlgoritm : IAlgorithm
{
    public IStrotage Run(List<IBackupObject> objs, IArchive arc, IRepository rep)
    {
        var l = new List<string>();
        foreach (var backupObject in objs)
        {
            l.Add(arc.Archive(objs, rep));
        }

        return new Strotage("ho", l);
    }
}