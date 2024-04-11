using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.DTOs
{
    public class PersonDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserID { get; set; }
    }
}
