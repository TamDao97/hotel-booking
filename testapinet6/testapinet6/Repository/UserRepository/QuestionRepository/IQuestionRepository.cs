using WebHotel.DTO;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.QuestionDtos;
using WebHotel.DTO.ReservationDtos;

namespace WebHotel.Repository.UserRepository.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<StatusDto> Create(QuestionCreateDto req);
    }
}
