using System;
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
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> UnitRate { get; set; }
        public Nullable<decimal> SalesPriceT { get; set; }
        public Nullable<decimal> SalesPriceL { get; set; }
        public int QtyStock { get; set; }
        public decimal SlsTax { get; set; }
        public string StInventoryId { get; set; }
        public string Description { get; set; }
        public string StaffId { get; set; }
    }
}
