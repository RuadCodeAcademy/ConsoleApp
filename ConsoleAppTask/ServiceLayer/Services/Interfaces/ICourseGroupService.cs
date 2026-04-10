using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICourseGroupService
    {
        CourseGroup Create(CourseGroup courseGroup);

        CourseGroup Update(int id, CourseGroup courseGroup);

        void Delete(int id);

        CourseGroup GetById(int id);

        List<CourseGroup> GetAll();

        List<CourseGroup> Search(string name);
    }
}
