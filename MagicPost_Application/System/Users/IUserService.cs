
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<PageResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<UserVm>> GetById(Guid Id);
        Task<ApiResult<bool>> Delete(Guid Id);


        Task<ApiResult<bool>> RoleAssign(Guid Id, RoleAssignRequest request);
        Task<ApiResult<bool>> Update(Guid Id, UserUpdateRequest request);

    }
}
