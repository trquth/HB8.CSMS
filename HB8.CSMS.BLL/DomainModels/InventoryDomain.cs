﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB8.CSMS.BLL.DomainModels
{
    public class InventoryDomain
    {
        public string InvtID { get; set; }
        public string InvtName { get; set; }
        public int ClassId { get; set; }
        public int UnitID { get; set; }
        public int UnitRate { get; set; }
        public int QtyStock { get; set; }
        public decimal SlsTax { get; set; }
        public string StInventoryId { get; set; }
        public string Description { get; set; }
        public string StaffId { get; set; }
        public string StockID { get; set; }
        public decimal SalePrice_T { get; set; }
        public decimal SalePrice_L { get; set; }
        public string ClassName { get; set; }
        public string UnitName { get; set; }
        public string StInvetoryName { get; set; }
        public string StaffName { get; set; }
        public string StockName { get; set; }
    }
}
