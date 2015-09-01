using System.Linq;
using Microsoft.Data.Entity;

namespace UserGroup.Models
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext Db;

        protected Repository(ApplicationDbContext db)
        {
            Db = db;
        }

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
        public MeetingRepository(ApplicationDbContext db) : base(db)
        {
        }

        public override IQueryable<Meeting> All()
        {
            return Db.Meetings.OrderByDescending(m => m.MeetingDate).Include(x => x.Venue);
        }
    }

    public class VenueRepository : Repository<Venue> {
        public VenueRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
    public class MemberRepository : Repository<Member> {
        public MemberRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
    public class RegistrationRepository : Repository<Registration> {
        public RegistrationRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}