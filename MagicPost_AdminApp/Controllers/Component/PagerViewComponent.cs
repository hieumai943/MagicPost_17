using MagicPost_ViewModel.Common;
using Microsoft.AspNetCore.Mvc;


namespace MagicPost_AdminApp.Controllers.Component
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
