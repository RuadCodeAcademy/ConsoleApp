
using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace RepositoryLayer.Repositories.Implementations
{
    public class GroupRepository : IRepository<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if(data == null) throw new DirectoryNotFoundException("Data not found!");

                AppDbContext<CourseGroup>.datas.Add(data);  
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(CourseGroup data)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
