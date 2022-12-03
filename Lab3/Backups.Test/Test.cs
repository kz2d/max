using Backups.Entities;
using Backups.Interfaces;
using Backups.Services;
using Backups.Tools;
using Xunit;

namespace Backups.Test;

public class BackupsTest
{
    [Fact]
    public void First()
    {
        var alg = new SingleStrotageAlgoritm();
        var arc = new SingleFileArchiver();
        var rep = new FileSystemRepository(".");

        rep.CreateFile("hoh1.txt").Close();
        rep.CreateFile("hoh2.txt").Close();
        rep.CreateFile("hoh3.txt").Close();

        var obj1 = new BackupObject("hoh1.txt", rep);
        var obj2 = new BackupObject("hoh2.txt", rep);

        var back = new BackupTask("hi", new List<IBackupObject> { obj1, obj2 }, alg, rep, arc);
        back.Run();

        var obj3 = new BackupObject("hoh3.txt", rep);
        back.AddBackupObject(obj3);

        back.Run();
        Assert.Equal(2, back.RestorePoints.Count);
    }

    [Fact]
    public void Second()
    {
        var alg = new MultipleStrotageAlgoritm();
        var arc = new SingleFileArchiver();
        var rep = new FileSystemRepository(".");

        rep.CreateFile("hoh1.txt").Close();
        rep.CreateFile("hoh2.txt").Close();
        rep.CreateFile("hoh3.txt").Close();

        var obj1 = new BackupObject("hoh1.txt", rep);
        var obj2 = new BackupObject("hoh2.txt", rep);

        var back = new BackupTask("hi", new List<IBackupObject> { obj1, obj2 }, alg, rep, arc);
        back.Run();

        var obj3 = new BackupObject("hoh3.txt", rep);
        back.AddBackupObject(obj3);

        back.Run();
        Assert.Equal(2, back.RestorePoints.Count);
    }
}