

using MagicPost__Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime? OrderDate { set; get; }
        public Guid? UserId { set; get; }
        public int? LogId { set; get; }
        public string? Code { set; get; }
		public string SendName { set; get; }

		public string ReceiveName { set; get; }
        public string SendAddress { set; get; }
		public string ReceiveAddress { set; get; }
		public string SendPhoneNumber { set; get; }
		public string ReceivePhoneNumber { set; get; }
		public decimal Cuoc { set; get; }
		public double KhoiLuong { set; get; }

        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; } // quan he 1 nhieu o day la: 1 order co nhieu order details con 1 order tails chi thuoc 1 order

        public AppUser AppUser { get; set; }
  
        public Log? Log { get; set; }

    }
}
