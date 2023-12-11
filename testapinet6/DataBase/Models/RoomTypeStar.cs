using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class RoomTypeStar
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public string? UserName { get; set; }
        public float? Std { get; set; }
        public float? Sup { get; set; }
        public float? Dlx { get; set; }
        public float? Sut { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
