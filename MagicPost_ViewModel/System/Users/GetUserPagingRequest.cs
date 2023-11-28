using MagicPost_ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ViewModel.System.Users
{
    public  class GetUserPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
