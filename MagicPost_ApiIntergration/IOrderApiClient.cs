using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPost_ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ApiIntergration
{
	public interface IOrderApiClient
	{
		Task<PageResult<OrderVm>> GetPagings(GetManageOrderPagingRequest request);
		Task<OrderVm> GetById(int id, string languageId);
		Task<bool> CreateOrder(OrderCreateRequest request);

    }
}
