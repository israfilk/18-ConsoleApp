using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;

namespace CourseManagement.Service.Services.Interfaces
{

    public interface IGroupService
    {

        Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        List<Group> GetAllGroupsByTeacher(string teacherName);
        List<Group> GetAllGroupsByRoom(int roomNo);
        List<Group> GetAll();
    }

}
