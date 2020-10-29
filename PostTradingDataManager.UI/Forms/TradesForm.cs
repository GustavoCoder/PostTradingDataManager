using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Diagnostics;
using System.Globalization;
using System.Data;
using ClosedXML;
using ClosedXML.Excel;

namespace PostTradingDataManager.UI
{
    public partial class TradesForm : Form
    {
        #region "API Endpoints"

        private string tradesEndpoint = ConfigurationManager.AppSettings.Get("getall");
        private string summarizedEndpoint = ConfigurationManager.AppSettings.Get("summarized");

        #endregion

        #region "Attributes"

        private IEnumerable<TradesDto> _trades;
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
                        //_trades = JsonConvert.DeserializeObject<IEnumerable<TradesDto>>(content);
                        _dataTable = (DataTable) JsonConvert.DeserializeObject(content, typeof(DataTable));

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
        private async Task<List<TradesDto>> SummarizeTrades(GroupingType groupingType)
        {
            try
            {
                switch (groupingType)
                {
                    case GroupingType.All:
                        {
                            using (var client = new HttpClient())
                            {

                                using (var response = await client.GetAsync(summarizedEndpoint))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        var trades = JsonConvert.DeserializeObject<IEnumerable<TradesDto>>(content);
                                        _dataTable = (DataTable) JsonConvert.DeserializeObject(content, typeof(DataTable));


                                        this.RefreshGridViewGrouping();
                                        return trades.ToList();

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

                                using (var response = await client.GetAsync($"{summarizedEndpoint}/ticker"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        var trades = JsonConvert.DeserializeObject<IEnumerable<TradesDto>>(content);

                                        this.RefreshGridViewTickerGrouping();
                                        return trades.ToList();

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

                                using (var response = await client.GetAsync($"{summarizedEndpoint}/side"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        var trades = JsonConvert.DeserializeObject<IEnumerable<TradesDto>>(content);

                                        this.RefreshGridViewSideGrouping();
                                        return trades.ToList();

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

                                using (var response = await client.GetAsync($"{summarizedEndpoint}/account"))
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var content = await response.Content.ReadAsStringAsync();
                                        var trades = JsonConvert.DeserializeObject<IEnumerable<TradesDto>>(content);

                                        this.RefreshGridViewAccountGrouping();
                                        return trades.ToList();

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

            return null;
        }

        #endregion

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

            //if(_trades == null)
            //{
            //    MessageBox.Show("There are no trades to group. Please, load trades first.");
            //    return;
            //}

            var result = await SummarizeTrades(_grouping);
            this.RefreshDataSource(result.ToList());
            this.UpdateRowsCount();
            stopwatch.Stop();
            var timeElapsed = stopwatch.ElapsedMilliseconds;
            MessageBox.Show($"Time elapsed: {timeElapsed}");
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
            var path = SaveAsExcel();

            if (!string.IsNullOrEmpty(path))
            {
                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(this._dataTable, "Trades");
                    wb.SaveAs(path);
                }
                MessageBox.Show("You have successfully exported your data to an excel file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            var path = SaveAsCsv();

            
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
        private string SaveAsCsv()
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.Title = "Exporting as .csv file.";
                saveFile.Filter = "Excel files (*.csv)|*.csv";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFile.CreatePrompt = false;

                var result = saveFile.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return null;
                }

                return saveFile.FileName;
            }
        }
        private string SaveAsExcel()
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.Title = "Exporting to excel.";
                saveFile.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFile.CreatePrompt = false;

                var result = saveFile.ShowDialog();

                if(result == DialogResult.Cancel)
                {
                    return null;
                }

                return saveFile.FileName;
            }
        }
        #endregion

    }
}
