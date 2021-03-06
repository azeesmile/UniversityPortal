﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPortal.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        IEnumerable<T> Select(object n);
        T SelectById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
