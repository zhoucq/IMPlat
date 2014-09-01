using System;
using System.Collections.Generic;

namespace Imp.Data.Models
{
    public partial class DL_Directory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentDirectoryId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastModifyDate { get; set; }
    }
}
