using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;
using CourseManagement.Repository.Data;
using CourseManagement.Repository.Exceptions;
using CourseManagement.Repository.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace CourseManagement.Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found!");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public void Update(Group data)
        {
            Group dbLibrary = Get(l => l.Id == data.Id);

            if (dbLibrary == null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dbLibrary.Name = data.Name;
            }

            if (data.Room > 0)
            {
                dbLibrary.Room = data.Room;
            }
        }
    }
}
