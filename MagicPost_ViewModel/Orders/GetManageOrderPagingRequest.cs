using MagicPost_ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ViewModel.Orders
{
	public class GetManageOrderPagingRequest : PagingRequestBase
	{ 
		public string? Keyword { get; set; }
		public int ? OrderStatusId { get; set; }
	}
}
