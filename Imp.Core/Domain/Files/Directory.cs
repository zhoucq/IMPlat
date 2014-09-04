using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;
using Imp.Core.Domain.Users;

namespace Imp.Core.Domain.Files
{
    /// <summary>
    /// directory
    /// </summary>
    public class Directory : BaseEntity
    {

        private ICollection<Directory> _subDirectories;
        private ICollection<File> _files;

        /// <summary>
        /// name of directory
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// date created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// date last modified
        /// </summary>
        public DateTime? LastModifyDate { get; set; }

        /// <summary>
        /// userid of owner
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// root directory
        /// </summary>
        public bool IsRoot { get; set; }

        /// <summary>
        /// parent directory id
        /// </summary>
        public string ParentDirectoryId { get; set; }

        /// <summary>
        /// parent directory entity
        /// </summary>
        public virtual Directory ParentDirectory { get; set; }

        /// <summary>
        /// sub directories
        /// </summary>
        public virtual ICollection<Directory> SubDirectories
        {
            get
            {
                return _subDirectories ?? (_subDirectories = new List<Directory>());
            }
            set { _subDirectories = value; }
        }

        /// <summary>
        /// files
        /// </summary>
        public virtual ICollection<File> Files
        {
            get
            {
                return _files ?? (_files = new List<File>());
            }
            set { _files = value; }
        }

        /// <summary>
        /// owner entity
        /// </summary>
        public virtual User Owner { get; set; }
    }
}
