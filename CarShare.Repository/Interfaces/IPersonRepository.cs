using CarShare.Repository.DTOs;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Interfaces
{
    public interface IPersonRepository
    {
        PersonModel Create(PersonDTO person);
        List<PersonModel> GetAll();
    }
}
