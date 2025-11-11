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
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Student Not Found");

                AppDbContext<Student>.datas.Add(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Delete(Student data) => AppDbContext<Student>.datas.Remove(data);

        public Student Get(Predicate<Student> predicate) => AppDbContext<Student>.datas.Find(predicate);

        public List<Student> GetAll(Predicate<Student> predicate) => AppDbContext<Student>.datas;

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
