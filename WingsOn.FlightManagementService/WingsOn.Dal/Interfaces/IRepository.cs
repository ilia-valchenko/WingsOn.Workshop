﻿using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.Dal.Interfaces
{
    public interface IRepository<T> where T : DomainObject
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Save(T element);
    }
}