
using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace RepositoryLayer.Repositories.Implementations
{
    public class CourseGroupRepository : ICourseGroupRepository<CourseGroup>
    {
        private CourseGroupRepository _grouprepository;


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
            AppDbContext<CourseGroup>.datas.Remove(data);
        }

        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.Find(predicate) : null;
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate = null)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.FindAll(predicate) : AppDbContext<CourseGroup>.datas;
        }

        public void Update(CourseGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
