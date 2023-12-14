﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicPost__Data.Enums;

namespace MagicPost_ViewModel.Orders
{
    public class TransferCreateRequest
    {
        public DateTime TransferDate { set; get; }
        //public Guid? UserId { set; get; }
        public int? FromDiemGd { set; get; }

        public int? FromDiemTk { set; get; }
        public int? ToDiemGd { set; get; }
        public int? ToDiemTk { set; get; }
        public OrderStatus Status { set; get; }
    }
}
