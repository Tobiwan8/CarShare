using CarShare.Repository.DTOs;
using CarShare.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Repository.Interfaces
{
    public interface IBookingRepository
    {
        Task<BookingModel> Create(BookingDTO booking);
        Task<List<BookingModel>> GetAll();
        Task<List<BookingPersonLidtReturnDTO?>> GetBookingsForSharedCars(int carID);
        Task<List<PersonBookingsReturnDTO?>> GetBookingsForPerson(int personID);
        Task<BookingModel?> Update(BookingUpdateDTO booking);
        Task<BookingModel?> Delete(int bookingID);
        Task<BookingModel?> GetBookingByID(int id);
    }
}
