using System;
using IMP.Core;
using Imp.Core.Domain.Users;

namespace Imp.Core.Domain.Files
{
    /// <summary>
    /// file
    /// </summary>
    public class File : BaseEntity
    {
        /// <summary>
        /// file name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// owner user id
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// create date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// last modified date
        /// </summary>
        public DateTime? LastModifyDate { get; set; }

        /// <summary>
        /// directory id
        /// </summary>
        public string DirectoryId { get; set; }

        /// <summary>
        /// is deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// owner entity
        /// </summary>
        public virtual User Owner { get; set; }

        /// <summary>
        /// directory entity
        /// </summary>
        public virtual Directory Directory { get; set; }
    }
}
