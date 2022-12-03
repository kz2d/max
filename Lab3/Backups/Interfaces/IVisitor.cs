using Backups.Entities;

namespace Backups.Interfaces;

public interface IVisitor
{
    public void VizitFile(IBackupObject file);
    public void VizitFolder(IBackupObject folder);
}