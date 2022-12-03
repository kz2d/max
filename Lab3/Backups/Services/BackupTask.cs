using System.Runtime.InteropServices.ComTypes;
using Backups.Entities;
using Backups.Interfaces;

namespace Backups.Services;

public class BackupTask : IBackupTask
{
    private List<IBackupObject> _watchableObj;
    private IRepository _rep;

    public BackupTask(string name, List<IBackupObject> backObj, IAlgorithm algo, IRepository repository, IArchive archive)
    {
        Archiver = archive ?? throw new NullReferenceException();
        Algo = algo ?? throw new NullReferenceException();
        _watchableObj = backObj ?? throw new NullReferenceException();
        _rep = repository ?? throw new NullReferenceException();
    }

    public List<RestorePoint> RestorePoints { get; } = new List<RestorePoint>();
    private IAlgorithm Algo { get; }
    private IArchive Archiver { get; }

    public void AddBackupObject(IBackupObject back)
    {
        _watchableObj.Add(back);
    }

    public IRestorePoint Run()
    {
        var rp = new RestorePoint(_watchableObj, Algo.Run(_watchableObj, Archiver, _rep));
        RestorePoints.Add(rp);
        return rp;
    }
}