using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;
using CourseManagement.Presentation.Helpers;
using CourseManagement.Service.Services.Implementations;
using CourseManagement.Service.Services.Interfaces;

namespace CourseManagement.Presentation.Controllers
{
    internal class StudentController
    {

        StudetService _studetService = new();
        public void Create()
        {
        groupId: Helper.PrintConsole(ConsoleColor.Blue, "Add group Id");

            string groupId = Console.ReadLine();

            int selectedIdGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedIdGroupId);

            if (isSelectedId)
            {

                Helper.PrintConsole(ConsoleColor.Blue, "Add student Name");

                string name = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add student surName");

                string surname = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Blue, "Add Age");

                string age = Console.ReadLine();

                Student student = new Student{ Name = name, Surname = surname , Age = int.Parse(age)};

                Helper.PrintConsole(ConsoleColor.Blue, "Add student group");

                string group = Console.ReadLine();

                var result = _studetService.Create(selectedIdGroupId, student);

                if (result != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Student Id : {student.Id}, Name : {student.Name}, Surname : {student.Surname}, age : {student.Age}, group : {student.Group.Id}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "group Not found, please add correct group id!");
                    goto groupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct group type");
                goto groupId;
            }
        }

        public void GetById()
        {
        groupId: Helper.PrintConsole(ConsoleColor.Blue, "Add student Id");

            string groupId = Console.ReadLine();

            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                Student student = _studetService.GetById(id);

                if (student != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"student Id : {student.Id}, Name : {student.Name}, Surname : {student.Surname}, age {student.Age}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "student not found!");
                    goto groupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct studetId type");
                goto groupId;
            }
        }
    }
}
