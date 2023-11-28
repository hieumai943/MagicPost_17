using MagicPost_ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ApiIntergration
{
    public interface ISlideApiClient
    {
        Task<List<SlideVm>> GetAll();
    }
}
