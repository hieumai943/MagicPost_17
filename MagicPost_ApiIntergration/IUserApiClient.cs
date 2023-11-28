
using MagicPost_ViewModel.Common;

using MagicPost_ViewModel.System.Users;

namespace MagicPost_ApiIntergration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PageResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<bool>> RoleAssign( Guid id , RoleAssignRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);


    }
}
