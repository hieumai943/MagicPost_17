using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPostUtilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.Transfer
{
    public class TransferService : ITransferService
    {
        private readonly MagicPostDbContext _context;

        public TransferService(MagicPostDbContext context)
        {
            _context = context;
        }

 
        public async Task<int> Create(TransferCreateRequest request)
        {

            var log = new Log()
            {
                DateCreated = DateTime.Now,
                OrderId = 1,
                DiemGiaoDichFromId = request.FromDiemGd,
                DiemGiaoDichToId = request.ToDiemGd,
                DiemTapKetFromId = request.FromDiemTk,
                DiemTapKetToId = request.ToDiemTk,
                OrderStatus = request.Status
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return log.Id;
        }

        public async Task<LogVm> GetById(int logId)
        {
            var log = await _context.Logs.FindAsync(logId);
            var logViewModel = new LogVm()
            {
                Id = log.Id,
                DateCreated = log.DateCreated,
                OrderStatus = log.OrderStatus,
                DiemTapKetFrom = log.DiemTapKetFromId,
                DiemGiaoDichFrom = log.DiemGiaoDichFromId,
                DiemGiaoDichTo = log.DiemGiaoDichToId,
                DiemTapKetTo = log.DiemTapKetToId
            };
            return logViewModel;
        }

    }
}
