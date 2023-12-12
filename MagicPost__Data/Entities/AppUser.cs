using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int? DiemGiaoDichId { get; set; }
        public int? DiemTapKetId { get; set; }
        public DateTime Dob { get; set; }

        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }
        // neu la truong diem giao dich hay giao dich vien tai diem giao dich
        public DiemGiaoDich? DiemGiaoDich { get; set; }
        // neu la nhan vien tai diem tap ket hoac truong diem tap ket
        public DiemTapKet? DiemTapKet { get; set; }
    }
}
