﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMP.Core;

namespace Imp.Core.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
    }
}
