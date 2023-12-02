using AutoMapper;
using Database.Data;
using Database.Models;
using DataBase.Models;
using WebHotel.DTO;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.QuestionDtos;
using WebHotel.DTO.ReservationDtos;
using WebHotel.DTO.RoomStarDtos;

namespace WebHotel.Repository.UserRepository.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        private static System.Timers.Timer timer;

        public QuestionRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(QuestionCreateDto req)
        {
            var question = _mapper.Map<Question>(req);

            if (question is not null)
            {
                question.CreatedAt = DateTime.Now;
                await _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Successful!" };
            }
            return new StatusDto { StatusCode = 0, Message = "Error!" };
        }
    }
}
