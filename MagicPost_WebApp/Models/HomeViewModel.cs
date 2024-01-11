using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPost_ViewModel.Utilities.Slides;

namespace MagicPost_WebApp.Models
{
	public class HomeViewModel
    {
        //  public List<SlideVm> Slides { get; set; }
        public PageResult<OrderVm> Orders { get; set; }
    }
}
