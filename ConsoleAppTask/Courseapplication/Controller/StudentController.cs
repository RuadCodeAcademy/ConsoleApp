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

                    if (result != null)
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

        public void UpdateStudent()
        {

        }

        public void GetStudentById()
        {

        studentid: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Student Id");

            string StudentId = Console.ReadLine();

            int id;

            bool isStudentId = int.TryParse(StudentId, out id);

            if (isStudentId)
            {
                Student student = _studentService.GetById(id);

                if (student != null)
                {
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"Student id :{student.Id}, Student Name : {student.Name},  Student Surnam:{student.SurName}, studentAge: {student.age}, studentGroup: {student.group.Name}");
                }

                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "student not found! ");
                    goto studentid;
                }
            }
            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Add Correct Student id type ");
                goto studentid;
            }
        }

        public void DeleteStudent()
        {
        studentid: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Student Id");

            string StudentId = Console.ReadLine();

            int id;

            bool isStudentId = int.TryParse(StudentId, out id);

            if (isStudentId)
            {


                Student student = _studentService.GetById(id);

                if (student != null)
                {
                    _studentService.Delete(id);
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"{student.Name} deleted successfully!");
                }

                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "student not found! ");
                }
            }
            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Add Correct Student id type ");
                goto studentid;
            }


        }


        public void GetStudentsByAge()
        {
        age: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Age :");

            string AgeInput = Console.ReadLine();
            int age;

            bool isAge = int.TryParse(AgeInput, out age);

            if (isAge)
            {
                List<Student> students = _studentService.GetStudentsByAge(age);

                if (students.Any())
                {


                    foreach (var student in students)
                    {
                        Helper.PrintConsoleColor(ConsoleColor.Green, $"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.age}, Group: {student.group.Name}");
                    }
                }
                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, $"No students found with age {age}");
                    goto age;
                }
            }
            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Please add correct age type");
                goto age;
            }







        }

        public void GetStudentsByGroupId()
        {
        groupid: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Group Id to search for students:");

            string GroupIdInput = Console.ReadLine();
            int groupId;

            bool isGroupId = int.TryParse(GroupIdInput, out groupId);

            if (isGroupId)
            {
                List<Student> students = _studentService.GetStudentsByGroupId(groupId); 

                if (students.Any())
                {
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"Students in Group ID {groupId}:");

                    foreach (var student in students)
                    {
                        Helper.PrintConsoleColor(ConsoleColor.Green, $"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.age}, Group: {student.group.Name}");
                    }
                }
                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, $"No students found in Group ID {groupId}");
                    goto groupid;
                }
            }
            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Please Add Correct Group ID Type");
                goto groupid;
            }
        }


        public void SearchGroupByName()
        {
        groupname: Helper.PrintConsoleColor(ConsoleColor.Blue, "Enter Group Name to search:");

            string groupName = Console.ReadLine();

            groupName = groupName?.Trim();

            if (!string.IsNullOrEmpty(groupName))
            {
                CourseGroup group = _courseGroupService.GetByName(groupName);  

                if (group != null)
                {
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"Group found: {group.Name}, ID: {group.Id}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "Group not found!");
                    goto groupname;
                }
            }
            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Please enter  group name.");
                goto groupname;
            }
        }


        public void SearchStudentByNameOrSurname()
        {
        nameorsurmane:  Helper.PrintConsoleColor(ConsoleColor.Blue, "Enter Student Name or Surname to search:");

            string nameOrSurname = Console.ReadLine();

            
            nameOrSurname = nameOrSurname?.Trim();

            if (string.IsNullOrEmpty(nameOrSurname))  
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Please enter a valid name or surname.");
                goto nameorsurmane;
            }
            else
            {
                
                List<Student> students = _studentService.GetByNameOrSurname(nameOrSurname);

                if (students.Any())
                {
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"Students found for '{nameOrSurname}':");

                    foreach (var student in students)
                    {
                        Helper.PrintConsoleColor(ConsoleColor.Green, $"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.age}, Group: {student.group.Name}");
                    }
                }
                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "No students found with that name or surname.");
                    goto nameorsurmane;
                }
            }
        }

    }
}
