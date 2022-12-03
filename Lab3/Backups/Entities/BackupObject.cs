using Backups.Interfaces;

namespace Backups.Entities;

public class BackupObject : IBackupObject
{
    public BackupObject(string path, IRepository rep)
    {
        Path = path;
        Rep = rep;
        Type = rep.GetFileType(path);
    }

    public IRepository Rep { get; }
    public string Path { get; }
    public FileType Type { get; }
    public void Visit(IVisitor visitor)
    {
        if (Type == FileType.Directory)
        {
            Rep.AllFilesInDirectory(Path).ForEach(s => new BackupObject(s, Rep).Visit(visitor));
        }
        else
        {
            visitor.VizitFile(this);
        }
    }

    public Stream GetFile()
    {
        if (Type == FileType.Directory)
        {
            throw new Exception();
        }

        return Rep.ReadFile(Path);
    }
}