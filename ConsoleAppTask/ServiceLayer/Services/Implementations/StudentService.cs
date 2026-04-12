using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private CourseGroupRepository _courseGroupRepository;
        private StudentRepository _studentRepository;
        private int _count = 1;

        public StudentService()
        {
            _courseGroupRepository = new CourseGroupRepository();
            _studentRepository = new StudentRepository();
        }



        public Student Create(int GroupId, Student student)
        {
            var group = _courseGroupRepository.Get(c => c.Id == GroupId);

            if (group == null) return null;

            student.Id = _count;

            student.group = group;

            _count++;

            _studentRepository.Create(student);

            return student;
        }

        public void Delete(int id)
        {
            Student student = GetById(id);

            _studentRepository.Delete(student);
        }



        public Student GetById(int id)
        {

            Student student = _studentRepository.Get(s => s.Id == id);
            if (student != null) return student;
            return null;

        }



        public List<Student> GetStudentsByAge(int age)
        {
            return _studentRepository.GetStudentsByAge(age);
        }

        public List<Student> GetStudentsByGroupId(int groupId)
        {
            return _studentRepository.GetAllByGroupId(groupId);
        }

        public List<Student> GetByNameOrSurname(string nameOrSurname)
        {
            return _studentRepository.GetByNameOrSurname(nameOrSurname);
        }

        public Student Update(int id, Student student)
        {
            student.Id = id; 
            _studentRepository.Update(student); 
            return student;
        }
    }
}
