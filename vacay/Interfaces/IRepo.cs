using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vacay.Interfaces
{
    public interface IRepo<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public T Create(T item);
        public void  Delete(int id);

        
    }
}