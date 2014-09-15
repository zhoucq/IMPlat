using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Imp.Core.Domain.Files;

namespace Imp.Services.Files
{
    public interface IFileService
    {
        Directory GetDirectory(string directoryId);

        IList<Directory> GetSubDirectories(string parentDirectoryId);

        void CreateDirectory(Directory directory);
    }
}