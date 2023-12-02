using WebHotel.DTO;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.ReservationDtos;

namespace WebHotel.Repository.UserRepository.ContactRepository
{
    public interface IContactRepository
    {
        Task<StatusDto> Create(ContactCreateDto req);
    }
}
