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
    public  class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public CourseGroup Create(CourseGroup courseGroup)
        {
            _groupRepository.Create(courseGroup);

            courseGroup.Id = _count;

            _count++;

            return courseGroup;



        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public CourseGroup GetById(int id)
        {
            CourseGroup courseGroup = _groupRepository.Get(c => c.Id == id);
            if (courseGroup == null) return null;
            return courseGroup;
        }

        public CourseGroup Update(int id, CourseGroup courseGroup)
        {
            throw new NotImplementedException();
        }
    }
}
