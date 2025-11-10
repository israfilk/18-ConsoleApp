using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseManagement.Repository.Data;
using CourseManagement.Repository.Exceptions;
using CourseManagement.Repository.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace CourseManagement.Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Created(Group entity)
        {
            try
            {
                if (entity is null) throw new NotFoundException("Group Not Found");

                AppDbContext<Group>.datas.Add(entity);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delet(Group entity)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
