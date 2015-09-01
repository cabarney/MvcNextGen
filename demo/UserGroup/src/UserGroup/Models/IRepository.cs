using System.Linq;

namespace UserGroup.Models
{
    public interface IRepository<T> where T : Entity
    {
        T Find(int id);
        IQueryable<T> All();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        void Save();
    }
}