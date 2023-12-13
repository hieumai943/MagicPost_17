using MagicPost__Data.EF;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.DiemGiaoDichs
{
    public class DiemGiaoDichService : IDiemGiaoDichService
    {
        private readonly MagicPostDbContext _context;

        public DiemGiaoDichService(MagicPostDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<PageResult<DiemGiaoDichVm>>> GetAllPaging(PagingRequestBase request, int DiemTapKetId)
        {
            var query = from p in _context.DiemGiaoDichs
                        where p.DiemTapKetId == DiemTapKetId
                        select new { p };
            // filter
            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new DiemGiaoDichVm()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    Address = x.p.Address,
                    UserId = x.p.UserId,
                    TruongDiemGiaoDich = x.p.TruongDiemGiaoDich
                }).ToListAsync();

            var pageResult = new PageResult<DiemGiaoDichVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return new ApiSuccessResult<PageResult<DiemGiaoDichVm>>(pageResult);

        }
    }
}
