using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.Orders
{
	public interface IOrderService
	{
		Task<PageResult<OrderVm>> GetAllPaging(GetManageOrderPagingRequest request);
        Task<PageResult<OrderVm>> GetAllPagingDiemTapKet(GetManageOrderPagingRequest request, int DiemTapKetId);
        Task<PageResult<OrderVm>> GetAllPagingDiemGiaoDich(GetManageOrderPagingRequest request, int DiemGiaoDichId);

        Task<OrderVm> GetById(int orderId);
        Task<int> Create(OrderCreateRequest request);
        Task<int> Delete(int orderId);

    }
}
