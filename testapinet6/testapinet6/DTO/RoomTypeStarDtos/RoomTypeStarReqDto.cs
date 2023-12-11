namespace WebHotel.DTO.RoomTypeStarDtos
{
    public class RoomTypeStarReqDto
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public string? UserName { get; set; }
        public float? Std { get; set; }
        public float? Sup { get; set; }
        public float? Dlx { get; set; }
        public float? Sui { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
