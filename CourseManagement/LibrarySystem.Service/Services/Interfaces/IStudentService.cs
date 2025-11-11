using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;

namespace CourseManagement.Service.Services.Interfaces
{
   public interface IStudentService
    {
        Student Create(int groupId, Student student);
        Student GetById(int id);
    }
}
