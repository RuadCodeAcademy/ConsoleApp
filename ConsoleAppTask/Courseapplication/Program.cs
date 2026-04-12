using Courseapplication.Controller;
using Courseapplication.Helpers;

namespace Courseapplication
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintConsoleColor(ConsoleColor.Blue, "Select one option");

            GetMenus();

            CourseGroupController coursecontroller = new();
            StudentController studentcontroller = new();
            while (true)
            {
            Selectoption1: string selectOption = Console.ReadLine();

                int selectnumber;

                bool isselectOption = int.TryParse(selectOption, out selectnumber);

                if (isselectOption)
                {
                    switch (selectnumber)
                    {
                        case (int)Menus.CreateGroup:

                            coursecontroller.CreateGroup();
                            goto Selectoption1;
                            break;

                        case (int)Menus.GetGroupById:
                            coursecontroller.GetGroupById();
                            goto Selectoption1;
                            break;

                        case (int)Menus.GetAllGroups: 
                            coursecontroller.GetAllGroups();
                            goto Selectoption1;

                        case (int)Menus.DeleteGroup:
                            coursecontroller.DeleteGroup();
                            goto Selectoption1;

                        case (int)Menus.UpdateGroup:
                            coursecontroller.UpdateGroup();
                            goto Selectoption1;

                        case (int)Menus.SearchGroupByTeacher:
                            coursecontroller.SearchGroupByTeacher();
                            goto Selectoption1;

                        case (int)Menus.SearchGroupByRoom:
                            coursecontroller.SearchGroupByRoom();
                            goto Selectoption1;

                        case (int)Menus.CreateStudent:
                            studentcontroller.CreateStudent();
                            goto Selectoption1;

                        case (int)Menus.UpdateStudent:
                            studentcontroller.UpdateStudent();
                            goto Selectoption1;

                        case (int)Menus.GetStudentById:
                            studentcontroller.GetStudentById();
                            goto Selectoption1;

                        case (int)Menus.DeleteStudent:
                            studentcontroller.DeleteStudent();
                            goto Selectoption1;

                        case (int)Menus.GetStudentsByAge:
                            studentcontroller.GetStudentsByAge();
                            goto Selectoption1;

                        case (int)Menus.GetStudentsByGroupId:
                            studentcontroller.GetStudentsByGroupId();
                            goto Selectoption1;

                        case (int)Menus.SearchGroupByName:
                            studentcontroller.SearchGroupByName();
                            goto Selectoption1;

                        case (int)Menus.SearchStudentByNameOrSurname:
                            studentcontroller.SearchStudentByNameOrSurname();
                            goto Selectoption1;





                    }
                }
                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "Add  correct option type ");
                    goto Selectoption1;
                }
            }
        }

        private static void GetMenus()
        {
            Helper.PrintConsoleColor(ConsoleColor.Yellow, "1 - CreateGroup\n2 - GetGroup by id\n3 - GetAllGroups\n4 - DeleteGroup\n5 - UpdateGroup\n6 - Search Group by Teacher\n7 - Search Group by Room\n8 - CreateStudent\n9 - Update Student\n10 - Get Student by id\n11 - Delete Student\n12 - GetStudentsByAge\n13 - GetStudentsByGroupId\n14 - SearchGroupByName\n15 - SearchStudentByNameOrSurname");
        }
    }
}
