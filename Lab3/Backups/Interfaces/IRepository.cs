using Backups.Entities;

namespace Backups.Interfaces;

public interface IRepository
{
    public Stream Write(string path);
    public Stream ReadFile(string path);
    public void CreateDirectory(string path);
    public List<string> AllFilesInDirectory(string path);
    public FileType GetFileType(string path);
    public bool GetExistingPath(string path);
}