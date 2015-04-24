using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HB8.CSMS.DAL.Models.Mapping;

namespace HB8.CSMS.DAL.Models
{
    public partial class CSMSContext : DbContext
    {
        static CSMSContext()
        {
            Database.SetInitializer<CSMSContext>(null);
        }

        public CSMSContext()
            : base("Name=CSMSContext")
        {
        }

        public DbSet<BillPurchaseOrdDetail> BillPurchaseOrdDetails { get; set; }
        public DbSet<BillPurchaseOrder> BillPurchaseOrders { get; set; }
        public DbSet<BillSaleOrder> BillSaleOrders { get; set; }
        public DbSet<BillSlsOrderDetail> BillSlsOrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StkTransDetail> StkTransDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockRequisition> StockRequisitions { get; set; }
        public DbSet<StockRequisitionDetail> StockRequisitionDetails { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BillPurchaseOrdDetailMap());
            modelBuilder.Configurations.Add(new BillPurchaseOrderMap());
            modelBuilder.Configurations.Add(new BillSaleOrderMap());
            modelBuilder.Configurations.Add(new BillSlsOrderDetailMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new InvoiceTypeMap());
            modelBuilder.Configurations.Add(new PaymentMap());
            modelBuilder.Configurations.Add(new StaffMap());
            modelBuilder.Configurations.Add(new StkTransDetailMap());
            modelBuilder.Configurations.Add(new StockMap());
            modelBuilder.Configurations.Add(new StockRequisitionMap());
            modelBuilder.Configurations.Add(new StockRequisitionDetailMap());
            modelBuilder.Configurations.Add(new StockTransferMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UnitMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new VendorMap());
        }
    }
}
