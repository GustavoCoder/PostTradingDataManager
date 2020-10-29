using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Data;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Text;

namespace PostTradingDataManager.UI
{
    public partial class TradesForm : Form
    {
        #region "API Endpoint"

        private string tradesEndpoint = ConfigurationManager.AppSettings.Get("getall");

        #endregion

        #region "Global Variables"

        private GroupingType _grouping;
        DataTable _dataTable = new DataTable();

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
                        _dataTable = (DataTable)JsonConvert.DeserializeObject(content, typeof(DataTable));

                        this.dgvTrades.DataSource = _dataTable;
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
        private async Task SummarizeTrades(GroupingType groupingType)
        {
            try
            {
                switch (groupingType)
                {
                    case GroupingType.All:
                        {
                            using (var client = new HttpClient())
                            {

                                using (var response = await client.GetAsync($"{tradesEndpoint}/summarized"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        _dataTable = (DataTable) JsonConvert.DeserializeObject(content, typeof(DataTable));


                                        this.RefreshGridViewGrouping();

                                    }
                                    else
                                    {
                                        MessageBox.Show($"Failed to load information: {response.ReasonPhrase} ");
                                    }
                                }
                            }
                            break;
                        }
                    case GroupingType.Ticker:
                        {
                            using (var client = new HttpClient())
                            {

                                using (var response = await client.GetAsync($"{tradesEndpoint}/summarized/ticker"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        _dataTable = (DataTable)JsonConvert.DeserializeObject(content, typeof(DataTable));

                                        this.RefreshGridViewTickerGrouping();

                                    }
                                    else
                                    {
                                        MessageBox.Show($"Failed to load information: {response.ReasonPhrase} ");
                                    }
                                }
                            }

                            break;
                        }
                    case GroupingType.Side:
                        {
                            using (var client = new HttpClient())
                            {

                                using (var response = await client.GetAsync($"{tradesEndpoint}/summarized/side"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        _dataTable = (DataTable)JsonConvert.DeserializeObject(content, typeof(DataTable));

                                        this.RefreshGridViewSideGrouping();

                                    }
                                    else
                                    {
                                        MessageBox.Show($"Failed to load information: {response.ReasonPhrase} ");
                                    }
                                }
                            }
                            break;
                        }
                    case GroupingType.Account:
                        {
                            using (var client = new HttpClient())
                            {

                                using (var response = await client.GetAsync($"{tradesEndpoint}/summarized/account"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        _dataTable = (DataTable)JsonConvert.DeserializeObject(content, typeof(DataTable));

                                        this.RefreshGridViewAccountGrouping();

                                    }
                                    else
                                    {
                                        MessageBox.Show($"Failed to load information: {response.ReasonPhrase} ");
                                    }
                                }
                            }
                            break;
                        }
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "Event Handlers"
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await this.LoadTrades();
            stopwatch.Stop();

            var timeElapsed = (stopwatch.ElapsedMilliseconds) / 1000.0M;
            MessageBox.Show($"Loaded successfully. Time elapsed: {timeElapsed} seconds.");
            
        }

        private async void btnGroupTrades_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (_dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No trades to group. Please, load trades first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                await SummarizeTrades(_grouping);
                this.RefreshDataSource(_dataTable);
                this.UpdateRowsCount();
                stopwatch.Stop();
                var timeElapsed = (stopwatch.ElapsedMilliseconds) / 1000.0M;
                MessageBox.Show($"Grouping was complete. Time elapsed: {timeElapsed} seconds.");
            }

        }

        private void rbGroupByAll_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
            _grouping = GroupingType.All;
        }

        private void rbGroupByTicker_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
            _grouping = GroupingType.Ticker;
        }

        private void rbSide_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
            _grouping = GroupingType.Side;
        }

        private void rbAccount_CheckedChanged(object sender, EventArgs e)
        {
            btnGroupSearch.Enabled = true;
            _grouping = GroupingType.Account;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var path = Helpers.ExportHelper.SaveAsExcel();

            if (!string.IsNullOrEmpty(path))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(_dataTable, "Trades");
                    wb.SaveAs(path);
                }
                sw.Stop();
                var timeElapsed = (sw.ElapsedMilliseconds) / 1000.0M;
                MessageBox.Show($"Data exported to excel file. Time elapsed: {timeElapsed} seconds.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {

            var path = Helpers.ExportHelper.SaveAsCsv();

            if (!string.IsNullOrEmpty(path))
            {
                StringBuilder sb = new StringBuilder();
                Stopwatch sw = new Stopwatch();
                sw.Start();

                foreach (DataRow row in _dataTable.Rows)
                    {
                        string[] data = row.ItemArray
                                            .Select(field => field.ToString())
                                            .ToArray();

                        sb.AppendLine(string.Join(",", data));
                    }

                File.WriteAllText(path, sb.ToString());
                sw.Stop();
                var timeElapsed = (sw.ElapsedMilliseconds) / 1000.0M;
                MessageBox.Show($"Data exported to .csv file. Time elapsed:{timeElapsed} seconds.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "Utility Methods"

        private void UpdateRowsCount()
        {
            this.lblRowCount.Text = $"Rows: {this.dgvTrades.Rows.Count}";
        }

        private void RefreshDataSource(DataTable summarizedTrades)
        {
            this.dgvTrades.DataSource = summarizedTrades;
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
        #endregion

    }
}
