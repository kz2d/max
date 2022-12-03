namespace Backups.Interfaces;

public interface IBackupObject
{
    public string Path { get; }
    public IRepository Rep { get; }
    public void Visit(IVisitor visitor);
    public Stream GetFile();
}

public enum FileType
{
    Directory,
    File,
}