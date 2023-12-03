using AutoMapper;
using Database.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHotel.Commom;
using WebHotel.DTO;
using WebHotel.DTO.AccountDtos;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.QuestionDtos;

namespace WebHotel.Controllers.AdminController
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("v{version:apiVersion}/admin/contact/")]
    [ApiVersion("2.0")]
    public class ContactAdminController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ContactAdminController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("get-all-contact")]
        public async Task<IActionResult> GetAllContact(ContactFilterDto grid)
        {
            var query = _context.Contacts.AsNoTracking();

            if (!string.IsNullOrEmpty(grid.KeyWord))
            {
                query = query.Where(r => r.Email.ToLower().Trim().Contains(grid.KeyWord.ToLower().Trim()) || r.PhoneNumber.ToLower().Trim().Contains(grid.KeyWord.ToLower().Trim())
                                || r.FullName.ToLower().Trim().Contains(grid.KeyWord.ToLower().Trim()));
            }

            int totalCount = query.Select(r => r.Id).Count();
            var datas = query.Skip((grid.PageIndex - 1) * grid.PageSize)
                            .Take(grid.PageSize)
                            .Select(r => _mapper.Map<ContactResponseDto>(r))
                            .ToList();

            GridReponseApi<ContactResponseDto> gridData = new GridReponseApi<ContactResponseDto>
            {
                PageIndex = grid.PageIndex,
                PageSize = grid.PageSize,
                TotalData = totalCount,
                GridData = datas
            };

            return Ok(ResponseApi<GridReponseApi<ContactResponseDto>>.Success(gridData));
        }

        [HttpPost("get-all-question")]
        public async Task<IActionResult> GetAllQuestion(QuestionFilterDto grid)
        {
            var query = _context.Questions.AsNoTracking();

            if (!string.IsNullOrEmpty(grid.KeyWord))
            {
                query = query.Where(r => r.Email.ToLower().Trim().Contains(grid.KeyWord.ToLower().Trim()) || r.Name.ToLower().Trim().Contains(grid.KeyWord.ToLower().Trim())
                                || r.Content.ToLower().Trim().Contains(grid.KeyWord.ToLower().Trim()));
            }

            int totalCount = query.Select(r => r.Id).Count();
            var datas = query.Skip((grid.PageIndex - 1) * grid.PageSize)
                            .Take(grid.PageSize)
                            .Select(r => _mapper.Map<QuestionResponseDto>(r))
                            .ToList();

            GridReponseApi<QuestionResponseDto> gridData = new GridReponseApi<QuestionResponseDto>
            {
                PageIndex = grid.PageIndex,
                PageSize = grid.PageSize,
                TotalData = totalCount,
                GridData = datas
            };

            return Ok(ResponseApi<GridReponseApi<QuestionResponseDto>>.Success(gridData));
        }
    }
}
