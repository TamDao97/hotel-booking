using AutoMapper;
using Database.Data;
using Database.Models;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebHotel.DTO;
using WebHotel.DTO.RoomStarDtos;

namespace WebHotel.Repository.UserRepository.RoomStarRepository
{
    public class RoomStarUserRepository : IRoomStarUserRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RoomStarUserRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(RoomStarRequestDto roomStarRequestDto)
        {
            var room = _context.Rooms.SingleOrDefault(a => a.Id == roomStarRequestDto.RoomId);
            if (room is not null)
            {
                await _context.AddAsync(_mapper.Map<RoomStar>(roomStarRequestDto));
                room.StarValue += roomStarRequestDto.Number;
                room.StarAmount++;
                room.StarSum = room.StarValue / room.StarAmount;

                var roomType = _context.RoomTypes.AsNoTracking().Where(r => r.Id == room.RoomTypeId).FirstOrDefault();
                RoomTypeStar roomTypeStar = new RoomTypeStar
                {
                    IdUser = int.Parse(roomStarRequestDto.UserId),
                    CreatedAt = DateTime.Now
                };

                if (roomType.TypeName.Contains("STD"))
                {
                    roomTypeStar.Std = (roomTypeStar.Std ?? 0) + 1;
                }
                else if (roomType.TypeName.Contains("SUP"))
                {
                    roomTypeStar.Std = (roomTypeStar.Sup ?? 0) + 1;
                }
                else if (roomType.TypeName.Contains("DLX"))
                {
                    roomTypeStar.Std = (roomTypeStar.Dlx ?? 0) + 1;
                }
                else if (roomType.TypeName.Contains("SUT"))
                {
                    roomTypeStar.Std = (roomTypeStar.Sut ?? 0) + 1;
                }
                _context.RoomTypeStars.Add(roomTypeStar);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Successful comment!" };
            }
            return new StatusDto { StatusCode = 0, Message = "Id room not found!" };
        }
    }
}
