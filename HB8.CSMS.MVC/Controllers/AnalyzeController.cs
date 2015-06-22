using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using HB8.CSMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ColumnWithRotatedLabels()
        {
            object[] value = TotalAmt();
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column, Margin = new[] { 10, 10, 30, 20 } })
                .SetTitle(new Title { Text = "Doanh số bán hàng trong năm 2015" })
                .SetXAxis(new XAxis
                {
                    Categories = GetCustomerName(),
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
                    Title = new YAxisTitle { Text = "Population (millions)" }
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
                    Data = new Data(value),
                });

            //return PartialView("ColumnWithRotatedLabels", chart);
            return View(chart);

        }
        public ActionResult PieWithLegend()
        {

            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart { PlotShadow = false, PlotBackgroundColor = null, PlotBorderWidth = null })
                .SetTitle(new Title { Text = "Browser market shares at a specific website, 2010" })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        Cursor = Cursors.Pointer,
                        DataLabels = new PlotOptionsPieDataLabels { Enabled = false },
                        ShowInLegend = true
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Browser share",
                    Data = new Data(billSaleOrderService.GetNameAndTotal().Select(x => new { x.CustName, x.TotalAmt }).ToArray())
                });

            return View(chart);
        }
        public ActionResult ChartPartialView()
        {
            return View("ChartPartialView");
        }
        #endregion
        #region Start Chart

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
