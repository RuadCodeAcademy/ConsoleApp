using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    internal interface IStudentService
    {
        Student Create(int GroupId, Student student);

        Student Update(int id, Student student);

        void Delete(int id);

        Student GetById(int id);

        


    }
}
