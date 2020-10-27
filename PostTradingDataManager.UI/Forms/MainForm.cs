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

namespace PostTradingDataManager.UI
{
    public partial class MainForm : Form
    {
        private Form activeForm;

        public MainForm()
        {
            InitializeComponent();
            this.btnReturn.Visible = false;
        }

        private void btnTrades_Click(object sender, EventArgs e)
        {
            OpenTradesForm(new TradesForm(), sender);
        }

        private void OpenTradesForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(childForm);
            this.pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
            this.btnReturn.Visible = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(activeForm!= null)
            {
                activeForm.Close();
                lblTitle.Text = "Post Trading System Manager";
                this.btnReturn.Visible = false;
            }
        }
    }
}
