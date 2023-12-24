
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.System.Users;

namespace MagicPost_ApiIntergration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PageResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<PageResult<UserVm>>> GetGiaoDichVienPagings(GetUserPagingRequest request, int DiemGiaoDichId );
        Task<ApiResult<PageResult<UserVm>>> GetNhanVienTapKetPagings(GetUserPagingRequest request, int DiemTapKetId);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<ApiResult<bool>> RegisterGiaoDichVien(RegisterRequest registerRequest , int DiemGiaoDichId);
        Task<ApiResult<bool>> RegisterNhanVienTapKet(RegisterRequest registerRequest, int DiemTapKetId);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<bool>> RoleAssign( Guid id , RoleAssignRequest request);
        Task<ApiResult<bool>> DiemTapKetAssign(Guid Userid, DiemTapKetAssignRequest request);
        Task<ApiResult<bool>> DiemGiaoDichAssign(Guid Userid, DiemGiaoDichAssignRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);


    }
}
