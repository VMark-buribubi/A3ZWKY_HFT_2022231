﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}