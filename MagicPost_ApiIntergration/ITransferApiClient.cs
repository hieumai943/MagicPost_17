using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;

namespace MagicPost_ApiIntergration
{
    public interface ITransferApiClient
    {
        Task<bool> CreateTransfer(int id, TransferCreateRequest request);
    }
}
