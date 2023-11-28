using Microsoft.AspNetCore.Mvc;
using MagicPost_ViewModel.Common;

namespace MagicPost_WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
