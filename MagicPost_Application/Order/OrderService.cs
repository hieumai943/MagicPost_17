using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.Order
{
	public class OrderService : IOrderService
	{
		private readonly MagicPostDbContext _context;

		public OrderService(MagicPostDbContext context)
		{
			_context = context;
		}

		public async Task<PageResult<OrderVm>> GetAllPaging(GetManageOrderPagingRequest request)
		{
			var query = from p in _context.Orders
						join pi in _context.ProductImages on p.Id equals pi.ProductId into ppi
						from pi in ppi.DefaultIfEmpty()
						select new { p, pi };
			// filter
			if (!string.IsNullOrEmpty(request.Keyword))
				query = query.Where(x => x.p.Code.Contains(request.Keyword));
			
			//3 .paging
			int totalRow = await query.CountAsync();
			var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
				.Select(x => new OrderVm()
				{
					Id = x.p.Id,
					OrderDate = x.p.OrderDate,
					Code = x.p.Code,
					SendName = x.p.SendName,
					ReceiveName = x.p.ReceiveName,
					SendAddress = x.p.SendAddress,
					ReceiveAddress = x.p.ReceiveAddress,
					Cuoc = x.p.Cuoc,
					KhoiLuong = x.p.KhoiLuong,
					ThumbnailImage = x.pi.ImagePath
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

		public async Task<OrderVm> GetById(int orderId)
		{
			var order = await _context.Orders.FindAsync(orderId);
		
			
			var orderViewModel = new OrderVm()
			{
				Id = order.Id,
				OrderDate = order.OrderDate,
				UserId = order.UserId,
				Code = order.Code,
				SendName = order.SendName,
				ReceiveName = order.ReceiveName,
				SendAddress = order.SendAddress,
				ReceiveAddress	= order.ReceiveAddress,
				SendPhoneNumber	= order.SendPhoneNumber,
				ReceivePhoneNumber	= order.ReceivePhoneNumber,
				Cuoc = order.Cuoc,
				KhoiLuong = order.KhoiLuong,
				Status = order.Status
			};
			return orderViewModel;
		}
	}
}
