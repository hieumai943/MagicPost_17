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
        Task<PageResult<OrderVm>> GetPagings(GetManageOrderPagingRequest request);
        Task<PageResult<OrderVm>> GetPagingNhan(GetManageOrderPagingRequest request);
        Task<PageResult<OrderVm>> GetPagingGui(GetManageOrderPagingRequest request);

       

    }
}
