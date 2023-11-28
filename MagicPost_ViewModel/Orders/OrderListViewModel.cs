using MagicPost_ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ViewModel.Orders
{
	public class OrderListViewModel
	{
		public PageResult<OrderVm> Orders { get; set; }

	}
}
