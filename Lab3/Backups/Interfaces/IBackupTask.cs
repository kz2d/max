using Backups.Entities;

namespace Backups.Interfaces;

public interface IBackupTask
{
    public void AddBackupObject(IBackupObject back);
    public IRestorePoint Run();
}