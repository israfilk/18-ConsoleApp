using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;
using CourseManagement.Repository.Repositories.Implementations;
using CourseManagement.Service.Services.Interfaces;
using CourseManagement.Repository.Repositories.Implementations;

namespace CourseManagement.Service.Services.Implementations
{
    
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
            group.Id = _count;

            _groupRepository.Create(group);

            _count++;

            return group;
        }

        public void Delete(int id)
        {
            Group group = GetById(id);

            _groupRepository.Delete(group);
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetAllGroupsByRoom(int roomNo)
        {
            return _groupRepository.GetAll(x => x.Room == roomNo);
        }

        public List<Group> GetAllGroupsByTeacher(string teacherName)
        {
            return _groupRepository.GetAll(x=>x.Teacher==teacherName);
        }

        public Group GetById(int id)
        {
            Group group = _groupRepository.Get(l => l.Id == id);

            if (group is null) return null;

            return group;
        }

        public List<Group> Search(string name)
        {
            return _groupRepository.GetAll(l => l.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Group Update(int id, Group group)
        {
            Group dbLibrary = GetById(id);

            if (dbLibrary is null) return null;

            group.Id = id;

            _groupRepository.Update(group);

            return GetById(id);
        }

    }
}
