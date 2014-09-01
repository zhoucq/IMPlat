using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Domain.Cms
{
    public class Article : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        public string Content { get; set; }


    }
}
