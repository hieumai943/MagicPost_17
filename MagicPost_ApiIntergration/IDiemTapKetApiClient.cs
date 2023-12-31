﻿using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ApiIntergration
{
    public interface IDiemTapKetApiClient
    {
        Task<ApiResult<PageResult<DiemTapKetVm>>> GetUsersPagings(PagingRequestBase request);

    }
}
