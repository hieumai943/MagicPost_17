using MagicPost__Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Entities
{
    public class DiemGiaoDich
    {
        public int Id { set; get; }
        public int DiemTapKetId { set; get; }
        public string Name { set; get; }

        public string Address { set; get; }

        public Guid? UserId { set; get; }
        public List<Order>? Orders { set; get; }

        public DiemTapKet DiemTapKet { get; set; } // quan he 1 nhieu o day la: 1 order co nhieu order details con 1 order tails chi thuoc 1 order
        // nguoi quan ly diem giao dich
        public AppUser TruongDiemGiaoDich { get; set; }
    }
}
