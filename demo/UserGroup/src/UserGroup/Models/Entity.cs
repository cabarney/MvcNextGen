using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Data.Entity;

namespace UserGroup.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }

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

    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext Db;

        public virtual void Add(T item)
        {
            Db.Add(item);
        }

        public virtual void Update(T item)
        {
            Db.Entry(item).State = EntityState.Modified;
        }

        public virtual IQueryable<T> All()
        {
            return Db.Set<T>().AsQueryable();
        }

        public virtual void Delete(int id)
        {
            Delete(Db.Set<T>().SingleOrDefault(x => x.Id == id));
        }

        public virtual void Delete(T item)
        {
            Db.Remove(item);
        }

        public virtual T Find(int id)
        {
            return All().SingleOrDefault(x => x.Id == id);
        }

        public virtual void Save()
        {
            Db.SaveChanges();
        }
    }


    public class MeetingRepository : Repository<Meeting>
    {
        public override IQueryable<Meeting> All()
        {
            return Db.Meetings.OrderByDescending(m=>m.MeetingDate).Include(x => x.Venue).Include(x=>x.Registrations);
        }
    }
}