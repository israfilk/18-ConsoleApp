using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagement.Domain.Entities;
using CourseManagement.Presentation.Helpers;
using CourseManagement.Service.Services.Implementations;
namespace CourseManagement.Presentation.Controllers
{
    internal class GroupController
    {
        GroupService _groupService = new();
        public void Create()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add group Name");

            string groupName = Console.ReadLine();

            Helper.PrintConsole(ConsoleColor.Blue, "Add group teacher");

            string teacher = Console.ReadLine();

        room: Helper.PrintConsole(ConsoleColor.Blue, "Add group room");

            string groupRoom = Console.ReadLine();

            int room;

            bool isRoomNo = int.TryParse(groupRoom, out room);

            if (isRoomNo)
            {
                Group group = new Group { Name = groupName, Teacher = teacher, Room = room };

                var result = _groupService.Create(group);

                Helper.PrintConsole(ConsoleColor.Green, $"group Id : {group.Id}, Name : {group.Name}, Teacher: {group.Teacher},Room No : {group.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct room type");
                goto room;
            }
        }
        public void GetById()
        {
        groupId: Helper.PrintConsole(ConsoleColor.Blue, "Add group Id");

            string groupId = Console.ReadLine();

            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                Group group = _groupService.GetById(id);

                if (group != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"group Id : {group.Id}, Name : {group.Name}, Room No : {group.Room}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "group not found!");
                    goto groupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct groupId type");
                goto groupId;
            }
        }

        public void GetByTeacher()
        {
        teacherName: Helper.PrintConsole(ConsoleColor.Blue, "Add teacher");

            string teacher = Console.ReadLine();


            List<Group> groups = _groupService.GetAllGroupsByTeacher(teacher);

            if (groups != null)
            {
                foreach (Group group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"group Id : {group.Id}, Name : {group.Name}, Room No : {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "group not found!");
                goto teacherName;
            }

        }

        public void GetByRoomNumber()
        {
        roomNo: Helper.PrintConsole(ConsoleColor.Blue, "Add room no");

            string roomNo = Console.ReadLine();


            List<Group> groups = _groupService.GetAllGroupsByRoom(int.Parse(roomNo));

            if (groups != null)
            {
                foreach (Group group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"group Id : {group.Id}, Name : {group.Name}, Room No : {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "group not found!");
                goto roomNo;
            }
        }
        public void GetAll()
        {
            List<Group> libraries = _groupService.GetAll();

            if (libraries.Count != 0)
            {
                foreach (var group in libraries)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"group Id : {group.Id}, Name : {group.Name}, Room : {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please Create group!");
            }
        }
        public void Delete()
        {
        groupId: Helper.PrintConsole(ConsoleColor.Blue, "Add group Id");

            string groupId = Console.ReadLine();

            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                _groupService.Delete(id);
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct groupId type");
                goto groupId;
            }
        }
        public void Search()
        {
        SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add group search text");

            string searchName = Console.ReadLine();

            List<Group> libraries = _groupService.Search(searchName);

            if (libraries.Count != 0)
            {
                foreach (var group in libraries)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"group Id : {group.Id}, Name : {group.Name}, Room No : {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Libraries not found for search text!");
                goto SearchText;
            }
        }
        public void Update()
        {
        groupId: Helper.PrintConsole(ConsoleColor.Blue, "Add group Id (or press Enter to cancel)");

            string groupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Update operation cancelled.");
                return;
            }

            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                var findgroup = _groupService.GetById(id);

                if (findgroup != null)
                {
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {findgroup.Name}. Add group new name (or press Enter to keep current)");

                    string groupNewName = Console.ReadLine();

                room: Helper.PrintConsole(ConsoleColor.Blue, $"Current Room No: {findgroup.Room}. Add group new Room No (or press Enter to keep current)");

                    string groupNewSeatCount = Console.ReadLine();

                    int room = findgroup.Room;

                    if (!string.IsNullOrWhiteSpace(groupNewSeatCount))
                    {
                        bool isSeatCount = int.TryParse(groupNewSeatCount, out room);

                        if (!isSeatCount)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Add correct Room No type");
                            goto room;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(groupNewName))
                    {
                        groupNewName = findgroup.Name;
                    }

                    Group group = new Group { Name = groupNewName, Room = room };

                    var updatedgroup = _groupService.Update(id, group);

                    if (updatedgroup == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "group not Updated, please try again");
                        goto groupId;
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"group Id: {updatedgroup.Id}, Name: {updatedgroup.Name}, Room no: {updatedgroup.Room}");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "group not found");
                    goto groupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct groupId type");
                goto groupId;
            }
        }
    }
}
