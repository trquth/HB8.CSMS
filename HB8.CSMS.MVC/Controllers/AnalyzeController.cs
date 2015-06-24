
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
        #region Ham tinh toan cho bieu do doanh thu
        private string[] GetCustomerName(int? month)
        {
            if (month == null)
            {
                month = DateTime.Now.Month;
                int number = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == month).GroupBy(x => x.CustID).Count();
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
            else
            {
                int selectMonth = (int)month;
                int number = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == selectMonth).GroupBy(x => x.CustID).Count();
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

        }
        private object[] TotalAmt(int? month)
        {
            if (month == null)
            {
                month = DateTime.Now.Month;
                int number = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == month).GroupBy(x => x.CustID).Count();
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
            else
            {
                int selectMonth = (int)month;
                int number = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == selectMonth).GroupBy(x => x.CustID).Count();
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

        }
        private object[] TotalQuantity(int? month)
        {
            if (month == null)
            {
                month = DateTime.Now.Month;
                int number = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == month).GroupBy(x => x.CustID).Count();
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
            else
            {
                int selectMonth = (int)month;
                int number = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == selectMonth).GroupBy(x => x.CustID).Count();
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

        }
        #endregion
        #region Ham tinh toan cho bieu do san pham
        private string[] GetInventoryName(int? month)
        {
            if (month == null)
            {
                month = DateTime.Now.Month;
                List<BillSaleOrderModel> listBill = new List<BillSaleOrderModel>();
                var bills = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == month);
                var detailBill = billSaleOrderService.GetListBillDetail();
                foreach (var item in bills)
                {
                    foreach (var detail in detailBill)
                    {
                        if (item.SOrderNo == detail.SOrderNo)
                        {
                            var itemBiLL = new BillSaleOrderModel
                            {
                                InvtID = detail.InvtID,
                                InvtName = detail.InvtName,

                            };
                            listBill.Add(itemBiLL);
                        }
                    }

                }
                var result = listBill.GroupBy(x => x.InvtID);
                int count = result.Count();
                string[] name = new string[count];
                int i = 0;
                foreach (var item in result)
                {
                    name[i] = item.Select(x => x.InvtName).First();
                    i++;
                }
                return name;
            }
            else
            {
                int selectMonth = (int)month;
                List<BillSaleOrderModel> listBill = new List<BillSaleOrderModel>();
                var bills = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == selectMonth);
                var detailBill = billSaleOrderService.GetListBillDetail();
                foreach (var item in bills)
                {
                    foreach (var detail in detailBill)
                    {
                        if (item.SOrderNo == detail.SOrderNo)
                        {
                            var itemBiLL = new BillSaleOrderModel
                            {
                                InvtID = detail.InvtID,
                                InvtName = detail.InvtName,

                            };
                            listBill.Add(itemBiLL);
                        }
                    }

                }
                var result = listBill.GroupBy(x => x.InvtID);
                int count = result.Count();
                string[] name = new string[count];
                int i = 0;
                foreach (var item in result)
                {
                    name[i] = item.Select(x => x.InvtName).First();
                    i++;
                }
                return name;
            }

        }
        private object[] TotalQuantityForInventory(int? month)
        {
            if (month == null)
            {
                month = DateTime.Now.Month;
                List<BillSaleOrderModel> listBill = new List<BillSaleOrderModel>();
                var bills = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == month);
                var detailBill = billSaleOrderService.GetListBillDetail();
                foreach (var item in bills)
                {
                    foreach (var detail in detailBill)
                    {
                        if (item.SOrderNo == detail.SOrderNo)
                        {
                            var itemBiLL = new BillSaleOrderModel
                            {
                                InvtID = detail.InvtID,
                                InvtName = detail.InvtName,
                                Qty = detail.Qty,

                            };
                            listBill.Add(itemBiLL);
                        }
                    }

                }
                var result = listBill.GroupBy(x => x.InvtID);
                int count = result.Count();
                object[] objects = new object[count];
                int i = 0;
                foreach (var item in result)
                {
                    int total = 0;
                    foreach (var detail in listBill)
                    {
                        if (item.Select(x => x.InvtID).First() == detail.InvtID)
                        {
                            total += detail.Qty;
                        }
                    }
                    objects[i] = total;
                    i++;
                }
                return objects;
            }
            else
            {
                int selectMonth = (int)month;
                List<BillSaleOrderModel> listBill = new List<BillSaleOrderModel>();
                var bills = billSaleOrderService.GetListBill().Where(x => x.OrderDate.Value.Month == selectMonth);
                var detailBill = billSaleOrderService.GetListBillDetail();
                foreach (var item in bills)
                {
                    foreach (var detail in detailBill)
                    {
                        if (item.SOrderNo == detail.SOrderNo)
                        {
                            var itemBiLL = new BillSaleOrderModel
                            {
                                InvtID = detail.InvtID,
                                InvtName = detail.InvtName,
                                Qty = detail.Qty,

                            };
                            listBill.Add(itemBiLL);
                        }
                    }

                }
                var result = listBill.GroupBy(x => x.InvtID);
                int count = result.Count();
                object[] objects = new object[count];
                int i = 0;
                foreach (var item in result)
                {
                    int total = 0;
                    foreach (var detail in listBill)
                    {
                        if (item.Select(x => x.InvtID).First() == detail.InvtID)
                        {
                            total += detail.Qty;
                        }
                    }
                    objects[i] = total;
                    i++;
                }
                return objects;
            }
        }
        #endregion
        #region Bieu do san pham ban chay nhat trong thang

        /// <summary>
        /// Bieu do cot danh sach hoa don trong thang
        /// </summary>
        /// <returns></returns>
        public ActionResult ChartForBillThisMonth()
        {
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column, Margin = new[] { 50, 50, 100, 80 } })
                .SetTitle(new Title { Text = "Danh sách mặt hàng trong tháng " + DateTime.Now.Month })
                .SetXAxis(new XAxis
                {
                    Categories = GetCustomerName(null),
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
                    Data = new Data(TotalQuantity(null)),
                });

            return View(chart);
        }
        //Danh sach san pham ban chay nhat     
        #endregion
        #region Bieu do doanh thu trong thang
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
                    Title = new YAxisTitle { Text = "Tổng số sản phẩm" }
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
                    Data = new Data(TotalQuantityForInventory(null)),
                });

            return View(chart);
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
