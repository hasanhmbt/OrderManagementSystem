using OrderManagementSystem.Repositories.Abstracts;
using OrderManagementSystem.Repositories.Concrete;
using OrderManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementSystem
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            datebeginproduct.Value= DateTime.Now.AddMonths(-1);
            RefreshBookCountTable();

        }

        public void RefreshBookCountTable()
        {
            ControlFiller controlFiller = new ControlFiller();
            IReportRepository reportRepository = new ReportRepository();
            SqlDataReader sqlDataReader = reportRepository.ProdctReports(out SqlConnection sqlConnection, beginDate: datebeginproduct.Value.ToString("yyyy-MM-dd"), endDate: dateFinishproduct.Value.ToString("yyyy-MM-dd"));

            controlFiller.FillControlDataSource(tblProductReport, sqlDataReader);
            tblProductReport.ClearSelection();
            sqlConnection.Close();

        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            RefreshBookCountTable();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            RefreshBookCountTable();
        }

        
    }
}
