using MagicPost__Data.EF;
using MagicPost__Data.Entities;
using MagicPost_ViewModel.Common;
using MagicPost_ViewModel.Diem;
using MagicPost_ViewModel.Orders;
using MagicPost_ViewModel.System.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost_Application.DiemTapKets
{
    public class DiemTapKetService : IDiemTapKetService
    {
        private readonly MagicPostDbContext _context;

        public DiemTapKetService(MagicPostDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<PageResult<DiemTapKetVm>>> GetAllPaging(PagingRequestBase request)
        {
            var query = from p in _context.DiemTapKets
                    
                        select new { p };
            // filter
            

            //3 .paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new DiemTapKetVm()
                {
                    Id = x.p.Id,
                   Name = x.p.Name,
                   Address = x.p.Address,
                   UserId = x.p.UserId,
                   TruongDiemTapKet = x.p.TruongDiemTapKet
                }).ToListAsync();
            var pageResult = new PageResult<DiemTapKetVm>()
            {
                items = data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                TotalRecords = totalRow
            };
            return new ApiSuccessResult<PageResult<DiemTapKetVm>>(pageResult);
        }

        public async Task<DiemTapKetVm> GetById(int DiemTapKetId)
        {
            var DiemTapKet = await _context.DiemTapKets.FindAsync(DiemTapKetId);


            var DiemTapKetViewModel = new DiemTapKetVm()
            {
                Id = DiemTapKet.Id,
                Name = DiemTapKet.Name,
                Address = DiemTapKet.Address,
                UserId = DiemTapKet.UserId,
                TruongDiemTapKet = DiemTapKet.TruongDiemTapKet
            };
            return DiemTapKetViewModel;
        }
    }
}
