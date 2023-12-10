using MagicPost__Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public int? DiemGiaoDichFromId { get; set; }
        public int? DiemTapKetFromId { get; set; }
        public int? DiemGiaoDichToId { get; set; }
        public int? DiemTapKetToId { get; set; }
        public int OrderId { get; set; }
        public DiemGiaoDich? DiemGiaoDichFrom { get; set; }
        public DiemTapKet? DiemTapKetFrom { get; set; }
        public DiemGiaoDich? DiemGiaoDichTo { get; set; }
        public DiemTapKet? DiemTapKetTo { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Order Order { get; set; }


    }
}
