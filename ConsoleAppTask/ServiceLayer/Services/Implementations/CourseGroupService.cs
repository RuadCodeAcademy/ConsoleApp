using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public  class CourseGroupService : ICourseGroupService
    {
        private CourseGroupRepository _coursegroupRepository;
        private int _count = 1;

        public CourseGroupService()
        {
            _coursegroupRepository = new CourseGroupRepository();
        }

        public CourseGroup Create(CourseGroup courseGroup)
        {
            _coursegroupRepository.Create(courseGroup);

            courseGroup.Id = _count;

            _count++;

            return courseGroup;



        }

        public void Delete(int id)
        {
            CourseGroup courseGroup = GetById(id);

            _coursegroupRepository.Delete(courseGroup);
        }

        public List<CourseGroup> GetAll()
        {
            return _coursegroupRepository.GetAll();
        }

        public CourseGroup GetById(int id)
        {
            CourseGroup courseGroup = _coursegroupRepository.Get(c => c.Id == id);
            if (courseGroup == null) return null;
            return courseGroup;
        }

        public List<CourseGroup> Searchbyroom(int grouproom)
        {
            return _coursegroupRepository.GetAll(c => c.Room == grouproom);
        }

        public List<CourseGroup> Searchbyteacher(string teachername)
        {
            return _coursegroupRepository.GetAll(c => c.Teacher.ToLower().Trim() == teachername.ToLower().Trim());
        }

        public CourseGroup Update(int id, CourseGroup courseGroup)
        {
            CourseGroup dbcoursegroup = GetById(id);

            if (dbcoursegroup == null) return null;

            courseGroup.Id = id;

            _coursegroupRepository.Update(courseGroup);

            return GetById(id);
        }

        public CourseGroup GetByName(string name)
        {
            return _coursegroupRepository.GetByName(name);  // Repository-dəki GetByName metodunu çağırır
        }
    }
}
