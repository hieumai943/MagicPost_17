using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.DiemTapKets
{
    public interface IDiemTapKetService
    {
        Task<ApiResult<PageResult<DiemTapKetVm>>> GetAllPaging(PagingRequestBase request);
        Task<DiemTapKetVm> GetById(int DiemTapKetId);


    }
}
