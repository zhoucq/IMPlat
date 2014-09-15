using System;
using System.Collections;
using System.Collections.Generic;
using Imp.Web.Framework.Mvc;

namespace Imp.Admin.Models.Doc
{
    public class DirectoryModel : BaseImpEntityModel
    {
        private ICollection<SubDirectory> _subDirectories;
        public string Name { get; set; }

        public DateTime LastModifyDate { get; set; }

        public ICollection<SubDirectory> SubDirectories
        {
            get { return _subDirectories ?? (_subDirectories = new List<SubDirectory>()); }
            set { _subDirectories = value; } 
        }

        public class SubDirectory:BaseImpEntityModel
        {
            public string Name { get; set; }

            public DateTime LastModifyDate { get; set; }
        }
    }
}