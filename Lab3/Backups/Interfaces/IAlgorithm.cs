using Backups.Entities;

namespace Backups.Interfaces;

public interface IAlgorithm
{
    public IStrotage Run(List<IBackupObject> objs, IArchive arc, IRepository rep);
}