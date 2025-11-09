using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Common;

namespace CourseManagement.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Created (T entity);
        void Update (T entity);
        void Delet (T entity);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
