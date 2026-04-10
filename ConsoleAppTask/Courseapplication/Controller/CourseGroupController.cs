using Courseapplication.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courseapplication.Controller
{
    public class CourseGroupController
    {
        GroupService _groupService = new GroupService();
        public void Create()
        {
            Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Group Name");

            string GroupName = Console.ReadLine();

            Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Group Teacher");

            string GroupTeacher = Console.ReadLine();

        Room: Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Group Room");

            string GroupRoom = Console.ReadLine();


            int Room;

            bool isRoom = int.TryParse(GroupRoom, out Room);

            if (isRoom)
            {
                
                CourseGroup courseGroup = new CourseGroup { Name = GroupName, Teacher = GroupTeacher, Room = Room };
                var result = _groupService.Create(courseGroup);
                Helper.PrintConsoleColor(ConsoleColor.Green, $"Group id :{courseGroup.Id}, Name : {courseGroup.Name}, Teacher:{courseGroup.Teacher}, Room: {courseGroup.Room}");
                

            }
            else
            {
                
                Helper.PrintConsoleColor(ConsoleColor.Red, "Add  correct Room type ");
                goto Room;
            }
        }

        public void GetById()
        {
        groupid : Helper.PrintConsoleColor(ConsoleColor.Blue, "Add Group Id");

            string GroupId = Console.ReadLine();

            int id;

            bool isGroupId = int.TryParse(GroupId, out id); 

            if (isGroupId)
            {
                CourseGroup courseGroup = _groupService.GetById(id);

                if(courseGroup != null)
                {
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"Group id :{courseGroup.Id}, Name : {courseGroup.Name}, Teacher:{courseGroup.Teacher}, Room: {courseGroup.Room}");
                }

                else
                {
                    Helper.PrintConsoleColor(ConsoleColor.Red, "group not found! ");
                }
            }
            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Add Correct Group id ");
                goto groupid;
            }
        }


        public void GetAll()
        {
            List<CourseGroup> courseGroups = _groupService.GetAll();

            if( courseGroups.Any())
            {
                foreach( var courseGroup in courseGroups)
                {
                    Helper.PrintConsoleColor(ConsoleColor.Green, $"Group id :{courseGroup.Id}, Name : {courseGroup.Name}, Teacher:{courseGroup.Teacher}, Room: {courseGroup.Room}");

                }
            }

            else
            {
                Helper.PrintConsoleColor(ConsoleColor.Red, "Please add courseGroups ");
            }
        }
    }
}
