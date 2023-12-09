using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ApiIntergration
{
    public interface IDiemGiaoDichApiClient
    {
        Task<ApiResult<PageResult<DiemGiaoDichVm>>> GetUsersPagings(PagingRequestBase request);

    }
}
