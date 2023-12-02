using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.ContactDtos;
using WebHotel.DTO.RoomDtos;
using WebHotel.Repository.UserRepository.ContactRepository;

namespace WebHotel.Controllers.UserController;

[ApiController]
[ApiVersion("1.0")]
[Route("user/")]
public partial class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;
    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpPost]
    [Route("contact/create")]
    public async Task<IActionResult> Create(ContactCreateDto req)
    {
        var result = await _contactRepository.Create(req);
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
