using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost__Data.Enums;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPostUtilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

 
        public async Task<int> Create(int id, TransferCreateRequest request)
        {
            var log = new Log()
            {
                //DiemGiaoDichToId = request.ToDiemGd,
                DiemTapKetToId = request.ToDiemTk,
            };
            log.OrderStatus = MagicPost__Data.Enums.OrderStatus.Success;
            log.DateCreated = DateTime.Now;
            var temp = await _context.Orders.FindAsync(request.OrderId);
            log.DiemGiaoDichFromId = temp.DiemGiaoDichId;
            log.DiemTapKetFromId = temp.DiemTapKetId;
            log.OrderId = request.OrderId;
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
