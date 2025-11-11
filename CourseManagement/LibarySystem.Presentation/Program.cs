using CourseManagement.Presentation.Controllers;
using CourseManagement.Presentation.Helpers;

namespace CourseManagement.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();
            StudentController studentController = new();

            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");

            GetMenus();

            while (true)
            {
            SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menus.CreateGroup:
                            groupController.Create();
                            break;
                        case (int)Menus.GetGroup:
                            groupController.GetById();
                            break;
                        case (int)Menus.GetAllGroups:
                            groupController.GetAll();
                            break;
                        case (int)Menus.DeleteGroup:
                            groupController.Delete();
                            break;
                        case (int)Menus.UpdateGroup:
                            groupController.Update();
                            break;
                        case (int)Menus.SearchGroup:
                            groupController.Search();
                            break;
                        case (int)Menus.CreateStudent:
                            studentController.Create();
                            break;
                        case (int)Menus.GetByTeacher:
                            groupController.GetByTeacher();
                            break;
                        case (int)Menus.GetByRoomNo:
                            groupController.GetByRoomNumber();
                            break;
                        case (int)Menus.GetStudentById:
                            studentController.GetById();
                            break;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "select correct option type!");
                    goto SelectOption;
                }
            }
        }

        private static void GetMenus()
        {
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Get Group , 3 - GetAll Groups, 4 - Delete Group, 5 - Update Group, 6 - Search Group, 7 - Student Create, 8- Get Groups by Teacher, 9 - Get by Room, 10- Get Student By Id");
        }
    }
}
