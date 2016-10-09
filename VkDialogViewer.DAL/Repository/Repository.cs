using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using VkDialogViewer.Core.Entities;

namespace VkDialogViewer.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VkViewerDbContext context;

        public Repository(VkViewerDbContext context)
        {
            this.context = context;
        }

        protected DbSet<T> DbSet => this.context.Set<T>();

        public IQueryable<T> All(params Expression<Func<T, object>>[] includes)
        {
            var query = this.DbSet.AsQueryable();

            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public int Create(T t)
        {
            this.DbSet.Add(t);
            return this.SaveChanges();
        }

        public void CreateWithoutCommit(T t)
        {
            this.DbSet.Add(t);
        }

        public int Update(T t)
        {
            this.UpdateWithoutCommit(t);
            return this.SaveChanges();
        }

        public void UpdateWithoutCommit(T t)
        {
            var entry = this.context.Entry(t);
            this.DbSet.Attach(t);
            entry.State = EntityState.Modified;
        }

        public int Delete(T t)
        {
            this.DbSet.Remove(t);
            return this.SaveChanges();
        }

        public void Dispose()
        {
            this.context?.Dispose();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return this.All(includes).Where(predicate);
        }

        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return this.All(includes).FirstOrDefault(expression);
        }

        public int SaveChanges()
        {
            return  this.context.SaveChanges();
        }

    }
}
