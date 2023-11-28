using MagicPost_ViewModel.Utilities.Slides;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.Utilities.Slides
{
	public interface ISlideService
	{
		Task<List<SlideVm>> GetAll();
	}
}
