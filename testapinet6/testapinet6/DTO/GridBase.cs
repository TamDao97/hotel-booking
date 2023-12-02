namespace WebHotel.DTO
{
    public class GridBase
    {
        public string? KeyWord { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
