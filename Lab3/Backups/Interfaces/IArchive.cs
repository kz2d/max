using Backups.Entities;

namespace Backups.Interfaces;

public interface IArchive
{
    public string Archive(List<IBackupObject> objs, IRepository rep);
}