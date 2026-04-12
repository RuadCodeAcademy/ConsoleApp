using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new DirectoryNotFoundException("student not found");
                AppDbContext<Student>.datas.Add(data);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

       

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }


        public List<Student> GetStudentsByAge(int age)
        {
            return AppDbContext<Student>.datas.FindAll(s => s.age == age);
        }

        public List<Student> GetAllByGroupId(int groupId)
        {
            return AppDbContext<Student>.datas.FindAll(s => s.group != null && s.group.Id == groupId);
        }

        public List<Student> GetByNameOrSurname(string nameOrSurname)
        {
            return AppDbContext<Student>.datas.Where(s =>
                s.Name.Contains(nameOrSurname, StringComparison.OrdinalIgnoreCase) ||
                s.SurName.Contains(nameOrSurname, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
