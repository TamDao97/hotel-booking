namespace WebHotel.DTO.ContactDtos
{
    public class ContactCreateDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName
        {
            get { return $"{this.LastName} {this.FirstName}"; }
        }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Message { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? Status { get; set; }
    }

    public class ContactResponseDto : ContactCreateDto
    {
    }

    public class ContactFilterDto : GridBase
    {
    }
}
