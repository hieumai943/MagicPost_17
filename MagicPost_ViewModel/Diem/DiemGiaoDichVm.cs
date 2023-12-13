using MagicPost__Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ViewModel.Diem
{
    public class DiemGiaoDichVm
    {
        public int Id { set; get; }
        public int DiemTapKetId { set; get; }
        public string Name { set; get; }

        public string Address { set; get; }
        public Guid UserId { set; get; }
        public AppUser TruongDiemGiaoDich { get; set; }

    }
}
