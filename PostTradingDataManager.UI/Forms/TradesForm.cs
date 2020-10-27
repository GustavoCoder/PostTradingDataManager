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

namespace PostTradingDataManager.UI
{
    public partial class TradesForm : Form
    {
        #region "API Endpoints"

        private string allTradesEndpoint = ConfigurationManager.AppSettings.Get("allTradesEndpoint");
        private string filteredTradesEndpoint = ConfigurationManager.AppSettings.Get("filteredTradesEndpoint");

        #endregion

        #region "Attributes"

        private IEnumerable<TradeDto> _trades;
        private IEnumerable<FilteredTradesDto> _filteredTrades;

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
        private async Task GetTrades()
        {
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(allTradesEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        _trades = JsonConvert.DeserializeObject<IEnumerable<TradeDto>>(content);

                        this.dgvTrades.DataSource = _trades;
                        this.lblRowCount.Text = $"Rows: {this.dgvTrades.Rows.Count}";
                        this.lblRowCount.Visible = true;
                        this.tradeIdDataGridViewTextBoxColumn.Visible = true;
                        this.tradeDateDataGridViewTextBoxColumn.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show($"Failed to load information: {response.ReasonPhrase} ");
                    }
                }
            }
        }

        private async Task GetFilteredTrades()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(filteredTradesEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        _filteredTrades = JsonConvert.DeserializeObject<IEnumerable<FilteredTradesDto>>(content);
                        this.dgvTrades.DataSource = _filteredTrades;
                        this.UpdateRowsCount();
                        this.lblRowCount.Visible = true;
                    }
                }
            }
        }

        #endregion

        private List<FilteredTradesDto> CalculateAveragePrice(IEnumerable<FilteredTradesDto> filteredTrades)
        {
            if (rbGroupByAll.Checked)
            {

                this.RefreshGridViewGrouping();

                var result = from trade in filteredTrades
                             group trade by new { trade.Ticker, trade.Side, trade.Account } into g
                             select new FilteredTradesDto
                             {
                                 Ticker = g.Key.Ticker,
                                 Side = g.Key.Side,
                                 Account = g.Key.Account,
                                 Quantity = g.Sum(x => x.Quantity),
                                 Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                             };

                return result.ToList();

            }  
            else if (rbGroupByTicker.Checked)
            {
                this.RefreshGridViewTickerGrouping();

                var result = from trade in filteredTrades
                             group trade by new {trade.Ticker} into g
                             select new FilteredTradesDto
                             {
                                 Ticker = g.Key.Ticker,
                                 Quantity = g.Sum(x => x.Quantity),
                                 Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                             };

                return result.ToList();
            } 
            else if (rbGroupBySide.Checked)
            {
                this.RefreshGridViewSideGrouping();

                var result = from trade in filteredTrades
                             group trade by new { trade.Side } into g
                             select new FilteredTradesDto
                             {
                                 Side = g.Key.Side,
                                 Quantity = g.Sum(x => x.Quantity),
                                 Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                             };

                return result.ToList();

            } else if (rbGroupByAccount.Checked)
            {
                this.RefreshGridViewAccountGrouping();

                var result = from trade in filteredTrades
                             group trade by new { trade.Account } into g
                             select new FilteredTradesDto
                             {
                                 Account = g.Key.Account,
                                 Quantity = g.Sum(x => x.Quantity),
                                 Price = g.Sum(y => (y.Quantity * y.Price) / g.Sum(z => z.Quantity))
                             };

                return result.ToList();

            }

            return null;
        }

        #region "Events"
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await this.GetTrades();
        }
        private async void btnAverages_Click(object sender, EventArgs e)
        {
            await this.GetFilteredTrades();
            _filteredTrades = CalculateAveragePrice(_filteredTrades);
            this.RefreshDataSource(_filteredTrades.ToList());
            this.UpdateRowsCount();
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

        private void RefreshDataSource(List<FilteredTradesDto> filteredTrades)
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


        #endregion

    }
}
