using MagicPost__Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ViewModel.Orders
{
	public class OrderVm
	{
		public int Id { set; get; }
		public DateTime? OrderDate { set; get; }
		public Guid? UserId { set; get; }
		public string? Code { set; get; }
		public string SendName { set; get; }

		public string ReceiveName { set; get; }
		public string SendAddress { set; get; }
		public string ReceiveAddress { set; get; }
		public string SendPhoneNumber { set; get; }
		public string ReceivePhoneNumber { set; get; }
		public decimal Cuoc { set; get; }
		public double KhoiLuong { set; get; }
		// public string ThumbnailImage { set; get; }
		public OrderStatus Status { set; get; }
	}
}
