using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost_Application.Orders;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.Orders;
using MagicPostUtilities.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.Logs
{
	public class LogService : ILogService
	{
		private readonly MagicPostDbContext _context;
       // private readonly OrderService orderService;

        public LogService(MagicPostDbContext context)
		{
			_context = context;
           // this.orderService = orderService;
		}

      
        public async Task<PageResult<OrderVm>> GetAllPagingDiemGiaoDichNhan(GetManageOrderPagingRequest request, int DiemGiaoDichId)
        {

            var query = from p in _context.Logs
                        where p.DiemGiaoDichFromId.Value == DiemGiaoDichId
                        select new { p, p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);
            }
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id = x.p.Order.Id,
                    OrderDate = x.p.Order.OrderDate,
                    Code = x.p.Order.Code,
                    SendName = x.p.Order.SendName,
                    ReceiveName = x.p.Order.ReceiveName,
                    SendAddress = x.p.Order.SendAddress,
                    ReceiveAddress = x.p.Order.ReceiveAddress,
                    Cuoc = x.p.Order.Cuoc,
                    KhoiLuong = x.p.Order.KhoiLuong,
                    // ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            var pageResult = new PageResult<OrderVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return pageResult;
        }
        public async Task<PageResult<OrderVm>> GetAllPagingDiemTapKetNhan(GetManageOrderPagingRequest request, int DiemTapKetId)
        {

            var query = from p in _context.Logs
                        where p.DiemTapKetFromId.Value == DiemTapKetId
                        select new { p, p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);
            }
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id = x.p.Order.Id,
                    OrderDate = x.p.Order.OrderDate,
                    Code = x.p.Order.Code,
                    SendName = x.p.Order.SendName,
                    ReceiveName = x.p.Order.ReceiveName,
                    SendAddress = x.p.Order.SendAddress,
                    ReceiveAddress = x.p.Order.ReceiveAddress,
                    Cuoc = x.p.Order.Cuoc,
                    KhoiLuong = x.p.Order.KhoiLuong,
                    // ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            var pageResult = new PageResult<OrderVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return pageResult;
        }
        public async Task<PageResult<OrderVm>> GetAllPagingNhan(GetManageOrderPagingRequest request)
        {

            var query = from p in _context.Logs
                        where p.DiemGiaoDichFromId.HasValue == true || p.DiemTapKetFromId.HasValue == true
                        select new { p, p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);
            }
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id = x.p.Order.Id,
                    OrderDate = x.p.Order.OrderDate,
                    Code = x.p.Order.Code,
                    SendName = x.p.Order.SendName,
                    ReceiveName = x.p.Order.ReceiveName,
                    SendAddress = x.p.Order.SendAddress,
                    ReceiveAddress = x.p.Order.ReceiveAddress,
                    Cuoc = x.p.Order.Cuoc,
                    KhoiLuong = x.p.Order.KhoiLuong,
                    // ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            var pageResult = new PageResult<OrderVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return pageResult;
        }
        public async Task<PageResult<OrderVm>> GetAllPagingGui(GetManageOrderPagingRequest request)
        {

            var query = from p in _context.Logs
                        where p.DiemGiaoDichToId.HasValue == true || p.DiemTapKetToId.HasValue == true
                        select new { p, p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);
            }
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id = x.p.Order.Id,
                    OrderDate = x.p.Order.OrderDate,
                    Code = x.p.Order.Code,
                    SendName = x.p.Order.SendName,
                    ReceiveName = x.p.Order.ReceiveName,
                    SendAddress = x.p.Order.SendAddress,
                    ReceiveAddress = x.p.Order.ReceiveAddress,
                    Cuoc = x.p.Order.Cuoc,
                    KhoiLuong = x.p.Order.KhoiLuong,
                    // ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            var pageResult = new PageResult<OrderVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return pageResult;
        }
        public async Task<PageResult<OrderVm>> GetAllPagingDiemGiaoDichGui(GetManageOrderPagingRequest request, int DiemGiaoDichId)
        {

            var query = from p in _context.Logs
                        where p.DiemGiaoDichToId.Value == DiemGiaoDichId
                        select new { p, p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);

            }
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id = x.p.Order.Id,
                    OrderDate = x.p.Order.OrderDate,
                    Code = x.p.Order.Code,
                    SendName = x.p.Order.SendName,
                    ReceiveName = x.p.Order.ReceiveName,
                    SendAddress = x.p.Order.SendAddress,
                    ReceiveAddress = x.p.Order.ReceiveAddress,
                    Cuoc = x.p.Order.Cuoc,
                    KhoiLuong = x.p.Order.KhoiLuong,
                    // ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            var pageResult = new PageResult<OrderVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return pageResult;
        }
        public async Task<PageResult<OrderVm>> GetAllPagingDiemTapKetGui(GetManageOrderPagingRequest request, int DiemTapKetId)
        {

            var query = from p in _context.Logs
                        where p.DiemTapKetToId.Value == DiemTapKetId
                        select new { p, p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);

            }
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id = x.p.Order.Id,
                    OrderDate = x.p.Order.OrderDate,
                    Code = x.p.Order.Code,
                    SendName = x.p.Order.SendName,
                    ReceiveName = x.p.Order.ReceiveName,
                    SendAddress = x.p.Order.SendAddress,
                    ReceiveAddress = x.p.Order.ReceiveAddress,
                    Cuoc = x.p.Order.Cuoc,
                    KhoiLuong = x.p.Order.KhoiLuong,
                    // ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();
            var pageResult = new PageResult<OrderVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return pageResult;
        }
        public async Task<PageResult<OrderVm>> GetAllPaging(GetManageOrderPagingRequest request)
		{
			
			var query = from p in _context.Logs
						
						select new { p , p.Order };
            // filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Order.Code.Contains(request.Keyword));
            if (request.OrderStatusId != null)
            {
                query = query.Where(x => (int)x.p.Order.Status == request.OrderStatusId);

            }
            //3 .paging
            int totalRow = await query.CountAsync();
			var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
				.Select(x => new OrderVm()
				{
					Id = x.p.Order.Id,
					OrderDate = x.p.Order.OrderDate,
					Code = x.p.Order.Code,
					SendName = x.p.Order.SendName,
					ReceiveName = x.p.Order.ReceiveName,
					SendAddress = x.p.Order.SendAddress,
					ReceiveAddress = x.p.Order.ReceiveAddress,
					Cuoc = x.p.Order.Cuoc,
					KhoiLuong = x.p.Order.KhoiLuong,
					// ThumbnailImage = x.pi.ImagePath
				}).ToListAsync();
			var pageResult = new PageResult<OrderVm>()
			{
				items = data,
				PageSize = request.PageSize,
				PageIndex = request.PageIndex,
				TotalRecords = totalRow
			};
			return pageResult;
		}

	}
}
