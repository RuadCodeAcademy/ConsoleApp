using Courseapplication.Controller;
using Courseapplication.Helpers;

namespace Courseapplication
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintConsoleColor(ConsoleColor.Blue, "Select one option");
            Helper.PrintConsoleColor(ConsoleColor.Yellow, "1 - CreateGroup\n2 - GetGroup\n3 - GetAllGroups\n4 - DeleteGroup\n5 - UpdateGroup");
            CourseGroupController coursecontroller = new();
            while (true)
            {
            Selectoption1: string selectOption = Console.ReadLine();

                int selectnumber;

                bool isselectOption = int.TryParse(selectOption, out selectnumber);

                if (isselectOption)
                {
                    switch (selectnumber)
                    {
                        case 1:

                            coursecontroller.Create();
                            goto Selectoption1;
                            break;

                        case 2:
                            coursecontroller.GetById();
                            goto Selectoption1;
                            break;

                        case 3: 
                            coursecontroller.GetAll();
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
    }
}
