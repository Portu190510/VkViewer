using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VkDialogViewer.DAL.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All(params Expression<Func<T, object>>[] includes);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        int Create(T t);

        void CreateWithoutCommit(T t);

        int Delete(T t);

        int Update(T t);

        void UpdateWithoutCommit(T t);

        int SaveChanges();
    }
}
