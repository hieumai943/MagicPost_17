﻿using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Orders;
using MagicPost_ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_ApiIntergration
{
	public interface IOrderApiClient
	{
		Task<PageResult<OrderVm>> GetPagings(GetManageOrderPagingRequest request);
        Task<PageResult<OrderVm>> GetPagingDiemGiaoDich(GetManageOrderPagingRequest request, int DiemGiaoDichId);
        Task<PageResult<OrderVm>> GetPagingDiemTapKet(GetManageOrderPagingRequest request, int DiemTapKetId);

        Task<byte[]> GetPdf(string nameOfFile,int OrderId);


        Task<OrderVm> GetById(int id, string languageId);
		Task<bool> CreateOrder(OrderCreateRequest request);

    }
}
