using System;
using System.Collections.Generic;
using System.Text;

namespace OuraDataAggregateVals.Services
{
    public interface ITableService<T>
    {
        public abstract bool AddEntity(T entity);
    }
}
