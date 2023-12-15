using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.Transfer
{
    public interface ITransferService
    {
        Task<LogVm> GetById(int transferId);
        Task<int> Create(TransferCreateRequest request);

    }
}
