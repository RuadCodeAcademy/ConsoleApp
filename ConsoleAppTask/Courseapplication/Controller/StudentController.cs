using Courseapplication.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courseapplication.Controller
{
    public class StudentController
    {
        StudentService _studentService = new();
        CourseGroupService _courseGroupService = new();

        public void CreateStudent()
        {
        groupID: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Group Id");

            string GroupId = Console.ReadLine();

            int id;

            bool isGroupId = int.TryParse(GroupId, out id);

           

            if (isGroupId)
            {
                var findgroup = _courseGroupService.GetById(id);

                if (findgroup == null)
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "Group not Found!");
                    goto groupID;
                }

                Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Student Name");

                string StudentName = Console.ReadLine();

                Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Student Surname");

                string StudentSurname = Console.ReadLine();

            Age: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Student Age");

                string StudentAge = Console.ReadLine();


                int Age;

                bool isAge = int.TryParse(StudentAge, out Age);

                if (isAge)
                {

                    Student student = new Student { Name = StudentName, SurName = StudentSurname, age = Age };
                    var result = _studentService.Create(id, student);

                    if(result != null)
                    {
                        Helper.PrintConsoleColor(ConsoleColor.Green, $"Student id :{student.Id}, Student Name : {student.Name},  Student Surnam:{student.SurName}, studentAge: {student.age}, studentGroup: {student.group.Name}");
                    }

                    else
                    {

                        Helper.PrintConsoleColor(ConsoleColor.Red, "Student not Created ");
                    }
                   


                }
                else
                {

                    Helper.PrintConsoleColor(ConsoleColor.Red, "Add  correct Age type ");
                    goto Age;
                }

            


            }

            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Add  correct Id type ");
                goto groupID;
            }
        }
    }
}
