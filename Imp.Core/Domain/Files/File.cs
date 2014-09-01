using System;
using IMP.Core;
using Imp.Core.Domain.Users;

namespace Imp.Core.Domain.Files
{
    public class File : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateUserId { get; set; }

        public DateTime LastModifyDate { get; set; }

        public string LastModifyUserId { get; set; }

        public virtual User CreateUser { get; set; }

        public virtual User LastModifyUser { get; set; }
    }
}
