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
            var temp = await _context.Orders.FindAsync(request.OrderId);
            var log = new Log();
            if(temp.Status == OrderStatus.InGD1)
            {
                log.OrderStatus = OrderStatus.ToTk1;
                var gd = await _context.DiemGiaoDichs.FindAsync(temp.DiemGiaoDichId);
                log.DiemGiaoDichFromId = temp.DiemGiaoDichId;
                log.DiemTapKetToId = gd.DiemTapKetId;
                temp.DiemTapKetId = log.DiemTapKetToId;
                temp.DiemGiaoDichId = null;
                temp.Status = OrderStatus.InTk1;
            }
            else if(temp.Status == OrderStatus.InTk1)
            {
                log.OrderStatus = OrderStatus.ToTk2;
                log.DiemTapKetFromId = temp.DiemTapKetId;
                log.DiemTapKetToId = request.ToDiemTk;
                temp.DiemTapKetId = request.ToDiemTk;
                temp.Status = OrderStatus.InTk2;
            }
            else if(temp.Status == OrderStatus.InTk2)
            {
                log.OrderStatus = OrderStatus.ToGD2;
                log.DiemTapKetFromId = temp.DiemTapKetId;
                log.DiemGiaoDichToId = request.ToDiemGd;
                temp.DiemGiaoDichId = log.DiemGiaoDichToId;
                temp.DiemTapKetId = null;
            }
            else if(temp.Status == OrderStatus.InGD2)
            {
                log.OrderStatus = OrderStatus.Shipping;
                log.DiemGiaoDichFromId = temp.DiemGiaoDichId;
            }
            log.DateCreated = DateTime.Now;
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
