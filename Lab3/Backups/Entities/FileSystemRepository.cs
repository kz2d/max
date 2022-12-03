using Backups.Interfaces;

namespace Backups.Entities;

public class FileSystemRepository : IRepository
{
    public FileSystemRepository(string path)
    {
        Root = Path.GetFullPath(path);
    }

    private string Root { get; }

    public Stream CreateFile(string path)
    {
        return new FileStream(Path.Join(Root, path), FileMode.OpenOrCreate, FileAccess.Write);
    }

    public void CreateDirectory(string path)
    {
        Directory.CreateDirectory(path);
    }

    public List<string> AllFilesInDirectory(string path)
    {
        if (GetFileType(path) == FileType.File)
        {
            throw new Exception();
        }

        return Directory.GetFiles(path).ToList().Concat(Directory.GetDirectories(path)
            .Select(AllFilesInDirectory).Aggregate((list, list1) => list.Concat(list1).ToList())).ToList();
    }

    public FileType GetFileType(string path)
    {
        return Directory.Exists(Path.Join(Root, path)) ? FileType.Directory : FileType.File;
    }

    public Stream ReadFile(string path)
    {
        return new FileStream(Path.Join(Root, path), FileMode.Open);
    }

    public bool GetExistingPath(string path)
    {
        return Directory.Exists(Path.Join(Root, path)) || File.Exists(Path.Join(Root, path));
    }

    public Stream Write(string path)
    {
        return new FileStream(Path.Join(Root, path), FileMode.OpenOrCreate);
    }
}