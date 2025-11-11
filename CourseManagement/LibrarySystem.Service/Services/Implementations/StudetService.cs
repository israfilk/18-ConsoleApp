using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;
using CourseManagement.Repository.Repositories.Implementations;
using CourseManagement.Service.Services.Interfaces;

namespace CourseManagement.Service.Services.Implementations
{
    public class StudetService:IStudentService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private int _count = 1;

        public StudetService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }

        public Student GetById(int id)
        {
            Student student = _studentRepository.Get(l => l.Id == id);
            return student ?? null;
        }

        public Student Create(int groupId, Student Student)
        {
            var group = _groupRepository.Get(l => l.Id == groupId);

            if (group is null) return null;

            Student.Id = _count;

            Student.Group = group;

            _studentRepository.Create(Student);

            _count++;

            return Student;
        }

        public void Delete(Student data)
        {
            _studentRepository.Delete(data);
        }
    }
}
