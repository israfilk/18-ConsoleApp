using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseManagement.Service.Services.Interfaces;

namespace CourseManagement.Service.Services.Implementations
{
    
    public class GroupService : IGroupService
    {

        private int _count = 1;
        public Group Create(Group group)
        {
            group.Id  = _count;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
