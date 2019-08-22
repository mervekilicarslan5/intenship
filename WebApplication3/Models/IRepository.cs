using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    
        public interface IRepository<T> where T : EntityBase
        {
            T GetById(int id);
            IEnumerable<T> List();
            bool Add(T entity, out T added);
            void Delete(int id);
            void Edit(T entity);
           T GetByDetail(string name, string surnames);
        }
public abstract class EntityBase
{
    public int Id { get; protected set; }
}


