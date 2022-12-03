namespace Backups.Interfaces;

public interface IRestorePoint
{
    public DateTime Time { get; }
    public IStrotage Archive { get; }

    public List<IBackupObject> Objects { get; }
}