
using HB8.CSMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HB8.CSMS.MVC.Models.BillSaleOrder;
using HB8.CSMS.MVC.Models.ChartModel;
using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;

namespace HB8.CSMS.MVC.Controllers
{
    public class AnalyzeController : Controller
    {
        #region Bien
        private IBillSaleOrderManagerService billSaleOrderService;
        public AnalyzeController(IBillSaleOrderManagerService billSaleOrderService)
        {
            this.billSaleOrderService = billSaleOrderService;
        }
        #endregion
        #region Bieu do doanh so ban hang
        private string[] GetCustomerName()
        {
            int number = billSaleOrderService.GetListBill().GroupBy(x => x.CustID).Count();
            string[] names = new string[number];
            int i = 0;
            var model = billSaleOrderService.GetCustomerNames().GroupBy(x => x.CustID);
            foreach (var item in model)
            {
                names[i] = item.First().CustName;
                i++;
            }
            return names;
        }
        private object[] TotalAmt()
        {
            int number = billSaleOrderService.GetListBill().GroupBy(x => x.CustID).Count();
            object[] objects = new object[number];
            var model = billSaleOrderService.TotalAmt();
            int i = 0;
            foreach (var item in model)
            {
                objects[i] = item.TotalAmt;
                i++;
            }
            return objects;
        }

        #endregion
        #region Bieu do san pham ban chay nhat trong thang
        //Danh sach san pham ban chay nhat
        private string[] GetInventoryName(int? month)
        {
            if (month == null)
            {
                month = DateTime.Now.Month;
                var bills = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == month);
                var detailBill = billSaleOrderService.GetListBillDetail();
                var detailBillsGroup = detailBill.GroupBy(x => x.InvtID);
                int number = detailBill.GroupBy(x => x.InvtID).Count();
                string[] name = new string[number];
                int i = 0;
                foreach (var detail in detailBillsGroup)
                {
                    foreach (var item in bills)
                    {
                        //if (item.SOrderNo == detail.SOrderNo)
                        //{
                        //    name[i] = detail.InvtName;
                        //    i++;
                        //}
                    }
                   
                }

                return name;
            }
            else
            {
                return null;
            }

        }
        private object[] TotalQuantity()
        {
            int number = billSaleOrderService.GetListBill().GroupBy(x => x.CustID).Count();
            object[] objects = new object[number];
            var model = billSaleOrderService.TotalAmt();
            int i = 0;
            foreach (var item in model)
            {
                objects[i] = item.TotalAmt;
                i++;
            }
            return objects;
        }
        #endregion
        #region
        public ActionResult ChartForInventoryThisMonth()
        {
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column, Margin = new[] { 50, 50, 100, 80 } })
                .SetTitle(new Title { Text = "Danh sách mặt hàng trong tháng " + DateTime.Now.Month })
                .SetXAxis(new XAxis
                {
                    Categories = GetInventoryName(null),
                    Labels = new XAxisLabels
                    {
                        Rotation = -45,
                        Align = HorizontalAligns.Right,
                        Style = "fontSize: '13px',fontFamily: 'Verdana, sans-serif'"
                    }
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle { Text = "Tổng doanh thu" }
                })
                .SetLegend(new Legend { Enabled = false })
                .SetTooltip(new Tooltip { Formatter = "TooltipFormatter" })
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true,
                            Rotation = -90,
                            Color = ColorTranslator.FromHtml("#FFFFFF"),
                            Align = HorizontalAligns.Right,
                            X = 4,
                            Y = 10,
                            Formatter = "function() { return this.y; }",
                            Style = "fontSize: '13px',fontFamily: 'Verdana, sans-serif',textShadow: '0 0 3px black'"
                        }
                    }
                })
                .SetSeries(new Series
                {
                    Name = "Population",
                    Data = new Data(TotalAmt()),
                });

            return PartialView("ChartForBillThisMonth", chart);
        }
        #endregion
        #region Start Chart
        public ActionResult ShowIndex()
        {
            return View();
        }
        #endregion
        #region Trang Index
        public ActionResult Index()
        {
            return PartialView("IndexPartialView");
        }
        #endregion
        #region Show NAVBAR
        public ActionResult NavBar()
        {
            return PartialView("PanelForChartPartialView");
        }
        #endregion

    }
}
