using System.IO.Compression;
using Backups.Entities;
using Backups.Interfaces;

namespace Backups.Tools;

public class SingleFileArchiver : IArchive
{
    public string Archive(List<IBackupObject> objs, IRepository rep)
    {
        var path = $".hi/{Guid.NewGuid().ToString()}";
        rep.CreateDirectory(".hi");
        var r = rep.Write(path);

        var zip = new ZipArchive(r, ZipArchiveMode.Create);

        var visitor = new ZipVisitor(zip);

        foreach (var obj in objs)
        {
            obj.Visit(visitor);
        }

        return path;
    }
}