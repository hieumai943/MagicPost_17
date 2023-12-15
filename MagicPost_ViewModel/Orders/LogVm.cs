using MagicPost__Data.Entities;
using MagicPost__Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ViewModel.Orders
{
    public class LogVm
    {
        public int Id { get; set; }
        public int? DiemGiaoDichFrom { get; set; }
        public int? DiemTapKetFrom { get; set; }
        public int? DiemGiaoDichTo { get; set; }
        public int? DiemTapKetTo { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
