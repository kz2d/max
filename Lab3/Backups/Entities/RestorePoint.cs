using Backups.Interfaces;

namespace Backups.Entities;

public class RestorePoint : IRestorePoint
{
    public RestorePoint(List<IBackupObject> objs, IStrotage pathToArchive)
    {
        Time = DateTime.Now;
        Objects = objs;
        Archive = pathToArchive;
    }

    public DateTime Time { get; }
    public IStrotage Archive { get; }

    public List<IBackupObject> Objects { get; }
}