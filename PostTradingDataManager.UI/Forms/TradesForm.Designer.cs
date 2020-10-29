namespace PostTradingDataManager.UI
{
    partial class TradesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTradesMenu = new System.Windows.Forms.Panel();
            this.gbGroupBy = new System.Windows.Forms.GroupBox();
            this.rbGroupByAccount = new System.Windows.Forms.RadioButton();
            this.rbGroupBySide = new System.Windows.Forms.RadioButton();
            this.rbGroupByTicker = new System.Windows.Forms.RadioButton();
            this.rbGroupByAll = new System.Windows.Forms.RadioButton();
            this.btnGroupSearch = new System.Windows.Forms.Button();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnLoadTrades = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvTrades = new System.Windows.Forms.DataGridView();
            this.tradeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tickerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTradesMenu.SuspendLayout();
            this.gbGroupBy.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTradesMenu
            // 
            this.pnlTradesMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTradesMenu.Controls.Add(this.gbGroupBy);
            this.pnlTradesMenu.Controls.Add(this.btnGroupSearch);
            this.pnlTradesMenu.Controls.Add(this.lblRowCount);
            this.pnlTradesMenu.Controls.Add(this.btnExportExcel);
            this.pnlTradesMenu.Controls.Add(this.btnExportCsv);
            this.pnlTradesMenu.Controls.Add(this.btnLoadTrades);
            this.pnlTradesMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTradesMenu.Location = new System.Drawing.Point(650, 0);
            this.pnlTradesMenu.Name = "pnlTradesMenu";
            this.pnlTradesMenu.Size = new System.Drawing.Size(150, 450);
            this.pnlTradesMenu.TabIndex = 0;
            // 
            // gbGroupBy
            // 
            this.gbGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGroupBy.Controls.Add(this.rbGroupByAccount);
            this.gbGroupBy.Controls.Add(this.rbGroupBySide);
            this.gbGroupBy.Controls.Add(this.rbGroupByTicker);
            this.gbGroupBy.Controls.Add(this.rbGroupByAll);
            this.gbGroupBy.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGroupBy.Location = new System.Drawing.Point(5, 90);
            this.gbGroupBy.MaximumSize = new System.Drawing.Size(140, 140);
            this.gbGroupBy.Name = "gbGroupBy";
            this.gbGroupBy.Size = new System.Drawing.Size(140, 140);
            this.gbGroupBy.TabIndex = 8;
            this.gbGroupBy.TabStop = false;
            this.gbGroupBy.Text = "Group By";
            // 
            // rbGroupByAccount
            // 
            this.rbGroupByAccount.AutoSize = true;
            this.rbGroupByAccount.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGroupByAccount.Location = new System.Drawing.Point(7, 107);
            this.rbGroupByAccount.Name = "rbGroupByAccount";
            this.rbGroupByAccount.Size = new System.Drawing.Size(72, 20);
            this.rbGroupByAccount.TabIndex = 3;
            this.rbGroupByAccount.TabStop = true;
            this.rbGroupByAccount.Text = "Account";
            this.rbGroupByAccount.UseVisualStyleBackColor = true;
            this.rbGroupByAccount.CheckedChanged += new System.EventHandler(this.rbAccount_CheckedChanged);
            // 
            // rbGroupBySide
            // 
            this.rbGroupBySide.AutoSize = true;
            this.rbGroupBySide.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGroupBySide.Location = new System.Drawing.Point(7, 79);
            this.rbGroupBySide.Name = "rbGroupBySide";
            this.rbGroupBySide.Size = new System.Drawing.Size(49, 20);
            this.rbGroupBySide.TabIndex = 2;
            this.rbGroupBySide.TabStop = true;
            this.rbGroupBySide.Text = "Side";
            this.rbGroupBySide.UseVisualStyleBackColor = true;
            this.rbGroupBySide.CheckedChanged += new System.EventHandler(this.rbSide_CheckedChanged);
            // 
            // rbGroupByTicker
            // 
            this.rbGroupByTicker.AutoSize = true;
            this.rbGroupByTicker.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGroupByTicker.Location = new System.Drawing.Point(7, 51);
            this.rbGroupByTicker.Name = "rbGroupByTicker";
            this.rbGroupByTicker.Size = new System.Drawing.Size(55, 20);
            this.rbGroupByTicker.TabIndex = 1;
            this.rbGroupByTicker.TabStop = true;
            this.rbGroupByTicker.Text = "Ticker";
            this.rbGroupByTicker.UseVisualStyleBackColor = true;
            this.rbGroupByTicker.CheckedChanged += new System.EventHandler(this.rbGroupByTicker_CheckedChanged);
            // 
            // rbGroupByAll
            // 
            this.rbGroupByAll.AutoSize = true;
            this.rbGroupByAll.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGroupByAll.Location = new System.Drawing.Point(7, 23);
            this.rbGroupByAll.Name = "rbGroupByAll";
            this.rbGroupByAll.Size = new System.Drawing.Size(136, 20);
            this.rbGroupByAll.TabIndex = 0;
            this.rbGroupByAll.TabStop = true;
            this.rbGroupByAll.Text = "Ticker, Side, Account";
            this.rbGroupByAll.UseVisualStyleBackColor = true;
            this.rbGroupByAll.CheckedChanged += new System.EventHandler(this.rbGroupByAll_CheckedChanged);
            // 
            // btnGroupSearch
            // 
            this.btnGroupSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGroupSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupSearch.Location = new System.Drawing.Point(0, 45);
            this.btnGroupSearch.Name = "btnGroupSearch";
            this.btnGroupSearch.Size = new System.Drawing.Size(150, 45);
            this.btnGroupSearch.TabIndex = 5;
            this.btnGroupSearch.Text = "Group Trades";
            this.btnGroupSearch.UseVisualStyleBackColor = false;
            this.btnGroupSearch.Click += new System.EventHandler(this.btnGroupTrades_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRowCount.Location = new System.Drawing.Point(0, 347);
            this.lblRowCount.Margin = new System.Windows.Forms.Padding(10);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Padding = new System.Windows.Forms.Padding(5);
            this.lblRowCount.Size = new System.Drawing.Size(10, 23);
            this.lblRowCount.TabIndex = 4;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportExcel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::PostTradingDataManager.UI.Properties.Resources.excel_file;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(0, 370);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Padding = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Size = new System.Drawing.Size(150, 40);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Export (.xlsx file)";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportCsv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCsv.Image = global::PostTradingDataManager.UI.Properties.Resources.csv_file;
            this.btnExportCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportCsv.Location = new System.Drawing.Point(0, 410);
            this.btnExportCsv.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Padding = new System.Windows.Forms.Padding(2);
            this.btnExportCsv.Size = new System.Drawing.Size(150, 40);
            this.btnExportCsv.TabIndex = 2;
            this.btnExportCsv.Text = "Export (.csv file)";
            this.btnExportCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // btnLoadTrades
            // 
            this.btnLoadTrades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadTrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTrades.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTrades.Image = global::PostTradingDataManager.UI.Properties.Resources.procurar;
            this.btnLoadTrades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadTrades.Location = new System.Drawing.Point(0, 0);
            this.btnLoadTrades.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadTrades.Name = "btnLoadTrades";
            this.btnLoadTrades.Padding = new System.Windows.Forms.Padding(5);
            this.btnLoadTrades.Size = new System.Drawing.Size(150, 45);
            this.btnLoadTrades.TabIndex = 0;
            this.btnLoadTrades.Text = "Load All";
            this.btnLoadTrades.UseVisualStyleBackColor = true;
            this.btnLoadTrades.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlGrid.Controls.Add(this.dgvTrades);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(650, 450);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvTrades
            // 
            this.dgvTrades.AllowUserToAddRows = false;
            this.dgvTrades.AllowUserToDeleteRows = false;
            this.dgvTrades.AutoGenerateColumns = false;
            this.dgvTrades.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tradeIdDataGridViewTextBoxColumn,
            this.tradeDateDataGridViewTextBoxColumn,
            this.accountDataGridViewTextBoxColumn,
            this.tickerDataGridViewTextBoxColumn,
            this.sideDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dgvTrades.DataSource = this.tradeDtoBindingSource;
            this.dgvTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrades.Location = new System.Drawing.Point(0, 0);
            this.dgvTrades.Name = "dgvTrades";
            this.dgvTrades.ReadOnly = true;
            this.dgvTrades.Size = new System.Drawing.Size(650, 450);
            this.dgvTrades.TabIndex = 0;
            // 
            // tradeIdDataGridViewTextBoxColumn
            // 
            this.tradeIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tradeIdDataGridViewTextBoxColumn.DataPropertyName = "TradeId";
            this.tradeIdDataGridViewTextBoxColumn.FillWeight = 50F;
            this.tradeIdDataGridViewTextBoxColumn.HeaderText = "Trade #";
            this.tradeIdDataGridViewTextBoxColumn.Name = "tradeIdDataGridViewTextBoxColumn";
            this.tradeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tradeDateDataGridViewTextBoxColumn
            // 
            this.tradeDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tradeDateDataGridViewTextBoxColumn.DataPropertyName = "TradeDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.tradeDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tradeDateDataGridViewTextBoxColumn.FillWeight = 60F;
            this.tradeDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.tradeDateDataGridViewTextBoxColumn.Name = "tradeDateDataGridViewTextBoxColumn";
            this.tradeDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountDataGridViewTextBoxColumn
            // 
            this.accountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountDataGridViewTextBoxColumn.DataPropertyName = "Account";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.accountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.accountDataGridViewTextBoxColumn.FillWeight = 60F;
            this.accountDataGridViewTextBoxColumn.HeaderText = "Account";
            this.accountDataGridViewTextBoxColumn.Name = "accountDataGridViewTextBoxColumn";
            this.accountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tickerDataGridViewTextBoxColumn
            // 
            this.tickerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tickerDataGridViewTextBoxColumn.DataPropertyName = "Ticker";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tickerDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tickerDataGridViewTextBoxColumn.FillWeight = 60F;
            this.tickerDataGridViewTextBoxColumn.HeaderText = "Ticker";
            this.tickerDataGridViewTextBoxColumn.Name = "tickerDataGridViewTextBoxColumn";
            this.tickerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sideDataGridViewTextBoxColumn
            // 
            this.sideDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sideDataGridViewTextBoxColumn.DataPropertyName = "Side";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sideDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sideDataGridViewTextBoxColumn.FillWeight = 40F;
            this.sideDataGridViewTextBoxColumn.HeaderText = "Side";
            this.sideDataGridViewTextBoxColumn.Name = "sideDataGridViewTextBoxColumn";
            this.sideDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantityDataGridViewTextBoxColumn.FillWeight = 60F;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.priceDataGridViewTextBoxColumn.FillWeight = 60F;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tradeDtoBindingSource
            // 
            this.tradeDtoBindingSource.DataSource = typeof(PostTradingDataManager.UI.TradesDto);
            // 
            // TradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTradesMenu);
            this.Name = "TradesForm";
            this.Text = "Trades Data";
            this.pnlTradesMenu.ResumeLayout(false);
            this.pnlTradesMenu.PerformLayout();
            this.gbGroupBy.ResumeLayout(false);
            this.gbGroupBy.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTradesMenu;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnLoadTrades;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvTrades;
        private System.Windows.Forms.BindingSource tradeDtoBindingSource;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Button btnGroupSearch;
        private System.Windows.Forms.GroupBox gbGroupBy;
        private System.Windows.Forms.RadioButton rbGroupByAccount;
        private System.Windows.Forms.RadioButton rbGroupBySide;
        private System.Windows.Forms.RadioButton rbGroupByTicker;
        private System.Windows.Forms.RadioButton rbGroupByAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tickerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}