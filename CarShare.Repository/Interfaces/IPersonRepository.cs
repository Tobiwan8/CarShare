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
        Task<PersonModel> Create(PersonDTO person);
        Task<List<PersonModel>> GetAll();
        Task<PersonModel?> Update(PersonUpdateDTO person);
        Task<PersonModel?> Delete(int personID);
    }
}
