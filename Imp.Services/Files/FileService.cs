using System;
using System.Collections.Generic;
using System.Linq;
using Imp.Core.Data;
using Imp.Core.Domain.Files;

namespace Imp.Services.Files
{
    public class FileService : IFileService
    {
        #region Fields
        private IRepository<Directory> _directoryRepository;
        private IRepository<File> _fileRepository;
        #endregion

        #region Ctor
        public FileService(IRepository<Directory> directoryRepository, IRepository<File> fileRepository)
        {
            _directoryRepository = directoryRepository;
            _fileRepository = fileRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// get a directory
        /// </summary>
        /// <param name="directoryId"></param>
        /// <returns></returns>
        public Directory GetDirectory(string directoryId)
        {
            if (string.IsNullOrWhiteSpace(directoryId))
            {
                throw new ArgumentNullException("directoryId");
            }
            return _directoryRepository.GetById(directoryId);
        }

        /// <summary>
        /// get sub directories
        /// </summary>
        /// <param name="parentDirectoryId"></param>
        /// <returns></returns>
        public IList<Directory> GetDirectories(string parentDirectoryId)
        {
            var query = from o in _directoryRepository.Table
                        where o.ParentDirectoryId == parentDirectoryId
                        select o;
            return query.ToList();
        }

        /// <summary>
        /// create directory
        /// </summary>
        /// <param name="directory"></param>

        public void CreateDirectory(Directory directory)
        {
            if (directory == null) throw new ArgumentNullException("directory");
            _directoryRepository.Insert(directory);
        }
        #endregion
    }
}