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
    public interface ILogApiClient
    {
        Task<PageResult<OrderVm>> GetAllPagingDiemGiaoDichNhan(GetManageOrderPagingRequest request, int DiemGiaoDichId);
        Task<PageResult<OrderVm>> GetAllPagingDiemTapKetNhan(GetManageOrderPagingRequest request, int DiemTapKetId);

        Task<PageResult<OrderVm>> GetAllPagingDiemGiaoDichGui(GetManageOrderPagingRequest request, int DiemGiaoDichId);

        Task<PageResult<OrderVm>> GetAllPagingDiemTapKetGui(GetManageOrderPagingRequest request, int DiemTapKetId);
        Task<PageResult<OrderVm>> GetAllPagingGui(GetManageOrderPagingRequest request);
        Task<PageResult<OrderVm>> GetAllPagingNhan(GetManageOrderPagingRequest request);

    }
}
