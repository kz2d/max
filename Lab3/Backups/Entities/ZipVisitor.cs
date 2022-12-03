using System.IO.Compression;
using Backups.Interfaces;

namespace Backups.Entities;

public class ZipVisitor : IVisitor
{
    private ZipArchive zip;
    public ZipVisitor(ZipArchive archive)
    {
        zip = archive;
    }

    public void VizitFile(IBackupObject file)
    {
        ZipArchiveEntry entry = zip.CreateEntry(Path.GetFileName(file.Path));
        using Stream stream = entry.Open();
        Stream fileStream = file.GetFile();
        fileStream.CopyTo(stream);
    }

    public void VizitFolder(IBackupObject folder)
    {
        var rep = folder.Rep;
        rep.AllFilesInDirectory(folder.Path).ForEach(s => new BackupObject(s, rep).Visit(this));
    }
}