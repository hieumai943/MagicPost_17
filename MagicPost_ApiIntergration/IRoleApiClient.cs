using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.System.Roles;
using Microsoft.AspNetCore.Mvc;


namespace MagicPost_ApiIntergration
{
    public interface IRoleApiClient 
    {
       
            Task<ApiResult<List<RoleVm>>> GetAll();


    }
}
