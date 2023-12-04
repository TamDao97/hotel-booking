using WebHotel.DTO.ContactDtos;

namespace WebHotel.DTO.QuestionDtos
{
    public class QuestionCreateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class QuestionResponseDto : QuestionCreateDto
    {
    }

    public class QuestionFilterDto : GridBase
    {
    }
}
