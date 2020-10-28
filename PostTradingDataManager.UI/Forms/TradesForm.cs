using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.Diagnostics;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace PostTradingDataManager.UI
{
    public partial class TradesForm : Form
    {
        #region "API Endpoints"

        private string tradesEndpoint = ConfigurationManager.AppSettings.Get("getall");

        #endregion

        #region "Attributes"

        private IEnumerable<TradesDto> _trades;
        private IEnumerable<TradesDto> _summarizedTrades;
        private IEnumerable<TradesDto> _summarizedByTicker;
        private IEnumerable<TradesDto> _summarizedBySide;
        private IEnumerable<TradesDto> _summarizedByAccount;


        #endregion

        #region "Constructor"
        public TradesForm()
        {
            InitializeComponent();
            lblRowCount.Visible = false;
            btnGroupSearch.Enabled = false;
        }
        #endregion

        #region "Tasks"
        private async Task LoadTrades()
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(tradesEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        _trades = JsonConvert.DeserializeObject<IEnumerable<TradesDto>>(content);

                        this.dgvTrades.DataSource = _trades;
                        this.UpdateRowsCount();
                        this.lblRowCount.Visible = true;
                        this.tradeIdDataGridViewTextBoxColumn.Visible = true;
                        this.tickerDataGridViewTextBoxColumn.Visible = true;
                        this.tradeDateDataGridViewTextBoxColumn.Visible = true;
                        this.priceDataGridViewTextBoxColumn.HeaderText = "Price";

                    }
                    else
                    {
                        MessageBox.Show($"Failed to load information: {response.ReasonPhrase} ");
                    }
                }
            }
        }

        #endregion

        private async Task<List<TradesDto>> SummarizeTrades(IEnumerable<TradesDto> trades)
        {

            if (rbGroupByAll.Checked)
            {
                if (_summarizedTrades == null)
                {
                    _summarizedTrades = await Task.Run(() => from item in trades
                                                             group item by new { item.Ticker, item.Side, item.Account } into g
                                                             orderby g.Key.Account, g.Key.Ticker, g.Key.Side
                                                             select new TradesDto
                                                             {
                                                                 Ticker = g.Key.Ticker,
                                                                 Side = g.Key.Side,
                                                                 Account = g.Key.Account,
                                                                 Quantity = g.Sum(x => x.Quantity),
                                                                 Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                                                             });
                }

                this.RefreshGridViewGrouping();
                return _summarizedTrades.ToList();


            }
            else if (rbGroupByTicker.Checked)
            {

                if (_summarizedByTicker == null)
                {
                    _summarizedByTicker = await Task.Run(() => from item in trades
                                                               group item by new { item.Ticker } into g
                                                               orderby g.Key.Ticker
                                                               select new TradesDto
                                                               {
                                                                   Ticker = g.Key.Ticker,
                                                                   Quantity = g.Sum(x => x.Quantity),
                                                                   Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                                                               });
                }

                this.RefreshGridViewTickerGrouping();
                return _summarizedByTicker.ToList();

            }
            else if (rbGroupBySide.Checked)
            {

                if (_summarizedBySide == null)
                {
                    _summarizedBySide = await Task.Run(() => from trade in trades
                                                             group trade by new { trade.Side } into g
                                                             orderby g.Key.Side
                                                             select new TradesDto
                                                             {
                                                                 Side = g.Key.Side,
                                                                 Quantity = g.Sum(x => x.Quantity),
                                                                 Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                                                             });
                }


                this.RefreshGridViewSideGrouping();
                return _summarizedBySide.ToList();

            }
            else
            {
                if (_summarizedByAccount == null)
                {
                    _summarizedByAccount = await Task.Run(() => from trade in trades
                                                                group trade by new { trade.Account } into g
                                                                orderby g.Key.Account
                                                                select new TradesDto
                                                                {
                                                                    Account = g.Key.Account,
                                                                    Quantity = g.Sum(x => x.Quantity),
                                                                    Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                                                                });
                }


                this.RefreshGridViewAccountGrouping();
                return _summarizedByAccount.ToList();

            }
        }

        #region "Events"
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await this.LoadTrades();
            stopwatch.Stop();

            var timeElapsed = stopwatch.ElapsedMilliseconds;
            MessageBox.Show($"Time elapsed: {timeElapsed}");
            

        }

        private async void btnGroupTrades_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = await SummarizeTrades(_trades);
            this.RefreshDataSource(result.ToList());
            this.UpdateRowsCount();
            stopwatch.Stop();
            var timeElapsed = stopwatch.ElapsedMilliseconds;
            MessageBox.Show($"Time elapsed: {timeElapsed}");
        }

        private void rbGroupByAll_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
        }

        private void rbGroupByTicker_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
        }

        private void rbSide_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
        }

        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvTrades.Rows.Count > 0)
            {
                try
                {
                    Application xcelApp = new Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvTrades.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvTrades.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvTrades.Rows.Count; i++)
                    {
                        for(int j = 0; j < dgvTrades.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvTrades.Rows[i].Cells[j].Value;
                        }
                    }

                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;

                } catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            //GetDestinationFile();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Utility Methods"
        private void UpdateRowsCount()
        {
            this.lblRowCount.Text = $"Rows: {this.dgvTrades.Rows.Count}";
        }

        private void RefreshDataSource(List<TradesDto> filteredTrades)
        {
            this.dgvTrades.DataSource = filteredTrades;
        }

        private void RefreshGridViewGrouping()
        {
            this.sideDataGridViewTextBoxColumn.Visible = true;
            this.accountDataGridViewTextBoxColumn.Visible = true;
            this.tickerDataGridViewTextBoxColumn.Visible = true;
            this.tradeIdDataGridViewTextBoxColumn.Visible = false;
            this.tradeDateDataGridViewTextBoxColumn.Visible = false;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Average Price";
        }

        private void RefreshGridViewSideGrouping()
        {
            this.sideDataGridViewTextBoxColumn.Visible = true;
            this.accountDataGridViewTextBoxColumn.Visible = false;
            this.tickerDataGridViewTextBoxColumn.Visible = false;
            this.tradeIdDataGridViewTextBoxColumn.Visible = false;
            this.tradeDateDataGridViewTextBoxColumn.Visible = false;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Average Price";
        }
        private void RefreshGridViewAccountGrouping()
        {
            this.sideDataGridViewTextBoxColumn.Visible = false;
            this.accountDataGridViewTextBoxColumn.Visible = true;
            this.tickerDataGridViewTextBoxColumn.Visible = false;
            this.tradeIdDataGridViewTextBoxColumn.Visible = false;
            this.tradeDateDataGridViewTextBoxColumn.Visible = false;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Average Price";
        }

        private void RefreshGridViewTickerGrouping()
        {
            this.tickerDataGridViewTextBoxColumn.Visible = true;
            this.sideDataGridViewTextBoxColumn.Visible = false;
            this.accountDataGridViewTextBoxColumn.Visible = false;
            this.tradeIdDataGridViewTextBoxColumn.Visible = false;
            this.tradeDateDataGridViewTextBoxColumn.Visible = false;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Average Price";
        }
        private string GetDestinationFile()
        {
            using (var path = new SaveFileDialog())
            {
                path.Title = "Exporting to excel...";
                path.Filter = "Excel files (*.xlsx)|*.xlsx";
                path.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path.CreatePrompt = false;

                var result = path.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return null;
                }

                return path.FileName;
            }
        }

        private void CopyDataToClipboard()
        {
            dgvTrades.SelectAll();
            DataObject data = dgvTrades.GetClipboardContent();
            if(data != null)
            {
                Clipboard.SetDataObject(data);
            }
        }
        #endregion


    }
}
