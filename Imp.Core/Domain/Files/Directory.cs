using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;
using Imp.Core.Domain.Users;

namespace Imp.Core.Domain.Files
{
    public class Directory : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifyDate { get; set; }

        public string OwnerId { get; set; }

        public bool IsRoot { get; set; }

        public string ParentDirectoryId { get; set; }

        public virtual Directory ParentDirectory { get; set; }

        public virtual User Owner { get; set; }
    }
}
