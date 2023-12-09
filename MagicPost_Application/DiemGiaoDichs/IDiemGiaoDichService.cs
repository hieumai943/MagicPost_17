using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.DiemGiaoDichs
{
    public interface IDiemGiaoDichService
    {
        Task<PageResult<DiemGiaoDichVm>> GetAllPaging(PagingRequestBase request, int DiemTapKetId);

    }
}
