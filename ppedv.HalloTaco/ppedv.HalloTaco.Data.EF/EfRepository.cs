using ppedv.HalloTaco.Model;
using ppedv.HalloTaco.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.HalloTaco.Data.EF
{
    public class EfRepository : IRepository
    {
        EfContext context = new EfContext();

        public bool HasChanges => context.ChangeTracker.HasChanges();

        public void Add<T>(T entity) where T : Entity
        {
            //    if (typeof(T) == typeof(Taco))
            //        context.Tacos.Add(entity as Taco);
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            //nur diconnected szenarien wie ASP oder WCF
            var loaded = GetById<T>(entity.Id);
            if (loaded != null)
                context.Entry(loaded).CurrentValues.SetValues(entity);
        }
    }
}
