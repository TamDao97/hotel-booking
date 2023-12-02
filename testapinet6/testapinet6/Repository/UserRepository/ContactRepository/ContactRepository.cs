using AutoMapper;
using Database.Data;
using Database.Models;
using DataBase.Models;
using WebHotel.DTO;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.ReservationDtos;
using WebHotel.DTO.RoomStarDtos;

namespace WebHotel.Repository.UserRepository.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        private static System.Timers.Timer timer;

        public ContactRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(ContactCreateDto req)
        {
            var contact = _mapper.Map<Contact>(req);

            if (contact is not null)
            {
                contact.CreatedAt = DateTime.Now;
                contact.Status = true;
                await _context.AddAsync(contact);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Successful!" };
            }
            return new StatusDto { StatusCode = 0, Message = "Error!" };
        }
    }
}
