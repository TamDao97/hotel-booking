using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.QuestionDtos;
using WebHotel.DTO.RoomDtos;
using WebHotel.Repository.UserRepository.ContactRepository;
using WebHotel.Repository.UserRepository.QuestionRepository;

namespace WebHotel.Controllers.UserController;

[ApiController]
[ApiVersion("1.0")]
[Route("user/")]
public partial class QuestionController : ControllerBase
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionController(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    [HttpPost]
    [Route("question/create")]
    public async Task<IActionResult> Create(QuestionCreateDto req)
    {
        var result = await _questionRepository.Create(req);
        return Ok(result);
    }

    //[HttpGet]
    //[Route("search-room")]
    //public async Task<IActionResult> GetRoomSearch()
    //{
    //    var result = await _roomUserRepository.GetRoomSearch();
    //    return Ok(result);
    //}
}
